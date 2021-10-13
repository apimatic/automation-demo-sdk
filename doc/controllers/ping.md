# Ping

```csharp
PingController pingController = client.PingController;
```

## Class Name

`PingController`


# Check AP Iserverstatus

Check API server status

```csharp
CheckAPIserverstatusAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await pingController.CheckAPIserverstatusAsync();
}
catch (ApiException e){};
```

