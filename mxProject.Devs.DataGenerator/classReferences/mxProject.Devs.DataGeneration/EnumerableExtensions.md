


# EnumerableExtensions Class



Entension methods for System.Collections.Generic.IEnumerable`1 .






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
| public | [AsList&lt;T&gt;(IEnumerable&lt;T&gt;)](#aslisttienumerablet-method) | IList&lt;T&gt; | Cast or convert to IList. |
| public | [AsNullable&lt;T&gt;(IEnumerable&lt;T&gt;)](#asnullabletienumerablet-method) | IEnumerable&lt;T?&gt; | Converts to System.Collections.Generic.IEnumerable`1 . |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))?&gt;)](#asnullablet1-t2-t3-t4-t5-t6-t7-t8-t9ienumerablet1-t2-t3-t4-t5-t6-t7-t8-t9-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))&gt;)](#asnullablet1-t2-t3-t4-t5-t6-t7-t8-t9ienumerablet1-t2-t3-t4-t5-t6-t7-t8-t9-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)?&gt;)](#asnullablet1-t2-t3-t4-t5-t6-t7-t8ienumerablet1-t2-t3-t4-t5-t6-t7-valuetuplet8-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)&gt;)](#asnullablet1-t2-t3-t4-t5-t6-t7-t8ienumerablet1-t2-t3-t4-t5-t6-t7-valuetuplet8-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)?&gt;)](#asnullablet1-t2-t3-t4-t5-t6-t7ienumerablet1-t2-t3-t4-t5-t6-t7-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)&gt;)](#asnullablet1-t2-t3-t4-t5-t6-t7ienumerablet1-t2-t3-t4-t5-t6-t7-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6)?&gt;)](#asnullablet1-t2-t3-t4-t5-t6ienumerablet1-t2-t3-t4-t5-t6-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5, T6&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6)&gt;)](#asnullablet1-t2-t3-t4-t5-t6ienumerablet1-t2-t3-t4-t5-t6-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5)?&gt;)](#asnullablet1-t2-t3-t4-t5ienumerablet1-t2-t3-t4-t5-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4, T5&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5)&gt;)](#asnullablet1-t2-t3-t4-t5ienumerablet1-t2-t3-t4-t5-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4&gt;(IEnumerable&lt;(T1, T2, T3, T4)?&gt;)](#asnullablet1-t2-t3-t4ienumerablet1-t2-t3-t4-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3, T4&gt;(IEnumerable&lt;(T1, T2, T3, T4)&gt;)](#asnullablet1-t2-t3-t4ienumerablet1-t2-t3-t4-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3&gt;(IEnumerable&lt;(T1, T2, T3)?&gt;)](#asnullablet1-t2-t3ienumerablet1-t2-t3-method) | IEnumerable&lt;(T1?, T2?, T3?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;. |
| public | [AsNullable&lt;T1, T2, T3&gt;(IEnumerable&lt;(T1, T2, T3)&gt;)](#asnullablet1-t2-t3ienumerablet1-t2-t3-method) | IEnumerable&lt;(T1?, T2?, T3?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;. |
| public | [AsNullable&lt;T1, T2&gt;(IEnumerable&lt;(T1, T2)?&gt;)](#asnullablet1-t2ienumerablet1-t2-method) | IEnumerable&lt;(T1?, T2?)&gt; | Converts to IEnumerable&lt;(T1?, T2?)&gt;. |
| public | [AsNullable&lt;T1, T2&gt;(IEnumerable&lt;(T1, T2)&gt;)](#asnullablet1-t2ienumerablet1-t2-method) | IEnumerable&lt;(T1?, T2?)&gt; | Converts to IEnumerable&lt;(T1?, T2?)&gt;. |
| public | [AsSimplify&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))?&gt;)](#assimplifyt1-t2-t3-t4-t5-t6-t7-t8-t9ienumerablet1-t2-t3-t4-t5-t6-t7-t8-t9-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;. |
| public | [AsSimplify&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)?&gt;)](#assimplifyt1-t2-t3-t4-t5-t6-t7-t8ienumerablet1-t2-t3-t4-t5-t6-t7-valuetuplet8-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;. |
| public | [AsSimplify&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)?&gt;)](#assimplifyt1-t2-t3-t4-t5-t6-t7ienumerablet1-t2-t3-t4-t5-t6-t7-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;. |
| public | [AsSimplify&lt;T1, T2, T3, T4, T5, T6&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)?&gt;)](#assimplifyt1-t2-t3-t4-t5-t6ienumerablet1-t2-t3-t4-t5-t6-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;. |
| public | [AsSimplify&lt;T1, T2, T3, T4, T5&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)?&gt;)](#assimplifyt1-t2-t3-t4-t5ienumerablet1-t2-t3-t4-t5-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;. |
| public | [AsSimplify&lt;T1, T2, T3, T4&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?)?&gt;)](#assimplifyt1-t2-t3-t4ienumerablet1-t2-t3-t4-method) | IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;. |
| public | [AsSimplify&lt;T1, T2, T3&gt;(IEnumerable&lt;(T1?, T2?, T3?)?&gt;)](#assimplifyt1-t2-t3ienumerablet1-t2-t3-method) | IEnumerable&lt;(T1?, T2?, T3?)&gt; | Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;. |
| public | [AsSimplify&lt;T1, T2&gt;(IEnumerable&lt;(T1?, T2?)?&gt;)](#assimplifyt1-t2ienumerablet1-t2-method) | IEnumerable&lt;(T1?, T2?)&gt; | Converts to IEnumerable&lt;(T1?, T2?)&gt;. |
| public | [Repeat&lt;T&gt;(IEnumerable&lt;T&gt;, int)](#repeattienumerablet-int-method) | IEnumerable&lt;T&gt; | Enumerates the specified enumeration repeatedly. |
| public | [RepeatUntil&lt;T&gt;(IEnumerable&lt;T&gt;, int)](#repeatuntiltienumerablet-int-method) | IEnumerable&lt;T&gt; | Enumerate repeatedly until the enumerated number reaches the specified number. |
---
### AsList&lt;T&gt;(IEnumerable&lt;T&gt;) Method

Cast or convert to IList.
```c#
public static IList<T> AsList<T>
(
	this IEnumerable<T> values
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;T&gt; |  | The values to enumerate. |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T&gt;(IEnumerable&lt;T&gt;) Method

Converts to System.Collections.Generic.IEnumerable`1 .
```c#
public static IEnumerable<T?> AsNullable<T>
(
	this IEnumerable<T> values
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;T&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, (T8, T9))?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
where T9 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
| T8 |  | struct |
| T9 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, (T8, T9))> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
where T9 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
| T8 |  | struct |
| T9 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>)> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, ValueTuple<T8>)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
| T8 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>)> AsNullable<T1, T2, T3, T4, T5, T6, T7, T8>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6, T7, ValueTuple<T8>)> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
| T8 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> AsNullable<T1, T2, T3, T4, T5, T6, T7>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6, T7)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> AsNullable<T1, T2, T3, T4, T5, T6, T7>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> AsNullable<T1, T2, T3, T4, T5, T6>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5, T6&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5, T6)&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> AsNullable<T1, T2, T3, T4, T5, T6>
(
	this IEnumerable<(T1, T2, T3, T4, T5, T6)> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6)&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> AsNullable<T1, T2, T3, T4, T5>
(
	this IEnumerable<(T1, T2, T3, T4, T5)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4, T5&gt;(IEnumerable&lt;(T1, T2, T3, T4, T5)&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> AsNullable<T1, T2, T3, T4, T5>
(
	this IEnumerable<(T1, T2, T3, T4, T5)> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4, T5)&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4&gt;(IEnumerable&lt;(T1, T2, T3, T4)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?)> AsNullable<T1, T2, T3, T4>
(
	this IEnumerable<(T1, T2, T3, T4)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3, T4&gt;(IEnumerable&lt;(T1, T2, T3, T4)&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?)> AsNullable<T1, T2, T3, T4>
(
	this IEnumerable<(T1, T2, T3, T4)> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3, T4)&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3&gt;(IEnumerable&lt;(T1, T2, T3)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?)> AsNullable<T1, T2, T3>
(
	this IEnumerable<(T1, T2, T3)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2, T3&gt;(IEnumerable&lt;(T1, T2, T3)&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?)> AsNullable<T1, T2, T3>
(
	this IEnumerable<(T1, T2, T3)> values
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2, T3)&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2&gt;(IEnumerable&lt;(T1, T2)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?)&gt;.
```c#
public static IEnumerable<(T1?, T2?)> AsNullable<T1, T2>
(
	this IEnumerable<(T1, T2)?> values
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsNullable&lt;T1, T2&gt;(IEnumerable&lt;(T1, T2)&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?)&gt;.
```c#
public static IEnumerable<(T1?, T2?)> AsNullable<T1, T2>
(
	this IEnumerable<(T1, T2)> values
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1, T2)&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))> AsSimplify<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
where T9 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
| T8 |  | struct |
| T9 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>)> AsSimplify<T1, T2, T3, T4, T5, T6, T7, T8>
(
	this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
where T8 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
| T8 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2, T3, T4, T5, T6, T7&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> AsSimplify<T1, T2, T3, T4, T5, T6, T7>
(
	this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
where T7 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
| T7 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2, T3, T4, T5, T6&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> AsSimplify<T1, T2, T3, T4, T5, T6>
(
	this IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
where T6 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
| T6 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2, T3, T4, T5&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> AsSimplify<T1, T2, T3, T4, T5>
(
	this IEnumerable<(T1?, T2?, T3?, T4?, T5?)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
where T5 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
| T5 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2, T3, T4&gt;(IEnumerable&lt;(T1?, T2?, T3?, T4?)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?, T4?)> AsSimplify<T1, T2, T3, T4>
(
	this IEnumerable<(T1?, T2?, T3?, T4?)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
| T4 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2, T3&gt;(IEnumerable&lt;(T1?, T2?, T3?)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?, T3?)&gt;.
```c#
public static IEnumerable<(T1?, T2?, T3?)> AsSimplify<T1, T2, T3>
(
	this IEnumerable<(T1?, T2?, T3?)?> values
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
| T3 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?, T3?)?&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsSimplify&lt;T1, T2&gt;(IEnumerable&lt;(T1?, T2?)?&gt;) Method

Converts to IEnumerable&lt;(T1?, T2?)&gt;.
```c#
public static IEnumerable<(T1?, T2?)> AsSimplify<T1, T2>
(
	this IEnumerable<(T1?, T2?)?> values
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 |  | struct |
| T2 |  | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;(T1?, T2?)?&gt; |  |  |
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
### Repeat&lt;T&gt;(IEnumerable&lt;T&gt;, int) Method

Enumerates the specified enumeration repeatedly.
```c#
public static IEnumerable<T> Repeat<T>
(
	this IEnumerable<T> values
	, int repeatCount
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;T&gt; |  | The values to enumerate. |
| repeatCount | int |  | The repeat count. |
#### Return type


[Go to methods](#Methods)

---
### RepeatUntil&lt;T&gt;(IEnumerable&lt;T&gt;, int) Method

Enumerate repeatedly until the enumerated number reaches the specified number.
```c#
public static IEnumerable<T> RepeatUntil<T>
(
	this IEnumerable<T> values
	, int enumerationCount
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value. |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| values | IEnumerable&lt;T&gt; |  | The values to enumerate. |
| enumerationCount | int |  | The enumeration count. |
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



