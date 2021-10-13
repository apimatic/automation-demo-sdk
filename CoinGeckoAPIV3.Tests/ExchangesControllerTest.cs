// <copyright file="ExchangesControllerTest.cs" company="APIMatic">
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
    /// ExchangesControllerTest.
    /// </summary>
    [TestFixture]
    public class ExchangesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ExchangesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.ExchangesController;
        }

        /// <summary>
        /// List all exchanges.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListallexchanges()
        {
            // Parameters for the API call
            int? perPage = null;
            string page = null;

            // Perform API call
            try
            {
                await this.controller.ListallexchangesAsync(perPage, page);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Use this to obtain all the markets' id in order to make API calls.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListallsupportedmarketsidandnameNopaginationrequired()
        {
            // Perform API call
            try
            {
                await this.controller.ListallsupportedmarketsidandnameNopaginationrequiredAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }
    }
}