# Simple

```csharp
SimpleController simpleController = client.SimpleController;
```

## Class Name

`SimpleController`

## Methods

* [Getthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneed](/doc/controllers/simple.md#getthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneed)
* [Getcurrentpriceoftokens Usingcontractaddresses Foragivenplatforminanyothercurrencythatyouneed](/doc/controllers/simple.md#getcurrentpriceoftokens-usingcontractaddresses-foragivenplatforminanyothercurrencythatyouneed)
* [Getlistofsupported Vs Currencies](/doc/controllers/simple.md#getlistofsupported-vs-currencies)


# Getthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneed

Get the current price of any cryptocurrencies in any other supported currencies that you need.

```csharp
GetthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneedAsync(
    string ids,
    string vsCurrencies,
    string includeMarketCap = null,
    string include24hrVol = null,
    string include24hrChange = null,
    string includeLastUpdatedAt = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ids` | `string` | Query, Required | id of coins, comma-separated if querying more than 1 coin<br>*refers to <b>`coins/list`</b> |
| `vsCurrencies` | `string` | Query, Required | vs_currency of coins, comma-separated if querying more than 1 vs_currency<br>*refers to <b>`simple/supported_vs_currencies`</b> |
| `includeMarketCap` | `string` | Query, Optional | <b>true/false</b> to include market_cap, <b>default: false</b> |
| `include24hrVol` | `string` | Query, Optional | <b>true/false</b> to include 24hr_vol, <b>default: false</b> |
| `include24hrChange` | `string` | Query, Optional | <b>true/false</b> to include 24hr_change, <b>default: false</b> |
| `includeLastUpdatedAt` | `string` | Query, Optional | <b>true/false</b> to include last_updated_at of price, <b>default: false</b> |

## Response Type

`Task`

## Example Usage

```csharp
string ids = "ids4";
string vsCurrencies = "vs_currencies8";

try
{
    await simpleController.GetthecurrentpriceofanycryptocurrenciesinanyothersupportedcurrenciesthatyouneedAsync(ids, vsCurrencies, null, null, null, null);
}
catch (ApiException e){};
```


# Getcurrentpriceoftokens Usingcontractaddresses Foragivenplatforminanyothercurrencythatyouneed

Get current price of tokens (using contract addresses) for a given platform in any other currency that you need.

```csharp
GetcurrentpriceoftokensUsingcontractaddressesForagivenplatforminanyothercurrencythatyouneedAsync(
    string id,
    string contractAddresses,
    string vsCurrencies,
    string includeMarketCap = null,
    string include24hrVol = null,
    string include24hrChange = null,
    string includeLastUpdatedAt = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The id of the platform issuing tokens (See asset_platforms endpoint for list of options) |
| `contractAddresses` | `string` | Query, Required | The contract address of tokens, comma separated |
| `vsCurrencies` | `string` | Query, Required | vs_currency of coins, comma-separated if querying more than 1 vs_currency<br>*refers to <b>`simple/supported_vs_currencies`</b> |
| `includeMarketCap` | `string` | Query, Optional | <b>true/false</b> to include market_cap, <b>default: false</b> |
| `include24hrVol` | `string` | Query, Optional | <b>true/false</b> to include 24hr_vol, <b>default: false</b> |
| `include24hrChange` | `string` | Query, Optional | <b>true/false</b> to include 24hr_change, <b>default: false</b> |
| `includeLastUpdatedAt` | `string` | Query, Optional | <b>true/false</b> to include last_updated_at of price, <b>default: false</b> |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
string contractAddresses = "contract_addresses6";
string vsCurrencies = "vs_currencies8";

try
{
    await simpleController.GetcurrentpriceoftokensUsingcontractaddressesForagivenplatforminanyothercurrencythatyouneedAsync(id, contractAddresses, vsCurrencies, null, null, null, null);
}
catch (ApiException e){};
```


# Getlistofsupported Vs Currencies

Get list of supported_vs_currencies.

```csharp
GetlistofsupportedVsCurrenciesAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await simpleController.GetlistofsupportedVsCurrenciesAsync();
}
catch (ApiException e){};
```

