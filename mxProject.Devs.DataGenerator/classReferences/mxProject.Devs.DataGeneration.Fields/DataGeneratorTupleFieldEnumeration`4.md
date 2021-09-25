


# DataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt; Class



Field that generates a tuple of multiple values.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |

## Inheritance tree
* mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase&lt;System.ValueTuple&lt;T1?, T2?, T3?, T4?&gt;&gt;
* [mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md)
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleFieldEnumeration](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration.md)
* System.IDisposable
* mxProject.Devs.DataGeneration.IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt;

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;)](#ctorstring-string-string-string-ienumerablet1-t2-t3-t4-constructor) | Creates a new instance. |
---
### .ctor(string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;) Constructor

Creates a new instance.
```c#
public DataGeneratorTupleFieldEnumeration(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, IEnumerable<(T1?, T2?, T3?, T4?)> enumeration
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName1 | string | The name of the first field. |
| fieldName2 | string | The name of the second field. |
| fieldName3 | string | The name of the third field. |
| fieldName4 | string | The name of the fourth field. |
| enumeration | IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt; | Enumeration of field values. |

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
| protected | [Dispose(bool)](#disposebool-method) | void | Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GenerateNext](#generatenext-method) | bool | Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} . |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| protected | [GetRawValue(int)](#getrawvalueint-method) | object | Gets the field value.Inherited from  [DataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumeration`4.md) . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetTypedValues](#gettypedvalues-method) | (T1?, T2?, T3?, T4?) | Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} . |
| protected | [GetValue(int)](#getvalueint-method) | object | Inherited from  [DataGeneratorTupleFieldEnumerationBase](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumerationBase.md) . |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} . |
| protected | [IsNullValue(int)](#isnullvalueint-method) | bool | Gets a value that indicates whether the generated value is null.Inherited from  [DataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumeration`4.md) . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [Reset](#reset-method) | void | Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} . |
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

Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} .
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

Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} .
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

Gets the field value.Inherited from  [DataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumeration`4.md) .
```c#
protected virtual object GetRawValue
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
### GetTypedValues Method

Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} .
```c#
public virtual (T1?, T2?, T3?, T4?) GetTypedValues()
```
#### Return type


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

Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} .
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


[Go to methods](#Methods)

---
### IsNullValue(int) Method

Gets a value that indicates whether the generated value is null.Inherited from  [DataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorTupleFieldEnumeration`4.md) .
```c#
protected virtual bool IsNullValue
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

Inherited from  mxProject.Devs.DataGeneration.Fields.DataGeneratorTupleFieldEnumerationBase{System.ValueTuple{System.Nullable{T1},System.Nullable{T2},System.Nullable{T3},System.Nullable{T4}}} .
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



