# Status Updates

```csharp
StatusUpdatesController statusUpdatesController = client.StatusUpdatesController;
```

## Class Name

`StatusUpdatesController`


# Listallstatus Updateswithdata Description Category Created at User User Titleandpin

List all status_updates with data (description, category, created_at, user, user_title and pin)

```csharp
ListallstatusUpdateswithdataDescriptionCategoryCreatedAtUserUserTitleandpinAsync(
    string category = null,
    string projectType = null,
    int? perPage = null,
    int? page = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `category` | `string` | Query, Optional | Filtered by category (eg. general, milestone, partnership, exchange_listing, software_release, fund_movement, new_listings, event) |
| `projectType` | `string` | Query, Optional | Filtered by Project Type (eg. coin, market). If left empty returns both status from coins and markets. |
| `perPage` | `int?` | Query, Optional | Total results per page |
| `page` | `int?` | Query, Optional | Page through results |

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await statusUpdatesController.ListallstatusUpdateswithdataDescriptionCategoryCreatedAtUserUserTitleandpinAsync(null, null, null, null);
}
catch (ApiException e){};
```

