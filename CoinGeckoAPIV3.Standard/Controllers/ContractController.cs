// <copyright file="ContractController.cs" company="APIMatic">
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
    /// ContractController.
    /// </summary>
    public class ContractController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal ContractController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Get coin info from contract address.
        /// </summary>
        /// <param name="id">Required parameter: Asset platform (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddress">Required parameter: Token's contract address.</param>
        public void Getcoininfofromcontractaddress(
                string id,
                string contractAddress)
        {
            Task t = this.GetcoininfofromcontractaddressAsync(id, contractAddress);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get coin info from contract address.
        /// </summary>
        /// <param name="id">Required parameter: Asset platform (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddress">Required parameter: Token's contract address.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetcoininfofromcontractaddressAsync(
                string id,
                string contractAddress,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/contract/{contract_address}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
                { "contract_address", contractAddress },
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
        /// Get historical market data include price, market cap, and 24h volume (granularity auto).
        /// </summary>
        /// <param name="id">Required parameter: The id of the platform issuing tokens (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddress">Required parameter: Token's contract address.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="days">Required parameter: Data up to number of days ago (eg. 1,14,30,max).</param>
        public void GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoFromacontractaddress(
                string id,
                string contractAddress,
                string vsCurrency,
                string days)
        {
            Task t = this.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoFromacontractaddressAsync(id, contractAddress, vsCurrency, days);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume (granularity auto).
        /// </summary>
        /// <param name="id">Required parameter: The id of the platform issuing tokens (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddress">Required parameter: Token's contract address.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="days">Required parameter: Data up to number of days ago (eg. 1,14,30,max).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoFromacontractaddressAsync(
                string id,
                string contractAddress,
                string vsCurrency,
                string days,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/contract/{contract_address}/market_chart/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
                { "contract_address", contractAddress },
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
        /// </summary>
        /// <param name="id">Required parameter: The id of the platform issuing tokens (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddress">Required parameter: Token's contract address.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="from">Required parameter: From date in UNIX Timestamp (eg. 1392577232).</param>
        /// <param name="to">Required parameter: To date in UNIX Timestamp (eg. 1422577232).</param>
        public void GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoFromacontractaddress(
                string id,
                string contractAddress,
                string vsCurrency,
                string from,
                string to)
        {
            Task t = this.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoFromacontractaddressAsync(id, contractAddress, vsCurrency, from, to);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get historical market data include price, market cap, and 24h volume within a range of timestamp (granularity auto).
        /// </summary>
        /// <param name="id">Required parameter: The id of the platform issuing tokens (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddress">Required parameter: Token's contract address.</param>
        /// <param name="vsCurrency">Required parameter: The target currency of market data (usd, eur, jpy, etc.).</param>
        /// <param name="from">Required parameter: From date in UNIX Timestamp (eg. 1392577232).</param>
        /// <param name="to">Required parameter: To date in UNIX Timestamp (eg. 1422577232).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoFromacontractaddressAsync(
                string id,
                string contractAddress,
                string vsCurrency,
                string from,
                string to,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/{id}/contract/{contract_address}/market_chart/range");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
                { "contract_address", contractAddress },
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
    }
}