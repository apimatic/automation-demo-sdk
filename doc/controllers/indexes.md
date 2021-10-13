# Indexes

```csharp
IndexesController indexesController = client.IndexesController;
```

## Class Name

`IndexesController`

## Methods

* [Listallmarketindexes](/doc/controllers/indexes.md#listallmarketindexes)
* [Getmarketindexbymarketidandindexid](/doc/controllers/indexes.md#getmarketindexbymarketidandindexid)
* [Listmarketindexesidandname](/doc/controllers/indexes.md#listmarketindexesidandname)


# Listallmarketindexes

List all market indexes

```csharp
ListallmarketindexesAsync(
    int? perPage = null,
    int? page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `perPage` | `int?` | Query, Optional | Total results per page |
| `page` | `int?` | Query, Optional | Page through results |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await indexesController.ListallmarketindexesAsync(null, null);
}
catch (ApiException e){};
```


# Getmarketindexbymarketidandindexid

get market index by market id and index id

```csharp
GetmarketindexbymarketidandindexidAsync(
    string marketId,
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `marketId` | `string` | Template, Required | pass the market id (can be obtained from /exchanges/list) |
| `id` | `string` | Template, Required | pass the index id (can be obtained from /indexes/list) |

## Response Type

`Task`

## Example Usage

```csharp
string marketId = "market_id8";
string id = "id0";

try
{
    await indexesController.GetmarketindexbymarketidandindexidAsync(marketId, id);
}
catch (ApiException e){};
```


# Listmarketindexesidandname

list market indexes id and name

```csharp
ListmarketindexesidandnameAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await indexesController.ListmarketindexesidandnameAsync();
}
catch (ApiException e){};
```

