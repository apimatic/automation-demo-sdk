// <copyright file="CategoriesController.cs" company="APIMatic">
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
    /// CategoriesController.
    /// </summary>
    public class CategoriesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CategoriesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// List all categories.
        /// </summary>
        public void Listallcategories()
        {
            Task t = this.ListallcategoriesAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all categories.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallcategoriesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/categories/list");

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
        /// List all categories with market data.
        /// </summary>
        /// <param name="order">Optional parameter: valid values: <b>market_cap_desc (default), market_cap_asc, name_desc, name_asc, market_cap_change_24h_desc and market_cap_change_24h_asc</b>.</param>
        public void Listallcategorieswithmarketdata(
                string order = null)
        {
            Task t = this.ListallcategorieswithmarketdataAsync(order);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all categories with market data.
        /// </summary>
        /// <param name="order">Optional parameter: valid values: <b>market_cap_desc (default), market_cap_asc, name_desc, name_asc, market_cap_change_24h_desc and market_cap_change_24h_asc</b>.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallcategorieswithmarketdataAsync(
                string order = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/coins/categories");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
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
    }
}