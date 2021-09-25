


# IDataRecordExtensions Class



Extension methods for System.Data.IDataRecord .






## Inheritance tree
* object

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
## Static Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [GetBoolean(IDataRecord, string)](#getbooleanidatarecord-string-method) | bool | Gets the value of the specified column as a Boolean. |
| public | [GetByte(IDataRecord, string)](#getbyteidatarecord-string-method) | byte | Gets the 8-bit unsigned integer value of the specified column. |
| public | [GetBytes(IDataRecord, string, long, byte[], int, int)](#getbytesidatarecord-string-long-byte-int-int-method) | long | Reads a stream of bytes from the specified column offset into the buffer as an array, starting at the given buffer offset. |
| public | [GetChar(IDataRecord, string)](#getcharidatarecord-string-method) | char | Gets the character value of the specified column. |
| public | [GetChars(IDataRecord, string, long, char[], int, int)](#getcharsidatarecord-string-long-char-int-int-method) | long | Reads a stream of characters from the specified column offset into the buffer as an array, starting at the given buffer offset. |
| public | [GetData(IDataRecord, string)](#getdataidatarecord-string-method) | IDataReader | Returns an System.Data.IDataReader for the specified column ordinal. |
| public | [GetDateTime(IDataRecord, string)](#getdatetimeidatarecord-string-method) | DateTime | Gets the date and time data value of the specified field. |
| public | [GetDecimal(IDataRecord, string)](#getdecimalidatarecord-string-method) | decimal | Gets the fixed-position numeric value of the specified field. |
| public | [GetDouble(IDataRecord, string)](#getdoubleidatarecord-string-method) | double | Gets the double-precision floating point number of the specified field. |
| public | [GetFloat(IDataRecord, string)](#getfloatidatarecord-string-method) | float | Gets the single-precision floating point number of the specified field. |
| public | [GetGuid(IDataRecord, string)](#getguididatarecord-string-method) | Guid | Returns the GUID value of the specified field. |
| public | [GetInt16(IDataRecord, string)](#getint16idatarecord-string-method) | short | Gets the 16-bit signed integer value of the specified field. |
| public | [GetInt32(IDataRecord, string)](#getint32idatarecord-string-method) | int | Gets the 32-bit signed integer value of the specified field. |
| public | [GetInt64(IDataRecord, string)](#getint64idatarecord-string-method) | long | Gets the 64-bit signed integer value of the specified field. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, int, int, int, int, int, int, int, int, int)](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8-t9idatagenerationrecord-int-int-int-int-int-int-int-int-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8-t9idatagenerationrecord-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, string, string, string, string, string, string, string, string, string)](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8-t9idatagenerationrecord-string-string-string-string-string-string-string-string-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8-t9idatagenerationrecord-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, int, int, int, int, int, int, int, int)](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8idatagenerationrecord-int-int-int-int-int-int-int-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8idatagenerationrecord-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, string, string, string, string, string, string, string, string)](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8idatagenerationrecord-string-string-string-string-string-string-string-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2-t3-t4-t5-t6-t7-t8idatagenerationrecord-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, int, int, int, int, int, int, int)](#getrawtuplet1-t2-t3-t4-t5-t6-t7idatagenerationrecord-int-int-int-int-int-int-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2-t3-t4-t5-t6-t7idatagenerationrecord-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, string, string, string, string, string, string, string)](#getrawtuplet1-t2-t3-t4-t5-t6-t7idatagenerationrecord-string-string-string-string-string-string-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2-t3-t4-t5-t6-t7idatagenerationrecord-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?, T7?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, int, int, int, int, int, int)](#getrawtuplet1-t2-t3-t4-t5-t6idatagenerationrecord-int-int-int-int-int-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2-t3-t4-t5-t6idatagenerationrecord-int-method) | (T1?, T2?, T3?, T4?, T5?, T6?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, string, string, string, string, string, string)](#getrawtuplet1-t2-t3-t4-t5-t6idatagenerationrecord-string-string-string-string-string-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2-t3-t4-t5-t6idatagenerationrecord-string-method) | (T1?, T2?, T3?, T4?, T5?, T6?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, int, int, int, int, int)](#getrawtuplet1-t2-t3-t4-t5idatagenerationrecord-int-int-int-int-int-method) | (T1?, T2?, T3?, T4?, T5?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2-t3-t4-t5idatagenerationrecord-int-method) | (T1?, T2?, T3?, T4?, T5?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, string, string, string, string, string)](#getrawtuplet1-t2-t3-t4-t5idatagenerationrecord-string-string-string-string-string-method) | (T1?, T2?, T3?, T4?, T5?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2-t3-t4-t5idatagenerationrecord-string-method) | (T1?, T2?, T3?, T4?, T5?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, int, int, int, int)](#getrawtuplet1-t2-t3-t4idatagenerationrecord-int-int-int-int-method) | (T1?, T2?, T3?, T4?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2-t3-t4idatagenerationrecord-int-method) | (T1?, T2?, T3?, T4?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, string, string, string, string)](#getrawtuplet1-t2-t3-t4idatagenerationrecord-string-string-string-string-method) | (T1?, T2?, T3?, T4?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2-t3-t4idatagenerationrecord-string-method) | (T1?, T2?, T3?, T4?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, int, int, int)](#getrawtuplet1-t2-t3idatagenerationrecord-int-int-int-method) | (T1?, T2?, T3?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2-t3idatagenerationrecord-int-method) | (T1?, T2?, T3?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, string, string, string)](#getrawtuplet1-t2-t3idatagenerationrecord-string-string-string-method) | (T1?, T2?, T3?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2-t3idatagenerationrecord-string-method) | (T1?, T2?, T3?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, int, int)](#getrawtuplet1-t2idatagenerationrecord-int-int-method) | (T1?, T2?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, int[])](#getrawtuplet1-t2idatagenerationrecord-int-method) | (T1?, T2?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, string, string)](#getrawtuplet1-t2idatagenerationrecord-string-string-method) | (T1?, T2?) | GetRaws the values of multiple specified fields. |
| public | [GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, string[])](#getrawtuplet1-t2idatagenerationrecord-string-method) | (T1?, T2?) | GetRaws the values of multiple specified fields. |
| public | [GetRawValue&lt;T&gt;(IDataGenerationRecord, string)](#getrawvaluetidatagenerationrecord-string-method) | T? | Gets the generated raw value of the specified field. |
| public | [GetString(IDataRecord, string)](#getstringidatarecord-string-method) | string | Gets the string value of the specified field. |
| public | [GetTuple&lt;T1, T2, T3&gt;(IDataRecord, int, int, int)](#gettuplet1-t2-t3idatarecord-int-int-int-method) | (T1, T2, T3) | Gets the values of multiple specified fields. |
| public | [GetTuple&lt;T1, T2, T3&gt;(IDataRecord, int[])](#gettuplet1-t2-t3idatarecord-int-method) | (T1, T2, T3) | Gets the values of multiple specified fields. |
| public | [GetTuple&lt;T1, T2, T3&gt;(IDataRecord, string, string, string)](#gettuplet1-t2-t3idatarecord-string-string-string-method) | (T1, T2, T3) | Gets the values of multiple specified fields. |
| public | [GetTuple&lt;T1, T2, T3&gt;(IDataRecord, string[])](#gettuplet1-t2-t3idatarecord-string-method) | (T1, T2, T3) | Gets the values of multiple specified fields. |
| public | [GetTuple&lt;T1, T2&gt;(IDataRecord, int, int)](#gettuplet1-t2idatarecord-int-int-method) | (T1, T2) | Gets the values of multiple specified fields. |
| public | [GetTuple&lt;T1, T2&gt;(IDataRecord, int[])](#gettuplet1-t2idatarecord-int-method) | (T1, T2) | Gets the values of multiple specified fields. |
| public | [GetTuple&lt;T1, T2&gt;(IDataRecord, string, string)](#gettuplet1-t2idatarecord-string-string-method) | (T1, T2) | Gets the values of multiple specified fields. |
| public | [GetTuple&lt;T1, T2&gt;(IDataRecord, string[])](#gettuplet1-t2idatarecord-string-method) | (T1, T2) | Gets the values of multiple specified fields. |
| public | [GetValue(IDataRecord, string)](#getvalueidatarecord-string-method) | object | Return the value of the specified field. |
| public | [IsDBNull(IDataRecord, string)](#isdbnullidatarecord-string-method) | bool | Return whether the specified field is set to null. |
---
### Equals(object) Method

Inherited from  System.Object .
```c#
public virtual bool Equals
(
	object obj
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| obj | object |  |  |
#### Return type


[Go to methods](#Methods)

---
### Finalize Method

Inherited from  System.Object .
```c#
protected virtual void Finalize()
```

[Go to methods](#Methods)

---
### GetBoolean(IDataRecord, string) Method

Gets the value of the specified column as a Boolean.
```c#
public static bool GetBoolean
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetByte(IDataRecord, string) Method

Gets the 8-bit unsigned integer value of the specified column.
```c#
public static byte GetByte
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetBytes(IDataRecord, string, long, byte[], int, int) Method

Reads a stream of bytes from the specified column offset into the buffer as an array, starting at the given buffer offset.
```c#
public static long GetBytes
(
	this IDataRecord record
	, string fieldName
	, long fieldOffset
	, byte[] buffer
	, int bufferoffset
	, int length
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
| fieldOffset | long |  |  |
| buffer | byte[] |  |  |
| bufferoffset | int |  |  |
| length | int |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetChar(IDataRecord, string) Method

Gets the character value of the specified column.
```c#
public static char GetChar
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetChars(IDataRecord, string, long, char[], int, int) Method

Reads a stream of characters from the specified column offset into the buffer as an array, starting at the given buffer offset.
```c#
public static long GetChars
(
	this IDataRecord record
	, string fieldName
	, long fieldoffset
	, char[] buffer
	, int bufferoffset
	, int length
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
| fieldoffset | long |  |  |
| buffer | char[] |  |  |
| bufferoffset | int |  |  |
| length | int |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetData(IDataRecord, string) Method

Returns an System.Data.IDataReader for the specified column ordinal.
```c#
public static IDataReader GetData
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetDateTime(IDataRecord, string) Method

Gets the date and time data value of the specified field.
```c#
public static DateTime GetDateTime
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetDecimal(IDataRecord, string) Method

Gets the fixed-position numeric value of the specified field.
```c#
public static decimal GetDecimal
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetDouble(IDataRecord, string) Method

Gets the double-precision floating point number of the specified field.
```c#
public static double GetDouble
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetFloat(IDataRecord, string) Method

Gets the single-precision floating point number of the specified field.
```c#
public static float GetFloat
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetGuid(IDataRecord, string) Method

Returns the GUID value of the specified field.
```c#
public static Guid GetGuid
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetHashCode Method

Inherited from  System.Object .
```c#
public virtual int GetHashCode()
```
#### Return type


[Go to methods](#Methods)

---
### GetInt16(IDataRecord, string) Method

Gets the 16-bit signed integer value of the specified field.
```c#
public static short GetInt16
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetInt32(IDataRecord, string) Method

Gets the 32-bit signed integer value of the specified field.
```c#
public static int GetInt32
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetInt64(IDataRecord, string) Method

Gets the 64-bit signed integer value of the specified field.
```c#
public static long GetInt64
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, int, int, int, int, int, int, int, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
	, int fieldIndex4
	, int fieldIndex5
	, int fieldIndex6
	, int fieldIndex7
	, int fieldIndex8
	, int fieldIndex9
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
where T9 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
| T9 | The value type of the ninth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
| fieldIndex4 | int |  | The index of the fourth field. |
| fieldIndex5 | int |  | The index of the fifth field. |
| fieldIndex6 | int |  | The index of the sixth field. |
| fieldIndex7 | int |  | The index of the seventh field. |
| fieldIndex8 | int |  | The index of the eighth field. |
| fieldIndex9 | int |  | The index of the ninth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
where T9 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
| T9 | The value type of the ninth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, string, string, string, string, string, string, string, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, string fieldName8
	, string fieldName9
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
where T9 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
| T9 | The value type of the ninth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| fieldName8 | string |  | The name of the eighth field. |
| fieldName9 | string |  | The name of the ninth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?)) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
where T9 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
| T9 | The value type of the ninth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, int, int, int, int, int, int, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
	, int fieldIndex4
	, int fieldIndex5
	, int fieldIndex6
	, int fieldIndex7
	, int fieldIndex8
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
| fieldIndex4 | int |  | The index of the fourth field. |
| fieldIndex5 | int |  | The index of the fifth field. |
| fieldIndex6 | int |  | The index of the sixth field. |
| fieldIndex7 | int |  | The index of the seventh field. |
| fieldIndex8 | int |  | The index of the eighth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, string, string, string, string, string, string, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, string fieldName8
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| fieldName8 | string |  | The name of the eighth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, int, int, int, int, int, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
	, int fieldIndex4
	, int fieldIndex5
	, int fieldIndex6
	, int fieldIndex7
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
| fieldIndex4 | int |  | The index of the fourth field. |
| fieldIndex5 | int |  | The index of the fifth field. |
| fieldIndex6 | int |  | The index of the sixth field. |
| fieldIndex7 | int |  | The index of the seventh field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, string, string, string, string, string, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, int, int, int, int, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
	, int fieldIndex4
	, int fieldIndex5
	, int fieldIndex6
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
| fieldIndex4 | int |  | The index of the fourth field. |
| fieldIndex5 | int |  | The index of the fifth field. |
| fieldIndex6 | int |  | The index of the sixth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, string, string, string, string, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5, T6&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, int, int, int, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
	, int fieldIndex4
	, int fieldIndex5
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
| fieldIndex4 | int |  | The index of the fourth field. |
| fieldIndex5 | int |  | The index of the fifth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, string, string, string, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4, T5&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, int, int, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
	, int fieldIndex4
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
| fieldIndex4 | int |  | The index of the fourth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, string, string, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3, T4&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, int, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, string, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2, T3&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, int, int) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?) GetRawTuple<T1, T2>
(
	this IDataGenerationRecord record
	, int fieldIndex1
	, int fieldIndex2
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, int[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?) GetRawTuple<T1, T2>
(
	this IDataGenerationRecord record
	, int[] fieldIndexes
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, string, string) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?) GetRawTuple<T1, T2>
(
	this IDataGenerationRecord record
	, string fieldName1
	, string fieldName2
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The index of the second field. |
#### Return type


[Go to methods](#Methods)

---
### GetRawTuple&lt;T1, T2&gt;(IDataGenerationRecord, string[]) Method

GetRaws the values of multiple specified fields.
```c#
public static (T1?, T2?) GetRawTuple<T1, T2>
(
	this IDataGenerationRecord record
	, string[] fieldNames
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetRawValue&lt;T&gt;(IDataGenerationRecord, string) Method

Gets the generated raw value of the specified field.
```c#
public static T? GetRawValue<T>
(
	this IDataGenerationRecord record
	, string fieldName
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
| record | [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetString(IDataRecord, string) Method

Gets the string value of the specified field.
```c#
public static string GetString
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2, T3&gt;(IDataRecord, int, int, int) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2, T3) GetTuple<T1, T2, T3>
(
	this IDataRecord record
	, int fieldIndex1
	, int fieldIndex2
	, int fieldIndex3
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
| T3 | The value type of the third field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
| fieldIndex3 | int |  | The index of the third field. |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2, T3&gt;(IDataRecord, int[]) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2, T3) GetTuple<T1, T2, T3>
(
	this IDataRecord record
	, int[] fieldIndexes
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
| T3 | The value type of the third field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2, T3&gt;(IDataRecord, string, string, string) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2, T3) GetTuple<T1, T2, T3>
(
	this IDataRecord record
	, string fieldName1
	, string fieldName2
	, string fieldName3
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
| T3 | The value type of the third field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2, T3&gt;(IDataRecord, string[]) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2, T3) GetTuple<T1, T2, T3>
(
	this IDataRecord record
	, string[] fieldNames
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
| T3 | The value type of the third field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2&gt;(IDataRecord, int, int) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2) GetTuple<T1, T2>
(
	this IDataRecord record
	, int fieldIndex1
	, int fieldIndex2
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldIndex1 | int |  | The index of the first field. |
| fieldIndex2 | int |  | The index of the second field. |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2&gt;(IDataRecord, int[]) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2) GetTuple<T1, T2>
(
	this IDataRecord record
	, int[] fieldIndexes
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldIndexes | int[] |  | The indexes of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2&gt;(IDataRecord, string, string) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2) GetTuple<T1, T2>
(
	this IDataRecord record
	, string fieldName1
	, string fieldName2
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The index of the second field. |
#### Return type


[Go to methods](#Methods)

---
### GetTuple&lt;T1, T2&gt;(IDataRecord, string[]) Method

Gets the values of multiple specified fields.
```c#
public static (T1, T2) GetTuple<T1, T2>
(
	this IDataRecord record
	, string[] fieldNames
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. |  |
| T2 | The value type of the second field. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldNames | string[] |  | The names of the fields. |
#### Return type


[Go to methods](#Methods)

---
### GetType Method

Inherited from  System.Object .
```c#
public Type GetType()
```
#### Return type


[Go to methods](#Methods)

---
### GetValue(IDataRecord, string) Method

Return the value of the specified field.
```c#
public static object GetValue
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### IsDBNull(IDataRecord, string) Method

Return whether the specified field is set to null.
```c#
public static bool IsDBNull
(
	this IDataRecord record
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| record | IDataRecord |  |  |
| fieldName | string |  |  |
#### Return type


[Go to methods](#Methods)

---
### MemberwiseClone Method

Inherited from  System.Object .
```c#
protected object MemberwiseClone()
```
#### Return type


[Go to methods](#Methods)

---
### ToString Method

Inherited from  System.Object .
```c#
public virtual string ToString()
```
#### Return type


[Go to methods](#Methods)



