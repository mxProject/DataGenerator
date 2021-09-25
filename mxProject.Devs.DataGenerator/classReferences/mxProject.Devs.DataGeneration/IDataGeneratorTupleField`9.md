


# IDataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt; Interface



Provides the functionality needed for fields that generate tuples of multiple values.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |
| T5 | The value type of the fifth field. | struct |
| T6 | The value type of the sixth field. | struct |
| T7 | The value type of the seventh field. | struct |
| T8 | The value type of the eighth field. | struct |
| T9 | The value type of the ninth field. | struct |

## Inheritance tree
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md)

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateTypedEnumerationAsync(int)](#createtypedenumerationasyncint-method) | ValueTask&lt;IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;&gt; | Creates an enumeration. |
---
### CreateTypedEnumerationAsync(int) Method

Creates an enumeration.
```c#
ValueTask<IDataGeneratorTupleFieldEnumeration<T1, T2, T3, T4, T5, T6, T7, T8, T9>> CreateTypedEnumerationAsync
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



