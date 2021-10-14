# Global

```csharp
GlobalController globalController = client.GlobalController;
```

## Class Name

`GlobalController`


# Getcryptocurrencyglobaldata

Get cryptocurrency global data

```csharp
GetcryptocurrencyglobaldataAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await globalController.GetcryptocurrencyglobaldataAsync();
}
catch (ApiException e){};
```

