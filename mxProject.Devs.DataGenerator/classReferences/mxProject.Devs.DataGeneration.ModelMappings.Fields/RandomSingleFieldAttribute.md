


# RandomSingleFieldAttribute Class

**[OBSOLETE]** 

Settings of a field that enumerates Single random values.






## Inheritance tree
* [mxProject.Devs.DataGeneration.ModelMappings.Fields.RandomFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomFieldAttribute.md)
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
| public | [.ctor(float, float, double, string)](#ctorfloat-float-double-string-constructor) | Create a new instance. |
---
### .ctor(float, float, double, string) Constructor

Create a new instance.
```c#
public RandomSingleFieldAttribute(
	float minValue
	, float maxValue
	, double nullProbability
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| minValue | float | The minimum value. |
| maxValue | float | The maximum value. |
| nullProbability | double | Probability of returning null. (between 0 and 1.0) |
| fieldName | string | The field name. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) . |
| public | [MaximumValue](#maximumvalue-property) | float | Gets the maximum value. |
| public | [MinimumValue](#minimumvalue-property) | float | Gets the minimum value. |
| public | [NullProbability](#nullprobability-property) | double | Inherited from  [RandomFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomFieldAttribute.md) . |
| public | [SelectorDecralingType](#selectordecralingtype-property) | Type | Inherited from  [RandomFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomFieldAttribute.md) . |
| public | [SelectorMethodName](#selectormethodname-property) | string | Inherited from  [RandomFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomFieldAttribute.md) . |
| public | [TypeId](#typeid-property) | object | Inherited from  System.Attribute . |
---
### FieldName Property

Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) .
```c#
public string FieldName { get; }
```

[Go to properties](#Properties)

---
### MaximumValue Property

Gets the maximum value.
```c#
public float MaximumValue { get; }
```

[Go to properties](#Properties)

---
### MinimumValue Property

Gets the minimum value.
```c#
public float MinimumValue { get; }
```

[Go to properties](#Properties)

---
### NullProbability Property

Inherited from  [RandomFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomFieldAttribute.md) .
```c#
public double NullProbability { get; }
```

[Go to properties](#Properties)

---
### SelectorDecralingType Property

Inherited from  [RandomFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomFieldAttribute.md) .
```c#
public Type SelectorDecralingType { get; }
```

[Go to properties](#Properties)

---
### SelectorMethodName Property

Inherited from  [RandomFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomFieldAttribute.md) .
```c#
public string SelectorMethodName { get; }
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
| public | [CreateField(MemberInfo, DataGeneratorContext)](#createfieldmemberinfo-datageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [RandomSingleFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomSingleFieldAttribute.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Attribute . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Attribute . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [IsDefaultAttribute](#isdefaultattribute-method) | bool | Inherited from  System.Attribute . |
| public | [Match(object)](#matchobject-method) | bool | Inherited from  System.Attribute . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateField(MemberInfo, DataGeneratorContext) Method

Creates an instance of [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) interface.Inherited from  [RandomSingleFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings.Fields/RandomSingleFieldAttribute.md) .
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



