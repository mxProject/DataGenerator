


# AnyEnumFieldSettings Class



Settings for a field that enumerates one of the specified enum values.






## Inheritance tree
* mxProject.Devs.DataGeneration.Configuration.Fields.AnyFieldSettingsBase&lt;string&gt;
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
public AnyEnumFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [EnumTypeName](#enumtypename-property) | string | Gets or sets the enum type name. |
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| public | [NullProbability](#nullprobability-property) | double | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.AnyFieldSettingsBase{System.String} . |
| public | [Values](#values-property) | string[] | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.AnyFieldSettingsBase{System.String} . |
---
### EnumTypeName Property

Gets or sets the enum type name.
```c#
public string EnumTypeName { get; set; }
```

[Go to properties](#Properties)

---
### FieldName Property

Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) .
```c#
public string FieldName { get; set; }
```

[Go to properties](#Properties)

---
### NullProbability Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.AnyFieldSettingsBase{System.String} .
```c#
public double NullProbability { get; set; }
```

[Go to properties](#Properties)

---
### Values Property

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.AnyFieldSettingsBase{System.String} .
```c#
public string[] Values { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.AnyFieldSettingsBase{System.String} . |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Inherited from  [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [AnyEnumFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/AnyEnumFieldSettings.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [GetValuesCount](#getvaluescount-method) | int | Inherited from  [AnyEnumFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/AnyEnumFieldSettings.md) . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

Inherited from  mxProject.Devs.DataGeneration.Configuration.Fields.AnyFieldSettingsBase{System.String} .
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

Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [AnyEnumFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/AnyEnumFieldSettings.md) .
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
### GetValuesCount Method

Inherited from  [AnyEnumFieldSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/AnyEnumFieldSettings.md) .
```c#
protected virtual int GetValuesCount()
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



