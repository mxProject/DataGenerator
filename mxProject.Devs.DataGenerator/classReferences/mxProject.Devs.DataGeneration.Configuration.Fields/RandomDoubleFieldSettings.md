


# RandomDoubleFieldSettings Class



Settings for a field that enumerates the random System.Double values.






## Inheritance tree
* mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase&lt;double&gt;
* mxProject.Devs.DataGeneration.Configuration.Fields.RandomFieldSettingsBase&lt;double&gt;
* [mxProject.Devs.DataGeneration.Configuration.DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md)
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
public RandomDoubleFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| public | [MaximumValue](#maximumvalue-property) | double? | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} . |
| public | [MinimumValue](#minimumvalue-property) | double? | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} . |
| public | [NullProbability](#nullprobability-property) | double | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomFieldSettingsBase{System.Double} . |
| public | [SelectorExpression](#selectorexpression-property) | string | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} . |
---
### FieldName Property

Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) .
```c#
public string FieldName { get; set; }
```

[Go to properties](#Properties)

---
### MaximumValue Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} .
```c#
public double? MaximumValue { get; set; }
```

[Go to properties](#Properties)

---
### MinimumValue Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} .
```c#
public double? MinimumValue { get; set; }
```

[Go to properties](#Properties)

---
### NullProbability Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomFieldSettingsBase{System.Double} .
```c#
public double NullProbability { get; set; }
```

[Go to properties](#Properties)

---
### SelectorExpression Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} .
```c#
public string SelectorExpression { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomFieldSettingsBase{System.Double} . |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [RandomDoubleFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/RandomDoubleFieldSettings.md) . |
| protected | [CreateSelectorAsync(DataGeneratorContext)](#createselectorasyncdatageneratorcontext-method) | Task&lt;Func&lt;double, double&gt;&gt; | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomFieldSettingsBase{System.Double} .
```c#
protected virtual void Assert()
```

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

Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [RandomDoubleFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/RandomDoubleFieldSettings.md) .
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
### CreateSelectorAsync(DataGeneratorContext) Method

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.RandomNumericFieldSettingsBase{System.Double} .
```c#
protected Task<Func<double, double>> CreateSelectorAsync
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



