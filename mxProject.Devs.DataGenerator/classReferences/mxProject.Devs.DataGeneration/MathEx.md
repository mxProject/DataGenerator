


# MathEx Class



Mathematical methods.






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
| public | [CeilingMultiple(decimal, int)](#ceilingmultipledecimal-int-method) | decimal | Returns the smallest multiple that is greater than or equal to the specified value. |
| public | [CeilingMultiple(double, int)](#ceilingmultipledouble-int-method) | double | Returns the smallest multiple that is greater than or equal to the specified value. |
| public | [FloorMultiple(decimal, int)](#floormultipledecimal-int-method) | decimal | Returns the largest multiple that is less than or equal to the specified number. |
| public | [FloorMultiple(double, int)](#floormultipledouble-int-method) | double | Returns the largest multiple that is less than or equal to the specified number. |
| public | [RoundMultiple(decimal, int)](#roundmultipledecimal-int-method) | decimal | Rounds to the specified multiples. |
| public | [RoundMultiple(decimal, int, int)](#roundmultipledecimal-int-int-method) | decimal | Rounds to the specified multiples. |
| public | [RoundMultiple(decimal, int, int, MidpointRounding)](#roundmultipledecimal-int-int-midpointrounding-method) | decimal | Rounds to the specified multiples. |
| public | [RoundMultiple(decimal, int, MidpointRounding)](#roundmultipledecimal-int-midpointrounding-method) | decimal | Rounds to the specified multiples. |
| public | [RoundMultiple(double, int)](#roundmultipledouble-int-method) | double | Rounds to the specified multiples. |
| public | [RoundMultiple(double, int, int)](#roundmultipledouble-int-int-method) | double | Rounds to the specified multiples. |
| public | [RoundMultiple(double, int, int, MidpointRounding)](#roundmultipledouble-int-int-midpointrounding-method) | double | Rounds to the specified multiples. |
| public | [RoundMultiple(double, int, MidpointRounding)](#roundmultipledouble-int-midpointrounding-method) | double | Rounds to the specified multiples. |
---
### CeilingMultiple(decimal, int) Method

Returns the smallest multiple that is greater than or equal to the specified value.
```c#
public static decimal CeilingMultiple
(
	decimal value
	, int multiple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | decimal |  | The number. |
| multiple | int |  | The multiple. |
#### Return type


[Go to methods](#Methods)

---
### CeilingMultiple(double, int) Method

Returns the smallest multiple that is greater than or equal to the specified value.
```c#
public static double CeilingMultiple
(
	double value
	, int multiple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | double |  | The number. |
| multiple | int |  | The multiple. |
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
### FloorMultiple(decimal, int) Method

Returns the largest multiple that is less than or equal to the specified number.
```c#
public static decimal FloorMultiple
(
	decimal value
	, int multiple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | decimal |  | The number. |
| multiple | int |  | The multiple. |
#### Return type


[Go to methods](#Methods)

---
### FloorMultiple(double, int) Method

Returns the largest multiple that is less than or equal to the specified number.
```c#
public static double FloorMultiple
(
	double value
	, int multiple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | double |  | The number. |
| multiple | int |  | The multiple. |
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
### RoundMultiple(decimal, int) Method

Rounds to the specified multiples.
```c#
public static decimal RoundMultiple
(
	decimal value
	, int multiple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | decimal |  | The number to be rounded. |
| multiple | int |  | The multiple. |
#### Return type


[Go to methods](#Methods)

---
### RoundMultiple(decimal, int, int) Method

Rounds to the specified multiples.
```c#
public static decimal RoundMultiple
(
	decimal value
	, int multiple
	, int decimals
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | decimal |  | The number to be rounded. |
| multiple | int |  | The multiple. |
| decimals | int |  | The number of decimal places in the return value. |
#### Return type


[Go to methods](#Methods)

---
### RoundMultiple(decimal, int, int, MidpointRounding) Method

Rounds to the specified multiples.
```c#
public static decimal RoundMultiple
(
	decimal value
	, int multiple
	, int decimals
	, MidpointRounding mode
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | decimal |  | The number to be rounded. |
| multiple | int |  | The multiple. |
| decimals | int |  | The number of decimal places in the return value. |
| mode | MidpointRounding |  | Specification for how to round value if it is midway between two other numbers. |
#### Return type


[Go to methods](#Methods)

---
### RoundMultiple(decimal, int, MidpointRounding) Method

Rounds to the specified multiples.
```c#
public static decimal RoundMultiple
(
	decimal value
	, int multiple
	, MidpointRounding mode
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | decimal |  | The number to be rounded. |
| multiple | int |  | The multiple. |
| mode | MidpointRounding |  | Specification for how to round value if it is midway between two other numbers. |
#### Return type


[Go to methods](#Methods)

---
### RoundMultiple(double, int) Method

Rounds to the specified multiples.
```c#
public static double RoundMultiple
(
	double value
	, int multiple
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | double |  | The number to be rounded. |
| multiple | int |  | The multiple. |
#### Return type


[Go to methods](#Methods)

---
### RoundMultiple(double, int, int) Method

Rounds to the specified multiples.
```c#
public static double RoundMultiple
(
	double value
	, int multiple
	, int digits
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | double |  | The number to be rounded. |
| multiple | int |  | The multiple. |
| digits | int |  | The number of fractional digits in the return value. |
#### Return type


[Go to methods](#Methods)

---
### RoundMultiple(double, int, int, MidpointRounding) Method

Rounds to the specified multiples.
```c#
public static double RoundMultiple
(
	double value
	, int multiple
	, int digits
	, MidpointRounding mode
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | double |  | The number to be rounded. |
| multiple | int |  | The multiple. |
| digits | int |  | The number of fractional digits in the return value. |
| mode | MidpointRounding |  | Specification for how to round value if it is midway between two other numbers. |
#### Return type


[Go to methods](#Methods)

---
### RoundMultiple(double, int, MidpointRounding) Method

Rounds to the specified multiples.
```c#
public static double RoundMultiple
(
	double value
	, int multiple
	, MidpointRounding mode
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| value | double |  | The number to be rounded. |
| multiple | int |  | The multiple. |
| mode | MidpointRounding |  | Specification for how to round value if it is midway between two other numbers. |
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



