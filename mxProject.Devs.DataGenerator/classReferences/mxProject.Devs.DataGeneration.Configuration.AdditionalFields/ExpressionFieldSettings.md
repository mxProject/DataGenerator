


# ExpressionFieldSettings Class



A setting for a field that returns the value of an expression.






## Inheritance tree
* [mxProject.Devs.DataGeneration.Configuration.DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md)
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
public ExpressionFieldSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [Expression](#expression-property) | string | Gets or sets the expression text of the selector. ex) "x =&gt; x.GetInt32(0) * x.GetInt32(1)" |
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) . |
| public | [ValueType](#valuetype-property) | string | Inherited from  [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) . |
---
### Expression Property

Gets or sets the expression text of the selector. ex) "x =&gt; x.GetInt32(0) * x.GetInt32(1)"
```c#
public string Expression { get; set; }
```

[Go to properties](#Properties)

---
### FieldName Property

Inherited from  [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) .
```c#
public string FieldName { get; set; }
```

[Go to properties](#Properties)

---
### ValueType Property

Inherited from  [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) .
```c#
public string ValueType { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | If the settings for this instance are invalid, an exception will be thrown.Inherited from  [ExpressionFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/ExpressionFieldSettings.md) . |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorAdditionalField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalField.md) | Inherited from  [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorAdditionalField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalField.md) | Creates an instance of [IDataGeneratorAdditionalField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalField.md) interface.Inherited from  [ExpressionFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/ExpressionFieldSettings.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

If the settings for this instance are invalid, an exception will be thrown.Inherited from  [ExpressionFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/ExpressionFieldSettings.md) .
```c#
protected virtual void Assert()
```

[Go to methods](#Methods)

---
### CreateField(DataGeneratorContext) Method

Inherited from  [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) .
```c#
public IDataGeneratorAdditionalField CreateField
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

Creates an instance of [IDataGeneratorAdditionalField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalField.md) interface.Inherited from  [ExpressionFieldSettings](../mxProject.Devs.DataGeneration.Configuration.AdditionalFields/ExpressionFieldSettings.md) .
```c#
protected virtual IDataGeneratorAdditionalField CreateFieldCore
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



