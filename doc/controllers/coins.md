# Coins

```csharp
CoinsController coinsController = client.CoinsController;
```

## Class Name

`CoinsController`

## Methods

* [Listallsupportedcoinsid Nameandsymbol Nopaginationrequired](/doc/controllers/coins.md#listallsupportedcoinsid-nameandsymbol-nopaginationrequired)
* [Listallsupportedcoinsprice Marketcap Volume Andmarketrelateddata](/doc/controllers/coins.md#listallsupportedcoinsprice-marketcap-volume-andmarketrelateddata)
* [Getcurrentdata Name Price Market Includingexchangetickers Foracoin](/doc/controllers/coins.md#getcurrentdata-name-price-market-includingexchangetickers-foracoin)
* [Getcointickers Paginatedto 100 Items](/doc/controllers/coins.md#getcointickers-paginatedto-100-items)
* [Gethistoricaldata Name Price Market Stats Atagivendateforacoin](/doc/controllers/coins.md#gethistoricaldata-name-price-market-stats-atagivendateforacoin)
* [Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolume Granularityauto](/doc/controllers/coins.md#gethistoricalmarketdataincludeprice-marketcap-and-24-hvolume-granularityauto)
* [Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolumewithinarangeoftimestamp Granularityauto](/doc/controllers/coins.md#gethistoricalmarketdataincludeprice-marketcap-and-24-hvolumewithinarangeoftimestamp-granularityauto)
* [Getstatusupdatesforagivencoin](/doc/controllers/coins.md#getstatusupdatesforagivencoin)
* [Getcoin S OHLC](/doc/controllers/coins.md#getcoin-s-ohlc)


# Listallsupportedcoinsid Nameandsymbol Nopaginationrequired

Use this to obtain all the coins' id in order to make API calls

```csharp
ListallsupportedcoinsidNameandsymbolNopaginationrequiredAsync(
    bool? includePlatform = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `includePlatform` | `bool?` | Query, Optional | flag to include platform contract addresses (eg. 0x.... for Ethereum based tokens).<br>valid values: true, false |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await coinsController.ListallsupportedcoinsidNameandsymbolNopaginationrequiredAsync(null);
}
catch (ApiException e){};
```


# Listallsupportedcoinsprice Marketcap Volume Andmarketrelateddata

Use this to obtain all the coins market data (price, market cap, volume)

```csharp
ListallsupportedcoinspriceMarketcapVolumeAndmarketrelateddataAsync(
    string vsCurrency,
    string ids = null,
    string category = null,
    string order = "market_cap_desc",
    int? perPage = 100,
    int? page = 1,
    bool? sparkline = false,
    string priceChangePercentage = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `vsCurrency` | `string` | Query, Required | The target currency of market data (usd, eur, jpy, etc.) |
| `ids` | `string` | Query, Optional | The ids of the coin, comma separated crytocurrency symbols (base). refers to `/coins/list`.<br><b>When left empty, returns numbers the coins observing the params `limit` and `start`</b> |
| `category` | `string` | Query, Optional | filter by coin category. Refer to /coin/categories/list |
| `order` | `string` | Query, Optional | valid values: <b>market_cap_desc, gecko_desc, gecko_asc, market_cap_asc, market_cap_desc, volume_asc, volume_desc, id_asc, id_desc</b><br>sort results by field.<br>**Default**: `"market_cap_desc"` |
| `perPage` | `int?` | Query, Optional | valid values: 1..250<br>Total results per page<br>**Default**: `100` |
| `page` | `int?` | Query, Optional | Page through results<br>**Default**: `1` |
| `sparkline` | `bool?` | Query, Optional | Include sparkline 7 days data (eg. true, false)<br>**Default**: `false` |
| `priceChangePercentage` | `string` | Query, Optional | Include price change percentage in <b>1h, 24h, 7d, 14d, 30d, 200d, 1y</b> (eg. '`1h,24h,7d`' comma-separated, invalid values will be discarded) |

## Response Type

`Task`

## Example Usage

```csharp
string vsCurrency = "vs_currency8";
string order = "market_cap_desc";
int? perPage = 100;
int? page = 1;
bool? sparkline = false;

try
{
    await coinsController.ListallsupportedcoinspriceMarketcapVolumeAndmarketrelateddataAsync(vsCurrency, null, null, order, perPage, page, sparkline, null);
}
catch (ApiException e){};
```


# Getcurrentdata Name Price Market Includingexchangetickers Foracoin

Get current data (name, price, market, ... including exchange tickers) for a coin.<br><br> **IMPORTANT**:
Ticker object is limited to 100 items, to get more tickers, use `/coins/{id}/tickers`
Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while.
Ticker `is_anomaly` is true if ticker's price is outliered by our system.
You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide)

```csharp
GetcurrentdataNamePriceMarketIncludingexchangetickersForacoinAsync(
    string id,
    string localization = null,
    bool? tickers = null,
    bool? marketData = null,
    bool? communityData = null,
    bool? developerData = null,
    bool? sparkline = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the coin id (can be obtained from /coins) eg. bitcoin |
| `localization` | `string` | Query, Optional | Include all localized languages in response (true/false) <b>[default: true]</b> |
| `tickers` | `bool?` | Query, Optional | Include tickers data (true/false) <b>[default: true]</b> |
| `marketData` | `bool?` | Query, Optional | Include market_data (true/false) <b>[default: true]</b> |
| `communityData` | `bool?` | Query, Optional | Include community_data data (true/false) <b>[default: true]</b> |
| `developerData` | `bool?` | Query, Optional | Include developer_data data (true/false) <b>[default: true]</b> |
| `sparkline` | `bool?` | Query, Optional | Include sparkline 7 days data (eg. true, false) <b>[default: false]</b> |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await coinsController.GetcurrentdataNamePriceMarketIncludingexchangetickersForacoinAsync(id, null, null, null, null, null, null);
}
catch (ApiException e){};
```


# Getcointickers Paginatedto 100 Items

Get coin tickers (paginated to 100 items)<br><br> **IMPORTANT**:
Ticker `is_stale` is true when ticker that has not been updated/unchanged from the exchange for a while.
Ticker `is_anomaly` is true if ticker's price is outliered by our system.
You are responsible for managing how you want to display these information (e.g. footnote, different background, change opacity, hide)

```csharp
GetcointickersPaginatedto100itemsAsync(
    string id,
    string exchangeIds = null,
    string includeExchangeLogo = null,
    int? page = null,
    string order = null,
    string depth = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the coin id (can be obtained from /coins/list) eg. bitcoin |
| `exchangeIds` | `string` | Query, Optional | filter results by exchange_ids (ref: v3/exchanges/list) |
| `includeExchangeLogo` | `string` | Query, Optional | flag to show exchange_logo |
| `page` | `int?` | Query, Optional | Page through results |
| `order` | `string` | Query, Optional | valid values: <b>trust_score_desc (default), trust_score_asc and volume_desc</b> |
| `depth` | `string` | Query, Optional | flag to show 2% orderbook depth. valid values: true, false |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await coinsController.GetcointickersPaginatedto100itemsAsync(id, null, null, null, null, null);
}
catch (ApiException e){};
```


# Gethistoricaldata Name Price Market Stats Atagivendateforacoin

Get historical data (name, price, market, stats) at a given date for a coin

```csharp
GethistoricaldataNamePriceMarketStatsAtagivendateforacoinAsync(
    string id,
    string date,
    string localization = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the coin id (can be obtained from /coins) eg. bitcoin |
| `date` | `string` | Query, Required | The date of data snapshot in dd-mm-yyyy eg. 30-12-2017 |
| `localization` | `string` | Query, Optional | Set to false to exclude localized languages in response |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
string date = "date4";

try
{
    await coinsController.GethistoricaldataNamePriceMarketStatsAtagivendateforacoinAsync(id, date, null);
}
catch (ApiException e){};
```


# Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolume Granularityauto

Get historical market data include price, market cap, and 24h volume (granularity auto)
<b>Minutely data will be used for duration within 1 day, Hourly data will be used for duration between 1 day and 90 days, Daily data will be used for duration above 90 days.</b>

```csharp
GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoAsync(
    string id,
    string vsCurrency,
    string days,
    string interval = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the coin id (can be obtained from /coins) eg. bitcoin |
| `vsCurrency` | `string` | Query, Required | The target currency of market data (usd, eur, jpy, etc.) |
| `days` | `string` | Query, Required | Data up to number of days ago (eg. 1,14,30,max) |
| `interval` | `string` | Query, Optional | Data interval. Possible value: daily |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
string vsCurrency = "vs_currency8";
string days = "days0";

try
{
    await coinsController.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoAsync(id, vsCurrency, days, null);
}
catch (ApiException e){};
```


# Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolumewithinarangeoftimestamp Granularityauto

Get historical market data include price, market cap, and 24h volume within a range of timestamp (granularity auto)
<b><ul><li>Data granularity is automatic (cannot be adjusted)</li><li>1 day from query time = 5 minute interval data</li><li>1 - 90 days from query time = hourly data</li><li>above 90 days from query time = daily data (00:00 UTC)</li></ul> </b>

```csharp
GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoAsync(
    string id,
    string vsCurrency,
    string from,
    string to)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the coin id (can be obtained from /coins) eg. bitcoin |
| `vsCurrency` | `string` | Query, Required | The target currency of market data (usd, eur, jpy, etc.) |
| `from` | `string` | Query, Required | From date in UNIX Timestamp (eg. 1392577232) |
| `to` | `string` | Query, Required | To date in UNIX Timestamp (eg. 1422577232) |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
string vsCurrency = "vs_currency8";
string from = "from2";
string to = "to6";

try
{
    await coinsController.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoAsync(id, vsCurrency, from, to);
}
catch (ApiException e){};
```


# Getstatusupdatesforagivencoin

Get status updates for a given coin

```csharp
GetstatusupdatesforagivencoinAsync(
    string id,
    int? perPage = null,
    int? page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the coin id (can be obtained from /coins) eg. bitcoin |
| `perPage` | `int?` | Query, Optional | Total results per page |
| `page` | `int?` | Query, Optional | Page through results |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";

try
{
    await coinsController.GetstatusupdatesforagivencoinAsync(id, null, null);
}
catch (ApiException e){};
```


# Getcoin S OHLC

Candle's body:

1 - 2 days: 30 minutes
3 - 30 days: 4 hours
31 and before: 4 days

```csharp
GetcoinSOHLCAsync(
    string id,
    string vsCurrency,
    int days)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | pass the coin id (can be obtained from /coins/list) eg. bitcoin |
| `vsCurrency` | `string` | Query, Required | The target currency of market data (usd, eur, jpy, etc.) |
| `days` | `int` | Query, Required | Data up to number of days ago (1/7/14/30/90/180/365/max) |

## Response Type

`Task<List<double>>`

## Example Usage

```csharp
string id = "id0";
string vsCurrency = "vs_currency8";
int days = 120;

try
{
    List<double> result = await coinsController.GetcoinSOHLCAsync(id, vsCurrency, days);
}
catch (ApiException e){};
```

