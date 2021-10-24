

# mxProject.Devs.DataGeneration Namespace

[Classes](#Classes)&nbsp;&nbsp;
[ValueTypes](#ValueTypes)&nbsp;&nbsp;
[Interfaces](#Interfaces)&nbsp;&nbsp;
[Delegates](#Delegates)&nbsp;&nbsp;

## Classes
|Type|Summary|
|:--|:--|
| [DataGenerator](../mxProject.Devs.DataGeneration/DataGenerator.md) | DataGenerator. |
| [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) | DataGeneratorBuilder. |
| [DataGeneratorBuilderExtensions](../mxProject.Devs.DataGeneration/DataGeneratorBuilderExtensions.md) | Extension methods for [DataGeneratorBuilder](../mxProject.Devs.DataGeneration/DataGeneratorBuilder.md) . |
| [DataGeneratorContext](../mxProject.Devs.DataGeneration/DataGeneratorContext.md) | Context that holds the state of the data generation process. |
| [DataGeneratorFieldException](../mxProject.Devs.DataGeneration/DataGeneratorFieldException.md) | Exception indicating that the field definition is incorrect. |
| [DataGeneratorFieldFactory](../mxProject.Devs.DataGeneration/DataGeneratorFieldFactory.md) | Generate fields for DataGenerator. |
| [DataGeneratorFieldInfo](../mxProject.Devs.DataGeneration/DataGeneratorFieldInfo.md) | Field information. |
| [DefaultDbProvider](../mxProject.Devs.DataGeneration/DefaultDbProvider.md) | Default DbProvider. Use System.Data.OleDb. |
| [DefaultRandomGenerator](../mxProject.Devs.DataGeneration/DefaultRandomGenerator.md) | Random value generation logic. |
| [DefaultStringConverter](../mxProject.Devs.DataGeneration/DefaultStringConverter.md) | Default string converter. |
| [EnumerableExtensions](../mxProject.Devs.DataGeneration/EnumerableExtensions.md) | Entension methods for System.Collections.Generic.IEnumerable`1 . |
| [EnumerableFactory](../mxProject.Devs.DataGeneration/EnumerableFactory.md) | Enumeration Factory. |
| [FieldValueConverter](../mxProject.Devs.DataGeneration/FieldValueConverter.md) | Field value converter. |
| [IDataRecordExtensions](../mxProject.Devs.DataGeneration/IDataRecordExtensions.md) | Extension methods for System.Data.IDataRecord . |
| [IStringConverterExtensions](../mxProject.Devs.DataGeneration/IStringConverterExtensions.md) | Extension methods for [IStringConverter](../mxProject.Devs.DataGeneration/IStringConverter.md) . |
| [MathEx](../mxProject.Devs.DataGeneration/MathEx.md) | Mathematical methods. |
| [StringDictionaryExtensions](../mxProject.Devs.DataGeneration/StringDictionaryExtensions.md) | Extension methods for System.Collections.Generic.IDictionary`2 . |
| [StringEnumerableExtensions](../mxProject.Devs.DataGeneration/StringEnumerableExtensions.md) | Extension methods for System.Collections.Generic.IEnumerable`1 . |
| [StringExtensions](../mxProject.Devs.DataGeneration/StringExtensions.md) | Extension methods for System.String . |
| [StringLookupExtensions](../mxProject.Devs.DataGeneration/StringLookupExtensions.md) | Extension methods for System.Linq.ILookup`2 . |

## ValueTypes
|Type|Summary|
|:--|:--|
| [StringValue](../mxProject.Devs.DataGeneration/StringValue.md) |  |


## Interfaces
|Type|Summary|
|:--|:--|
| [IDataGenerationReader](../mxProject.Devs.DataGeneration/IDataGenerationReader.md) | Provides the functionality needed for a DataReader to read the generated values. |
| [IDataGenerationRecord](../mxProject.Devs.DataGeneration/IDataGenerationRecord.md) | Provides the functionality needed for a DataRecord to read the generated values. |
| [IDataGeneratorAdditionalField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalField.md) | Provides the required functionality for an additional field. |
| [IDataGeneratorAdditionalTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorAdditionalTupleField.md) | Provides the required functionality for an additional tuple field. |
| [IDataGeneratorField](../mxProject.Devs.DataGeneration/IDataGeneratorField.md) | Provides the required functionality for a data generator field. |
| [IDataGeneratorField&lt;T&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorField`1.md) | Provides the required functionality for a data generator field. |
| [IDataGeneratorFieldEnumeration](../mxProject.Devs.DataGeneration/IDataGeneratorFieldEnumeration.md) | Provides the required functionality for a data generator field. |
| [IDataGeneratorFieldEnumeration&lt;T&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorFieldEnumeration`1.md) | Provides the required functionality for a data generator field. |
| [IDataGeneratorFieldInfo](../mxProject.Devs.DataGeneration/IDataGeneratorFieldInfo.md) | Provides definitions for data generator field. |
| [IDataGeneratorTupleField](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`2.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2, T3&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`3.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2, T3, T4&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`4.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2, T3, T4, T5&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`5.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`6.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6, T7&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`7.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`8.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleField&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleField`9.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`2.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`3.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`4.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4, T5&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`5.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4, T5, T6&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`6.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4, T5, T6, T7&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`7.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`8.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDataGeneratorTupleFieldEnumeration&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;](../mxProject.Devs.DataGeneration/IDataGeneratorTupleFieldEnumeration`9.md) | Provides the functionality needed for fields that generate tuples of multiple values. |
| [IDbProvider](../mxProject.Devs.DataGeneration/IDbProvider.md) | Provides the functionality needed to activate database objects. |
| [IRandomGenerator](../mxProject.Devs.DataGeneration/IRandomGenerator.md) | Provides the functionality needed to generate random values. |
| [IStringConverter](../mxProject.Devs.DataGeneration/IStringConverter.md) | Provides the functionality needed to convert string values. |

## Delegates
|Type|Summary|
|:--|:--|
| [EnumerationCreator](../mxProject.Devs.DataGeneration/EnumerationCreator.md) | Indicates a method that generates an enumeration. |
| [EnumerationCreator&lt;T&gt;](../mxProject.Devs.DataGeneration/EnumerationCreator`1.md) | Indicates a method that generates an enumeration. |
| [StringEnumerationCreator](../mxProject.Devs.DataGeneration/StringEnumerationCreator.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`2.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2, T3&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`3.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2, T3, T4&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`4.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2, T3, T4, T5&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`5.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`6.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6, T7&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`7.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`8.md) | Indicates a method that generates an enumeration. |
| [TupleEnumerationCreator&lt;T1, T2, T3, T4, T5, T6, T7, T8, T9&gt;](../mxProject.Devs.DataGeneration/TupleEnumerationCreator`9.md) | Indicates a method that generates an enumeration. |

