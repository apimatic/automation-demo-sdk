// <copyright file="StatusUpdatesController.cs" company="APIMatic">
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
    /// StatusUpdatesController.
    /// </summary>
    public class StatusUpdatesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusUpdatesController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal StatusUpdatesController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// List all status_updates with data (description, category, created_at, user, user_title and pin).
        /// </summary>
        /// <param name="category">Optional parameter: Filtered by category (eg. general, milestone, partnership, exchange_listing, software_release, fund_movement, new_listings, event).</param>
        /// <param name="projectType">Optional parameter: Filtered by Project Type (eg. coin, market). If left empty returns both status from coins and markets..</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        public void ListallstatusUpdateswithdataDescriptionCategoryCreatedAtUserUserTitleandpin(
                string category = null,
                string projectType = null,
                int? perPage = null,
                int? page = null)
        {
            Task t = this.ListallstatusUpdateswithdataDescriptionCategoryCreatedAtUserUserTitleandpinAsync(category, projectType, perPage, page);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// List all status_updates with data (description, category, created_at, user, user_title and pin).
        /// </summary>
        /// <param name="category">Optional parameter: Filtered by category (eg. general, milestone, partnership, exchange_listing, software_release, fund_movement, new_listings, event).</param>
        /// <param name="projectType">Optional parameter: Filtered by Project Type (eg. coin, market). If left empty returns both status from coins and markets..</param>
        /// <param name="perPage">Optional parameter: Total results per page.</param>
        /// <param name="page">Optional parameter: Page through results.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ListallstatusUpdateswithdataDescriptionCategoryCreatedAtUserUserTitleandpinAsync(
                string category = null,
                string projectType = null,
                int? perPage = null,
                int? page = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/status_updates");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "category", category },
                { "project_type", projectType },
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
    }
}