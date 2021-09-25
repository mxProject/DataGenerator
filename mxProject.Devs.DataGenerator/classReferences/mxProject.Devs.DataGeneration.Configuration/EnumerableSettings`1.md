


# EnumerableSettings&lt;T&gt; Class



Basic implementation of enumerable settings.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value to enumerate. | struct |

## Inheritance tree
* [mxProject.Devs.DataGeneration.Configuration.EnumerableSettings](../mxProject.Devs.DataGeneration.Configuration/EnumerableSettings.md)
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| protected | [.ctor](#ctor-constructor) | Create a new instance. |
---
### .ctor Constructor

Create a new instance.
```c#
protected EnumerableSettings()
```

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [ValueType](#valuetype-property) | Type | ( Although "inheritdoc" is specified, the comment of the inheritance source cannot be obtained. ) |
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
| public | [CreateEnumerableAsync(int, DataGeneratorContext)](#createenumerableasyncint-datageneratorcontext-method) | ValueTask&lt;IEnumerable&lt;object&gt;&gt; | Creates an instance of System.Collections.Generic.IEnumerable`1 .Inherited from  [EnumerableSettings&lt;T&gt;](../mxProject.Devs.DataGeneration.Configuration/EnumerableSettings`1.md) . |
| public | [CreateTypedEnumerableAsync(int, DataGeneratorContext)](#createtypedenumerableasyncint-datageneratorcontext-method) | ValueTask&lt;IEnumerable&lt;T?&gt;&gt; | Creates an instance of System.Collections.Generic.IEnumerable`1 . |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetEnumerateValueCount(DataGeneratorContext)](#getenumeratevaluecountdatageneratorcontext-method) | int? | Inherited from  [EnumerableSettings](../mxProject.Devs.DataGeneration.Configuration/EnumerableSettings.md) . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### CreateEnumerableAsync(int, DataGeneratorContext) Method

Creates an instance of System.Collections.Generic.IEnumerable`1 .Inherited from  [EnumerableSettings&lt;T&gt;](../mxProject.Devs.DataGeneration.Configuration/EnumerableSettings`1.md) .
```c#
public virtual ValueTask<IEnumerable<object>> CreateEnumerableAsync
(
	int generateCount
	, DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  | Number of values to generate. |
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  | The context. |
#### Return type


[Go to methods](#Methods)

---
### CreateTypedEnumerableAsync(int, DataGeneratorContext) Method

Creates an instance of System.Collections.Generic.IEnumerable`1 .
```c#
public abstract ValueTask<IEnumerable<T?>> CreateTypedEnumerableAsync
(
	int generateCount
	, DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  |  |
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  |  |
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
### GetEnumerateValueCount(DataGeneratorContext) Method

Inherited from  [EnumerableSettings](../mxProject.Devs.DataGeneration.Configuration/EnumerableSettings.md) .
```c#
public abstract int? GetEnumerateValueCount
(
	DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  |  |
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



