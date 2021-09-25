


# DataGeneratorAdditionalField Class



Field that returns a value generated based on the value generated.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorAdditionalField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalField.md)

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, Type, Func&lt;IDataGenerationRecord, object&gt;)](#ctorstring-type-funcidatagenerationrecord-object-constructor) | Create a new instance. |
| public | [.ctor(string, Type, ValueTask&lt;Func&lt;IDataGenerationRecord, object&gt;&gt;)](#ctorstring-type-valuetaskfuncidatagenerationrecord-object-constructor) | Create a new instance. |
---
### .ctor(string, Type, Func&lt;IDataGenerationRecord, object&gt;) Constructor

Create a new instance.
```c#
public DataGeneratorAdditionalField(
	string fieldName
	, Type valueType
	, Func<IDataGenerationRecord, object> valueGetter
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName | string | The field name. |
| valueType | Type | The type of the field. |
| valueGetter | Func&lt;IDataGenerationRecord, object&gt; | The method to get the value of the field. |

[Go to constructors](#Constructors)

---
### .ctor(string, Type, ValueTask&lt;Func&lt;IDataGenerationRecord, object&gt;&gt;) Constructor

Create a new instance.
```c#
public DataGeneratorAdditionalField(
	string fieldName
	, Type valueType
	, ValueTask<Func<IDataGenerationRecord, object>> valueGetterCreator
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName | string | The field name. |
| valueType | Type | The type of the field. |
| valueGetterCreator | ValueTask&lt;Func&lt;IDataGenerationRecord, object&gt;&gt; | The task that return a method to get the value of the field. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
| public | [ValueType](#valuetype-property) | Type | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
---
### FieldName Property

( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. )
```c#
public virtual string FieldName { get; }
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
| public | [CreateValueGetterAsync](#createvaluegetterasync-method) | ValueTask&lt;Func&lt;IDataGenerationRecord, object&gt;&gt; | Inherited from  [DataGeneratorAdditionalField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalField.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateValueGetterAsync Method

Inherited from  [DataGeneratorAdditionalField](../mxProject.Devs.DataGeneration.AdditionalFields/DataGeneratorAdditionalField.md) .
```c#
public virtual ValueTask<Func<IDataGenerationRecord, object>> CreateValueGetterAsync()
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
### ToString Method

Inherited from  System.Object .
```c#
public virtual string ToString()
```
#### Return type


[Go to methods](#Methods)



