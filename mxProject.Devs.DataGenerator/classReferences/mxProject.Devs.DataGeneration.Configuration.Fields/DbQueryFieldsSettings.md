


# DbQueryFieldsSettings Class



Settings for a tuple field that lists ths values read from the specified database query.






## Inheritance tree
* [mxProject.Devs.DataGeneration.Configuration.DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md)
* object

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
public DbQueryFieldsSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [DbQuerySettings](#dbquerysettings-property) | [DbQuerySettings](../mxProject.Devs.DataGeneration.Configuration/DbQuerySettings.md) | Gets or sets the database query settings. |
| public | [FieldNames](#fieldnames-property) | string[] | Gets or sets the fields information. |
---
### DbQuerySettings Property

Gets or sets the database query settings.
```c#
public DbQuerySettings DbQuerySettings { get; set; }
```

[Go to properties](#Properties)

---
### FieldNames Property

Gets or sets the fields information.
```c#
public string[] FieldNames { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | If the settings for this instance are invalid, an exception will be thrown.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) . |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Inherited from  [DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md) . |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetFieldCount](#getfieldcount-method) | int | Gets the number of tuple fields.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) . |
| public | [GetFieldNames](#getfieldnames-method) | string[] | Gets the names of tuple fields.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

If the settings for this instance are invalid, an exception will be thrown.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) .
```c#
protected virtual void Assert()
```
#### Exceptions
|Exception Type|Message|
|:--|:--|
| NullReferenceException | The value of Fields property is null. The value of Values property is null. The value of FieldInfo.FieldName property is null. The value of FieldInfo.ValueType property is null. |

[Go to methods](#Methods)

---
### CreateField(DataGeneratorContext) Method

Inherited from  [DataGeneratorTupleFieldSettings](../mxProject.Devs.DataGeneration.Configuration/DataGeneratorTupleFieldSettings.md) .
```c#
public IDataGeneratorTupleField CreateField
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

Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) .
```c#
protected virtual IDataGeneratorTupleField CreateFieldCore
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
### GetFieldCount Method

Gets the number of tuple fields.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) .
```c#
public virtual int GetFieldCount()
```
#### Return type


[Go to methods](#Methods)

---
### GetFieldNames Method

Gets the names of tuple fields.Inherited from  [DbQueryFieldsSettings](../mxProject.Devs.DataGeneration.Configuration.Fields/DbQueryFieldsSettings.md) .
```c#
public virtual string[] GetFieldNames()
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



