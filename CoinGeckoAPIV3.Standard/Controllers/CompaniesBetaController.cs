// <copyright file="CompaniesBetaController.cs" company="APIMatic">
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
    /// CompaniesBetaController.
    /// </summary>
    public class CompaniesBetaController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesBetaController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CompaniesBetaController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Get public companies bitcoin or ethereum holdings (Ordered by total holdings descending).
        /// </summary>
        /// <param name="coinId">Required parameter: bitcoin or ethereum.</param>
        public void Getpubliccompaniesdata(
                string coinId)
        {
            Task t = this.GetpubliccompaniesdataAsync(coinId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get public companies bitcoin or ethereum holdings (Ordered by total holdings descending).
        /// </summary>
        /// <param name="coinId">Required parameter: bitcoin or ethereum.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetpubliccompaniesdataAsync(
                string coinId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/companies/public_treasury/{coin_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "coin_id", coinId },
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
    }
}