// <copyright file="CoinsController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace CoinGeckoAPIV3.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using CoinGeckoAPIV3.Standard;
    using CoinGeckoAPIV3.Standard.Authentication;
    using CoinGeckoAPIV3.Standard.Http.Client;
    using CoinGeckoAPIV3.Standard.Http.Request;
    using CoinGeckoAPIV3.Standard.Http.Response;
    using CoinGeckoAPIV3.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// CoinsController.
    /// </summary>
    public class CoinsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoinsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CoinsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Use this to obtain all the coins' id in order to make API calls.
        /// </summary>
        /// <param name="includePlatform">Optional parameter: flag to include platform contract addresses (eg. 0x.... for Ethereum based tokens).   valid values: true, false.</param>
        public void ListallsupportedcoinsidNameandsymbolNopaginationrequired(
                bool? includePlatform = null)
        {
            Task t = this.ListallsupportedcoinsidNameandsymbolNopaginationrequiredAsync(includePlatform);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Use this to obtain all the coins' id in order to make API calls.
        /// </summary>
        /// <param name="includePlatform">Optional parameter: flag to include platform contract addresses (eg. 0x.... for Ethereum based tokens).   valid values: true, false.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallsupportedcoinsidNameandsymbolNopaginationrequiredAsync(
                bool? includePlatform = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/list");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "include_platform", includePlatform },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Use this to obtain all the coins market data (price, market cap, volume).
        /// </summary>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="ids">Optional parameter: The ids of the coin, comma separated crytocurrency symbols (base). refers to `/coins/list`. <b>When left empty, returns numbers the coins observing the params `limit` and `start`</b>.</param>
        /// <param name="category">Optional parameter: filter by coin category. Refer to /coin/categories/list.</param>
        /// <param name="order">Optional parameter: valid values: <b>market_cap_desc, gecko_desc, gecko_asc, market_cap_asc, market_cap_desc, volume_asc, volume_desc, id_asc, id_desc</b> sort results by field..</param>
        /// <param name="perPage">Optional parameter: valid values: 1..250  Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="sparkline">Optional parameter: Include sparkline 7 days data (eg. true, false).</param>
        /// <param name="priceChangePercentage">Optional parameter: Include price change percentage in <b>1h, 24h, 7d, 14d, 30d, 200d, 1y</b> (eg. '`1h,24h,7d`' comma-separated, invalid values will be discarded).</param>
        public void ListallsupportedcoinspriceMarketcapVolumeAndmarketrelateddata(
                string vsCurrency,
                string ids = null,
                string category = null,
                string order = "market_cap_desc",
                int? perPage = 100,
                int? page = 1,
                bool? sparkline = false,
                string priceChangePercentage = null)
        {
            Task t = this.ListallsupportedcoinspriceMarketcapVolumeAndmarketrelateddataAsync(vsCurrency, ids, category, order, perPage, page, sparkline, priceChangePercentage);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Use this to obtain all the coins market data (price, market cap, volume).
        /// </summary>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="ids">Optional parameter: The ids of the coin, comma separated crytocurrency symbols (base). refers to `/coins/list`. <b>When left empty, returns numbers the coins observing the params `limit` and `start`</b>.</param>
        /// <param name="category">Optional parameter: filter by coin category. Refer to /coin/categories/list.</param>
        /// <param name="order">Optional parameter: valid values: <b>market_cap_desc, gecko_desc, gecko_asc, market_cap_asc, market_cap_desc, volume_asc, volume_desc, id_asc, id_desc</b> sort results by field..</param>
        /// <param name="perPage">Optional parameter: valid values: 1..250  Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="sparkline">Optional parameter: Include sparkline 7 days data (eg. true, false).</param>
        /// <param name="priceChangePercentage">Optional parameter: Include price change percentage in <b>1h, 24h, 7d, 14d, 30d, 200d, 1y</b> (eg. '`1h,24h,7d`' comma-separated, invalid values will be discarded).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallsupportedcoinspriceMarketcapVolumeAndmarketrelateddataAsync(
                string vsCurrency,
                string ids = null,
                string category = null,
                string order = "market_cap_desc",
                int? perPage = 100,
                int? page = 1,
                bool? sparkline = false,
                string priceChangePercentage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/markets");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "vs_currency", vsCurrency },
                { "ids", ids },
                { "category", category },
                { "order", (order != null) ? order : "market_cap_desc" },
                { "per_page", (perPage != null) ? perPage : 100 },
                { "page", (page != null) ? page : 1 },
                { "sparkline", (sparkline != null) ? sparkline : false },
                { "price_change_percentage", priceChangePercentage },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get current data (name, price, market, ... including exchange tickers) for a coin.<br><br> **IMPORTANT**:.
        ///  Ticker object is limited to 100 items, to get more tickers, use `/coins/{id}/tickers`.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="localization">Optional parameter: Include all localized languages in response (true/false) <b>[default: true]</b>.</param>
        /// <param name="tickers">Optional parameter: Include tickers data (true/false) <b>[default: true]</b>.</param>
        /// <param name="marketData">Optional parameter: Include market_data (true/false) <b>[default: true]</b>.</param>
        /// <param name="communityData">Optional parameter: Include community_data data (true/false) <b>[default: true]</b>.</param>
        /// <param name="developerData">Optional parameter: Include developer_data data (true/false) <b>[default: true]</b>.</param>
        /// <param name="sparkline">Optional parameter: Include sparkline 7 days data (eg. true, false) <b>[default: false]</b>.</param>
        public void GetcurrentdataNamePriceMarketIncludingexchangetickersForacoin(
                string id,
                string localization = null,
                bool? tickers = null,
                bool? marketData = null,
                bool? communityData = null,
                bool? developerData = null,
                bool? sparkline = null)
        {
            Task t = this.GetcurrentdataNamePriceMarketIncludingexchangetickersForacoinAsync(id, localization, tickers, marketData, communityData, developerData, sparkline);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get current data (name, price, market, ... including exchange tickers) for a coin.<br><br> **IMPORTANT**:.
        ///  Ticker object is limited to 100 items, to get more tickers, use `/coins/{id}/tickers`.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="localization">Optional parameter: Include all localized languages in response (true/false) <b>[default: true]</b>.</param>
        /// <param name="tickers">Optional parameter: Include tickers data (true/false) <b>[default: true]</b>.</param>
        /// <param name="marketData">Optional parameter: Include market_data (true/false) <b>[default: true]</b>.</param>
        /// <param name="communityData">Optional parameter: Include community_data data (true/false) <b>[default: true]</b>.</param>
        /// <param name="developerData">Optional parameter: Include developer_data data (true/false) <b>[default: true]</b>.</param>
        /// <param name="sparkline">Optional parameter: Include sparkline 7 days data (eg. true, false) <b>[default: false]</b>.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetcurrentdataNamePriceMarketIncludingexchangetickersForacoinAsync(
                string id,
                string localization = null,
                bool? tickers = null,
                bool? marketData = null,
                bool? communityData = null,
                bool? developerData = null,
                bool? sparkline = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "localization", localization },
                { "tickers", tickers },
                { "market_data", marketData },
                { "community_data", communityData },
                { "developer_data", developerData },
                { "sparkline", sparkline },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get coin tickers (paginated to 100 items)<br><br> **IMPORTANT**:.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins/list) eg. bitcoin.</param>
        /// <param name="exchangeIds">Optional parameter: filter results by exchange_ids (ref: v3/exchanges/list).</param>
        /// <param name="includeExchangeLogo">Optional parameter: flag to show exchange_logo.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="order">Optional parameter: valid values: <b>trust_score_desc (default), trust_score_asc and volume_desc</b>.</param>
        /// <param name="depth">Optional parameter: flag to show 2% orderbook depth. valid values: true, false.</param>
        public void GetcointickersPaginatedto100items(
                string id,
                string exchangeIds = null,
                string includeExchangeLogo = null,
                int? page = null,
                string order = null,
                string depth = null)
        {
            Task t = this.GetcointickersPaginatedto100itemsAsync(id, exchangeIds, includeExchangeLogo, page, order, depth);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get coin tickers (paginated to 100 items)<br><br> **IMPORTANT**:.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins/list) eg. bitcoin.</param>
        /// <param name="exchangeIds">Optional parameter: filter results by exchange_ids (ref: v3/exchanges/list).</param>
        /// <param name="includeExchangeLogo">Optional parameter: flag to show exchange_logo.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="order">Optional parameter: valid values: <b>trust_score_desc (default), trust_score_asc and volume_desc</b>.</param>
        /// <param name="depth">Optional parameter: flag to show 2% orderbook depth. valid values: true, false.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetcointickersPaginatedto100itemsAsync(
                string id,
                string exchangeIds = null,
                string includeExchangeLogo = null,
                int? page = null,
                string order = null,
                string depth = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/tickers");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "exchange_ids", exchangeIds },
                { "include_exchange_logo", includeExchangeLogo },
                { "page", page },
                { "order", order },
                { "depth", depth },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get historical data (name, price, market, stats) at a given date for a coin.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="date">Required parameter: The date of data snapshot in dd-mm-yyyy eg. 30-12-2017.</param>
        /// <param name="localization">Optional parameter: Set to false to exclude localized languages in response.</param>
        public void GethistoricaldataNamePriceMarketStatsAtagivendateforacoin(
                string id,
                string date,
                string localization = null)
        {
            Task t = this.GethistoricaldataNamePriceMarketStatsAtagivendateforacoinAsync(id, date, localization);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get historical data (name, price, market, stats) at a given date for a coin.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="date">Required parameter: The date of data snapshot in dd-mm-yyyy eg. 30-12-2017.</param>
        /// <param name="localization">Optional parameter: Set to false to exclude localized languages in response.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GethistoricaldataNamePriceMarketStatsAtagivendateforacoinAsync(
                string id,
                string date,
                string localization = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/history");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "date", date },
                { "localization", localization },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume (granularity auto).
        ///  <b>Minutely data will be used for duration within 1 day, Hourly data will be used for duration between 1 day and 90 days, Daily data will be used for duration above 90 days.</b>.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="days">Required parameter: Data up to number of days ago (eg. 1,14,30,max).</param>
        /// <param name="interval">Optional parameter: Data interval. Possible value: daily.</param>
        public void GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityauto(
                string id,
                string vsCurrency,
                string days,
                string interval = null)
        {
            Task t = this.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoAsync(id, vsCurrency, days, interval);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume (granularity auto).
        ///  <b>Minutely data will be used for duration within 1 day, Hourly data will be used for duration between 1 day and 90 days, Daily data will be used for duration above 90 days.</b>.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="days">Required parameter: Data up to number of days ago (eg. 1,14,30,max).</param>
        /// <param name="interval">Optional parameter: Data interval. Possible value: daily.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoAsync(
                string id,
                string vsCurrency,
                string days,
                string interval = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/market_chart");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "vs_currency", vsCurrency },
                { "days", days },
                { "interval", interval },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume within a range of timestamp (granularity auto).
        ///  <b><ul><li>Data granularity is automatic (cannot be adjusted)</li><li>1 day from query time = 5 minute interval data</li><li>1 - 90 days from query time = hourly data</li><li>above 90 days from query time = daily data (00:00 UTC)</li></ul> </b>.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="from">Required parameter: From date in UNIX Timestamp (eg. 1392577232).</param>
        /// <param name="to">Required parameter: To date in UNIX Timestamp (eg. 1422577232).</param>
        public void GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityauto(
                string id,
                string vsCurrency,
                string from,
                string to)
        {
            Task t = this.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoAsync(id, vsCurrency, from, to);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume within a range of timestamp (granularity auto).
        ///  <b><ul><li>Data granularity is automatic (cannot be adjusted)</li><li>1 day from query time = 5 minute interval data</li><li>1 - 90 days from query time = hourly data</li><li>above 90 days from query time = daily data (00:00 UTC)</li></ul> </b>.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="from">Required parameter: From date in UNIX Timestamp (eg. 1392577232).</param>
        /// <param name="to">Required parameter: To date in UNIX Timestamp (eg. 1422577232).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoAsync(
                string id,
                string vsCurrency,
                string from,
                string to,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/market_chart/range");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "vs_currency", vsCurrency },
                { "from", from },
                { "to", to },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get status updates for a given coin.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        public void Getstatusupdatesforagivencoin(
                string id,
                int? perPage = null,
                int? page = null)
        {
            Task t = this.GetstatusupdatesforagivencoinAsync(id, perPage, page);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get status updates for a given coin.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins) eg. bitcoin.</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetstatusupdatesforagivencoinAsync(
                string id,
                int? perPage = null,
                int? page = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/status_updates");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "per_page", perPage },
                { "page", page },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Candle's body:.
        /// 1 - 2 days: 30 minutes.
        /// 3 - 30 days: 4 hours.
        /// 31 and before: 4 days.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins/list) eg. bitcoin.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="days">Required parameter: Data up to number of days ago (1/7/14/30/90/180/365/max).</param>
        /// <returns>Returns the List of double response from the API call.</returns>
        public List<double> GetcoinSOHLC(
                string id,
                string vsCurrency,
                int days)
        {
            Task<List<double>> t = this.GetcoinSOHLCAsync(id, vsCurrency, days);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Candle's body:.
        /// 1 - 2 days: 30 minutes.
        /// 3 - 30 days: 4 hours.
        /// 31 and before: 4 days.
        /// </summary>
        /// <param name="id">Required parameter: pass the coin id (can be obtained from /coins/list) eg. bitcoin.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="days">Required parameter: Data up to number of days ago (1/7/14/30/90/180/365/max).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of double response from the API call.</returns>
        public async Task<List<double>> GetcoinSOHLCAsync(
                string id,
                string vsCurrency,
                int days,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/ohlc");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "vs_currency", vsCurrency },
                { "days", days },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<double>>(response.Body);
        }
    }
}