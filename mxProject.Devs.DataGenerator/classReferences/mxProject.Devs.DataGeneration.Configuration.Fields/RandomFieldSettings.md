


# RandomFieldSettings Class



Settings for a field that enumerates the random values.






## Inheritance tree
* [mxProject.Devs.DataGeneration.Configuration.DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md)
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
| public | [.ctor](#ctor-constructor) | Create a new instance. |
---
### .ctor Constructor

Create a new instance.
```c#
public RandomFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| public | [MaximumValue](#maximumvalue-property) | string | Gets or sets the maximum value. |
| public | [MinimumValue](#minimumvalue-property) | string | Gets or sets the minimum value. |
| public | [NullProbability](#nullprobability-property) | double | Gets or sets probability of returning null. (between 0 and 1.0) |
| public | [SelectorExpression](#selectorexpression-property) | string | Gets or sets the expression text of the selector. ex) "x =&gt; System.Round(x, 1)" |
| public | [ValueTypeName](#valuetypename-property) | string | Gets or sets the value type name. |
---
### FieldName Property

Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) .
```c#
public string FieldName { get; set; }
```

[Go to properties](#Properties)

---
### MaximumValue Property

Gets or sets the maximum value.
```c#
public string MaximumValue { get; set; }
```

[Go to properties](#Properties)

---
### MinimumValue Property

Gets or sets the minimum value.
```c#
public string MinimumValue { get; set; }
```

[Go to properties](#Properties)

---
### NullProbability Property

Gets or sets probability of returning null. (between 0 and 1.0)
```c#
public double NullProbability { get; set; }
```

[Go to properties](#Properties)

---
### SelectorExpression Property

Gets or sets the expression text of the selector. ex) "x =&gt; System.Round(x, 1)"
```c#
public string SelectorExpression { get; set; }
```

[Go to properties](#Properties)

---
### ValueTypeName Property

Gets or sets the value type name.
```c#
public string ValueTypeName { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | If the settings for this instance are invalid, an exception will be thrown.Inherited from  [RandomFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/RandomFieldSettings.md) . |
| public | [Clone](#clone-method) | object | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [RandomFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/RandomFieldSettings.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

If the settings for this instance are invalid, an exception will be thrown.Inherited from  [RandomFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/RandomFieldSettings.md) .
```c#
protected virtual void Assert()
```

[Go to methods](#Methods)

---
### Clone Method

Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) .
```c#
public virtual object Clone()
```
#### Return type


[Go to methods](#Methods)

---
### CreateField(DataGeneratorContext) Method

Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) .
```c#
public IDataGeneratorField CreateField
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

Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [RandomFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/RandomFieldSettings.md) .
```c#
protected virtual IDataGeneratorField CreateFieldCore
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



