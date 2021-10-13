# Companies Beta

```csharp
CompaniesBetaController companiesBetaController = client.CompaniesBetaController;
```

## Class Name

`CompaniesBetaController`


# Getpubliccompaniesdata

Get public companies bitcoin or ethereum holdings (Ordered by total holdings descending)

```csharp
GetpubliccompaniesdataAsync(
    string coinId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `coinId` | `string` | Template, Required | bitcoin or ethereum |

## Response Type

`Task`

## Example Usage

```csharp
string coinId = "coin_id6";

try
{
    await companiesBetaController.GetpubliccompaniesdataAsync(coinId);
}
catch (ApiException e){};
```

