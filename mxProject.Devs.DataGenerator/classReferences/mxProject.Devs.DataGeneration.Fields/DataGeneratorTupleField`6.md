


# DataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6&gt; Class



Field that generates a tuple of multiple values.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |

## Inheritance tree
* [mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md)
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md)
* mxProject.Devs.DataGeneration.IDataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6&gt;

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, bool, string, bool, string, bool, string, bool, string, bool, string, bool, TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6&gt;)](#ctorstring-bool-string-bool-string-bool-string-bool-string-bool-string-bool-tupleenumerationcreatort1-t2-t3-t4-t5-t6-constructor) | Creates a new instance. |
---
### .ctor(string, bool, string, bool, string, bool, string, bool, string, bool, string, bool, TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6&gt;) Constructor

Creates a new instance.
```c#
public DataGeneratorTupleField(
	string fieldName1
	, bool mayBeNull1
	, string fieldName2
	, bool mayBeNull2
	, string fieldName3
	, bool mayBeNull3
	, string fieldName4
	, bool mayBeNull4
	, string fieldName5
	, bool mayBeNull5
	, string fieldName6
	, bool mayBeNull6
	, TupleEnumerationCreator<T1, T2, T3, T4, T5, T6> enumerationCreator
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName1 | string | The name of the first field. |
| mayBeNull1 | bool | A value that indicates whether the first field may return a null value. |
| fieldName2 | string | The name of the second field. |
| mayBeNull2 | bool | A value that indicates whether the second field may return a null value. |
| fieldName3 | string | The name of the third field. |
| mayBeNull3 | bool | A value that indicates whether the third field may return a null value. |
| fieldName4 | string | The name of the fourth field. |
| mayBeNull4 | bool | A value that indicates whether the fourth field may return a null value. |
| fieldName5 | string | The name of the fifth field. |
| mayBeNull5 | bool | A value that indicates whether the fifth field may return a null value. |
| fieldName6 | string | The name of the sixth field. |
| mayBeNull6 | bool | A value that indicates whether the sixth field may return a null value. |
| enumerationCreator | TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6&gt; | The method to generate an enumeration. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldCount](#fieldcount-property) | int | Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) . |
---
### FieldCount Property

Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) .
```c#
public virtual int FieldCount { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateEnumerationAsync(int)](#createenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&gt; | Inherited from  [DataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`6.md) . |
| public | [CreateTypedEnumerationAsync(int)](#createtypedenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4, T5, T6&gt;&gt; | Inherited from  [DataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`6.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) . |
| public | [MayBeNull(int)](#maybenullint-method) | bool | Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateEnumerationAsync(int) Method

Inherited from  [DataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`6.md) .
```c#
public virtual ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync
(
	int generateCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  |  |
#### Return type


[Go to methods](#Methods)

---
### CreateTypedEnumerationAsync(int) Method

Inherited from  [DataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`6.md) .
```c#
public virtual ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6>> CreateTypedEnumerationAsync
(
	int generateCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  |  |
#### Return type


[Go to methods](#Methods)

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
### GetFieldName(int) Method

Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) .
```c#
public virtual string GetFieldName
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  |  |
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
### GetType Method

Inherited from  System.Object .
```c#
public Type GetType()
```
#### Return type


[Go to methods](#Methods)

---
### GetValueType(int) Method

Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) .
```c#
public virtual Type GetValueType
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  |  |
#### Return type


[Go to methods](#Methods)

---
### MayBeNull(int) Method

Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) .
```c#
public virtual bool MayBeNull
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  |  |
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



