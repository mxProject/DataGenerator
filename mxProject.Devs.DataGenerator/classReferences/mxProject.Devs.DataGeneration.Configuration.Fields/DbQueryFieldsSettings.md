


# DbQueryFieldsSettings Class










## Inheritance tree
* [mxProject.Devs.DataGeneration.Configuration.DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md)
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor](#ctor-constructor) |  |
---
### .ctor Constructor


```c#
public DbQueryFieldsSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [DbQuerySettings](#dbquerysettings-property) | DbQuerySettings |  |
| public | [FieldNames](#fieldnames-property) | string[] |  |
---
### DbQuerySettings Property


```c#
public DbQuerySettings DbQuerySettings { get; set; }
```

[Go to properties](#Properties)

---
### FieldNames Property


```c#
public string[] FieldNames { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void |  |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Inherited from  [DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) |  |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetFieldCount](#getfieldcount-method) | int |  |
| public | [GetFieldNames](#getfieldnames-method) | string[] |  |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method


```c#
protected virtual void Assert()
```

[Go to methods](#Methods)

---
### CreateField(DataGeneratorContext) Method

Inherited from  [DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md) .
```c#
public IDataGeneratorTupleField CreateField
(
	DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  |  |
#### Return type


[Go to methods](#Methods)

---
### CreateFieldCore(DataGeneratorContext) Method


```c#
protected virtual IDataGeneratorTupleField CreateFieldCore
(
	DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  |  |
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
### GetFieldCount Method


```c#
public virtual int GetFieldCount()
```
#### Return type


[Go to methods](#Methods)

---
### GetFieldNames Method


```c#
public virtual string[] GetFieldNames()
```
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



