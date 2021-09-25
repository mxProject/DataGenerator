


# DataGeneratorField&lt;T&gt; Class



Basic implementation of a field.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The value type of the field. | struct |

## Inheritance tree
* object
## Implemented interfaces
* mxProject.Devs.DataGeneration.IDataGeneratorField&lt;T&gt;
* [mxProject.Devs.DataGeneration.IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md)

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, int?, bool, EnumerationCreator&lt;T&gt;)](#ctorstring-int-bool-enumerationcreatort-constructor) | Creates a new instance. |
---
### .ctor(string, int?, bool, EnumerationCreator&lt;T&gt;) Constructor

Creates a new instance.
```c#
public DataGeneratorField(
	string fieldName
	, int? enumerateValueCount
	, bool mayBeNull
	, EnumerationCreator<T> enumerationCreator
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName | string | The name of the field. |
| enumerateValueCount | int? | Number of values that will be enumerated. |
| mayBeNull | bool | A value that indicates whether it may return a null value. |
| enumerationCreator | EnumerationCreator&lt;T&gt; | The method to generate an enumeration. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
| public | [IsFixedLength](#isfixedlength-property) | bool | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
| public | [MayBeNull](#maybenull-property) | bool | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
| public | [ValueType](#valuetype-property) | Type | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
---
### FieldName Property

( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. )
```c#
public virtual string FieldName { get; }
```

[Go to properties](#Properties)

---
### IsFixedLength Property

( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. )
```c#
public virtual bool IsFixedLength { get; }
```

[Go to properties](#Properties)

---
### MayBeNull Property

( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. )
```c#
public virtual bool MayBeNull { get; }
```

[Go to properties](#Properties)

---
### ValueType Property

( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. )
```c#
public virtual Type ValueType { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateEnumerationAsync(int)](#createenumerationasyncint-method) | ValueTask&lt;IDataGeneratorFieldEnumeration&lt;T&gt;&gt; |  |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetEnumerateValueCount](#getenumeratevaluecount-method) | int? | Inherited from  [DataGeneratorField&lt;T&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorField`1.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateEnumerationAsync(int) Method


```c#
public ValueTask<IDataGeneratorFieldEnumeration<T>> CreateEnumerationAsync
(
	int generationCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generationCount | int |  |  |
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
### GetEnumerateValueCount Method

Inherited from  [DataGeneratorField&lt;T&gt;](../mxProject.Devs.DataGeneration.Fields/DataGeneratorField`1.md) .
```c#
public virtual int? GetEnumerateValueCount()
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



