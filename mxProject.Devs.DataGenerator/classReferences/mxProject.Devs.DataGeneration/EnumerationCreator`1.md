


# EnumerationCreator&lt;T&gt; Delegate



Indicates a method that generates an enumeration.


```c#
delegate ValueTask<IEnumerable<T?>> EnumerationCreator<T>
(
	int generateCount
)
where T : struct
```



## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T | The type of value to generate. | struct |









## Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  | Number of values to generate. |
## Return type

