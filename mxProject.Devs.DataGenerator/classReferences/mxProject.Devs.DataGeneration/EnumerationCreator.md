


# EnumerationCreator Delegate



Indicates a method that generates an enumeration.


```c#
delegate ValueTask<IEnumerable<object>> EnumerationCreator
(
	int generateCount
)
```












## Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generateCount | int |  | Number of values to generate. |
## Return type

