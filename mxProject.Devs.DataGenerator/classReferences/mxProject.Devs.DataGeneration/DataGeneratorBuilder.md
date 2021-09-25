


# DataGeneratorBuilder Class



DataGeneratorBuilder.






## Inheritance tree
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(DataGeneratorFieldFactory)](#ctordatageneratorfieldfactory-constructor) | Create a new instance. |
---
### .ctor(DataGeneratorFieldFactory) Constructor

Create a new instance.
```c#
public DataGeneratorBuilder(
	DataGeneratorFieldFactory factory
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| factory | [DataGeneratorFieldFactory](../mxProject.Devs.DataGeneration/DataGeneratorFieldFactory.md) | The field factory. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldCount](#fieldcount-property) | int | Gets the field count. |
---
### FieldCount Property

Gets the field count.
```c#
public int FieldCount { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [AddAdditionalField(IDataGeneratorAdditionalField)](#addadditionalfieldidatageneratoradditionalfield-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Adds the specified additional field. |
| public | [AddAdditionalTupleField(IDataGeneratorAdditionalTupleField)](#addadditionaltuplefieldidatageneratoradditionaltuplefield-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Adds the specified additional tuple field. |
| public | [AddField(Func&lt;DataGeneratorFieldFactory, IDataGeneratorField&gt;)](#addfieldfuncdatageneratorfieldfactory-idatageneratorfield-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Adds the field created by the specified method. |
| public | [AddField(IDataGeneratorField)](#addfieldidatageneratorfield-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Adds the specified field. |
| public | [AddTupleField(Func&lt;DataGeneratorFieldFactory, IDataGeneratorTupleField&gt;)](#addtuplefieldfuncdatageneratorfieldfactory-idatageneratortuplefield-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Adds the tuple field created by the specified method. |
| public | [AddTupleField(IDataGeneratorTupleField)](#addtuplefieldidatageneratortuplefield-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | Adds the specified tuple field. |
| public | [BuildAsDataReaderAsync(int)](#buildasdatareaderasyncint-method) | ValueTask&lt;IDataGenerationReader&gt; | Creates an instance of DataGenerator and returns DataReader that wraps the DataGenerator. |
| public | [BuildAsync(int)](#buildasyncint-method) | ValueTask&lt;DataGenerator&gt; | Creates an instance of DataGenerator. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Gets the name of the specified field. |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Gets the value type of the specified field. |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
## Static Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [FromType(Type, DataGeneratorContext)](#fromtypetype-datageneratorcontext-method) | [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | **[OBSOLETE]** Creates a DataGeneratorBuilder from the attributes defined for the specified type. |
---
### AddAdditionalField(IDataGeneratorAdditionalField) Method

Adds the specified additional field.
```c#
public DataGeneratorBuilder AddAdditionalField
(
	IDataGeneratorAdditionalField field
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| field | [IDataGeneratorAdditionalField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalField.md) |  | The field. |
#### Return type


[Go to methods](#Methods)

---
### AddAdditionalTupleField(IDataGeneratorAdditionalTupleField) Method

Adds the specified additional tuple field.
```c#
public DataGeneratorBuilder AddAdditionalTupleField
(
	IDataGeneratorAdditionalTupleField tuple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| tuple | [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) |  | The tuple field. |
#### Return type


[Go to methods](#Methods)

---
### AddField(Func&lt;DataGeneratorFieldFactory, IDataGeneratorField&gt;) Method

Adds the field created by the specified method.
```c#
public DataGeneratorBuilder AddField
(
	Func<DataGeneratorFieldFactory, IDataGeneratorField> fieldCreator
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldCreator | Func&lt;DataGeneratorFieldFactory, IDataGeneratorField&gt; |  | The method to create field. |
#### Return type


[Go to methods](#Methods)

---
### AddField(IDataGeneratorField) Method

Adds the specified field.
```c#
public DataGeneratorBuilder AddField
(
	IDataGeneratorField field
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| field | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) |  | The field. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| ArgumentNullException | The spacified field is null. |

[Go to methods](#Methods)

---
### AddTupleField(Func&lt;DataGeneratorFieldFactory, IDataGeneratorTupleField&gt;) Method

Adds the tuple field created by the specified method.
```c#
public DataGeneratorBuilder AddTupleField
(
	Func<DataGeneratorFieldFactory, IDataGeneratorTupleField> fieldCreator
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldCreator | Func&lt;DataGeneratorFieldFactory, IDataGeneratorTupleField&gt; |  | The method to create field. |
#### Return type


[Go to methods](#Methods)

---
### AddTupleField(IDataGeneratorTupleField) Method

Adds the specified tuple field.
```c#
public DataGeneratorBuilder AddTupleField
(
	IDataGeneratorTupleField tuple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| tuple | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) |  | The field. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| ArgumentNullException | The spacified field is null. |

[Go to methods](#Methods)

---
### BuildAsDataReaderAsync(int) Method

Creates an instance of DataGenerator and returns DataReader that wraps the DataGenerator.
```c#
public ValueTask<IDataGenerationReader> BuildAsDataReaderAsync
(
	int generateCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  | Number of values to generate. |
#### Return type


[Go to methods](#Methods)

---
### BuildAsync(int) Method

Creates an instance of DataGenerator.
```c#
public ValueTask<DataGenerator> BuildAsync
(
	int generateCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  | Number of values to generate. |
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
### FromType(Type, DataGeneratorContext) Method
**[OBSOLETE]** 
Creates a DataGeneratorBuilder from the attributes defined for the specified type.
```c#
public static DataGeneratorBuilder FromType
(
	Type modelType
	, DataGeneratorContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| modelType | Type |  | The type of the data model. |
| context | [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) |  | The context. |
#### Return type


[Go to methods](#Methods)

---
### GetFieldName(int) Method

Gets the name of the specified field.
```c#
public string GetFieldName
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
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
### GetValueType(int) Method

Gets the value type of the specified field.
```c#
public Type GetValueType
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
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



