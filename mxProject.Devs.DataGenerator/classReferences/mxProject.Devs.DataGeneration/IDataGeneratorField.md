


# IDataGeneratorField Interface



Provides the required functionality for a data generator field.






## Inheritance tree

[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Gets the field name. |
| public | [IsFixedLength](#isfixedlength-property) | bool | Gets a value that indicates whether the number of values to generate is fixed. |
| public | [MayBeNull](#maybenull-property) | bool | Gets a value that indicates whether it may return a null value. |
| public | [ValueType](#valuetype-property) | Type | Gets the value type. |
---
### FieldName Property

Gets the field name.
```c#
string FieldName { get; }
```

[Go to properties](#Properties)

---
### IsFixedLength Property

Gets a value that indicates whether the number of values to generate is fixed.
```c#
bool IsFixedLength { get; }
```

[Go to properties](#Properties)

---
### MayBeNull Property

Gets a value that indicates whether it may return a null value.
```c#
bool MayBeNull { get; }
```

[Go to properties](#Properties)

---
### ValueType Property

Gets the value type.
```c#
Type ValueType { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateEnumerationAsync(int)](#createenumerationasyncint-method) | ValueTask&lt;IDataGeneratorFieldEnumeration&gt; | Creates an enumeration. |
| public | [GetEnumerateValueCount](#getenumeratevaluecount-method) | int? | Gets the number of values to generate. |
---
### CreateEnumerationAsync(int) Method

Creates an enumeration.
```c#
ValueTask<IDataGeneratorFieldEnumeration> CreateEnumerationAsync
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
### GetEnumerateValueCount Method

Gets the number of values to generate.
```c#
int? GetEnumerateValueCount()
```
#### Return type
Returns null if the number of values to generate is not fixed.

[Go to methods](#Methods)



