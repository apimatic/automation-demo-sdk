// <copyright file="SimpleController.cs" company="APIMatic">
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
    /// SimpleController.
    /// </summary>
    public class SimpleController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal SimpleController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Get the current price of any cryptocurrencies in any other supported currencies that you need..
        /// </summary>
        /// <param name="ids">Required parameter: id of coins, comma-separated if querying more than 1 coin *refers to <b>`coins/list`</b>.</param>
        /// <param name="vsCurrencies">Required parameter: vs_currency of coins, comma-separated if querying more than 1 vs_currency *refers to <b>`simple/supported_vs_currencies`</b>.</param>
        /// <param name="includeMarketCap">Optional parameter: <b>true/false</b> to include market_cap, <b>default: false</b>.</param>
        /// <param name="include24hrVol">Optional parameter: <b>true/false</b> to include 24hr_vol, <b>default: false</b>.</param>
        /// <param name="include24hrChange">Optional parameter: <b>true/false</b> to include 24hr_change, <b>default: false</b>.</param>
        /// <param name="includeLastUpdatedAt">Optional parameter: <b>true/false</b> to include last_updated_at of price, <b>default: false</b>.</param>
        public void Getthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneed(
                string ids,
                string vsCurrencies,
                string includeMarketCap = null,
                string include24hrVol = null,
                string include24hrChange = null,
                string includeLastUpdatedAt = null)
        {
            Task t = this.GetthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneedAsync(ids, vsCurrencies, includeMarketCap, include24hrVol, include24hrChange, includeLastUpdatedAt);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get the current price of any cryptocurrencies in any other supported currencies that you need..
        /// </summary>
        /// <param name="ids">Required parameter: id of coins, comma-separated if querying more than 1 coin *refers to <b>`coins/list`</b>.</param>
        /// <param name="vsCurrencies">Required parameter: vs_currency of coins, comma-separated if querying more than 1 vs_currency *refers to <b>`simple/supported_vs_currencies`</b>.</param>
        /// <param name="includeMarketCap">Optional parameter: <b>true/false</b> to include market_cap, <b>default: false</b>.</param>
        /// <param name="include24hrVol">Optional parameter: <b>true/false</b> to include 24hr_vol, <b>default: false</b>.</param>
        /// <param name="include24hrChange">Optional parameter: <b>true/false</b> to include 24hr_change, <b>default: false</b>.</param>
        /// <param name="includeLastUpdatedAt">Optional parameter: <b>true/false</b> to include last_updated_at of price, <b>default: false</b>.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneedAsync(
                string ids,
                string vsCurrencies,
                string includeMarketCap = null,
                string include24hrVol = null,
                string include24hrChange = null,
                string includeLastUpdatedAt = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/simple/price");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "ids", ids },
                { "vs_currencies", vsCurrencies },
                { "include_market_cap", includeMarketCap },
                { "include_24hr_vol", include24hrVol },
                { "include_24hr_change", include24hrChange },
                { "include_last_updated_at", includeLastUpdatedAt },
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
        /// Get current price of tokens (using contract addresses) for a given platform in any other currency that you need..
        /// </summary>
        /// <param name="id">Required parameter: The id of the platform issuing tokens (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddresses">Required parameter: The contract address of tokens, comma separated.</param>
        /// <param name="vsCurrencies">Required parameter: vs_currency of coins, comma-separated if querying more than 1 vs_currency *refers to <b>`simple/supported_vs_currencies`</b>.</param>
        /// <param name="includeMarketCap">Optional parameter: <b>true/false</b> to include market_cap, <b>default: false</b>.</param>
        /// <param name="include24hrVol">Optional parameter: <b>true/false</b> to include 24hr_vol, <b>default: false</b>.</param>
        /// <param name="include24hrChange">Optional parameter: <b>true/false</b> to include 24hr_change, <b>default: false</b>.</param>
        /// <param name="includeLastUpdatedAt">Optional parameter: <b>true/false</b> to include last_updated_at of price, <b>default: false</b>.</param>
        public void GetcurrentpriceoftokensUsingcontractaddressesForagivenplatforminanyothercurrencythatyouneed(
                string id,
                string contractAddresses,
                string vsCurrencies,
                string includeMarketCap = null,
                string include24hrVol = null,
                string include24hrChange = null,
                string includeLastUpdatedAt = null)
        {
            Task t = this.GetcurrentpriceoftokensUsingcontractaddressesForagivenplatforminanyothercurrencythatyouneedAsync(id, contractAddresses, vsCurrencies, includeMarketCap, include24hrVol, include24hrChange, includeLastUpdatedAt);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get current price of tokens (using contract addresses) for a given platform in any other currency that you need..
        /// </summary>
        /// <param name="id">Required parameter: The id of the platform issuing tokens (See asset_platforms endpoint for list of options).</param>
        /// <param name="contractAddresses">Required parameter: The contract address of tokens, comma separated.</param>
        /// <param name="vsCurrencies">Required parameter: vs_currency of coins, comma-separated if querying more than 1 vs_currency *refers to <b>`simple/supported_vs_currencies`</b>.</param>
        /// <param name="includeMarketCap">Optional parameter: <b>true/false</b> to include market_cap, <b>default: false</b>.</param>
        /// <param name="include24hrVol">Optional parameter: <b>true/false</b> to include 24hr_vol, <b>default: false</b>.</param>
        /// <param name="include24hrChange">Optional parameter: <b>true/false</b> to include 24hr_change, <b>default: false</b>.</param>
        /// <param name="includeLastUpdatedAt">Optional parameter: <b>true/false</b> to include last_updated_at of price, <b>default: false</b>.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetcurrentpriceoftokensUsingcontractaddressesForagivenplatforminanyothercurrencythatyouneedAsync(
                string id,
                string contractAddresses,
                string vsCurrencies,
                string includeMarketCap = null,
                string include24hrVol = null,
                string include24hrChange = null,
                string includeLastUpdatedAt = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/simple/token_price/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "contract_addresses", contractAddresses },
                { "vs_currencies", vsCurrencies },
                { "include_market_cap", includeMarketCap },
                { "include_24hr_vol", include24hrVol },
                { "include_24hr_change", include24hrChange },
                { "include_last_updated_at", includeLastUpdatedAt },
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
        /// Get list of supported_vs_currencies..
        /// </summary>
        public void GetlistofsupportedVsCurrencies()
        {
            Task t = this.GetlistofsupportedVsCurrenciesAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get list of supported_vs_currencies..
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetlistofsupportedVsCurrenciesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/simple/supported_vs_currencies");

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
    }
}