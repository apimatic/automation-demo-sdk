// <copyright file="EventsController.cs" company="APIMatic">
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
    /// EventsController.
    /// </summary>
    public class EventsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal EventsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Get events, paginated by 100.
        /// </summary>
        /// <param name="countryCode">Optional parameter: country_code of event (eg. 'US'). use <b>/api/v3/events/countries</b> for list of country_codes.</param>
        /// <param name="type">Optional parameter: type of event (eg. 'Conference'). use <b>/api/v3/events/types</b> for list of types.</param>
        /// <param name="page">Optional parameter: page of results (paginated by 100).</param>
        /// <param name="upcomingEventsOnly">Optional parameter: lists only upcoming events. <br>true, false</br> (defaults to true, set to false to list all events).</param>
        /// <param name="fromDate">Optional parameter: lists events after this date yyyy-mm-dd.</param>
        /// <param name="toDate">Optional parameter: lists events before this date yyyy-mm-dd (set upcoming_events_only to false if fetching past events).</param>
        public void GeteventsPaginatedby100(
                string countryCode = null,
                string type = null,
                string page = null,
                string upcomingEventsOnly = null,
                string fromDate = null,
                string toDate = null)
        {
            Task t = this.GeteventsPaginatedby100Async(countryCode, type, page, upcomingEventsOnly, fromDate, toDate);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get events, paginated by 100.
        /// </summary>
        /// <param name="countryCode">Optional parameter: country_code of event (eg. 'US'). use <b>/api/v3/events/countries</b> for list of country_codes.</param>
        /// <param name="type">Optional parameter: type of event (eg. 'Conference'). use <b>/api/v3/events/types</b> for list of types.</param>
        /// <param name="page">Optional parameter: page of results (paginated by 100).</param>
        /// <param name="upcomingEventsOnly">Optional parameter: lists only upcoming events. <br>true, false</br> (defaults to true, set to false to list all events).</param>
        /// <param name="fromDate">Optional parameter: lists events after this date yyyy-mm-dd.</param>
        /// <param name="toDate">Optional parameter: lists events before this date yyyy-mm-dd (set upcoming_events_only to false if fetching past events).</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GeteventsPaginatedby100Async(
                string countryCode = null,
                string type = null,
                string page = null,
                string upcomingEventsOnly = null,
                string fromDate = null,
                string toDate = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/events");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "country_code", countryCode },
                { "type", type },
                { "page", page },
                { "upcoming_events_only", upcomingEventsOnly },
                { "from_date", fromDate },
                { "to_date", toDate },
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
        /// Get list of event countries.
        /// </summary>
        public void Getlistofeventcountries()
        {
            Task t = this.GetlistofeventcountriesAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get list of event countries.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetlistofeventcountriesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/events/countries");

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
        /// Get list of event types.
        /// </summary>
        public void Getlistofeventstypes()
        {
            Task t = this.GetlistofeventstypesAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Get list of event types.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task GetlistofeventstypesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/events/types");

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