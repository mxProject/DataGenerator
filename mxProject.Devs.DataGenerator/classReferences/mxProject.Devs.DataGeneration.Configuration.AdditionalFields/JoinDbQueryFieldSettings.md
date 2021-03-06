


# JoinDbQueryFieldSettings Class



A setting for a field that returns the values read from a database query.






## Inheritance tree
* [mxProject.Devs.DataGeneration.Configuration.DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md)
* object
## Implemented interfaces
* System.ICloneable

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor](#ctor-constructor) | Creates a new instance. |
---
### .ctor Constructor

Creates a new instance.
```c#
public JoinDbQueryFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [AdditionalFields](#additionalfields-property) | DataGeneratorFieldInfo[] | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| public | [AdditionalKeyFieldNames](#additionalkeyfieldnames-property) | string[] | Gets or sets the additional key field names. |
| public | [AdditionalValueFieldNames](#additionalvaluefieldnames-property) | string[] | Gets or sets the additional value field names. |
| public | [DbQuerySettings](#dbquerysettings-property) | [DbQuerySettings](../mxProject.Devs.DataGeneration.Configuration/DbQuerySettings.md) | Gets or sets the database query settings. |
| public | [ReferenceKeyFieldNames](#referencekeyfieldnames-property) | string[] | Gets or sets the reference key field names. |
---
### AdditionalFields Property

Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) .
```c#
public DataGeneratorFieldInfo[] AdditionalFields { get; set; }
```

[Go to properties](#Properties)

---
### AdditionalKeyFieldNames Property

Gets or sets the additional key field names.
```c#
public string[] AdditionalKeyFieldNames { get; set; }
```

[Go to properties](#Properties)

---
### AdditionalValueFieldNames Property

Gets or sets the additional value field names.
```c#
public string[] AdditionalValueFieldNames { get; set; }
```

[Go to properties](#Properties)

---
### DbQuerySettings Property

Gets or sets the database query settings.
```c#
public DbQuerySettings DbQuerySettings { get; set; }
```

[Go to properties](#Properties)

---
### ReferenceKeyFieldNames Property

Gets or sets the reference key field names.
```c#
public string[] ReferenceKeyFieldNames { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | If the settings for this instance are invalid, an exception will be thrown.Inherited from  [JoinDbQueryFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinDbQueryFieldSettings.md) . |
| public | [Clone](#clone-method) | object |  |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) | Creates an instance of [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) interface.Inherited from  [JoinDbQueryFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinDbQueryFieldSettings.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetAdditionalFieldNames](#getadditionalfieldnames-method) | string[] |  |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

If the settings for this instance are invalid, an exception will be thrown.Inherited from  [JoinDbQueryFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinDbQueryFieldSettings.md) .
```c#
protected virtual void Assert()
```

[Go to methods](#Methods)

---
### Clone Method


```c#
public virtual object Clone()
```
#### Return type


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

Creates an instance of [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) interface.Inherited from  [JoinDbQueryFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinDbQueryFieldSettings.md) .
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


```c#
public virtual string[] GetAdditionalFieldNames()
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



