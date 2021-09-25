


# RandomFieldAttribute Class

**[OBSOLETE]** 

Basic implementation of a field attribute that enumerates random values.






## Inheritance tree
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
| protected | [.ctor(double, Type, string, string)](#ctordouble-type-string-string-constructor) | Create a new instance. |
---
### .ctor(double, Type, string, string) Constructor

Create a new instance.
```c#
protected RandomFieldAttribute(
	double nullProbability
	, Type selectorDecralingType
	, string selectorMethodName
	, string fieldName
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| nullProbability | double | Probability of returning null. (between 0 and 1.0) |
| selectorDecralingType | Type | The type in which the selector method is declared. |
| selectorMethodName | string | The name of the selector method. |
| fieldName | string | The field name. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) . |
| public | [NullProbability](#nullprobability-property) | double | Gets probability of returning null. (between 0 and 1.0) |
| public | [SelectorDecralingType](#selectordecralingtype-property) | Type | Gets the type in which the selector method is declared. |
| public | [SelectorMethodName](#selectormethodname-property) | string | Gets the name of the selector method. |
| public | [TypeId](#typeid-property) | object | Inherited from  System.Attribute . |
---
### FieldName Property

Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) .
```c#
public string FieldName { get; }
```

[Go to properties](#Properties)

---
### NullProbability Property

Gets probability of returning null. (between 0 and 1.0)
```c#
public double NullProbability { get; }
```

[Go to properties](#Properties)

---
### SelectorDecralingType Property

Gets the type in which the selector method is declared.
```c#
public Type SelectorDecralingType { get; }
```

[Go to properties](#Properties)

---
### SelectorMethodName Property

Gets the name of the selector method.
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
| public | [CreateField(MemberInfo, DataGeneratorContext)](#createfieldmemberinfo-datageneratorcontext-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Attribute . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Attribute . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [IsDefaultAttribute](#isdefaultattribute-method) | bool | Inherited from  System.Attribute . |
| public | [Match(object)](#matchobject-method) | bool | Inherited from  System.Attribute . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
## Static Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| protected | [GetSelectorMethod&lt;TMethod&gt;(Type, string)](#getselectormethodtmethodtype-string-method) | TMethod | Gets the selector method. |
---
### CreateField(MemberInfo, DataGeneratorContext) Method

Inherited from  [DataGenerationFieldAttribute](../mxProject.Devs.DataGeneration.ModelMappings/DataGenerationFieldAttribute.md) .
```c#
public abstract IDataGeneratorField CreateField
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
### GetSelectorMethod&lt;TMethod&gt;(Type, string) Method

Gets the selector method.
```c#
protected static TMethod GetSelectorMethod<TMethod>
(
	Type declaringType
	, string methodName
)
where TMethod : Delegate
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TMethod | The type of the selector method. | Delegate |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| declaringType | Type |  | The type in which the selector method is declared. |
| methodName | string |  | The name of the selector method. |
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



