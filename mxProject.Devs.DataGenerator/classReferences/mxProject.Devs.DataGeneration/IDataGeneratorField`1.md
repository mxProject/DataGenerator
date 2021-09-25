


# IDataGeneratorField&lt;T&gt; Interface



Provides the required functionality for a data generator field.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T |  | struct |

## Inheritance tree
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md)

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateTypedEnumerationAsync(int)](#createtypedenumerationasyncint-method) | ValueTask&lt;IDataGeneratorFieldEnumeration&lt;T&gt;&gt; | Creates an enumeration. |
---
### CreateTypedEnumerationAsync(int) Method

Creates an enumeration.
```c#
ValueTask<IDataGeneratorFieldEnumeration<T>> CreateTypedEnumerationAsync
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



