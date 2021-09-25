


# TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6, T7&gt; Delegate



Indicates a method that generates an enumeration.


```c#
delegate ValueTask<IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>> TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7>
(
	int generateCount
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
| T1 | The type of object to enumerate in the first enumeration. | struct |
| T2 | The type of object to enumerate in the second enumeration. | struct |
| T3 | The type of object to enumerate in the third enumeration. | struct |
| T4 | The type of object to enumerate in the fourth enumeration. | struct |
| T5 | The type of object to enumerate in the fifth enumeration. | struct |
| T6 | The type of object to enumerate in the sixth enumeration. | struct |
| T7 | The type of object to enumerate in the seventh enumeration. | struct |









## Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  | Number of values to generate. |
## Return type

