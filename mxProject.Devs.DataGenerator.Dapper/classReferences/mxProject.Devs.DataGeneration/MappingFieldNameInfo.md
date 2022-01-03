


# MappingFieldNameInfo Class










## Inheritance tree
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, string)](#ctorstring-string-constructor) |  |
---
### .ctor(string, string) Constructor


```c#
public MappingFieldNameInfo(
	string fieldName
	, string mappingName
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldName | string |  |
| mappingName | string |  |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string |  |
| public | [MappingName](#mappingname-property) | string |  |
---
### FieldName Property


```c#
public string FieldName { get; }
```

[Go to properties](#Properties)

---
### MappingName Property


```c#
public string MappingName { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
## Static Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateArray((string, string)[])](#createarraystring-string-method) | MappingFieldNameInfo[] |  |
| public | [CreateArray(string[])](#createarraystring-method) | MappingFieldNameInfo[] |  |
---
### CreateArray((string, string)[]) Method


```c#
public static MappingFieldNameInfo[] CreateArray
(
	(string, string)[] fieldNames
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldNames | (string, string)[] |  |  |
#### Return type


[Go to methods](#Methods)

---
### CreateArray(string[]) Method


```c#
public static MappingFieldNameInfo[] CreateArray
(
	string[] fieldNames
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldNames | string[] |  |  |
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



