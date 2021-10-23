


# IStringConverterExtensions Class



Extension methods for [IStringConverter](../mxProject.Devs.DataGeneration/IStringConverter.md) .






## Inheritance tree
* object

[Methods](#Methods)&nbsp;&nbsp;





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
| public | [ConvertToOrNull&lt;T&gt;(IStringConverter, string)](#converttoornulltistringconverter-string-method) | T? | Converts the specified string value. |
---
### ConvertToOrNull&lt;T&gt;(IStringConverter, string) Method

Converts the specified string value.
```c#
public static T? ConvertToOrNull<T>
(
	this IStringConverter converter
	, string value
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of converted value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| converter | [IStringConverter](../mxProject.Devs.DataGeneration/IStringConverter.md) |  |  |
| value | string |  | The value. |
#### Return type
A converted value.

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



