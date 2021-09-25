


# TupleEnumerationCreator&lt;T1, T2, T3&gt; Delegate



Indicates a method that generates an enumeration.


```c#
delegate ValueTask<IEnumerable<(T1?, T2?, T3?)>> TupleEnumerationCreator<T1, T2, T3>
(
	int generateCount
)
where T1 : struct
where T2 : struct
where T3 : struct
```



## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The type of object to enumerate in the first enumeration. | struct |
| T2 | The type of object to enumerate in the second enumeration. | struct |
| T3 | The type of object to enumerate in the third enumeration. | struct |









## Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  | Number of values to generate. |
## Return type

