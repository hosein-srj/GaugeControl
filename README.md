| Property           | Type     | Description                                                         |
| ------------------ | -------- | ------------------------------------------------------------------- |
| `Minimum`          | `double` | Minimum value of the gauge                                          |
| `Maximum`          | `double` | Maximum value of the gauge                                          |
| `Value`            | `double` | Current value displayed by the needle                               |
| `InvertedRange`    | `bool`   | If `true`, the scale direction is reversed                          |
| `RangeScaleFactor` | `double` | Multiplier applied to range values (e.g. 1000 for RPM in thousands) |


| Property                | Type     | Description                          |
| ----------------------- | -------- | ------------------------------------ |
| `ScaleStartAngle`       | `double` | Start angle of the scale (degrees)   |
| `ScaleEndAngle`         | `double` | End angle of the scale (degrees)     |
| `RangeInnerStartExtent` | `double` | Inner radius of range at scale start |
| `RangeOuterStartExtent` | `double` | Outer radius of range at scale start |
| `RangeInnerEndExtent`   | `double` | Inner radius of range at scale end   |
| `RangeOuterEndExtent`   | `double` | Outer radius of range at scale end   |


| Property          | Type     | Description                  |
| ----------------- | -------- | ---------------------------- |
| `TickInterval`    | `double` | Interval between major ticks |
| `TickStartExtent` | `double` | Start radius of major ticks  |
| `TickEndExtent`   | `double` | End radius of major ticks    |
| `TickBrush`       | `Brush`  | Color of major ticks         |
| `TickStrokeWidth` | `double` | Thickness of major ticks     |


| Property               | Type     | Description                  |
| ---------------------- | -------- | ---------------------------- |
| `MinorTickInterval`    | `double` | Interval between minor ticks |
| `MinorTickStartExtent` | `double` | Start radius of minor ticks  |
| `MinorTickEndExtent`   | `double` | End radius of minor ticks    |
| `MinorTickBrush`       | `Brush`  | Color of minor ticks         |
| `MinorTickStrokeWidth` | `double` | Thickness of minor ticks     |


| Property            | Type         | Description                               |
| ------------------- | ------------ | ----------------------------------------- |
| `LabelFontFamily`   | `FontFamily` | Font family of scale labels               |
| `LabelFontSize`     | `double`     | Font size of scale labels                 |
| `LabelFontWeight`   | `FontWeight` | Font weight of scale labels               |
| `LabelFontBrush`    | `Brush`      | Color of scale labels                     |
| `LabelFormatString` | `string`     | Format string for labels perceived values |
| `LabelExtent`       | `double`     | Radial position of labels                 |

| Property                  | Type     | Description                      |
| ------------------------- | -------- | -------------------------------- |
| `NeedleBrush`             | `Brush`  | Color of the needle              |
| `NeedleEndExtent`         | `double` | Needle length relative to radius |
| `NeedleEndWidth`          | `double` | Needle width                     |
| `NeedleCircleRadius`      | `double` | Radius of needle pivot circle    |
| `NeedlePivotBrush`        | `Brush`  | Pivot fill color                 |
| `NeedlePivotOutlineBrush` | `Brush`  | Pivot outline color              |
| `NeedlePivotEndExtent`    | `double` | Pivot circle size                |

| Property            | Type                | Description                                     |
| ------------------- | ------------------- | ----------------------------------------------- |
| `ValueExtent`       | `double`            | Radial position of the value text               |
| `PostfixValue`      | `string`            | Text appended after the value (e.g. `V`, `RPM`) |
| `ValueFormatString` | `string`            | .NET format string for value                    |
| `ValueFontFamily`   | `FontFamily`        | Font family of value text                       |
| `ValueFontSize`     | `double`            | Font size of value text                         |
| `ValueFontWeight`   | `FontWeight`        | Font weight of value text                       |
| `ValueFontBrush`    | `Brush`             | Color of value text                             |
| `ValueLocation`     | `ValueLocationEnum` | Position of value text                          |


| Value          | Description            |
| -------------- | ---------------------- |
| `Center`       | Center of the gauge    |
| `LeftCenter`   | Left of center         |
| `RightCenter`  | Right of center        |
| `BottomCenter` | Bottom center of gauge |
| `TopCenter`    | Top center of gauge    |


| Property           | Type     | Description                        |
| ------------------ | -------- | ---------------------------------- |
| `RangeBrush`       | `Brush`  | Color of the scale range           |
| `RangeScaleFactor` | `double` | Visual scale multiplier for ranges |
