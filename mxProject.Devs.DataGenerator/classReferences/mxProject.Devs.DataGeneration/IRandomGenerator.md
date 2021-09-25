


# IRandomGenerator Interface



Provides the functionality needed to generate random values.






## Inheritance tree

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [NextBoolean(double)](#nextbooleandouble-method) | bool | Generates a Boolean value. |
| public | [NextByte(byte, byte)](#nextbytebyte-byte-method) | byte | Generates a Byte value. |
| public | [NextDateTime(DateTime, DateTime)](#nextdatetimedatetime-datetime-method) | DateTime | Generates a DateTime value. |
| public | [NextDateTimeOffset(DateTimeOffset, DateTimeOffset)](#nextdatetimeoffsetdatetimeoffset-datetimeoffset-method) | DateTimeOffset | Generates a DateTimeOffset value. |
| public | [NextDecimal(decimal, decimal)](#nextdecimaldecimal-decimal-method) | decimal | Generates a Decimal value. |
| public | [NextDouble(double, double)](#nextdoubledouble-double-method) | double | Generates a Double value. |
| public | [NextInt16(short, short)](#nextint16short-short-method) | short | Generates an Int16 value. |
| public | [NextInt32(int, int)](#nextint32int-int-method) | int | Generates an Int32 value. |
| public | [NextInt64(long, long)](#nextint64long-long-method) | long | Generates an Int64 value. |
| public | [NextSByte(sbyte, sbyte)](#nextsbytesbyte-sbyte-method) | sbyte | Generates a SByte value. |
| public | [NextSingle(float, float)](#nextsinglefloat-float-method) | float | Generates a Single value. |
| public | [NextTimeSpan(TimeSpan, TimeSpan)](#nexttimespantimespan-timespan-method) | TimeSpan | Generates a TimeSpan value. |
| public | [NextUInt16(ushort, ushort)](#nextuint16ushort-ushort-method) | ushort | Generates a UInt16 value. |
| public | [NextUInt32(uint, uint)](#nextuint32uint-uint-method) | uint | Generates a UInt32 value. |
| public | [NextUInt64(ulong, ulong)](#nextuint64ulong-ulong-method) | ulong | Generates a UInt64 value. |
---
### NextBoolean(double) Method

Generates a Boolean value.
```c#
bool NextBoolean
(
	double trueProbability
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| trueProbability | double |  | probability of returning true. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### NextByte(byte, byte) Method

Generates a Byte value.
```c#
byte NextByte
(
	byte minValue
	, byte maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | byte |  | The minimum value. |
| maxValue | byte |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextDateTime(DateTime, DateTime) Method

Generates a DateTime value.
```c#
DateTime NextDateTime
(
	DateTime minValue
	, DateTime maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | DateTime |  | The minimum value. |
| maxValue | DateTime |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextDateTimeOffset(DateTimeOffset, DateTimeOffset) Method

Generates a DateTimeOffset value.
```c#
DateTimeOffset NextDateTimeOffset
(
	DateTimeOffset minValue
	, DateTimeOffset maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | DateTimeOffset |  | The minimum value. |
| maxValue | DateTimeOffset |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextDecimal(decimal, decimal) Method

Generates a Decimal value.
```c#
decimal NextDecimal
(
	decimal minValue
	, decimal maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | decimal |  | The minimum value. |
| maxValue | decimal |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextDouble(double, double) Method

Generates a Double value.
```c#
double NextDouble
(
	double minValue
	, double maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | double |  | The minimum value. |
| maxValue | double |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextInt16(short, short) Method

Generates an Int16 value.
```c#
short NextInt16
(
	short minValue
	, short maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | short |  | The minimum value. |
| maxValue | short |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextInt32(int, int) Method

Generates an Int32 value.
```c#
int NextInt32
(
	int minValue
	, int maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | int |  | The minimum value. |
| maxValue | int |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextInt64(long, long) Method

Generates an Int64 value.
```c#
long NextInt64
(
	long minValue
	, long maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | long |  | The minimum value. |
| maxValue | long |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextSByte(sbyte, sbyte) Method

Generates a SByte value.
```c#
sbyte NextSByte
(
	sbyte minValue
	, sbyte maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | sbyte |  | The minimum value. |
| maxValue | sbyte |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextSingle(float, float) Method

Generates a Single value.
```c#
float NextSingle
(
	float minValue
	, float maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | float |  | The minimum value. |
| maxValue | float |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextTimeSpan(TimeSpan, TimeSpan) Method

Generates a TimeSpan value.
```c#
TimeSpan NextTimeSpan
(
	TimeSpan minValue
	, TimeSpan maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | TimeSpan |  | The minimum value. |
| maxValue | TimeSpan |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextUInt16(ushort, ushort) Method

Generates a UInt16 value.
```c#
ushort NextUInt16
(
	ushort minValue
	, ushort maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | ushort |  | The minimum value. |
| maxValue | ushort |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextUInt32(uint, uint) Method

Generates a UInt32 value.
```c#
uint NextUInt32
(
	uint minValue
	, uint maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | uint |  | The minimum value. |
| maxValue | uint |  | The maximum value. |
#### Return type


[Go to methods](#Methods)

---
### NextUInt64(ulong, ulong) Method

Generates a UInt64 value.
```c#
ulong NextUInt64
(
	ulong minValue
	, ulong maxValue
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| minValue | ulong |  | The minimum value. |
| maxValue | ulong |  | The maximum value. |
#### Return type


[Go to methods](#Methods)



