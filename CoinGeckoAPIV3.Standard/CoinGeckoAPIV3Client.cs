// <copyright file="CoinGeckoAPIV3Client.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace CoinGeckoAPIV3.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using CoinGeckoAPIV3.Standard.Authentication;
    using CoinGeckoAPIV3.Standard.Controllers;
    using CoinGeckoAPIV3.Standard.Http.Client;
    using CoinGeckoAPIV3.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class CoinGeckoAPIV3Client : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "https://api.coingecko.com/api/v3" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;
        private readonly HttpCallBack httpCallBack;

        private readonly Lazy<PingController> ping;
        private readonly Lazy<SimpleController> simple;
        private readonly Lazy<CoinsController> coins;
        private readonly Lazy<ContractController> contract;
        private readonly Lazy<AssetPlatformsController> assetPlatforms;
        private readonly Lazy<CategoriesController> categories;
        private readonly Lazy<ExchangesController> exchanges;
        private readonly Lazy<FinanceController> finance;
        private readonly Lazy<IndexesController> indexes;
        private readonly Lazy<DerivativesController> derivatives;
        private readonly Lazy<StatusUpdatesController> statusUpdates;
        private readonly Lazy<EventsController> events;
        private readonly Lazy<ExchangeRatesController> exchangeRates;
        private readonly Lazy<TrendingController> trending;
        private readonly Lazy<GlobalController> mGlobal;
        private readonly Lazy<CompaniesBetaController> companiesBeta;

        private CoinGeckoAPIV3Client(
            Environment environment,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.ping = new Lazy<PingController>(
                () => new PingController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.simple = new Lazy<SimpleController>(
                () => new SimpleController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.coins = new Lazy<CoinsController>(
                () => new CoinsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.contract = new Lazy<ContractController>(
                () => new ContractController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.assetPlatforms = new Lazy<AssetPlatformsController>(
                () => new AssetPlatformsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.categories = new Lazy<CategoriesController>(
                () => new CategoriesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.exchanges = new Lazy<ExchangesController>(
                () => new ExchangesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.finance = new Lazy<FinanceController>(
                () => new FinanceController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.indexes = new Lazy<IndexesController>(
                () => new IndexesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.derivatives = new Lazy<DerivativesController>(
                () => new DerivativesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.statusUpdates = new Lazy<StatusUpdatesController>(
                () => new StatusUpdatesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.events = new Lazy<EventsController>(
                () => new EventsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.exchangeRates = new Lazy<ExchangeRatesController>(
                () => new ExchangeRatesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.trending = new Lazy<TrendingController>(
                () => new TrendingController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.mGlobal = new Lazy<GlobalController>(
                () => new GlobalController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.companiesBeta = new Lazy<CompaniesBetaController>(
                () => new CompaniesBetaController(this, this.httpClient, this.authManagers, this.httpCallBack));
        }

        /// <summary>
        /// Gets PingController controller.
        /// </summary>
        public PingController PingController => this.ping.Value;

        /// <summary>
        /// Gets SimpleController controller.
        /// </summary>
        public SimpleController SimpleController => this.simple.Value;

        /// <summary>
        /// Gets CoinsController controller.
        /// </summary>
        public CoinsController CoinsController => this.coins.Value;

        /// <summary>
        /// Gets ContractController controller.
        /// </summary>
        public ContractController ContractController => this.contract.Value;

        /// <summary>
        /// Gets AssetPlatformsController controller.
        /// </summary>
        public AssetPlatformsController AssetPlatformsController => this.assetPlatforms.Value;

        /// <summary>
        /// Gets CategoriesController controller.
        /// </summary>
        public CategoriesController CategoriesController => this.categories.Value;

        /// <summary>
        /// Gets ExchangesController controller.
        /// </summary>
        public ExchangesController ExchangesController => this.exchanges.Value;

        /// <summary>
        /// Gets FinanceController controller.
        /// </summary>
        public FinanceController FinanceController => this.finance.Value;

        /// <summary>
        /// Gets IndexesController controller.
        /// </summary>
        public IndexesController IndexesController => this.indexes.Value;

        /// <summary>
        /// Gets DerivativesController controller.
        /// </summary>
        public DerivativesController DerivativesController => this.derivatives.Value;

        /// <summary>
        /// Gets StatusUpdatesController controller.
        /// </summary>
        public StatusUpdatesController StatusUpdatesController => this.statusUpdates.Value;

        /// <summary>
        /// Gets EventsController controller.
        /// </summary>
        public EventsController EventsController => this.events.Value;

        /// <summary>
        /// Gets ExchangeRatesController controller.
        /// </summary>
        public ExchangeRatesController ExchangeRatesController => this.exchangeRates.Value;

        /// <summary>
        /// Gets TrendingController controller.
        /// </summary>
        public TrendingController TrendingController => this.trending.Value;

        /// <summary>
        /// Gets GlobalController controller.
        /// </summary>
        public GlobalController GlobalController => this.mGlobal.Value;

        /// <summary>
        /// Gets CompaniesBetaController controller.
        /// </summary>
        public CompaniesBetaController CompaniesBetaController => this.companiesBeta.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the CoinGeckoAPIV3Client using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpCallBack(this.httpCallBack)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> CoinGeckoAPIV3Client.</returns>
        internal static CoinGeckoAPIV3Client CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("COIN_GECKO_APIV_3_STANDARD_ENVIRONMENT");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = CoinGeckoAPIV3.Standard.Environment.Production;
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private IHttpClient httpClient;
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the CoinGeckoAPIV3Client using the values provided for the builder.
            /// </summary>
            /// <returns>CoinGeckoAPIV3Client.</returns>
            public CoinGeckoAPIV3Client Build()
            {
                this.httpClient = new HttpClientWrapper(this.httpClientConfig.Build());

                return new CoinGeckoAPIV3Client(
                    this.environment,
                    this.authManagers,
                    this.httpClient,
                    this.httpCallBack,
                    this.httpClientConfig.Build());
            }
        }
    }
}
