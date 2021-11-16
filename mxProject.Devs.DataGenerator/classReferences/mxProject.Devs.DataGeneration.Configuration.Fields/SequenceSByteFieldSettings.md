


# SequenceSByteFieldSettings Class



Settings for a field that enumerates the sequential System.SByte values.






## Inheritance tree
* mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase&lt;sbyte, sbyte&gt;
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
| public | [.ctor](#ctor-constructor) |  |
---
### .ctor Constructor


```c#
public SequenceSByteFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| public | [Increment](#increment-property) | sbyte? | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} . |
| public | [InitialValue](#initialvalue-property) | sbyte | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} . |
| public | [MaximumValue](#maximumvalue-property) | sbyte? | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} . |
| public | [NullProbability](#nullprobability-property) | double | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} . |
---
### FieldName Property

Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) .
```c#
public string FieldName { get; set; }
```

[Go to properties](#Properties)

---
### Increment Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} .
```c#
public sbyte? Increment { get; set; }
```

[Go to properties](#Properties)

---
### InitialValue Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} .
```c#
public sbyte InitialValue { get; set; }
```

[Go to properties](#Properties)

---
### MaximumValue Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} .
```c#
public sbyte? MaximumValue { get; set; }
```

[Go to properties](#Properties)

---
### NullProbability Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} .
```c#
public double NullProbability { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} . |
| public | [Clone](#clone-method) | object | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [SequenceSByteFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/SequenceSByteFieldSettings.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.SequenceFieldSettingsBase{System.SByte,System.SByte} .
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

Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [SequenceSByteFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/SequenceSByteFieldSettings.md) .
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



