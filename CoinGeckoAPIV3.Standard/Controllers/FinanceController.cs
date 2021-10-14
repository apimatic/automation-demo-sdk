// <copyright file="FinanceController.cs" company="APIMatic">
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
    /// FinanceController.
    /// </summary>
    public class FinanceController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal FinanceController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// List all finance platforms.
        /// </summary>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: page of results (paginated to 100 by default).</param>
        public void Listallfinanceplatforms(
                int? perPage = null,
                string page = null)
        {
            Task t = this.ListallfinanceplatformsAsync(perPage, page);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all finance platforms.
        /// </summary>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: page of results (paginated to 100 by default).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallfinanceplatformsAsync(
                int? perPage = null,
                string page = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/finance_platforms");

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
        /// List all finance products.
        /// </summary>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: page of results (paginated to 100 by default).</param>
        /// <param name="startAt">Optional parameter: start date of the financial products.</param>
        /// <param name="endAt">Optional parameter: end date of the financial products.</param>
        public void Listallfinanceproducts(
                int? perPage = null,
                string page = null,
                string startAt = null,
                string endAt = null)
        {
            Task t = this.ListallfinanceproductsAsync(perPage, page, startAt, endAt);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all finance products.
        /// </summary>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: page of results (paginated to 100 by default).</param>
        /// <param name="startAt">Optional parameter: start date of the financial products.</param>
        /// <param name="endAt">Optional parameter: end date of the financial products.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallfinanceproductsAsync(
                int? perPage = null,
                string page = null,
                string startAt = null,
                string endAt = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/finance_products");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "per_page", perPage },
                { "page", page },
                { "start_at", startAt },
                { "end_at", endAt },
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