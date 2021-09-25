


# IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt; Interface



Provides the functionality needed for fields that generate tuples of multiple values.





## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| T1 | The value type of the first field. | struct |
| T2 | The value type of the second field. | struct |
| T3 | The value type of the third field. | struct |
| T4 | The value type of the fourth field. | struct |

## Inheritance tree
## Implemented interfaces
* [mxProject.Devs.DataGeneration.IDataGeneratorTupleFieldEnumeration](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration.md)
* System.IDisposable

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [GetTypedValues](#gettypedvalues-method) | (T1?, T2?, T3?, T4?) | Gets the generated values. |
---
### GetTypedValues Method

Gets the generated values.
```c#
(T1?, T2?, T3?, T4?) GetTypedValues()
```
#### Return type


[Go to methods](#Methods)



