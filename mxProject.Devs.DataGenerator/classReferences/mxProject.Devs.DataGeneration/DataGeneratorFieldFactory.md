


# DataGeneratorFieldFactory Class



Generate fields for DataGenerator.






## Inheritance tree
* object

[Constructors](#Constructors)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(EnumerableFactory)](#ctorenumerablefactory-constructor) | Creates a new instance. |
---
### .ctor(EnumerableFactory) Constructor

Creates a new instance.
```c#
public DataGeneratorFieldFactory(
	EnumerableFactory enumeration
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| enumeration | [EnumerableFactory](../mxProject.Devs.DataGeneration/EnumerableFactory.md) | The enumeration logic. |

[Go to constructors](#Constructors)





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [AnyOne(string, IList&lt;string&gt;, double)](#anyonestring-iliststring-double-method) | IDataGeneratorField&lt;StringValue&gt; | Creates a field that enumerates any of the values contained in the specified list. |
| public | [AnyOne&lt;T&gt;(string, IList&lt;T?&gt;, double)](#anyonetstring-ilistt-double-method) | IDataGeneratorField&lt;T&gt; | Creates a field that enumerates any of the values contained in the specified list. |
| public | [AnyOne&lt;T&gt;(string, IList&lt;T&gt;, double)](#anyonetstring-ilistt-double-method) | IDataGeneratorField&lt;T&gt; | Creates a field that enumerates any of the values contained in the specified list. |
| public | [AnyOneEnum&lt;TEnum&gt;(string, double)](#anyoneenumtenumstring-double-method) | IDataGeneratorField&lt;TEnum&gt; | Creates a field that enumerates any of the values of the specified enumeration type. |
| public | [AnyOneEnum&lt;TEnum&gt;(string, IList&lt;TEnum?&gt;, double)](#anyoneenumtenumstring-ilisttenum-double-method) | IDataGeneratorField&lt;TEnum&gt; | Creates a field that enumerates any of the values of the specified enumeration type. |
| public | [AnyOneEnum&lt;TEnum&gt;(string, IList&lt;TEnum&gt;, double)](#anyoneenumtenumstring-ilisttenum-double-method) | IDataGeneratorField&lt;TEnum&gt; | Creates a field that enumerates any of the values of the specified enumeration type. |
| public | [Create(string, int?, bool, StringEnumerationCreator)](#createstring-int-bool-stringenumerationcreator-method) | IDataGeneratorField&lt;StringValue&gt; | Creates a field that returns the values retrieved from the specified enumeration. |
| public | [Create(string, Type, int?, bool, EnumerationCreator)](#createstring-type-int-bool-enumerationcreator-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Creates a field that returns the values retrieved from the specified enumeration. |
| public | [Create&lt;T&gt;(string, int?, bool, EnumerationCreator&lt;T&gt;)](#createtstring-int-bool-enumerationcreatort-method) | IDataGeneratorField&lt;T&gt; | Creates a field that returns the values retrieved from the specified enumeration. |
| public | [Create&lt;T1, T2, T3&gt;(string, string, string, IEnumerable&lt;(T1?, T2?, T3?)&gt;)](#createt1-t2-t3string-string-string-ienumerablet1-t2-t3-method) | IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3&gt; | Creates a tuple field that returns the values retrieved from the specified enumeration. |
| public | [Create&lt;T1, T2&gt;(string, string, IEnumerable&lt;(T1?, T2?)&gt;)](#createt1-t2string-string-ienumerablet1-t2-method) | IDataGeneratorTupleFieldEnumeration&lt;T1, T2&gt; | Creates a tuple field that returns the values retrieved from the specified enumeration. |
| public | [Each(string, IEnumerable&lt;string&gt;, double)](#eachstring-ienumerablestring-double-method) | IDataGeneratorField&lt;StringValue&gt; | Creates a field that enumerates the specified values. |
| public | [Each&lt;T&gt;(string, IEnumerable&lt;T?&gt;, double)](#eachtstring-ienumerablet-double-method) | IDataGeneratorField&lt;T&gt; | Creates a field that enumerates the specified values. |
| public | [Each&lt;T&gt;(string, IEnumerable&lt;T&gt;, double)](#eachtstring-ienumerablet-double-method) | IDataGeneratorField&lt;T&gt; | Creates a field that enumerates the specified values. |
| public | [EachEnum&lt;TEnum&gt;(string, double)](#eachenumtenumstring-double-method) | IDataGeneratorField&lt;TEnum&gt; | Creates a field that enumerates the values of the specified enumeration type. |
| public | [EachEnum&lt;TEnum&gt;(string, IEnumerable&lt;TEnum?&gt;, double)](#eachenumtenumstring-ienumerabletenum-double-method) | IDataGeneratorField&lt;TEnum&gt; | Creates a field that enumerates the values of the specified enumeration type. |
| public | [EachEnum&lt;TEnum&gt;(string, IEnumerable&lt;TEnum&gt;, double)](#eachenumtenumstring-ienumerabletenum-double-method) | IDataGeneratorField&lt;TEnum&gt; | Creates a field that enumerates the values of the specified enumeration type. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(string, string, string, string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6-t7-t8-t9string-string-string-string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-t7-t8-t9-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(string, string, string, string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6-t7-t8-t9string-string-string-string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-t7-t8-t9-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(string, string, string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6-t7-t8string-string-string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-t7-valuetuplet8-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(string, string, string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6-t7-t8string-string-string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-t7-valuetuplet8-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(string, string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6-t7string-string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-t7-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(string, string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6-t7string-string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-t7-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6&gt;(string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6)&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5, T6&gt;(string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;, double)](#eachtuplet1-t2-t3-t4-t5-t6string-string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-t6-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5&gt;(string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5)&gt;, double)](#eachtuplet1-t2-t3-t4-t5string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4, T5&gt;(string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;, double)](#eachtuplet1-t2-t3-t4-t5string-string-string-string-string-ienumerablet1-t2-t3-t4-t5-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4&gt;(string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4)&gt;, double)](#eachtuplet1-t2-t3-t4string-string-string-string-ienumerablet1-t2-t3-t4-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3, T4&gt;(string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;, double)](#eachtuplet1-t2-t3-t4string-string-string-string-ienumerablet1-t2-t3-t4-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3&gt;(string, string, string, IEnumerable&lt;(T1, T2, T3)&gt;, double)](#eachtuplet1-t2-t3string-string-string-ienumerablet1-t2-t3-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2, T3&gt;(string, string, string, IEnumerable&lt;(T1?, T2?, T3?)&gt;, double)](#eachtuplet1-t2-t3string-string-string-ienumerablet1-t2-t3-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2&gt;(string, string, IEnumerable&lt;(T1, T2)&gt;, double)](#eachtuplet1-t2string-string-ienumerablet1-t2-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [EachTuple&lt;T1, T2&gt;(string, string, IEnumerable&lt;(T1?, T2?)&gt;, double)](#eachtuplet1-t2string-string-ienumerablet1-t2-double-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Creates a field that enumerates the specified values. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [FromDataReader(int, IDataReader)](#fromdatareaderint-idatareader-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) |  |
| public | [FromDataReader(int[], IDataReader)](#fromdatareaderint-idatareader-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) |  |
| public | [FromDataReader(string, IDataReader)](#fromdatareaderstring-idatareader-method) | [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) |  |
| public | [FromDataReader(string[], IDataReader)](#fromdatareaderstring-idatareader-method) | [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) |  |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [RandomBoolean(string, double, double)](#randombooleanstring-double-double-method) | IDataGeneratorField&lt;bool&gt; | Creates a field that returns Boolean random values. |
| public | [RandomByte(string, byte, byte, Func&lt;byte, byte&gt;, double)](#randombytestring-byte-byte-funcbyte-byte-double-method) | IDataGeneratorField&lt;byte&gt; | Creates a field that returns Byte random values. |
| public | [RandomDateTime(string, DateTime, DateTime, Func&lt;DateTime, DateTime&gt;, double)](#randomdatetimestring-datetime-datetime-funcdatetime-datetime-double-method) | IDataGeneratorField&lt;DateTime&gt; | Creates a field that returns DateTime random values. |
| public | [RandomDateTimeOffset(string, DateTimeOffset, DateTimeOffset, Func&lt;DateTimeOffset, DateTimeOffset&gt;, double)](#randomdatetimeoffsetstring-datetimeoffset-datetimeoffset-funcdatetimeoffset-datetimeoffset-double-method) | IDataGeneratorField&lt;DateTimeOffset&gt; | Creates a field that returns DateTimeOffset random values. |
| public | [RandomDecimal(string, decimal, decimal, Func&lt;decimal, decimal&gt;, double)](#randomdecimalstring-decimal-decimal-funcdecimal-decimal-double-method) | IDataGeneratorField&lt;decimal&gt; | Creates a field that returns Decimal random values. |
| public | [RandomDouble(string, double, double, Func&lt;double, double&gt;, double)](#randomdoublestring-double-double-funcdouble-double-double-method) | IDataGeneratorField&lt;double&gt; | Creates a field that returns Double random values. |
| public | [RandomGuid(string, double)](#randomguidstring-double-method) | IDataGeneratorField&lt;Guid&gt; | Creates a field that returns Guid random values. |
| public | [RandomInt16(string, short, short, Func&lt;short, short&gt;, double)](#randomint16string-short-short-funcshort-short-double-method) | IDataGeneratorField&lt;short&gt; | Creates a field that returns Int16 random values. |
| public | [RandomInt32(string, int, int, Func&lt;int, int&gt;, double)](#randomint32string-int-int-funcint-int-double-method) | IDataGeneratorField&lt;int&gt; | Creates a field that returns Int32 random values. |
| public | [RandomInt64(string, long, long, Func&lt;long, long&gt;, double)](#randomint64string-long-long-funclong-long-double-method) | IDataGeneratorField&lt;long&gt; | Creates a field that returns Int64 random values. |
| public | [RandomSByte(string, sbyte, sbyte, Func&lt;sbyte, sbyte&gt;, double)](#randomsbytestring-sbyte-sbyte-funcsbyte-sbyte-double-method) | IDataGeneratorField&lt;sbyte&gt; | Creates a field that returns SByte random values. |
| public | [RandomSingle(string, float, float, Func&lt;float, float&gt;, double)](#randomsinglestring-float-float-funcfloat-float-double-method) | IDataGeneratorField&lt;float&gt; | Creates a field that returns Single random values. |
| public | [RandomTimeSpan(string, TimeSpan, TimeSpan, Func&lt;TimeSpan, TimeSpan&gt;, double)](#randomtimespanstring-timespan-timespan-functimespan-timespan-double-method) | IDataGeneratorField&lt;TimeSpan&gt; | Creates a field that returns TimeSpan random values. |
| public | [RandomUInt16(string, ushort, ushort, Func&lt;ushort, ushort&gt;, double)](#randomuint16string-ushort-ushort-funcushort-ushort-double-method) | IDataGeneratorField&lt;ushort&gt; | Creates a field that returns UInt16 random values. |
| public | [RandomUInt32(string, uint, uint, Func&lt;uint, uint&gt;, double)](#randomuint32string-uint-uint-funcuint-uint-double-method) | IDataGeneratorField&lt;uint&gt; | Creates a field that returns UInt32 random values. |
| public | [RandomUInt64(string, ulong, ulong, Func&lt;ulong, ulong&gt;, double)](#randomuint64string-ulong-ulong-funculong-ulong-double-method) | IDataGeneratorField&lt;ulong&gt; | Creates a field that returns UInt64 random values. |
| public | [SequenceByte(string, byte, byte?, byte, double)](#sequencebytestring-byte-byte-byte-double-method) | IDataGeneratorField&lt;byte&gt; | Creates a field that enumerates Byte sequencial values. |
| public | [SequenceDateMonth(string, DateTime, DateTime, int, double)](#sequencedatemonthstring-datetime-datetime-int-double-method) | IDataGeneratorField&lt;DateTime&gt; | Creates a field that enumerates DateTime sequencial values. |
| public | [SequenceDateMonthOffset(string, DateTimeOffset, DateTimeOffset, int, double)](#sequencedatemonthoffsetstring-datetimeoffset-datetimeoffset-int-double-method) | IDataGeneratorField&lt;DateTimeOffset&gt; | Creates a field that enumerates DateTimeOffset sequencial values. |
| public | [SequenceDateTime(string, DateTime, DateTime, TimeSpan, double)](#sequencedatetimestring-datetime-datetime-timespan-double-method) | IDataGeneratorField&lt;DateTime&gt; | Creates a field that enumerates DateTime sequencial values. |
| public | [SequenceDateTimeOffset(string, DateTimeOffset, DateTimeOffset, TimeSpan, double)](#sequencedatetimeoffsetstring-datetimeoffset-datetimeoffset-timespan-double-method) | IDataGeneratorField&lt;DateTimeOffset&gt; | Creates a field that enumerates DateTimeOffset sequencial values. |
| public | [SequenceInt16(string, short, short?, short, double)](#sequenceint16string-short-short-short-double-method) | IDataGeneratorField&lt;short&gt; | Creates a field that enumerates Int16 sequencial values. |
| public | [SequenceInt32(string, int, int?, int, double)](#sequenceint32string-int-int-int-double-method) | IDataGeneratorField&lt;int&gt; | Creates a field that enumerates Int32 sequencial values. |
| public | [SequenceInt64(string, long, long?, long, double)](#sequenceint64string-long-long-long-double-method) | IDataGeneratorField&lt;long&gt; | Creates a field that enumerates Int64 sequencial values. |
| public | [SequenceSByte(string, sbyte, sbyte?, sbyte, double)](#sequencesbytestring-sbyte-sbyte-sbyte-double-method) | IDataGeneratorField&lt;sbyte&gt; | Creates a field that enumerates SByte sequencial values. |
| public | [SequenceTimeSpan(string, TimeSpan, TimeSpan, TimeSpan, double)](#sequencetimespanstring-timespan-timespan-timespan-double-method) | IDataGeneratorField&lt;TimeSpan&gt; | Creates a field that enumerates DateTimeOffset sequencial values. |
| public | [SequenceUInt16(string, ushort, ushort?, ushort, double)](#sequenceuint16string-ushort-ushort-ushort-double-method) | IDataGeneratorField&lt;ushort&gt; | Creates a field that enumerates UInt16 sequencial values. |
| public | [SequenceUInt32(string, uint, uint?, uint, double)](#sequenceuint32string-uint-uint-uint-double-method) | IDataGeneratorField&lt;uint&gt; | Creates a field that enumerates UInt32 sequencial values. |
| public | [SequenceUInt64(string, ulong, ulong?, ulong, double)](#sequenceuint64string-ulong-ulong-ulong-double-method) | IDataGeneratorField&lt;ulong&gt; | Creates a field that enumerates UInt64 sequencial values. |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### AnyOne(string, IList&lt;string&gt;, double) Method

Creates a field that enumerates any of the values contained in the specified list.
```c#
public IDataGeneratorField<StringValue> AnyOne
(
	string fieldName
	, IList<string> values
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IList&lt;string&gt; |  | The list containing the values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### AnyOne&lt;T&gt;(string, IList&lt;T?&gt;, double) Method

Creates a field that enumerates any of the values contained in the specified list.
```c#
public IDataGeneratorField<T> AnyOne<T>
(
	string fieldName
	, IList<T?> values
	, double nullProbability = 0
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IList&lt;T?&gt; |  | The list containing the values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### AnyOne&lt;T&gt;(string, IList&lt;T&gt;, double) Method

Creates a field that enumerates any of the values contained in the specified list.
```c#
public IDataGeneratorField<T> AnyOne<T>
(
	string fieldName
	, IList<T> values
	, double nullProbability = 0
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IList&lt;T&gt; |  | The list containing the values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### AnyOneEnum&lt;TEnum&gt;(string, double) Method

Creates a field that enumerates any of the values of the specified enumeration type.
```c#
public IDataGeneratorField<TEnum> AnyOneEnum<TEnum>
(
	string fieldName
	, double nullProbability = 0
)
where TEnum : struct, Enum
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TEnum | The enumeration type. | struct, Enum |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### AnyOneEnum&lt;TEnum&gt;(string, IList&lt;TEnum?&gt;, double) Method

Creates a field that enumerates any of the values of the specified enumeration type.
```c#
public IDataGeneratorField<TEnum> AnyOneEnum<TEnum>
(
	string fieldName
	, IList<TEnum?> values
	, double nullProbability = 0
)
where TEnum : struct, Enum
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TEnum | The enumeration type. | struct, Enum |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IList&lt;TEnum?&gt; |  | The list containing the values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### AnyOneEnum&lt;TEnum&gt;(string, IList&lt;TEnum&gt;, double) Method

Creates a field that enumerates any of the values of the specified enumeration type.
```c#
public IDataGeneratorField<TEnum> AnyOneEnum<TEnum>
(
	string fieldName
	, IList<TEnum> values
	, double nullProbability = 0
)
where TEnum : struct, Enum
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TEnum | The enumeration type. | struct, Enum |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IList&lt;TEnum&gt; |  | The list containing the values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### Create(string, int?, bool, StringEnumerationCreator) Method

Creates a field that returns the values retrieved from the specified enumeration.
```c#
public IDataGeneratorField<StringValue> Create
(
	string fieldName
	, int? enumerateValueCount
	, bool mayBeNull
	, StringEnumerationCreator enumeration
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| enumerateValueCount | int? |  | Number of values that will be enumerated. |
| mayBeNull | bool |  | A value that indicates whether it may return a null value. |
| enumeration | [StringEnumerationCreator](../mxProject.Devs.DataGeneration/StringEnumerationCreator.md) |  | The enumeration of field values. |
#### Return type


[Go to methods](#Methods)

---
### Create(string, Type, int?, bool, EnumerationCreator) Method

Creates a field that returns the values retrieved from the specified enumeration.
```c#
public IDataGeneratorField Create
(
	string fieldName
	, Type valueType
	, int? enumerateValueCount
	, bool mayBeNull
	, EnumerationCreator enumeration
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| valueType | Type |  | The value type of the field. |
| enumerateValueCount | int? |  | Number of values that will be enumerated. |
| mayBeNull | bool |  | A value that indicates whether it may return a null value. |
| enumeration | [EnumerationCreator](../mxProject.Devs.DataGeneration/EnumerationCreator.md) |  | The enumeration of field values. |
#### Return type


[Go to methods](#Methods)

---
### Create&lt;T&gt;(string, int?, bool, EnumerationCreator&lt;T&gt;) Method

Creates a field that returns the values retrieved from the specified enumeration.
```c#
public IDataGeneratorField<T> Create<T>
(
	string fieldName
	, int? enumerateValueCount
	, bool mayBeNull
	, EnumerationCreator<T> enumeration
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The value type of the field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| enumerateValueCount | int? |  | Number of values that will be enumerated. |
| mayBeNull | bool |  | A value that indicates whether it may return a null value. |
| enumeration | EnumerationCreator&lt;T&gt; |  | The enumeration of field values. |
#### Return type


[Go to methods](#Methods)

---
### Create&lt;T1, T2, T3&gt;(string, string, string, IEnumerable&lt;(T1?, T2?, T3?)&gt;) Method

Creates a tuple field that returns the values retrieved from the specified enumeration.
```c#
public IDataGeneratorTupleFieldEnumeration<T1, T2, T3> Create<T1, T2, T3>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, IEnumerable<(T1?, T2?, T3?)> enumeration
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| enumeration | IEnumerable&lt;(T1?, T2?, T3?)&gt; |  | The enumeration of field values. |
#### Return type


[Go to methods](#Methods)

---
### Create&lt;T1, T2&gt;(string, string, IEnumerable&lt;(T1?, T2?)&gt;) Method

Creates a tuple field that returns the values retrieved from the specified enumeration.
```c#
public IDataGeneratorTupleFieldEnumeration<T1, T2> Create<T1, T2>
(
	string fieldName1
	, string fieldName2
	, IEnumerable<(T1?, T2?)> enumeration
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| enumeration | IEnumerable&lt;(T1?, T2?)&gt; |  | The enumeration of field values. |
#### Return type


[Go to methods](#Methods)

---
### Each(string, IEnumerable&lt;string&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorField<StringValue> Each
(
	string fieldName
	, IEnumerable<string> values
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IEnumerable&lt;string&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### Each&lt;T&gt;(string, IEnumerable&lt;T?&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorField<T> Each<T>
(
	string fieldName
	, IEnumerable<T?> values
	, double nullProbability = 0
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IEnumerable&lt;T?&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### Each&lt;T&gt;(string, IEnumerable&lt;T&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorField<T> Each<T>
(
	string fieldName
	, IEnumerable<T> values
	, double nullProbability = 0
)
where T : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of the value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IEnumerable&lt;T&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachEnum&lt;TEnum&gt;(string, double) Method

Creates a field that enumerates the values of the specified enumeration type.
```c#
public IDataGeneratorField<TEnum> EachEnum<TEnum>
(
	string fieldName
	, double nullProbability = 0
)
where TEnum : struct, Enum
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TEnum | The enumeration type. | struct, Enum |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachEnum&lt;TEnum&gt;(string, IEnumerable&lt;TEnum?&gt;, double) Method

Creates a field that enumerates the values of the specified enumeration type.
```c#
public IDataGeneratorField<TEnum> EachEnum<TEnum>
(
	string fieldName
	, IEnumerable<TEnum?> values
	, double nullProbability = 0
)
where TEnum : struct, Enum
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TEnum | The enumeration type. | struct, Enum |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IEnumerable&lt;TEnum?&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachEnum&lt;TEnum&gt;(string, IEnumerable&lt;TEnum&gt;, double) Method

Creates a field that enumerates the values of the specified enumeration type.
```c#
public IDataGeneratorField<TEnum> EachEnum<TEnum>
(
	string fieldName
	, IEnumerable<TEnum> values
	, double nullProbability = 0
)
where TEnum : struct, Enum
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TEnum | The enumeration type. | struct, Enum |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| values | IEnumerable&lt;TEnum&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(string, string, string, string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, string fieldName8
	, string fieldName9
	, IEnumerable<(T1, T2, T3, T4, T5, T6, T7, (T8, T9))> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
| T7 | The type of the seventh value. | struct |
| T8 | The type of the eighth value. | struct |
| T9 | The type of the ninth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| fieldName8 | string |  | The name of the eighth field. |
| fieldName9 | string |  | The name of the ninth field. |
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, (T8, T9))&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;(string, string, string, string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, string fieldName8
	, string fieldName9
	, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
| T7 | The type of the seventh value. | struct |
| T8 | The type of the eighth value. | struct |
| T9 | The type of the ninth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| fieldName8 | string |  | The name of the eighth field. |
| fieldName9 | string |  | The name of the ninth field. |
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, (T8?, T9?))&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(string, string, string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, string fieldName8
	, IEnumerable<(T1, T2, T3, T4, T5, T6, T7, ValueTuple<T8>)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
| T7 | The type of the seventh value. | struct |
| T8 | The type of the eighth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| fieldName8 | string |  | The name of the eighth field. |
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7, ValueTuple&lt;T8&gt;)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;(string, string, string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7, T8>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, string fieldName8
	, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple<T8?>)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
| T7 | The type of the seventh value. | struct |
| T8 | The type of the eighth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| fieldName8 | string |  | The name of the eighth field. |
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?, ValueTuple&lt;T8?&gt;)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(string, string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
| T7 | The type of the seventh value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6, T7)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6, T7&gt;(string, string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6, T7>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, string fieldName7
	, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
| T7 | The type of the seventh value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| fieldName7 | string |  | The name of the seventh field. |
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?, T7?)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6&gt;(string, string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5, T6)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, IEnumerable<(T1, T2, T3, T4, T5, T6)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| values | IEnumerable&lt;(T1, T2, T3, T4, T5, T6)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5, T6&gt;(string, string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5, T6>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, string fieldName6
	, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
| T6 | The type of the sixth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| fieldName6 | string |  | The name of the sixth field. |
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?, T6?)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5&gt;(string, string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4, T5)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, IEnumerable<(T1, T2, T3, T4, T5)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| values | IEnumerable&lt;(T1, T2, T3, T4, T5)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4, T5&gt;(string, string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4, T5>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, string fieldName5
	, IEnumerable<(T1?, T2?, T3?, T4?, T5?)> values
	, double nullProbability = 0
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
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
| T5 | The type of the fifth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| fieldName5 | string |  | The name of the fifth field. |
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?, T5?)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4&gt;(string, string, string, string, IEnumerable&lt;(T1, T2, T3, T4)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, IEnumerable<(T1, T2, T3, T4)> values
	, double nullProbability = 0
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| values | IEnumerable&lt;(T1, T2, T3, T4)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3, T4&gt;(string, string, string, string, IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3, T4>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, string fieldName4
	, IEnumerable<(T1?, T2?, T3?, T4?)> values
	, double nullProbability = 0
)
where T1 : struct
where T2 : struct
where T3 : struct
where T4 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
| T4 | The type of the fourth value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| fieldName4 | string |  | The name of the fourth field. |
| values | IEnumerable&lt;(T1?, T2?, T3?, T4?)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3&gt;(string, string, string, IEnumerable&lt;(T1, T2, T3)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, IEnumerable<(T1, T2, T3)> values
	, double nullProbability = 0
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| values | IEnumerable&lt;(T1, T2, T3)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2, T3&gt;(string, string, string, IEnumerable&lt;(T1?, T2?, T3?)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2, T3>
(
	string fieldName1
	, string fieldName2
	, string fieldName3
	, IEnumerable<(T1?, T2?, T3?)> values
	, double nullProbability = 0
)
where T1 : struct
where T2 : struct
where T3 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
| T3 | The type of the third value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| fieldName3 | string |  | The name of the third field. |
| values | IEnumerable&lt;(T1?, T2?, T3?)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2&gt;(string, string, IEnumerable&lt;(T1, T2)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2>
(
	string fieldName1
	, string fieldName2
	, IEnumerable<(T1, T2)> values
	, double nullProbability = 0
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| values | IEnumerable&lt;(T1, T2)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### EachTuple&lt;T1, T2&gt;(string, string, IEnumerable&lt;(T1?, T2?)&gt;, double) Method

Creates a field that enumerates the specified values.
```c#
public IDataGeneratorTupleField EachTuple<T1, T2>
(
	string fieldName1
	, string fieldName2
	, IEnumerable<(T1?, T2?)> values
	, double nullProbability = 0
)
where T1 : struct
where T2 : struct
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The type of the first value. | struct |
| T2 | The type of the second value. | struct |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName1 | string |  | The name of the first field. |
| fieldName2 | string |  | The name of the second field. |
| values | IEnumerable&lt;(T1?, T2?)&gt; |  | The values to enumerate. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
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
### FromDataReader(int, IDataReader) Method


```c#
public IDataGeneratorField FromDataReader
(
	int fieldIndex
	, IDataReader reader
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldIndex | int |  |  |
| reader | IDataReader |  |  |
#### Return type


[Go to methods](#Methods)

---
### FromDataReader(int[], IDataReader) Method


```c#
public IDataGeneratorTupleField FromDataReader
(
	int[] fieldIndexes
	, IDataReader reader
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldIndexes | int[] |  |  |
| reader | IDataReader |  |  |
#### Return type


[Go to methods](#Methods)

---
### FromDataReader(string, IDataReader) Method


```c#
public IDataGeneratorField FromDataReader
(
	string fieldName
	, IDataReader reader
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  |  |
| reader | IDataReader |  |  |
#### Return type


[Go to methods](#Methods)

---
### FromDataReader(string[], IDataReader) Method


```c#
public IDataGeneratorTupleField FromDataReader
(
	string[] fieldNames
	, IDataReader reader
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldNames | string[] |  |  |
| reader | IDataReader |  |  |
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
### RandomBoolean(string, double, double) Method

Creates a field that returns Boolean random values.
```c#
public IDataGeneratorField<bool> RandomBoolean
(
	string fieldName
	, double trueProbability = 0.5
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| trueProbability | double |  | probability of returning true. (between 0 and 1.0) |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomByte(string, byte, byte, Func&lt;byte, byte&gt;, double) Method

Creates a field that returns Byte random values.
```c#
public IDataGeneratorField<byte> RandomByte
(
	string fieldName
	, byte minValue
	, byte maxValue
	, Func<byte, byte> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | byte |  | The minimum value. |
| maxValue | byte |  | The maximum value. |
| selector | Func&lt;byte, byte&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomDateTime(string, DateTime, DateTime, Func&lt;DateTime, DateTime&gt;, double) Method

Creates a field that returns DateTime random values.
```c#
public IDataGeneratorField<DateTime> RandomDateTime
(
	string fieldName
	, DateTime minValue
	, DateTime maxValue
	, Func<DateTime, DateTime> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | DateTime |  | The minimum value. |
| maxValue | DateTime |  | The maximum value. |
| selector | Func&lt;DateTime, DateTime&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomDateTimeOffset(string, DateTimeOffset, DateTimeOffset, Func&lt;DateTimeOffset, DateTimeOffset&gt;, double) Method

Creates a field that returns DateTimeOffset random values.
```c#
public IDataGeneratorField<DateTimeOffset> RandomDateTimeOffset
(
	string fieldName
	, DateTimeOffset minValue
	, DateTimeOffset maxValue
	, Func<DateTimeOffset, DateTimeOffset> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | DateTimeOffset |  | The minimum value. |
| maxValue | DateTimeOffset |  | The maximum value. |
| selector | Func&lt;DateTimeOffset, DateTimeOffset&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomDecimal(string, decimal, decimal, Func&lt;decimal, decimal&gt;, double) Method

Creates a field that returns Decimal random values.
```c#
public IDataGeneratorField<decimal> RandomDecimal
(
	string fieldName
	, decimal minValue
	, decimal maxValue
	, Func<decimal, decimal> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | decimal |  | The minimum value. |
| maxValue | decimal |  | The maximum value. |
| selector | Func&lt;decimal, decimal&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomDouble(string, double, double, Func&lt;double, double&gt;, double) Method

Creates a field that returns Double random values.
```c#
public IDataGeneratorField<double> RandomDouble
(
	string fieldName
	, double minValue
	, double maxValue
	, Func<double, double> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | double |  | The minimum value. |
| maxValue | double |  | The maximum value. |
| selector | Func&lt;double, double&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomGuid(string, double) Method

Creates a field that returns Guid random values.
```c#
public IDataGeneratorField<Guid> RandomGuid
(
	string fieldName
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomInt16(string, short, short, Func&lt;short, short&gt;, double) Method

Creates a field that returns Int16 random values.
```c#
public IDataGeneratorField<short> RandomInt16
(
	string fieldName
	, short minValue
	, short maxValue
	, Func<short, short> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | short |  | The minimum value. |
| maxValue | short |  | The maximum value. |
| selector | Func&lt;short, short&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomInt32(string, int, int, Func&lt;int, int&gt;, double) Method

Creates a field that returns Int32 random values.
```c#
public IDataGeneratorField<int> RandomInt32
(
	string fieldName
	, int minValue
	, int maxValue
	, Func<int, int> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | int |  | The minimum value. |
| maxValue | int |  | The maximum value. |
| selector | Func&lt;int, int&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomInt64(string, long, long, Func&lt;long, long&gt;, double) Method

Creates a field that returns Int64 random values.
```c#
public IDataGeneratorField<long> RandomInt64
(
	string fieldName
	, long minValue
	, long maxValue
	, Func<long, long> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | long |  | The minimum value. |
| maxValue | long |  | The maximum value. |
| selector | Func&lt;long, long&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomSByte(string, sbyte, sbyte, Func&lt;sbyte, sbyte&gt;, double) Method

Creates a field that returns SByte random values.
```c#
public IDataGeneratorField<sbyte> RandomSByte
(
	string fieldName
	, sbyte minValue
	, sbyte maxValue
	, Func<sbyte, sbyte> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | sbyte |  | The minimum value. |
| maxValue | sbyte |  | The maximum value. |
| selector | Func&lt;sbyte, sbyte&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomSingle(string, float, float, Func&lt;float, float&gt;, double) Method

Creates a field that returns Single random values.
```c#
public IDataGeneratorField<float> RandomSingle
(
	string fieldName
	, float minValue
	, float maxValue
	, Func<float, float> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | float |  | The minimum value. |
| maxValue | float |  | The maximum value. |
| selector | Func&lt;float, float&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomTimeSpan(string, TimeSpan, TimeSpan, Func&lt;TimeSpan, TimeSpan&gt;, double) Method

Creates a field that returns TimeSpan random values.
```c#
public IDataGeneratorField<TimeSpan> RandomTimeSpan
(
	string fieldName
	, TimeSpan minValue
	, TimeSpan maxValue
	, Func<TimeSpan, TimeSpan> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | TimeSpan |  | The minimum value. |
| maxValue | TimeSpan |  | The maximum value. |
| selector | Func&lt;TimeSpan, TimeSpan&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomUInt16(string, ushort, ushort, Func&lt;ushort, ushort&gt;, double) Method

Creates a field that returns UInt16 random values.
```c#
public IDataGeneratorField<ushort> RandomUInt16
(
	string fieldName
	, ushort minValue
	, ushort maxValue
	, Func<ushort, ushort> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | ushort |  | The minimum value. |
| maxValue | ushort |  | The maximum value. |
| selector | Func&lt;ushort, ushort&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomUInt32(string, uint, uint, Func&lt;uint, uint&gt;, double) Method

Creates a field that returns UInt32 random values.
```c#
public IDataGeneratorField<uint> RandomUInt32
(
	string fieldName
	, uint minValue
	, uint maxValue
	, Func<uint, uint> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | uint |  | The minimum value. |
| maxValue | uint |  | The maximum value. |
| selector | Func&lt;uint, uint&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### RandomUInt64(string, ulong, ulong, Func&lt;ulong, ulong&gt;, double) Method

Creates a field that returns UInt64 random values.
```c#
public IDataGeneratorField<ulong> RandomUInt64
(
	string fieldName
	, ulong minValue
	, ulong maxValue
	, Func<ulong, ulong> selector = null
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| minValue | ulong |  | The minimum value. |
| maxValue | ulong |  | The maximum value. |
| selector | Func&lt;ulong, ulong&gt; |  | The transform function to apply to each value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceByte(string, byte, byte?, byte, double) Method

Creates a field that enumerates Byte sequencial values.
```c#
public IDataGeneratorField<byte> SequenceByte
(
	string fieldName
	, byte initialValue
	, byte? maximumValue = null
	, byte increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | byte |  | The initial value. |
| maximumValue | byte? |  | The maximum value. |
| increment | byte |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceDateMonth(string, DateTime, DateTime, int, double) Method

Creates a field that enumerates DateTime sequencial values.
```c#
public IDataGeneratorField<DateTime> SequenceDateMonth
(
	string fieldName
	, DateTime initialValue
	, DateTime maximumValue
	, int incrementMonths
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | DateTime |  | The initial value. |
| maximumValue | DateTime |  | The maximum value. |
| incrementMonths | int |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceDateMonthOffset(string, DateTimeOffset, DateTimeOffset, int, double) Method

Creates a field that enumerates DateTimeOffset sequencial values.
```c#
public IDataGeneratorField<DateTimeOffset> SequenceDateMonthOffset
(
	string fieldName
	, DateTimeOffset initialValue
	, DateTimeOffset maximumValue
	, int incrementMonths
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | DateTimeOffset |  | The initial value. |
| maximumValue | DateTimeOffset |  | The maximum value. |
| incrementMonths | int |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceDateTime(string, DateTime, DateTime, TimeSpan, double) Method

Creates a field that enumerates DateTime sequencial values.
```c#
public IDataGeneratorField<DateTime> SequenceDateTime
(
	string fieldName
	, DateTime initialValue
	, DateTime maximumValue
	, TimeSpan increment
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | DateTime |  | The initial value. |
| maximumValue | DateTime |  | The maximum value. |
| increment | TimeSpan |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceDateTimeOffset(string, DateTimeOffset, DateTimeOffset, TimeSpan, double) Method

Creates a field that enumerates DateTimeOffset sequencial values.
```c#
public IDataGeneratorField<DateTimeOffset> SequenceDateTimeOffset
(
	string fieldName
	, DateTimeOffset initialValue
	, DateTimeOffset maximumValue
	, TimeSpan increment
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | DateTimeOffset |  | The initial value. |
| maximumValue | DateTimeOffset |  | The maximum value. |
| increment | TimeSpan |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceInt16(string, short, short?, short, double) Method

Creates a field that enumerates Int16 sequencial values.
```c#
public IDataGeneratorField<short> SequenceInt16
(
	string fieldName
	, short initialValue
	, short? maximumValue = null
	, short increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | short |  | The initial value. |
| maximumValue | short? |  | The maximum value. |
| increment | short |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceInt32(string, int, int?, int, double) Method

Creates a field that enumerates Int32 sequencial values.
```c#
public IDataGeneratorField<int> SequenceInt32
(
	string fieldName
	, int initialValue
	, int? maximumValue = null
	, int increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | int |  | The initial value. |
| maximumValue | int? |  | The maximum value. |
| increment | int |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceInt64(string, long, long?, long, double) Method

Creates a field that enumerates Int64 sequencial values.
```c#
public IDataGeneratorField<long> SequenceInt64
(
	string fieldName
	, long initialValue
	, long? maximumValue = null
	, long increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | long |  | The initial value. |
| maximumValue | long? |  | The maximum value. |
| increment | long |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceSByte(string, sbyte, sbyte?, sbyte, double) Method

Creates a field that enumerates SByte sequencial values.
```c#
public IDataGeneratorField<sbyte> SequenceSByte
(
	string fieldName
	, sbyte initialValue
	, sbyte? maximumValue = null
	, sbyte increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | sbyte |  | The initial value. |
| maximumValue | sbyte? |  | The maximum value. |
| increment | sbyte |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceTimeSpan(string, TimeSpan, TimeSpan, TimeSpan, double) Method

Creates a field that enumerates DateTimeOffset sequencial values.
```c#
public IDataGeneratorField<TimeSpan> SequenceTimeSpan
(
	string fieldName
	, TimeSpan initialValue
	, TimeSpan maximumValue
	, TimeSpan increment
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | TimeSpan |  | The initial value. |
| maximumValue | TimeSpan |  | The maximum value. |
| increment | TimeSpan |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceUInt16(string, ushort, ushort?, ushort, double) Method

Creates a field that enumerates UInt16 sequencial values.
```c#
public IDataGeneratorField<ushort> SequenceUInt16
(
	string fieldName
	, ushort initialValue
	, ushort? maximumValue = null
	, ushort increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | ushort |  | The initial value. |
| maximumValue | ushort? |  | The maximum value. |
| increment | ushort |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceUInt32(string, uint, uint?, uint, double) Method

Creates a field that enumerates UInt32 sequencial values.
```c#
public IDataGeneratorField<uint> SequenceUInt32
(
	string fieldName
	, uint initialValue
	, uint? maximumValue = null
	, uint increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | uint |  | The initial value. |
| maximumValue | uint? |  | The maximum value. |
| increment | uint |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
#### Return type


[Go to methods](#Methods)

---
### SequenceUInt64(string, ulong, ulong?, ulong, double) Method

Creates a field that enumerates UInt64 sequencial values.
```c#
public IDataGeneratorField<ulong> SequenceUInt64
(
	string fieldName
	, ulong initialValue
	, ulong? maximumValue = null
	, ulong increment = 1
	, double nullProbability = 0
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The name of the field. |
| initialValue | ulong |  | The initial value. |
| maximumValue | ulong? |  | The maximum value. |
| increment | ulong |  | The amount of increase in value when creating a new sequence value. |
| nullProbability | double |  | Probability of returning null. (between 0 and 1.0) |
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



