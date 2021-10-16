


# JoinDbQueryFieldSettings Class










## Inheritance tree
* [mxProject.Devs.DataGeneration.Configuration.DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md)
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
public JoinDbQueryFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [AdditionalFields](#additionalfields-property) | DataGeneratorFieldInfo[] | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| public | [AdditionalKeyFieldNames](#additionalkeyfieldnames-property) | string[] |  |
| public | [AdditionalValueFieldNames](#additionalvaluefieldnames-property) | string[] |  |
| public | [DbQuerySettings](#dbquerysettings-property) | DbQuerySettings |  |
| public | [ReferenceKeyFieldNames](#referencekeyfieldnames-property) | string[] |  |
---
### AdditionalFields Property

Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) .
```c#
public DataGeneratorFieldInfo[] AdditionalFields { get; set; }
```

[Go to properties](#Properties)

---
### AdditionalKeyFieldNames Property


```c#
public string[] AdditionalKeyFieldNames { get; set; }
```

[Go to properties](#Properties)

---
### AdditionalValueFieldNames Property


```c#
public string[] AdditionalValueFieldNames { get; set; }
```

[Go to properties](#Properties)

---
### DbQuerySettings Property


```c#
public DbQuerySettings DbQuerySettings { get; set; }
```

[Go to properties](#Properties)

---
### ReferenceKeyFieldNames Property


```c#
public string[] ReferenceKeyFieldNames { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void |  |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) |  |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetAdditionalFieldNames](#getadditionalfieldnames-method) | string[] | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
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

Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) .
```c#
public IDataGeneratorAdditionalTupleField CreateField
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
protected virtual IDataGeneratorAdditionalTupleField CreateFieldCore
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
### GetAdditionalFieldNames Method

Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) .
```c#
public string[] GetAdditionalFieldNames()
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



