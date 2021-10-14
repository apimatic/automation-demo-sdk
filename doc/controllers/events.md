# Events

```csharp
EventsController eventsController = client.EventsController;
```

## Class Name

`EventsController`

## Methods

* [Getevents Paginatedby 100](/doc/controllers/events.md#getevents-paginatedby-100)
* [Getlistofeventcountries](/doc/controllers/events.md#getlistofeventcountries)
* [Getlistofeventstypes](/doc/controllers/events.md#getlistofeventstypes)


# Getevents Paginatedby 100

Get events, paginated by 100

```csharp
GeteventsPaginatedby100Async(
    string countryCode = null,
    string type = null,
    string page = null,
    string upcomingEventsOnly = null,
    string fromDate = null,
    string toDate = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `countryCode` | `string` | Query, Optional | country_code of event (eg. 'US'). use <b>/api/v3/events/countries</b> for list of country_codes |
| `type` | `string` | Query, Optional | type of event (eg. 'Conference'). use <b>/api/v3/events/types</b> for list of types |
| `page` | `string` | Query, Optional | page of results (paginated by 100) |
| `upcomingEventsOnly` | `string` | Query, Optional | lists only upcoming events. <br>true, false</br> (defaults to true, set to false to list all events) |
| `fromDate` | `string` | Query, Optional | lists events after this date yyyy-mm-dd |
| `toDate` | `string` | Query, Optional | lists events before this date yyyy-mm-dd (set upcoming_events_only to false if fetching past events) |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await eventsController.GeteventsPaginatedby100Async(null, null, null, null, null, null);
}
catch (ApiException e){};
```


# Getlistofeventcountries

Get list of event countries

```csharp
GetlistofeventcountriesAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await eventsController.GetlistofeventcountriesAsync();
}
catch (ApiException e){};
```


# Getlistofeventstypes

Get list of event types

```csharp
GetlistofeventstypesAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await eventsController.GetlistofeventstypesAsync();
}
catch (ApiException e){};
```

