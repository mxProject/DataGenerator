


# DataGeneratorFieldTypeConverterBuilder Class



JSON converter builder for resolving subtypes of DataGeneratorField.






## Inheritance tree
* object

[Constructors](#Constructors)&nbsp;&nbsp;
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
public DataGeneratorFieldTypeConverterBuilder()
```

[Go to constructors](#Constructors)





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Build](#build-method) | IList&lt;JsonConverter&gt; | Creates a JSON converter. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [RegisterAdditionalField&lt;T&gt;(string)](#registeradditionalfieldtstring-method) | [DataGeneratorFieldTypeConverterBuilder](../mxProject.Devs.DataGeneration.Configuration.Json/DataGeneratorFieldTypeConverterBuilder.md) | Registers the specified subtype of [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) . |
| public | [RegisterAdditionalTupleField&lt;T&gt;(string)](#registeradditionaltuplefieldtstring-method) | [DataGeneratorFieldTypeConverterBuilder](../mxProject.Devs.DataGeneration.Configuration.Json/DataGeneratorFieldTypeConverterBuilder.md) | Registers the specified subtype of [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) . |
| public | [RegisterField&lt;T&gt;(string)](#registerfieldtstring-method) | [DataGeneratorFieldTypeConverterBuilder](../mxProject.Devs.DataGeneration.Configuration.Json/DataGeneratorFieldTypeConverterBuilder.md) | Registers the specified subtype of [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) . |
| public | [RegisterTupleField&lt;T&gt;(string)](#registertuplefieldtstring-method) | [DataGeneratorFieldTypeConverterBuilder](../mxProject.Devs.DataGeneration.Configuration.Json/DataGeneratorFieldTypeConverterBuilder.md) | Registers the specified subtype of [DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md) . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
## Static Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateDefault](#createdefault-method) | [DataGeneratorFieldTypeConverterBuilder](../mxProject.Devs.DataGeneration.Configuration.Json/DataGeneratorFieldTypeConverterBuilder.md) | Create a default instance. |
---
### Build Method

Creates a JSON converter.
```c#
public IList<JsonConverter> Build()
```
#### Return type


[Go to methods](#Methods)

---
### CreateDefault Method

Create a default instance.
```c#
public static DataGeneratorFieldTypeConverterBuilder CreateDefault()
```
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
### RegisterAdditionalField&lt;T&gt;(string) Method

Registers the specified subtype of [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) .
```c#
public DataGeneratorFieldTypeConverterBuilder RegisterAdditionalField<T>
(
	string name
)
where T : DataGeneratorAdditionalFieldSettings
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The subtype. | [DataGeneratorAdditionalFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalFieldSettings.md) |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| name | string |  | The name to associate with the subtype. |
#### Return type


[Go to methods](#Methods)

---
### RegisterAdditionalTupleField&lt;T&gt;(string) Method

Registers the specified subtype of [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) .
```c#
public DataGeneratorFieldTypeConverterBuilder RegisterAdditionalTupleField<T>
(
	string name
)
where T : DataGeneratorAdditionalTupleFieldSettings
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The subtype. | [DataGeneratorAdditionalTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorAdditionalTupleFieldSettings.md) |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| name | string |  | The name to associate with the subtype. |
#### Return type


[Go to methods](#Methods)

---
### RegisterField&lt;T&gt;(string) Method

Registers the specified subtype of [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) .
```c#
public DataGeneratorFieldTypeConverterBuilder RegisterField<T>
(
	string name
)
where T : DataGeneratorFieldSettings
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The subtype. | [DataGeneratorFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorFieldSettings.md) |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| name | string |  | The name to associate with the subtype. |
#### Return type


[Go to methods](#Methods)

---
### RegisterTupleField&lt;T&gt;(string) Method

Registers the specified subtype of [DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md) .
```c#
public DataGeneratorFieldTypeConverterBuilder RegisterTupleField<T>
(
	string name
)
where T : DataGeneratorTupleFieldSettings
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The subtype. | [DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md) |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| name | string |  | The name to associate with the subtype. |
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



