


# DataGeneratorContext Class



Context that holds the state of the data generation process.






## Inheritance tree
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(DataGeneratorFieldFactory, IRandomGenerator, IStringConverter, EnumerableFactory, object, IDbProvider)](#ctordatageneratorfieldfactory-irandomgenerator-istringconverter-enumerablefactory-object-idbprovider-constructor) |  |
---
### .ctor(DataGeneratorFieldFactory, IRandomGenerator, IStringConverter, EnumerableFactory, object, IDbProvider) Constructor


```c#
public DataGeneratorContext(
	DataGeneratorFieldFactory fieldFactory
	, IRandomGenerator randomGenerator
	, IStringConverter stringConverter
	, EnumerableFactory enumerableFactory
	, object cSharpScriptGlobalObject
	, IDbProvider dbProvider
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| fieldFactory | [DataGeneratorFieldFactory](../mxProject.Devs.DataGeneration/DataGeneratorFieldFactory.md) |  |
| randomGenerator | [IRandomGenerator](../mxProject.Devs.DataGeneration/IRandomGenerator.md) |  |
| stringConverter | [IStringConverter](../mxProject.Devs.DataGeneration/IStringConverter.md) |  |
| enumerableFactory | [EnumerableFactory](../mxProject.Devs.DataGeneration/EnumerableFactory.md) |  |
| cSharpScriptGlobalObject | object |  |
| dbProvider | IDbProvider |  |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [CSharpScriptGlobalObject](#csharpscriptglobalobject-property) | object | Gets the object to use as a global variable in CSharpScript. |
| public | [DbProvider](#dbprovider-property) | IDbProvider |  |
| public | [EnumerableFactory](#enumerablefactory-property) | [EnumerableFactory](../mxProject.Devs.DataGeneration/EnumerableFactory.md) | Gets the enumerable factory. |
| public | [FieldFactory](#fieldfactory-property) | [DataGeneratorFieldFactory](../mxProject.Devs.DataGeneration/DataGeneratorFieldFactory.md) | Gets the field factory. |
| public | [RandomGenerator](#randomgenerator-property) | [IRandomGenerator](../mxProject.Devs.DataGeneration/IRandomGenerator.md) | Gets the random value generation logic. |
| public | [StringConverter](#stringconverter-property) | [IStringConverter](../mxProject.Devs.DataGeneration/IStringConverter.md) | Gets the string converter. |
---
### CSharpScriptGlobalObject Property

Gets the object to use as a global variable in CSharpScript.
```c#
public object CSharpScriptGlobalObject { get; }
```

[Go to properties](#Properties)

---
### DbProvider Property


```c#
public IDbProvider DbProvider { get; }
```

[Go to properties](#Properties)

---
### EnumerableFactory Property

Gets the enumerable factory.
```c#
public EnumerableFactory EnumerableFactory { get; }
```

[Go to properties](#Properties)

---
### FieldFactory Property

Gets the field factory.
```c#
public DataGeneratorFieldFactory FieldFactory { get; }
```

[Go to properties](#Properties)

---
### RandomGenerator Property

Gets the random value generation logic.
```c#
public IRandomGenerator RandomGenerator { get; }
```

[Go to properties](#Properties)

---
### StringConverter Property

Gets the string converter.
```c#
public IStringConverter StringConverter { get; }
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



