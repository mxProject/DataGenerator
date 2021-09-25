


# IDataGeneratorAdditionalTupleField Interface



Provides the required functionality for an additional tuple field.






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
| public | [CreateValueGetterAsync](#createvaluegetterasync-method) | ValueTask&lt;Func&lt;IDataGenerationRecord, object[]&gt;&gt; | Creates a method to get the value of the field. |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Gets the field name. |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Gets the value type. |
---
### CreateValueGetterAsync Method

Creates a method to get the value of the field.
```c#
ValueTask<Func<IDataGenerationRecord, object[]>> CreateValueGetterAsync()
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



