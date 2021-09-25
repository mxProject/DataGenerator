


# IDataGeneratorTupleField Interface



Provides the functionality needed for fields that generate tuples of multiple values.






## Inheritance tree

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
| public | [CreateEnumerationAsync(int)](#createenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&gt; | Creates an enumeration. |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Gets the field name. |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Gets the value type. |
| public | [MayBeNull(int)](#maybenullint-method) | bool | Gets a value that indicates whether it may return a null value. |
---
### CreateEnumerationAsync(int) Method

Creates an enumeration.
```c#
ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync
(
	int generationCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generationCount | int |  | Number of values to generate. |
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
### MayBeNull(int) Method

Gets a value that indicates whether it may return a null value.
```c#
bool MayBeNull
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



