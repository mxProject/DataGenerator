


# DefaultRandomGenerator Class



Random value generation logic.






## Inheritance tree
* object
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IRandomGenerator](../mxProject.Devs.DataGeneration/IRandomGenerator.md)

[Constructors](#Constructors)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor](#ctor-constructor) | Creates a new instance. |
---
### .ctor Constructor

Creates a new instance.
```c#
public DefaultRandomGenerator()
```

[Go to constructors](#Constructors)





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [NextBoolean(double)](#nextbooleandouble-method) | bool | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextByte(byte, byte)](#nextbytebyte-byte-method) | byte | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextDateTime(DateTime, DateTime)](#nextdatetimedatetime-datetime-method) | DateTime | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextDateTimeOffset(DateTimeOffset, DateTimeOffset)](#nextdatetimeoffsetdatetimeoffset-datetimeoffset-method) | DateTimeOffset | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextDecimal(decimal, decimal)](#nextdecimaldecimal-decimal-method) | decimal | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextDouble(double, double)](#nextdoubledouble-double-method) | double | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextInt16(short, short)](#nextint16short-short-method) | short | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextInt32(int, int)](#nextint32int-int-method) | int | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextInt64(long, long)](#nextint64long-long-method) | long | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextSByte(sbyte, sbyte)](#nextsbytesbyte-sbyte-method) | sbyte | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextSingle(float, float)](#nextsinglefloat-float-method) | float | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextTimeSpan(TimeSpan, TimeSpan)](#nexttimespantimespan-timespan-method) | TimeSpan | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextUInt16(ushort, ushort)](#nextuint16ushort-ushort-method) | ushort | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextUInt32(uint, uint)](#nextuint32uint-uint-method) | uint | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
| public | [NextUInt64(ulong, ulong)](#nextuint64ulong-ulong-method) | ulong | Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) . |
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
### NextBoolean(double) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual bool NextBoolean
(
	double trueProbability
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| trueProbability | double |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextByte(byte, byte) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual byte NextByte
(
	byte minValue
	, byte maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | byte |  |  |
| maxValue | byte |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextDateTime(DateTime, DateTime) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual DateTime NextDateTime
(
	DateTime minValue
	, DateTime maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | DateTime |  |  |
| maxValue | DateTime |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextDateTimeOffset(DateTimeOffset, DateTimeOffset) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual DateTimeOffset NextDateTimeOffset
(
	DateTimeOffset minValue
	, DateTimeOffset maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | DateTimeOffset |  |  |
| maxValue | DateTimeOffset |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextDecimal(decimal, decimal) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual decimal NextDecimal
(
	decimal minValue
	, decimal maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | decimal |  |  |
| maxValue | decimal |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextDouble(double, double) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual double NextDouble
(
	double minValue
	, double maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | double |  |  |
| maxValue | double |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextInt16(short, short) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual short NextInt16
(
	short minValue
	, short maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | short |  |  |
| maxValue | short |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextInt32(int, int) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual int NextInt32
(
	int minValue
	, int maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | int |  |  |
| maxValue | int |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextInt64(long, long) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual long NextInt64
(
	long minValue
	, long maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | long |  |  |
| maxValue | long |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextSByte(sbyte, sbyte) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual sbyte NextSByte
(
	sbyte minValue
	, sbyte maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | sbyte |  |  |
| maxValue | sbyte |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextSingle(float, float) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual float NextSingle
(
	float minValue
	, float maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | float |  |  |
| maxValue | float |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextTimeSpan(TimeSpan, TimeSpan) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual TimeSpan NextTimeSpan
(
	TimeSpan minValue
	, TimeSpan maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | TimeSpan |  |  |
| maxValue | TimeSpan |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextUInt16(ushort, ushort) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual ushort NextUInt16
(
	ushort minValue
	, ushort maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | ushort |  |  |
| maxValue | ushort |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextUInt32(uint, uint) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual uint NextUInt32
(
	uint minValue
	, uint maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | uint |  |  |
| maxValue | uint |  |  |
#### Return type


[Go to methods](#Methods)

---
### NextUInt64(ulong, ulong) Method

Inherited from  [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) .
```c#
public virtual ulong NextUInt64
(
	ulong minValue
	, ulong maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | ulong |  |  |
| maxValue | ulong |  |  |
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



