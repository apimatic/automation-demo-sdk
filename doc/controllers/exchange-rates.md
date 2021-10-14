# Exchange Rates

```csharp
ExchangeRatesController exchangeRatesController = client.ExchangeRatesController;
```

## Class Name

`ExchangeRatesController`


# Get BTC-to-Currencyexchangerates

Get BTC-to-Currency exchange rates

```csharp
GetBTCToCurrencyexchangeratesAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await exchangeRatesController.GetBTCToCurrencyexchangeratesAsync();
}
catch (ApiException e){};
```

