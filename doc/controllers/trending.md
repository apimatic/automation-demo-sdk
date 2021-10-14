# Trending

```csharp
TrendingController trendingController = client.TrendingController;
```

## Class Name

`TrendingController`


# Gettrendingsearchcoins Top-7 on Coin Geckointhelast 24 Hours

Top-7 trending coins on CoinGecko as searched by users in the last 24 hours (Ordered by most popular first)

```csharp
GettrendingsearchcoinsTop7OnCoinGeckointhelast24hoursAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await trendingController.GettrendingsearchcoinsTop7OnCoinGeckointhelast24hoursAsync();
}
catch (ApiException e){};
```

