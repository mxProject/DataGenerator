


# DataGeneratorAdditionalTupleField Class



Field that returns values generated based on the value generated.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md)

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(IDataGeneratorFieldInfo[], Func&lt;IDataGenerationRecord, object[]&gt;)](#ctoridatageneratorfieldinfo-funcidatagenerationrecord-object-constructor) | Create a new instance. |
| public | [.ctor(IDataGeneratorFieldInfo[], ValueTask&lt;Func&lt;IDataGenerationRecord, object[]&gt;&gt;)](#ctoridatageneratorfieldinfo-valuetaskfuncidatagenerationrecord-object-constructor) | Create a new instance. |
---
### .ctor(IDataGeneratorFieldInfo[], Func&lt;IDataGenerationRecord, object[]&gt;) Constructor

Create a new instance.
```c#
public DataGeneratorAdditionalTupleField(
	IDataGeneratorFieldInfo[] fields
	, Func<IDataGenerationRecord, object[]> valueGetter
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fields | IDataGeneratorFieldInfo[] | The fields. |
| valueGetter | Func&lt;IDataGenerationRecord, object[]&gt; | The method to get the value of the field. |

[Go to constructors](#Constructors)

---
### .ctor(IDataGeneratorFieldInfo[], ValueTask&lt;Func&lt;IDataGenerationRecord, object[]&gt;&gt;) Constructor

Create a new instance.
```c#
public DataGeneratorAdditionalTupleField(
	IDataGeneratorFieldInfo[] fields
	, ValueTask<Func<IDataGenerationRecord, object[]>> valueGetterCreator
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fields | IDataGeneratorFieldInfo[] | The fields. |
| valueGetterCreator | ValueTask&lt;Func&lt;IDataGenerationRecord, object[]&gt;&gt; | The task that return a method to get the value of the field. |

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
| public | [CreateValueGetterAsync](#createvaluegetterasync-method) | ValueTask&lt;Func&lt;IDataGenerationRecord, object[]&gt;&gt; | Inherited from  [DataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalTupleField.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Inherited from  [DataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalTupleField.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Inherited from  [DataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalTupleField.md) . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateValueGetterAsync Method

Inherited from  [DataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalTupleField.md) .
```c#
public virtual ValueTask<Func<IDataGenerationRecord, object[]>> CreateValueGetterAsync()
```
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

Inherited from  [DataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalTupleField.md) .
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

Inherited from  [DataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalTupleField.md) .
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



