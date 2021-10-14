# Finance

```csharp
FinanceController financeController = client.FinanceController;
```

## Class Name

`FinanceController`

## Methods

* [Listallfinanceplatforms](/doc/controllers/finance.md#listallfinanceplatforms)
* [Listallfinanceproducts](/doc/controllers/finance.md#listallfinanceproducts)


# Listallfinanceplatforms

List all finance platforms

```csharp
ListallfinanceplatformsAsync(
    int? perPage = null,
    string page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `perPage` | `int?` | Query, Optional | Total results per page |
| `page` | `string` | Query, Optional | page of results (paginated to 100 by default) |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await financeController.ListallfinanceplatformsAsync(null, null);
}
catch (ApiException e){};
```


# Listallfinanceproducts

List all finance products

```csharp
ListallfinanceproductsAsync(
    int? perPage = null,
    string page = null,
    string startAt = null,
    string endAt = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `perPage` | `int?` | Query, Optional | Total results per page |
| `page` | `string` | Query, Optional | page of results (paginated to 100 by default) |
| `startAt` | `string` | Query, Optional | start date of the financial products |
| `endAt` | `string` | Query, Optional | end date of the financial products |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await financeController.ListallfinanceproductsAsync(null, null, null, null);
}
catch (ApiException e){};
```

