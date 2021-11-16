


# DataGeneratorSettings Class



DataGenerator settings.






## Inheritance tree
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
| public | [.ctor](#ctor-constructor) |  |
---
### .ctor Constructor


```c#
public DataGeneratorSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [AdditionalFields](#additionalfields-property) | DataGeneratorAdditionalFieldSettings[] | Gets or sets the additional field settings. |
| public | [AdditionalTupleFields](#additionaltuplefields-property) | DataGeneratorAdditionalTupleFieldSettings[] | Gets or sets the additional tuple field settings. |
| public | [Fields](#fields-property) | DataGeneratorFieldSettings[] | Gets or sets the field settings. |
| public | [TupleFields](#tuplefields-property) | DataGeneratorTupleFieldSettings[] | Gets or sets the tuple field settings. |
---
### AdditionalFields Property

Gets or sets the additional field settings.
```c#
public DataGeneratorAdditionalFieldSettings[] AdditionalFields { get; set; }
```

[Go to properties](#Properties)

---
### AdditionalTupleFields Property

Gets or sets the additional tuple field settings.
```c#
public DataGeneratorAdditionalTupleFieldSettings[] AdditionalTupleFields { get; set; }
```

[Go to properties](#Properties)

---
### Fields Property

Gets or sets the field settings.
```c#
public DataGeneratorFieldSettings[] Fields { get; set; }
```

[Go to properties](#Properties)

---
### TupleFields Property

Gets or sets the tuple field settings.
```c#
public DataGeneratorTupleFieldSettings[] TupleFields { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Clone](#clone-method) | object |  |
| public | [CreateBuilder(DataGeneratorContext)](#createbuilderdatageneratorcontext-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Creates an instance of [DataGenerator](../mxProject.Devs.DataGeneration/DataGenerator.md) class. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Clone Method


```c#
public virtual object Clone()
```
#### Return type


[Go to methods](#Methods)

---
### CreateBuilder(DataGeneratorContext) Method

Creates an instance of [DataGenerator](../mxProject.Devs.DataGeneration/DataGenerator.md) class.
```c#
public DataGeneratorBuilder CreateBuilder
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



