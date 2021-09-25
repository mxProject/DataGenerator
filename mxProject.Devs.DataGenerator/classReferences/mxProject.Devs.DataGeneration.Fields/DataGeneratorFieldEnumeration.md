


# DataGeneratorFieldEnumeration Class



Field of data generator.






## Inheritance tree
* [mxProject.Devs.DataGeneration.Fields.DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md)
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
| public | [.ctor(IDataGeneratorField, IEnumerable&lt;object&gt;)](#ctoridatageneratorfield-ienumerableobject-constructor) |  |
---
### .ctor(IDataGeneratorField, IEnumerable&lt;object&gt;) Constructor


```c#
public DataGeneratorFieldEnumeration(
	IDataGeneratorField field
	, IEnumerable<object> values
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| field | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) |  |
| values | IEnumerable&lt;object&gt; |  |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [Field](#field-property) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
---
### Field Property

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
public IDataGeneratorField Field { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Dispose](#dispose-method) | void | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| protected | [Dispose(bool)](#disposebool-method) | void | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GenerateNext](#generatenext-method) | bool | Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetRawValue](#getrawvalue-method) | object | Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetValue](#getvalue-method) | object | Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) . |
| public | [IsNullValue](#isnullvalue-method) | bool | Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [Reset](#reset-method) | void | Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) . |
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

Inherited from  [DataGeneratorFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumerationBase.md) .
```c#
protected virtual void Dispose
(
	bool disposing
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| disposing | bool |  |  |

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

Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) .
```c#
public virtual bool GenerateNext()
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

Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) .
```c#
public virtual object GetRawValue()
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

Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) .
```c#
public virtual bool IsNullValue()
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

Inherited from  [DataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration.Fields/DataGeneratorFieldEnumeration.md) .
```c#
public virtual void Reset()
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



