# Contract

```csharp
ContractController contractController = client.ContractController;
```

## Class Name

`ContractController`

## Methods

* [Getcoininfofromcontractaddress](/doc/controllers/contract.md#getcoininfofromcontractaddress)
* [Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolume Granularityauto Fromacontractaddress](/doc/controllers/contract.md#gethistoricalmarketdataincludeprice-marketcap-and-24-hvolume-granularityauto-fromacontractaddress)
* [Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolumewithinarangeoftimestamp Granularityauto Fromacontractaddress](/doc/controllers/contract.md#gethistoricalmarketdataincludeprice-marketcap-and-24-hvolumewithinarangeoftimestamp-granularityauto-fromacontractaddress)


# Getcoininfofromcontractaddress

Get coin info from contract address

```csharp
GetcoininfofromcontractaddressAsync(
    string id,
    string contractAddress)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | Asset platform (See asset_platforms endpoint for list of options) |
| `contractAddress` | `string` | Template, Required | Token's contract address |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
string contractAddress = "contract_address6";

try
{
    await contractController.GetcoininfofromcontractaddressAsync(id, contractAddress);
}
catch (ApiException e){};
```


# Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolume Granularityauto Fromacontractaddress

Get historical market data include price, market cap, and 24h volume (granularity auto)

```csharp
GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoFromacontractaddressAsync(
    string id,
    string contractAddress,
    string vsCurrency,
    string days)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The id of the platform issuing tokens (See asset_platforms endpoint for list of options) |
| `contractAddress` | `string` | Template, Required | Token's contract address |
| `vsCurrency` | `string` | Query, Required | The target currency of market data (usd, eur, jpy, etc.) |
| `days` | `string` | Query, Required | Data up to number of days ago (eg. 1,14,30,max) |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
string contractAddress = "contract_address6";
string vsCurrency = "vs_currency8";
string days = "days0";

try
{
    await contractController.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumeGranularityautoFromacontractaddressAsync(id, contractAddress, vsCurrency, days);
}
catch (ApiException e){};
```


# Gethistoricalmarketdataincludeprice Marketcap and 24 Hvolumewithinarangeoftimestamp Granularityauto Fromacontractaddress

Get historical market data include price, market cap, and 24h volume within a range of timestamp (granularity auto)

```csharp
GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoFromacontractaddressAsync(
    string id,
    string contractAddress,
    string vsCurrency,
    string from,
    string to)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The id of the platform issuing tokens (See asset_platforms endpoint for list of options) |
| `contractAddress` | `string` | Template, Required | Token's contract address |
| `vsCurrency` | `string` | Query, Required | The target currency of market data (usd, eur, jpy, etc.) |
| `from` | `string` | Query, Required | From date in UNIX Timestamp (eg. 1392577232) |
| `to` | `string` | Query, Required | To date in UNIX Timestamp (eg. 1422577232) |

## Response Type

`Task`

## Example Usage

```csharp
string id = "id0";
string contractAddress = "contract_address6";
string vsCurrency = "vs_currency8";
string from = "from2";
string to = "to6";

try
{
    await contractController.GethistoricalmarketdataincludepriceMarketcapAnd24hvolumewithinarangeoftimestampGranularityautoFromacontractaddressAsync(id, contractAddress, vsCurrency, from, to);
}
catch (ApiException e){};
```

