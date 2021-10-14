// <copyright file="ExchangesController.cs" company="APIMatic">
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
    /// ExchangesController.
    /// </summary>
    public class ExchangesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal ExchangesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// List all exchanges.
        /// </summary>
        /// <param name="perPage">Optional parameter: Valid values: 1...250 Total results per page Default value:: 100.</param>
        /// <param name="page">Optional parameter: page through results.</param>
        public void Listallexchanges(
                int? perPage = null,
                string page = null)
        {
            Task t = this.ListallexchangesAsync(perPage, page);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all exchanges.
        /// </summary>
        /// <param name="perPage">Optional parameter: Valid values: 1...250 Total results per page Default value:: 100.</param>
        /// <param name="page">Optional parameter: page through results.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallexchangesAsync(
                int? perPage = null,
                string page = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/exchanges");

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
        /// Use this to obtain all the markets' id in order to make API calls.
        /// </summary>
        public void ListallsupportedmarketsidandnameNopaginationrequired()
        {
            Task t = this.ListallsupportedmarketsidandnameNopaginationrequiredAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Use this to obtain all the markets' id in order to make API calls.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallsupportedmarketsidandnameNopaginationrequiredAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/exchanges/list");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

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
        /// Get exchange volume in BTC and tickers<br><br> **IMPORTANT**:.
        ///  Ticker object is limited to 100 items, to get more tickers, use `/exchanges/{id}/tickers`.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        public void GetexchangevolumeinBTCandtop100tickersonly(
                string id)
        {
            Task t = this.GetexchangevolumeinBTCandtop100tickersonlyAsync(id);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get exchange volume in BTC and tickers<br><br> **IMPORTANT**:.
        ///  Ticker object is limited to 100 items, to get more tickers, use `/exchanges/{id}/tickers`.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetexchangevolumeinBTCandtop100tickersonlyAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/exchanges/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

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
        /// Get exchange tickers (paginated)<br><br> **IMPORTANT**:.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        /// <param name="coinIds">Optional parameter: filter tickers by coin_ids (ref: v3/coins/list).</param>
        /// <param name="includeExchangeLogo">Optional parameter: flag to show exchange_logo.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="depth">Optional parameter: flag to show 2% orderbook depth i.e., cost_to_move_up_usd and cost_to_move_down_usd.</param>
        /// <param name="order">Optional parameter: valid values: <b>trust_score_desc (default), trust_score_asc and volume_desc</b>.</param>
        public void GetexchangetickersPaginated100tickersperpage(
                string id,
                string coinIds = null,
                string includeExchangeLogo = null,
                int? page = null,
                string depth = null,
                string order = null)
        {
            Task t = this.GetexchangetickersPaginated100tickersperpageAsync(id, coinIds, includeExchangeLogo, page, depth, order);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get exchange tickers (paginated)<br><br> **IMPORTANT**:.
        ///  Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while..
        ///  Ticker `is_anomaly` is true if ticker's price is outliered by our system..
        ///  You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide).
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        /// <param name="coinIds">Optional parameter: filter tickers by coin_ids (ref: v3/coins/list).</param>
        /// <param name="includeExchangeLogo">Optional parameter: flag to show exchange_logo.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="depth">Optional parameter: flag to show 2% orderbook depth i.e., cost_to_move_up_usd and cost_to_move_down_usd.</param>
        /// <param name="order">Optional parameter: valid values: <b>trust_score_desc (default), trust_score_asc and volume_desc</b>.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetexchangetickersPaginated100tickersperpageAsync(
                string id,
                string coinIds = null,
                string includeExchangeLogo = null,
                int? page = null,
                string depth = null,
                string order = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/exchanges/{id}/tickers");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "coin_ids", coinIds },
                { "include_exchange_logo", includeExchangeLogo },
                { "page", page },
                { "depth", depth },
                { "order", order },
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
        /// Get status updates for a given exchange.
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        public void Getstatusupdatesforagivenexchange(
                string id,
                int? perPage = null,
                int? page = null)
        {
            Task t = this.GetstatusupdatesforagivenexchangeAsync(id, perPage, page);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get status updates for a given exchange.
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetstatusupdatesforagivenexchangeAsync(
                string id,
                int? perPage = null,
                int? page = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/exchanges/{id}/status_updates");

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
        /// Get volume_chart data for a given exchange.
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        /// <param name="days">Required parameter: Data up to number of days ago (eg. 1,14,30).</param>
        public void GetvolumeChartdataforagivenexchange(
                string id,
                int days)
        {
            Task t = this.GetvolumeChartdataforagivenexchangeAsync(id, days);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get volume_chart data for a given exchange.
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from /exchanges/list) eg. binance.</param>
        /// <param name="days">Required parameter: Data up to number of days ago (eg. 1,14,30).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetvolumeChartdataforagivenexchangeAsync(
                string id,
                int days,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/exchanges/{id}/volume_chart");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "days", days },
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
    }
}