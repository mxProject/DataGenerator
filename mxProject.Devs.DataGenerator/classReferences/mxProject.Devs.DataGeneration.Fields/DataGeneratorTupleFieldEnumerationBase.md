


# DataGeneratorTupleFieldEnumerationBase Class



Basic implementation of a field that generates a tuple of multiple values.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleFieldEnumeration](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration.md)
* System.IDisposable

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| protected | [.ctor(IEnumerable&lt;string&gt;)](#ctorienumerablestring-constructor) | Creates a new instance. |
---
### .ctor(IEnumerable&lt;string&gt;) Constructor

Creates a new instance.
```c#
protected DataGeneratorTupleFieldEnumerationBase(
	IEnumerable<string> fieldNames
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldNames | IEnumerable&lt;string&gt; | The name of the fields. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldCount](#fieldcount-property) | int | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
---
### FieldCount Property

( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. )
```c#
public virtual int FieldCount { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Dispose](#dispose-method) | void | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| protected | [Dispose(bool)](#disposebool-method) | void | Disposes the resources it is using. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GenerateNext](#generatenext-method) | bool | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| protected | [GetRawValue(int)](#getrawvalueint-method) | object | Gets the field value. |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [GetValue(int)](#getvalueint-method) | object | Gets the field value. The value is converted to a well-known type. |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| protected | [IsNullValue(int)](#isnullvalueint-method) | bool | Gets a value that indicates whether the generated value is null. |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [Reset](#reset-method) | void | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Dispose Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
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

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
```c#
public abstract bool GenerateNext()
```
#### Return type


[Go to methods](#Methods)

---
### GetFieldName(int) Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
```c#
public virtual string GetFieldName
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  |  |
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
### GetRawValue(int) Method

Gets the field value.
```c#
protected abstract object GetRawValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
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
### GetValue(int) Method

Gets the field value. The value is converted to a well-known type.
```c#
protected object GetValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### GetValueType(int) Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
```c#
public abstract Type GetValueType
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  |  |
#### Return type


[Go to methods](#Methods)

---
### IsNullValue(int) Method

Gets a value that indicates whether the generated value is null.
```c#
protected abstract bool IsNullValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
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

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
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



