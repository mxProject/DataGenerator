


# IDataGenerationRecord Interface



Provides the functionality needed for a DataRecord to read the generated values.






## Inheritance tree
## Implemented interfaces
* System.Data.IDataRecord

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [GetBoolean(string)](#getbooleanstring-method) | bool | Gets the value of the specified column as a Boolean. |
| public | [GetByte(string)](#getbytestring-method) | byte | Gets the 8-bit unsigned integer value of the specified column. |
| public | [GetChar(string)](#getcharstring-method) | char | Gets the character value of the specified column. |
| public | [GetDateTime(string)](#getdatetimestring-method) | DateTime | Gets the date and time data value of the specified field. |
| public | [GetDecimal(string)](#getdecimalstring-method) | decimal | Gets the fixed-position numeric value of the specified field. |
| public | [GetDouble(string)](#getdoublestring-method) | double | Gets the double-precision floating point number of the specified field. |
| public | [GetFloat(string)](#getfloatstring-method) | float | Gets the single-precision floating point number of the specified field. |
| public | [GetGuid(string)](#getguidstring-method) | Guid | Returns the GUID value of the specified field. |
| public | [GetInt16(string)](#getint16string-method) | short | Gets the 16-bit signed integer value of the specified field. |
| public | [GetInt32(string)](#getint32string-method) | int | Gets the 32-bit signed integer value of the specified field. |
| public | [GetInt64(string)](#getint64string-method) | long | Gets the 64-bit signed integer value of the specified field. |
| public | [GetRawValue&lt;T&gt;(int)](#getrawvaluetint-method) | T? | Gets the generated raw value of the specified field. |
| public | [GetRawValue&lt;T&gt;(string)](#getrawvaluetstring-method) | T? | Gets the generated raw value of the specified field. |
| public | [GetString(string)](#getstringstring-method) | string | Gets the string value of the specified field. |
| public | [GetValue(string)](#getvaluestring-method) | object | Return the value of the specified field. |
| public | [IsDBNull(string)](#isdbnullstring-method) | bool | Return whether the specified field is set to null. |
---
### GetBoolean(string) Method

Gets the value of the specified column as a Boolean.
```c#
bool GetBoolean
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetByte(string) Method

Gets the 8-bit unsigned integer value of the specified column.
```c#
byte GetByte
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetChar(string) Method

Gets the character value of the specified column.
```c#
char GetChar
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetDateTime(string) Method

Gets the date and time data value of the specified field.
```c#
DateTime GetDateTime
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetDecimal(string) Method

Gets the fixed-position numeric value of the specified field.
```c#
decimal GetDecimal
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetDouble(string) Method

Gets the double-precision floating point number of the specified field.
```c#
double GetDouble
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetFloat(string) Method

Gets the single-precision floating point number of the specified field.
```c#
float GetFloat
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetGuid(string) Method

Returns the GUID value of the specified field.
```c#
Guid GetGuid
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetInt16(string) Method

Gets the 16-bit signed integer value of the specified field.
```c#
short GetInt16
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetInt32(string) Method

Gets the 32-bit signed integer value of the specified field.
```c#
int GetInt32
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetInt64(string) Method

Gets the 64-bit signed integer value of the specified field.
```c#
long GetInt64
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetRawValue&lt;T&gt;(int) Method

Gets the generated raw value of the specified field.
```c#
T? GetRawValue<T>
(
	int index
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### GetRawValue&lt;T&gt;(string) Method

Gets the generated raw value of the specified field.
```c#
T? GetRawValue<T>
(
	string fieldName
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetString(string) Method

Gets the string value of the specified field.
```c#
string GetString
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetValue(string) Method

Return the value of the specified field.
```c#
object GetValue
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### IsDBNull(string) Method

Return whether the specified field is set to null.
```c#
bool IsDBNull
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)



