


# DataGeneratorTupleField&lt;T1, T2&gt; Class



Field that generates a tuple of multiple values.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |

## Inheritance tree
* [mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md)
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md)
* mxProject.Devs.DataGeneration.IDataGeneratorTupleField&lt;T1, T2&gt;

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, bool, string, bool, TupleEnumerationCreator&lt;T1, T2&gt;)](#ctorstring-bool-string-bool-tupleenumerationcreatort1-t2-constructor) | Creates a new instance. |
---
### .ctor(string, bool, string, bool, TupleEnumerationCreator&lt;T1, T2&gt;) Constructor

Creates a new instance.
```c#
public DataGeneratorTupleField(
	string fieldName1
	, bool mayBeNull1
	, string fieldName2
	, bool mayBeNull2
	, TupleEnumerationCreator<T1, T2> enumerationCreator
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName1 | string | The name of the first field. |
| mayBeNull1 | bool | A value that indicates whether the first field may return a null value. |
| fieldName2 | string | The name of the second field. |
| mayBeNull2 | bool | A value that indicates whether the second field may return a null value. |
| enumerationCreator | TupleEnumerationCreator&lt;T1, T2&gt; | The method to generate an enumeration. |

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
| public | [CreateEnumerationAsync(int)](#createenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&gt; | Inherited from  [DataGeneratorTupleField&lt;T1, T2&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`2.md) . |
| public | [CreateTypedEnumerationAsync(int)](#createtypedenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&lt;T1, T2&gt;&gt; | Inherited from  [DataGeneratorTupleField&lt;T1, T2&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`2.md) . |
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

Inherited from  [DataGeneratorTupleField&lt;T1, T2&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`2.md) .
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

Inherited from  [DataGeneratorTupleField&lt;T1, T2&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleField`2.md) .
```c#
public virtual ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2>> CreateTypedEnumerationAsync
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



