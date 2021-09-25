


# IDataGeneratorTupleFieldEnumeration Interface



Provides the functionality needed for fields that generate tuples of multiple values.






## Inheritance tree
## Implemented interfaces
* System.IDisposable

[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldCount](#fieldcount-property) | int | Gets the field count. |
---
### FieldCount Property

Gets the field count.
```c#
int FieldCount { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [GenerateNext](#generatenext-method) | bool | Generates the next new value. |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Gets the field name. |
| public | [GetRawValue(int)](#getrawvalueint-method) | object | Gets the generated value. |
| public | [GetValue(int)](#getvalueint-method) | object | Gets the generated value. The value is converted to a well-known type. |
| public | [GetValues(Memory&lt;object&gt;)](#getvaluesmemoryobject-method) | void | Populates a memory with the generated values. |
| public | [GetValues(object[])](#getvaluesobject-method) | void | Populates an array of objects with the generated values. |
| public | [GetValues(Span&lt;object&gt;)](#getvaluesspanobject-method) | void | Populates a span with the generated values. |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Gets the value type. |
| public | [IsNullValue(int)](#isnullvalueint-method) | bool | Gets a value that indicates whether the generated value is null. |
| public | [Reset](#reset-method) | void | Resets the status of data generation processing. |
---
### GenerateNext Method

Generates the next new value.
```c#
bool GenerateNext()
```
#### Return type


[Go to methods](#Methods)

---
### GetFieldName(int) Method

Gets the field name.
```c#
string GetFieldName
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### GetRawValue(int) Method

Gets the generated value.
```c#
object GetRawValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### GetValue(int) Method

Gets the generated value. The value is converted to a well-known type.
```c#
object GetValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### GetValues(Memory&lt;object&gt;) Method

Populates a memory with the generated values.
```c#
void GetValues
(
	Memory<object> values
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | Memory&lt;object&gt; |  |  |

[Go to methods](#Methods)

---
### GetValues(object[]) Method

Populates an array of objects with the generated values.
```c#
void GetValues
(
	object[] values
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | object[] |  |  |

[Go to methods](#Methods)

---
### GetValues(Span&lt;object&gt;) Method

Populates a span with the generated values.
```c#
void GetValues
(
	Span<object> values
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | Span&lt;object&gt; |  |  |

[Go to methods](#Methods)

---
### GetValueType(int) Method

Gets the value type.
```c#
Type GetValueType
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### IsNullValue(int) Method

Gets a value that indicates whether the generated value is null.
```c#
bool IsNullValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### Reset Method

Resets the status of data generation processing.
```c#
void Reset()
```

[Go to methods](#Methods)



