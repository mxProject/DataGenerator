


# IStringConverter Interface



Provides the functionality needed to convert string values.






## Inheritance tree

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [ConvertTo(string, Type)](#converttostring-type-method) | object | Converts the specified string value. |
| public | [ConvertTo&lt;T&gt;(string)](#converttotstring-method) | T | Converts the specified string value. |
---
### ConvertTo(string, Type) Method

Converts the specified string value.
```c#
object ConvertTo
(
	string value
	, Type type
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | string |  | The value. |
| type | Type |  | The type of converted value. |
#### Return type
A converted value.

[Go to methods](#Methods)

---
### ConvertTo&lt;T&gt;(string) Method

Converts the specified string value.
```c#
T ConvertTo<T>
(
	string value
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of converted value. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | string |  | The value. |
#### Return type
A converted value.

[Go to methods](#Methods)



