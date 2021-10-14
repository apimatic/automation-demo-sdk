// <copyright file="EventsControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace CoinGeckoAPIV3.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using CoinGeckoAPIV3.Standard;
    using CoinGeckoAPIV3.Standard.Controllers;
    using CoinGeckoAPIV3.Standard.Exceptions;
    using CoinGeckoAPIV3.Standard.Http.Client;
    using CoinGeckoAPIV3.Standard.Http.Response;
    using CoinGeckoAPIV3.Standard.Utilities;
    using CoinGeckoAPIV3.Tests.Helpers;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;

    /// <summary>
    /// EventsControllerTest.
    /// </summary>
    [TestFixture]
    public class EventsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private EventsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.EventsController;
        }

        /// <summary>
        /// Get events, paginated by 100
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGeteventsPaginatedby100()
        {
            // Parameters for the API call
            string countryCode = null;
            string type = null;
            string page = null;
            string upcomingEventsOnly = null;
            string fromDate = null;
            string toDate = null;

            // Perform API call
            try
            {
                await this.controller.GeteventsPaginatedby100Async(countryCode, type, page, upcomingEventsOnly, fromDate, toDate);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Get list of event countries
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetlistofeventcountries()
        {
            // Perform API call
            try
            {
                await this.controller.GetlistofeventcountriesAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Get list of event types
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetlistofeventstypes()
        {
            // Perform API call
            try
            {
                await this.controller.GetlistofeventstypesAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }
    }
}