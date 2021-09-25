


# IDataGeneratorTupleField&lt;T1, T2, T3&gt; Interface



Provides the functionality needed for fields that generate tuples of multiple values.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |

## Inheritance tree
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md)

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateTypedEnumerationAsync(int)](#createtypedenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3&gt;&gt; | Creates an enumeration. |
---
### CreateTypedEnumerationAsync(int) Method

Creates an enumeration.
```c#
ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2, T3>> CreateTypedEnumerationAsync
(
	int generationCount
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| generationCount | int |  | Number of values to generate. |
#### Return type


[Go to methods](#Methods)



