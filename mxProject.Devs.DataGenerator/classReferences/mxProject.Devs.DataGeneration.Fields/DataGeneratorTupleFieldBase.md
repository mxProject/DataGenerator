


# DataGeneratorTupleFieldBase Class



Basic implement of a field that generates a tuple of multiple values.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md)

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| protected | [.ctor(string[], Type[], bool[])](#ctorstring-type-bool-constructor) | Creates a new instance. |
---
### .ctor(string[], Type[], bool[]) Constructor

Creates a new instance.
```c#
protected DataGeneratorTupleFieldBase(
	string[] fieldNames
	, Type[] valueTypes
	, bool[] mayBeNull
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldNames | string[] | The names of the fields. |
| valueTypes | Type[] | The value types of the fields. |
| mayBeNull | bool[] | A value that indicates whether the fields may return a null value. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldCount](#fieldcount-property) | int | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
---
### FieldCount Property

( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. )
```c#
public virtual int FieldCount { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateEnumerationAsync(int)](#createenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&gt; | Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) . |
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

Inherited from  [DataGeneratorTupleFieldBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldBase.md) .
```c#
public abstract ValueTask<IDataGeneratorTupleFieldEnumeration> CreateEnumerationAsync
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



