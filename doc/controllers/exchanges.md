# Exchanges

```csharp
ExchangesController exchangesController = client.ExchangesController;
```

## Class Name

`ExchangesController`

## Methods

* [Listallexchanges](/doc/controllers/exchanges.md#listallexchanges)
* [Listallsupportedmarketsidandname Nopaginationrequired](/doc/controllers/exchanges.md#listallsupportedmarketsidandname-nopaginationrequired)
* [Getexchangevolumein BT Candtop 100 Tickersonly](/doc/controllers/exchanges.md#getexchangevolumein-bt-candtop-100-tickersonly)
* [Getexchangetickers Paginated 100 Tickersperpage](/doc/controllers/exchanges.md#getexchangetickers-paginated-100-tickersperpage)
* [Getstatusupdatesforagivenexchange](/doc/controllers/exchanges.md#getstatusupdatesforagivenexchange)
* [Getvolume Chartdataforagivenexchange](/doc/controllers/exchanges.md#getvolume-chartdataforagivenexchange)


# Listallexchanges

List all exchanges

```csharp
ListallexchangesAsync(
    int? perPage = null,
    string page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `perPage` | `int?` | Query, Optional | Valid values: 1...250<br>Total results per page<br>Default value:: 100 |
| `page` | `string` | Query, Optional | page through results |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await exchangesController.ListallexchangesAsync(null, null);
}
catch (ApiException e){};
```


# Listallsupportedmarketsidandname Nopaginationrequired

Use this to obtain all the markets' id in order to make API calls

```csharp
ListallsupportedmarketsidandnameNopaginationrequiredAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await exchangesController.ListallsupportedmarketsidandnameNopaginationrequiredAsync();
}
catch (ApiException e){};
```


# Getexchangevolumein BT Candtop 100 Tickersonly

Get exchange volume in BTC and tickers<br><br> **IMPORTANT**:
Ticker object is limited to 100 items, to get more tickers, use `/exchanges/{id}/tickers`
Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while.
Ticker `is_anomaly` is true if ticker's price is outliered by our system.
You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide)

```csharp
GetexchangevolumeinBTCandtop100tickersonlyAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the exchange id (can be obtained from /exchanges/list) eg. binance |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await exchangesController.GetexchangevolumeinBTCandtop100tickersonlyAsync(id);
}
catch (ApiException e){};
```


# Getexchangetickers Paginated 100 Tickersperpage

Get exchange tickers (paginated)<br><br> **IMPORTANT**:
Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while.
Ticker `is_anomaly` is true if ticker's price is outliered by our system.
You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide)

```csharp
GetexchangetickersPaginated100tickersperpageAsync(
    string id,
    string coinIds = null,
    string includeExchangeLogo = null,
    int? page = null,
    string depth = null,
    string order = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the exchange id (can be obtained from /exchanges/list) eg. binance |
| `coinIds` | `string` | Query, Optional | filter tickers by coin_ids (ref: v3/coins/list) |
| `includeExchangeLogo` | `string` | Query, Optional | flag to show exchange_logo |
| `page` | `int?` | Query, Optional | Page through results |
| `depth` | `string` | Query, Optional | flag to show 2% orderbook depth i.e., cost_to_move_up_usd and cost_to_move_down_usd |
| `order` | `string` | Query, Optional | valid values: <b>trust_score_desc (default), trust_score_asc and volume_desc</b> |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await exchangesController.GetexchangetickersPaginated100tickersperpageAsync(id, null, null, null, null, null);
}
catch (ApiException e){};
```


# Getstatusupdatesforagivenexchange

Get status updates for a given exchange

```csharp
GetstatusupdatesforagivenexchangeAsync(
    string id,
    int? perPage = null,
    int? page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the exchange id (can be obtained from /exchanges/list) eg. binance |
| `perPage` | `int?` | Query, Optional | Total results per page |
| `page` | `int?` | Query, Optional | Page through results |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await exchangesController.GetstatusupdatesforagivenexchangeAsync(id, null, null);
}
catch (ApiException e){};
```


# Getvolume Chartdataforagivenexchange

Get volume_chart data for a given exchange

```csharp
GetvolumeChartdataforagivenexchangeAsync(
    string id,
    int days)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the exchange id (can be obtained from /exchanges/list) eg. binance |
| `days` | `int` | Query, Required | Data up to number of days ago (eg. 1,14,30) |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
int days = 120;

try
{
    await exchangesController.GetvolumeChartdataforagivenexchangeAsync(id, days);
}
catch (ApiException e){};
```

