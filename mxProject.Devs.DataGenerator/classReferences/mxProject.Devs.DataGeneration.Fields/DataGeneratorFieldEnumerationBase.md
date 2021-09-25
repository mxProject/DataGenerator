


# DataGeneratorFieldEnumerationBase Class



Basic implementation of a field.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration/IDataGeneratorFieldEnumeration.md)
* System.IDisposable

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| protected | [.ctor(IDataGeneratorField)](#ctoridatageneratorfield-constructor) | Creates a new instance. |
---
### .ctor(IDataGeneratorField) Constructor

Creates a new instance.
```c#
protected DataGeneratorFieldEnumerationBase(
	IDataGeneratorField field
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| field | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | The field. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [Field](#field-property) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Gets the field. |
---
### Field Property

Gets the field.
```c#
public IDataGeneratorField Field { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Dispose](#dispose-method) | void | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| protected | [Dispose(bool)](#disposebool-method) | void | Disposes the resources it is using. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GenerateNext](#generatenext-method) | bool | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetRawValue](#getrawvalue-method) | object | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetValue](#getvalue-method) | object | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| public | [IsNullValue](#isnullvalue-method) | bool | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [Reset](#reset-method) | void | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Dispose Method

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
public virtual void Dispose()
```

[Go to methods](#Methods)

---
### Dispose(bool) Method

Disposes the resources it is using.
```c#
protected virtual void Dispose
(
	bool disposing
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| disposing | bool |  | A value that indicates whether it was called from the dispose method. |

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
### GenerateNext Method

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
public abstract bool GenerateNext()
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
### GetRawValue Method

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
public abstract object GetRawValue()
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
### GetValue Method

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
public virtual object GetValue()
```
#### Return type


[Go to methods](#Methods)

---
### IsNullValue Method

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
public abstract bool IsNullValue()
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
### Reset Method

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
public abstract void Reset()
```

[Go to methods](#Methods)

---
### ToString Method

Inherited from  System.Object .
```c#
public virtual string ToString()
```
#### Return type


[Go to methods](#Methods)



