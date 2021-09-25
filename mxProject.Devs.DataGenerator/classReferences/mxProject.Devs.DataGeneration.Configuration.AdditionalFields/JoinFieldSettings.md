


# JoinFieldSettings Class



A setting for a field that returns the value of an expression.






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
| public | [.ctor](#ctor-constructor) | Creates a new instance. |
---
### .ctor Constructor

Creates a new instance.
```c#
public JoinFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [AdditionalFields](#additionalfields-property) | DataGeneratorFieldInfo[] | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| public | [AdditionalValues](#additionalvalues-property) | Dictionary&lt;string[], string[]&gt; | Gets or sets the values of the additional fields. |
| public | [KeyFields](#keyfields-property) | DataGeneratorFieldInfo[] | Gets or sets the key field information." |
---
### AdditionalFields Property

Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) .
```c#
public DataGeneratorFieldInfo[] AdditionalFields { get; set; }
```

[Go to properties](#Properties)

---
### AdditionalValues Property

Gets or sets the values of the additional fields.
```c#
public Dictionary<string[], string[]> AdditionalValues { get; set; }
```

[Go to properties](#Properties)

---
### KeyFields Property

Gets or sets the key field information."
```c#
public DataGeneratorFieldInfo[] KeyFields { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | If the settings for this instance are invalid, an exception will be thrown.Inherited from  [JoinFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinFieldSettings.md) . |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) | Creates an instance of [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) interface.Inherited from  [JoinFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinFieldSettings.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetAdditionalFieldNames](#getadditionalfieldnames-method) | string[] | Inherited from  [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

If the settings for this instance are invalid, an exception will be thrown.Inherited from  [JoinFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinFieldSettings.md) .
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

Creates an instance of [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) interface.Inherited from  [JoinFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/JoinFieldSettings.md) .
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



