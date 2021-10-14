# Simple Calculator

```csharp
SimpleCalculatorController simpleCalculatorController = client.SimpleCalculatorController;
```

## Class Name

`SimpleCalculatorController`


# Calculate

Calculates the expression using the specified operation.

| Table Column 1 | Table Column 2 | Table Column 3 |  
| -------------- | -------------- | -------------- |  
| Row 1x1        | Row 1x2        | Row 1x3        |  
| Row 2x1        | Row 2x2        | Row 2x3        |

```csharp
CalculateAsync(
    Models.OperationTypeEnum operation,
    double x,
    double y)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | [`Models.OperationTypeEnum`](/doc/models/operation-type-enum.md) | Template, Required | The operator to apply on the variables |
| `x` | `double` | Query, Required | The LHS value |
| `y` | `double` | Query, Required | The RHS value |

## Response Type

`Task<double>`

## Example Usage

```csharp
OperationTypeEnum operation = OperationTypeEnum.SUM;
double x = 222.14;
double y = 165.14;

try
{
    double? result = await simpleCalculatorController.CalculateAsync(operation, x, y);
}
catch (ApiException e){};
```

