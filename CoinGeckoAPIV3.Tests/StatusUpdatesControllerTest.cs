// <copyright file="StatusUpdatesControllerTest.cs" company="APIMatic">
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
    /// StatusUpdatesControllerTest.
    /// </summary>
    [TestFixture]
    public class StatusUpdatesControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private StatusUpdatesController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.StatusUpdatesController;
        }

        /// <summary>
        /// List all status_updates with data (description, category, created_at, user, user_title and pin)
        ///.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListallstatusUpdateswithdataDescriptionCategoryCreatedAtUserUserTitleandpin()
        {
            // Parameters for the API call
            string category = null;
            string projectType = null;
            int? perPage = null;
            int? page = null;

            // Perform API call
            try
            {
                await this.controller.ListallstatusUpdateswithdataDescriptionCategoryCreatedAtUserUserTitleandpinAsync(category, projectType, perPage, page);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }
    }
}