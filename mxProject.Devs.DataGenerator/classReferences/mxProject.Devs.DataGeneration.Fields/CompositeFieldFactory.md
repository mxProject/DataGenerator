


# CompositeFieldFactory Class










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
| public | [CreateComputingField(string, string, IEnumerable&lt;IDataGeneratorField&gt;, DataGeneratorContext, double)](#createcomputingfieldstring-string-ienumerableidatageneratorfield-datageneratorcontext-double-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) |  |
| public | [CreateFormattedStringField(string, string, IEnumerable&lt;IDataGeneratorField&gt;, DataGeneratorContext, double)](#createformattedstringfieldstring-string-ienumerableidatageneratorfield-datageneratorcontext-double-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) |  |
---
### CreateComputingField(string, string, IEnumerable&lt;IDataGeneratorField&gt;, DataGeneratorContext, double) Method


```c#
public static IDataGeneratorField CreateComputingField
(
	string fieldName
	, string expression
	, IEnumerable<IDataGeneratorField> argumentFields
	, DataGeneratorContext context
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
| expression | string |  |  |
| argumentFields | IEnumerable&lt;IDataGeneratorField&gt; |  |  |
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  |  |
| nullProbability | double |  |  |
#### Return type


[Go to methods](#Methods)

---
### CreateFormattedStringField(string, string, IEnumerable&lt;IDataGeneratorField&gt;, DataGeneratorContext, double) Method


```c#
public static IDataGeneratorField CreateFormattedStringField
(
	string fieldName
	, string formatString
	, IEnumerable<IDataGeneratorField> argumentFields
	, DataGeneratorContext context
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
| formatString | string |  |  |
| argumentFields | IEnumerable&lt;IDataGeneratorField&gt; |  |  |
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  |  |
| nullProbability | double |  |  |
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



