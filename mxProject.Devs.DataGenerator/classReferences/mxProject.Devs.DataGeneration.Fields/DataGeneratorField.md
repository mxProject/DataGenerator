


# DataGeneratorField Class



Basic implementation of a field.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md)

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, Type, int?, bool, EnumerationCreator)](#ctorstring-type-int-bool-enumerationcreator-constructor) | Creates a new instance. |
---
### .ctor(string, Type, int?, bool, EnumerationCreator) Constructor

Creates a new instance.
```c#
public DataGeneratorField(
	string fieldName
	, Type valueType
	, int? enumerateValueCount
	, bool mayBeNull
	, EnumerationCreator enumerationCreator
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName | string | The name of the field. |
| valueType | Type | The value type. |
| enumerateValueCount | int? | Number of values that will be enumerated. |
| mayBeNull | bool | A value that indicates whether it may return a null value. |
| enumerationCreator | [EnumerationCreator](../mxProject.Devs.DataGeneration/EnumerationCreator.md) | The method to generate an enumeration. |

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
| public | [CreateEnumerationAsync(int)](#createenumerationasyncint-method) | ValueTask&lt;IDataGeneratorFieldEnumeration&gt; | Inherited from  [DataGeneratorField](../mxProject.Devs.DataGeneration.Fields/DataGeneratorField.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetEnumerateValueCount](#getenumeratevaluecount-method) | int? | Inherited from  [DataGeneratorField](../mxProject.Devs.DataGeneration.Fields/DataGeneratorField.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateEnumerationAsync(int) Method

Inherited from  [DataGeneratorField](../mxProject.Devs.DataGeneration.Fields/DataGeneratorField.md) .
```c#
public virtual ValueTask<IDataGeneratorFieldEnumeration> CreateEnumerationAsync
(
	int generateCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  |  |
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

Inherited from  [DataGeneratorField](../mxProject.Devs.DataGeneration.Fields/DataGeneratorField.md) .
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



