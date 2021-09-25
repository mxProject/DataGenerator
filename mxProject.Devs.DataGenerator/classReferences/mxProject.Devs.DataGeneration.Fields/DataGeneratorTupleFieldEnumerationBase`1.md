


# DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt; Class



Basic implementation of a field that generates a tuple of multiple values.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TTuple | The value type to enumerate. |  |

## Inheritance tree
* [mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md)
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
| public | [.ctor(string[], Type[], IEnumerable&lt;TTuple&gt;)](#ctorstring-type-ienumerablettuple-constructor) | Creates a new instance. |
---
### .ctor(string[], Type[], IEnumerable&lt;TTuple&gt;) Constructor

Creates a new instance.
```c#
public DataGeneratorTupleFieldEnumerationBase(
	string[] fieldNames
	, Type[] valueTypes
	, IEnumerable<TTuple> enumeration
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldNames | string[] | The names of the fields. |
| valueTypes | Type[] | The value types of the fields. |
| enumeration | IEnumerable&lt;TTuple&gt; | Enumeration of field values. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldCount](#fieldcount-property) | int | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
---
### FieldCount Property

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
```c#
public virtual int FieldCount { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Dispose](#dispose-method) | void | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| protected | [Dispose(bool)](#disposebool-method) | void | Disposes the resources it is using.Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GenerateNext](#generatenext-method) | bool | Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) . |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| protected | [GetRawValue(int)](#getrawvalueint-method) | object | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetTypedValues](#gettypedvalues-method) | TTuple | Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) . |
| protected | [GetValue(int)](#getvalueint-method) | object | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) . |
| protected | [IsNullValue(int)](#isnullvalueint-method) | bool | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [Reset](#reset-method) | void | Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) . |
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

Disposes the resources it is using.Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) .
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

Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) .
```c#
public virtual bool GenerateNext()
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

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
```c#
protected abstract object GetRawValue
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
### GetType Method

Inherited from  System.Object .
```c#
public Type GetType()
```
#### Return type


[Go to methods](#Methods)

---
### GetTypedValues Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) .
```c#
public virtual TTuple GetTypedValues()
```
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| InvalidOperationException | This enumerator is already EOF. |

[Go to methods](#Methods)

---
### GetValue(int) Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
```c#
protected object GetValue
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
### GetValueType(int) Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) .
```c#
public virtual Type GetValueType
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  |  |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| IndexOutOfRangeException |  |

[Go to methods](#Methods)

---
### IsNullValue(int) Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) .
```c#
protected abstract bool IsNullValue
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
### MemberwiseClone Method

Inherited from  System.Object .
```c#
protected object MemberwiseClone()
```
#### Return type


[Go to methods](#Methods)

---
### Reset Method

Inherited from  [DataGeneratorTupleFieldEnumerationBase&lt;TTuple&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase`1.md) .
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



