


# DataGeneratorBuilderExtensions Class



Extension methods for [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) .






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
| public | [AddAdditionalField(DataGeneratorBuilder, string, Type, Func&lt;IDataGenerationRecord, object&gt;)](#addadditionalfielddatageneratorbuilder-string-type-funcidatagenerationrecord-object-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Add a field that returns a value generated based on the generated value. |
| public | [AddAdditionalTupleField(DataGeneratorBuilder, (string, Type)[], Func&lt;IDataGenerationRecord, object[]&gt;)](#addadditionaltuplefielddatageneratorbuilder-string-type-funcidatagenerationrecord-object-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Add a field that returns values generated based on the generated value. |
| public | [AddAdditionalTupleField(DataGeneratorBuilder, IDataGeneratorFieldInfo[], Func&lt;IDataGenerationRecord, object[]&gt;)](#addadditionaltuplefielddatageneratorbuilder-idatageneratorfieldinfo-funcidatagenerationrecord-object-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Add a field that returns values generated based on the generated value. |
| public | [AddJoinField(DataGeneratorBuilder, Func&lt;JoinFieldFactory, IDataGeneratorAdditionalTupleField&gt;)](#addjoinfielddatageneratorbuilder-funcjoinfieldfactory-idatageneratoradditionaltuplefield-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Add a field that returns a value that corresponds to the generated value. |
---
### AddAdditionalField(DataGeneratorBuilder, string, Type, Func&lt;IDataGenerationRecord, object&gt;) Method

Add a field that returns a value generated based on the generated value.
```c#
public static DataGeneratorBuilder AddAdditionalField
(
	this DataGeneratorBuilder builder
	, string additionalFieldName
	, Type additionalValueType
	, Func<IDataGenerationRecord, object> valueGetter
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| builder | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) |  |  |
| additionalFieldName | string |  | the field name to add. |
| additionalValueType | Type |  | the value type to add. |
| valueGetter | Func&lt;IDataGenerationRecord, object&gt; |  | The method to get the value of the field. |
#### Return type


[Go to methods](#Methods)

---
### AddAdditionalTupleField(DataGeneratorBuilder, (string, Type)[], Func&lt;IDataGenerationRecord, object[]&gt;) Method

Add a field that returns values generated based on the generated value.
```c#
public static DataGeneratorBuilder AddAdditionalTupleField
(
	this DataGeneratorBuilder builder
	, (string, Type)[] additionalFields
	, Func<IDataGenerationRecord, object[]> valueGetter
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| builder | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) |  |  |
| additionalFields | (string, Type)[] |  | Information about the fields to add. |
| valueGetter | Func&lt;IDataGenerationRecord, object[]&gt; |  | The method to get the values of the fields. |
#### Return type


[Go to methods](#Methods)

---
### AddAdditionalTupleField(DataGeneratorBuilder, IDataGeneratorFieldInfo[], Func&lt;IDataGenerationRecord, object[]&gt;) Method

Add a field that returns values generated based on the generated value.
```c#
public static DataGeneratorBuilder AddAdditionalTupleField
(
	this DataGeneratorBuilder builder
	, IDataGeneratorFieldInfo[] additionalFields
	, Func<IDataGenerationRecord, object[]> valueGetter
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| builder | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) |  |  |
| additionalFields | IDataGeneratorFieldInfo[] |  | Information about the fields to add. |
| valueGetter | Func&lt;IDataGenerationRecord, object[]&gt; |  | The method to get the values of the fields. |
#### Return type


[Go to methods](#Methods)

---
### AddJoinField(DataGeneratorBuilder, Func&lt;JoinFieldFactory, IDataGeneratorAdditionalTupleField&gt;) Method

Add a field that returns a value that corresponds to the generated value.
```c#
public static DataGeneratorBuilder AddJoinField
(
	this DataGeneratorBuilder builder
	, Func<JoinFieldFactory, IDataGeneratorAdditionalTupleField> fieldCreator
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| builder | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) |  |  |
| fieldCreator | Func&lt;JoinFieldFactory, IDataGeneratorAdditionalTupleField&gt; |  | A method to create a field. |
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



