


# DataGeneratorFieldInfo Class



Field information.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorFieldInfo](../mxProject.Devs.DataGeneration/IDataGeneratorFieldInfo.md)
* System.ICloneable

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor](#ctor-constructor) | Creates a new instance. |
| public | [.ctor(string, string)](#ctorstring-string-constructor) | Create a new instance. |
| public | [.ctor(string, Type)](#ctorstring-type-constructor) | Create a new instance. |
---
### .ctor Constructor

Creates a new instance.
```c#
public DataGeneratorFieldInfo()
```

[Go to constructors](#Constructors)

---
### .ctor(string, string) Constructor

Create a new instance.
```c#
public DataGeneratorFieldInfo(
	string fieldName
	, string valueType
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName | string | The field name. |
| valueType | string | The value type. |

[Go to constructors](#Constructors)

---
### .ctor(string, Type) Constructor

Create a new instance.
```c#
public DataGeneratorFieldInfo(
	string fieldName
	, Type valueType
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName | string | The field name. |
| valueType | Type | The value type. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Gets or sets the field name. |
| public | [ValueType](#valuetype-property) | string | Gets or sets the value type. |
---
### FieldName Property

Gets or sets the field name.
```c#
public string FieldName { get; set; }
```

[Go to properties](#Properties)

---
### ValueType Property

Gets or sets the value type.
```c#
public string ValueType { get; set; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Clone](#clone-method) | object |  |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetFieldValueType](#getfieldvaluetype-method) | Type | Gets the value type. |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### Clone Method


```c#
public virtual object Clone()
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
### GetFieldValueType Method

Gets the value type.
```c#
public Type GetFieldValueType()
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



