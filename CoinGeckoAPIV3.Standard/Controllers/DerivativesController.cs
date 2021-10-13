// <copyright file="DerivativesController.cs" company="APIMatic">
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
    /// DerivativesController.
    /// </summary>
    public class DerivativesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DerivativesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal DerivativesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// List all derivative tickers.
        /// </summary>
        /// <param name="includeTickers">Optional parameter: ['all', 'unexpired'] - expired to show unexpired tickers, all to list all tickers, defaults to unexpired.</param>
        public void Listallderivativetickers(
                string includeTickers = null)
        {
            Task t = this.ListallderivativetickersAsync(includeTickers);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all derivative tickers.
        /// </summary>
        /// <param name="includeTickers">Optional parameter: ['all', 'unexpired'] - expired to show unexpired tickers, all to list all tickers, defaults to unexpired.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallderivativetickersAsync(
                string includeTickers = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/derivatives");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "include_tickers", includeTickers },
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
        /// List all derivative exchanges.
        /// </summary>
        /// <param name="order">Optional parameter: order results using following params name_asc，name_desc，open_interest_btc_asc，open_interest_btc_desc，trade_volume_24h_btc_asc，trade_volume_24h_btc_desc.</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        public void Listallderivativeexchanges(
                string order = null,
                int? perPage = null,
                int? page = null)
        {
            Task t = this.ListallderivativeexchangesAsync(order, perPage, page);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all derivative exchanges.
        /// </summary>
        /// <param name="order">Optional parameter: order results using following params name_asc，name_desc，open_interest_btc_asc，open_interest_btc_desc，trade_volume_24h_btc_asc，trade_volume_24h_btc_desc.</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallderivativeexchangesAsync(
                string order = null,
                int? perPage = null,
                int? page = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/derivatives/exchanges");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "order", order },
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
        /// show derivative exchange data.
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from derivatives/exchanges/list) eg. bitmex.</param>
        /// <param name="includeTickers">Optional parameter: ['all', 'unexpired'] - expired to show unexpired tickers, all to list all tickers, leave blank to omit tickers data in response.</param>
        public void Showderivativeexchangedata(
                string id,
                string includeTickers = null)
        {
            Task t = this.ShowderivativeexchangedataAsync(id, includeTickers);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// show derivative exchange data.
        /// </summary>
        /// <param name="id">Required parameter: pass the exchange id (can be obtained from derivatives/exchanges/list) eg. bitmex.</param>
        /// <param name="includeTickers">Optional parameter: ['all', 'unexpired'] - expired to show unexpired tickers, all to list all tickers, leave blank to omit tickers data in response.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ShowderivativeexchangedataAsync(
                string id,
                string includeTickers = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/derivatives/exchanges/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "include_tickers", includeTickers },
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
        /// List all derivative exchanges name and identifier.
        /// </summary>
        public void Listallderivativeexchangesnameandidentifier()
        {
            Task t = this.ListallderivativeexchangesnameandidentifierAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all derivative exchanges name and identifier.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallderivativeexchangesnameandidentifierAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/derivatives/exchanges/list");

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