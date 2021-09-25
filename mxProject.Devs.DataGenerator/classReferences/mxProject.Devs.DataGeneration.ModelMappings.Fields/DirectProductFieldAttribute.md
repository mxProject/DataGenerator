


# DirectProductFieldAttribute Class

**[OBSOLETE]** 

Indicates that it is part of a field that generates a direct product of multiple values.






## Inheritance tree
* [mxProject.Devs.DataGeneration.ModelMappings.DataGenerationTupleFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationTupleFieldAttribute.md)
* System.Attribute
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, int)](#ctorstring-int-constructor) | Create a new instanse. |
---
### .ctor(string, int) Constructor

Create a new instanse.
```c#
public DirectProductFieldAttribute(
	string tupleId
	, int fieldIndex
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| tupleId | string | A value that uniquely identifies a group of tuple fields. |
| fieldIndex | int | The field index. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldIndex](#fieldindex-property) | int | Inherited from  [DataGenerationTupleFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationTupleFieldAttribute.md) . |
| public | [TupleID](#tupleid-property) | string | Inherited from  [DataGenerationTupleFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationTupleFieldAttribute.md) . |
| public | [TypeId](#typeid-property) | object | Inherited from  System.Attribute . |
---
### FieldIndex Property

Inherited from  [DataGenerationTupleFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationTupleFieldAttribute.md) .
```c#
public int FieldIndex { get; }
```

[Go to properties](#Properties)

---
### TupleID Property

Inherited from  [DataGenerationTupleFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationTupleFieldAttribute.md) .
```c#
public string TupleID { get; }
```

[Go to properties](#Properties)

---
### TypeId Property

Inherited from  System.Attribute .
```c#
public virtual object TypeId { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateTupleField(IDataGeneratorField[], DataGeneratorContext)](#createtuplefieldidatageneratorfield-datageneratorcontext-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Attribute . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Attribute . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [IsDefaultAttribute](#isdefaultattribute-method) | bool | Inherited from  System.Attribute . |
| public | [Match(object)](#matchobject-method) | bool | Inherited from  System.Attribute . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateTupleField(IDataGeneratorField[], DataGeneratorContext) Method

Creates an instance of [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) interface.
```c#
public virtual IDataGeneratorTupleField CreateTupleField
(
	IDataGeneratorField[] fields
	, DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fields | IDataGeneratorField[] |  |  |
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  |  |
#### Return type


[Go to methods](#Methods)

---
### Equals(object) Method

Inherited from  System.Attribute .
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

Inherited from  System.Attribute .
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
### IsDefaultAttribute Method

Inherited from  System.Attribute .
```c#
public virtual bool IsDefaultAttribute()
```
#### Return type


[Go to methods](#Methods)

---
### Match(object) Method

Inherited from  System.Attribute .
```c#
public virtual bool Match
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



