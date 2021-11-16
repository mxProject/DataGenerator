


# DataGeneratorTupleFieldSettings Class



Basic implementation of DataGeneratorTupleField settings.






## Inheritance tree
* object
## Implemented interfaces
* System.ICloneable

[Constructors](#Constructors)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| protected | [.ctor](#ctor-constructor) | Create a new instance. |
---
### .ctor Constructor

Create a new instance.
```c#
protected DataGeneratorTupleFieldSettings()
```

[Go to constructors](#Constructors)





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [Assert](#assert-method) | void | If the settings for this instance are invalid, an exception will be thrown. |
| public | [Clone](#clone-method) | object |  |
| public | [CreateField(DataGeneratorContext)](#createfielddatageneratorcontext-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface. |
| protected | [CreateFieldCore(DataGeneratorContext)](#createfieldcoredatageneratorcontext-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetFieldCount](#getfieldcount-method) | int | Gets the number of tuple fields. |
| public | [GetFieldNames](#getfieldnames-method) | string[] | Gets the names of tuple fields. |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Assert Method

If the settings for this instance are invalid, an exception will be thrown.
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

Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface.
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

#### Exceptions
|Exception Type|Message|
|:--|:--|
| [DataGeneratorFieldException](../mxProject.Devs.DataGeneration/DataGeneratorFieldException.md) | The field setting is invalid. |

[Go to methods](#Methods)

---
### CreateFieldCore(DataGeneratorContext) Method

Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface.
```c#
protected abstract IDataGeneratorTupleField CreateFieldCore
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

Gets the number of tuple fields.
```c#
public abstract int GetFieldCount()
```
#### Return type


[Go to methods](#Methods)

---
### GetFieldNames Method

Gets the names of tuple fields.
```c#
public abstract string[] GetFieldNames()
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



