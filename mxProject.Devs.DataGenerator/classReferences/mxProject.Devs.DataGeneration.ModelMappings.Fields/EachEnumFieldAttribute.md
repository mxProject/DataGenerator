


# EachEnumFieldAttribute Class

**[OBSOLETE]** 

Settings of a field that enumerates the specified enum values.






## Inheritance tree
* [mxProject.Devs.DataGeneration.ModelMappings.Fields.EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md)
* [mxProject.Devs.DataGeneration.ModelMappings.DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md)
* System.Attribute
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(Type, double, string)](#ctortype-double-string-constructor) | Create a new instance. |
| public | [.ctor(Type, string[], double, string)](#ctortype-string-double-string-constructor) | Create a new instance. |
---
### .ctor(Type, double, string) Constructor

Create a new instance.
```c#
public EachEnumFieldAttribute(
	Type enumType
	, double nullProbability
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| enumType | Type | The type of the enum type. |
| nullProbability | double | Probability of returning null. (between 0 and 1.0) |
| fieldName | string | The field name. |

[Go to constructors](#Constructors)

---
### .ctor(Type, string[], double, string) Constructor

Create a new instance.
```c#
public EachEnumFieldAttribute(
	Type enumType
	, string[] values
	, double nullProbability
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| enumType | Type | The type of the enum type. |
| values | string[] | The values to enumerate. |
| nullProbability | double | Probability of returning null. (between 0 and 1.0) |
| fieldName | string | The field name. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) . |
| public | [NullProbability](#nullprobability-property) | double | Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) . |
| public | [TypeId](#typeid-property) | object | Inherited from  System.Attribute . |
| public | [Values](#values-property) | object[] | Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) . |
| public | [ValueType](#valuetype-property) | Type | Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) . |
---
### FieldName Property

Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) .
```c#
public string FieldName { get; }
```

[Go to properties](#Properties)

---
### NullProbability Property

Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) .
```c#
public double NullProbability { get; }
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
### Values Property

Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) .
```c#
public object[] Values { get; }
```

[Go to properties](#Properties)

---
### ValueType Property

Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) .
```c#
public Type ValueType { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [ConvertValues(object[], Type, DataGeneratorContext)](#convertvaluesobject-type-datageneratorcontext-method) | IEnumerable&lt;object&gt; | Converts the specified value to a type that enumerates it.Inherited from  [EachEnumFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachEnumFieldAttribute.md) . |
| public | [CreateField(MemberInfo, DataGeneratorContext)](#createfieldmemberinfo-datageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Attribute . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Attribute . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [IsDefaultAttribute](#isdefaultattribute-method) | bool | Inherited from  System.Attribute . |
| public | [Match(object)](#matchobject-method) | bool | Inherited from  System.Attribute . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### ConvertValues(object[], Type, DataGeneratorContext) Method

Converts the specified value to a type that enumerates it.Inherited from  [EachEnumFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachEnumFieldAttribute.md) .
```c#
protected virtual IEnumerable<object> ConvertValues
(
	object[] values
	, Type valueType
	, DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | object[] |  | The values to enumerate. |
| valueType | Type |  | The type of the field value. |
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  | The context. |
#### Return type


[Go to methods](#Methods)

---
### CreateField(MemberInfo, DataGeneratorContext) Method

Inherited from  [EachFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/EachFieldAttribute.md) .
```c#
public virtual IDataGeneratorField CreateField
(
	MemberInfo member
	, DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| member | MemberInfo |  |  |
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



