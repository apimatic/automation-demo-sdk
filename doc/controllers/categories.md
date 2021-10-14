# Categories

```csharp
CategoriesController categoriesController = client.CategoriesController;
```

## Class Name

`CategoriesController`

## Methods

* [Listallcategories](/doc/controllers/categories.md#listallcategories)
* [Listallcategorieswithmarketdata](/doc/controllers/categories.md#listallcategorieswithmarketdata)


# Listallcategories

List all categories

```csharp
ListallcategoriesAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await categoriesController.ListallcategoriesAsync();
}
catch (ApiException e){};
```


# Listallcategorieswithmarketdata

List all categories with market data

```csharp
ListallcategorieswithmarketdataAsync(
    string order = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `order` | `string` | Query, Optional | valid values: <b>market_cap_desc (default), market_cap_asc, name_desc, name_asc, market_cap_change_24h_desc and market_cap_change_24h_asc</b> |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await categoriesController.ListallcategorieswithmarketdataAsync(null);
}
catch (ApiException e){};
```

