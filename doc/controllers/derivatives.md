# Derivatives

```csharp
DerivativesController derivativesController = client.DerivativesController;
```

## Class Name

`DerivativesController`

## Methods

* [Listallderivativetickers](/doc/controllers/derivatives.md#listallderivativetickers)
* [Listallderivativeexchanges](/doc/controllers/derivatives.md#listallderivativeexchanges)
* [Showderivativeexchangedata](/doc/controllers/derivatives.md#showderivativeexchangedata)
* [Listallderivativeexchangesnameandidentifier](/doc/controllers/derivatives.md#listallderivativeexchangesnameandidentifier)


# Listallderivativetickers

List all derivative tickers

```csharp
ListallderivativetickersAsync(
    string includeTickers = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `includeTickers` | `string` | Query, Optional | ['all', 'unexpired'] - expired to show unexpired tickers, all to list all tickers, defaults to unexpired |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await derivativesController.ListallderivativetickersAsync(null);
}
catch (ApiException e){};
```


# Listallderivativeexchanges

List all derivative exchanges

```csharp
ListallderivativeexchangesAsync(
    string order = null,
    int? perPage = null,
    int? page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `order` | `string` | Query, Optional | order results using following params name_asc，name_desc，open_interest_btc_asc，open_interest_btc_desc，trade_volume_24h_btc_asc，trade_volume_24h_btc_desc |
| `perPage` | `int?` | Query, Optional | Total results per page |
| `page` | `int?` | Query, Optional | Page through results |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await derivativesController.ListallderivativeexchangesAsync(null, null, null);
}
catch (ApiException e){};
```


# Showderivativeexchangedata

show derivative exchange data

```csharp
ShowderivativeexchangedataAsync(
    string id,
    string includeTickers = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the exchange id (can be obtained from derivatives/exchanges/list) eg. bitmex |
| `includeTickers` | `string` | Query, Optional | ['all', 'unexpired'] - expired to show unexpired tickers, all to list all tickers, leave blank to omit tickers data in response |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await derivativesController.ShowderivativeexchangedataAsync(id, null);
}
catch (ApiException e){};
```


# Listallderivativeexchangesnameandidentifier

List all derivative exchanges name and identifier

```csharp
ListallderivativeexchangesnameandidentifierAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await derivativesController.ListallderivativeexchangesnameandidentifierAsync();
}
catch (ApiException e){};
```

