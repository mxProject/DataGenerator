


# DefaultStringConverter Class



Default string converter.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IStringConverter](../mxProject.Devs.DataGeneration/IStringConverter.md)

[Constructors](#Constructors)&nbsp;&nbsp;
[Fields](#Fields)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor](#ctor-constructor) |  |
---
### .ctor Constructor


```c#
public DefaultStringConverter()
```

[Go to constructors](#Constructors)



---
## Static Fields
|Scope|Name|Field Type|Summary|
|:--|:--|:--|:--|
| public | [Instance](#instance-field) | [DefaultStringConverter](../mxProject.Devs.DataGeneration/DefaultStringConverter.md) | Singleton instance. |
---
### Instance Field

Singleton instance.

[Go to fields](#Fields)



---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [ConvertTo(string, Type)](#converttostring-type-method) | object | Inherited from  [DefaultStringConverter](../mxProject.Devs.DataGeneration/DefaultStringConverter.md) . |
| public | [ConvertTo&lt;T&gt;(string)](#converttotstring-method) | T | Inherited from  [DefaultStringConverter](../mxProject.Devs.DataGeneration/DefaultStringConverter.md) . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### ConvertTo(string, Type) Method

Inherited from  [DefaultStringConverter](../mxProject.Devs.DataGeneration/DefaultStringConverter.md) .
```c#
public virtual object ConvertTo
(
	string value
	, Type type
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | string |  |  |
| type | Type |  |  |
#### Return type


[Go to methods](#Methods)

---
### ConvertTo&lt;T&gt;(string) Method

Inherited from  [DefaultStringConverter](../mxProject.Devs.DataGeneration/DefaultStringConverter.md) .
```c#
public virtual T ConvertTo<T>
(
	string value
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T |  |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | string |  |  |
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



