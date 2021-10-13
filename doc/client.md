
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |

The API client can be initialized as follows:

```csharp
CoinGeckoAPIV3.Standard.CoinGeckoAPIV3Client client = new CoinGeckoAPIV3.Standard.CoinGeckoAPIV3Client.Builder().Build();
```

## CoinGecko API V3Client Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| PingController | Gets PingController controller. |
| SimpleController | Gets SimpleController controller. |
| CoinsController | Gets CoinsController controller. |
| ContractController | Gets ContractController controller. |
| AssetPlatformsController | Gets AssetPlatformsController controller. |
| CategoriesController | Gets CategoriesController controller. |
| ExchangesController | Gets ExchangesController controller. |
| FinanceController | Gets FinanceController controller. |
| IndexesController | Gets IndexesController controller. |
| DerivativesController | Gets DerivativesController controller. |
| StatusUpdatesController | Gets StatusUpdatesController controller. |
| EventsController | Gets EventsController controller. |
| ExchangeRatesController | Gets ExchangeRatesController controller. |
| TrendingController | Gets TrendingController controller. |
| GlobalController | Gets GlobalController controller. |
| CompaniesBetaController | Gets CompaniesBetaController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the CoinGecko API V3Client using the values provided for the builder. | `Builder` |

## CoinGecko API V3Client Builder Class

Class to build instances of CoinGecko API V3Client.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |

