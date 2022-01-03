using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="DataGenerator"/>.
    /// </summary>
    public static class DataGeneratorExtensions
    {

        #region single mapping

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <returns></returns>
        public static IEnumerable<TReturn> Map<TReturn>(this DataGenerator generator)
        {
            foreach (var model in Map(generator, typeof(TReturn)))
            {
                yield return (TReturn)model;
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="returnType">The type of objects to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> Map(this DataGenerator generator, Type returnType)
        {
            using var reader = new MappingDataReader(generator.AsDataReader());

            if (reader.Read())
            {
                var deserializer = SqlMapper.GetTypeDeserializer(returnType, reader, 0, -1, false);
                var underlayType = Nullable.GetUnderlyingType(returnType) ?? returnType;

                do
                {
                    object? obj = deserializer(reader);
                    yield return ChangeType(obj, underlayType)!;
                }
                while (reader.Read());
            }
        }

        #endregion

        #region multi mapping (2 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            Func<TMapping1, TMapping2, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            Func<TMapping1, TMapping2, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region multi mapping (3 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TMapping3, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            MappingFieldIndexInfo[] mappingIndexes3,
            Func<TMapping1, TMapping2, TMapping3, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2),
                (typeof(TMapping3), mappingIndexes3)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Type mappingType3,
            MappingFieldIndexInfo[] mappingIndexes3,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2),
                (mappingType3, mappingIndexes3)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TMapping3, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            MappingFieldNameInfo[] mappingNames3,
            Func<TMapping1, TMapping2, TMapping3, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2),
                (typeof(TMapping3), mappingNames3)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Type mappingType3,
            MappingFieldNameInfo[] mappingNames3,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2),
                (mappingType3, mappingNames3)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region multi mapping (4 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TMapping3, TMapping4, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            MappingFieldIndexInfo[] mappingIndexes3,
            MappingFieldIndexInfo[] mappingIndexes4,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2),
                (typeof(TMapping3), mappingIndexes3),
                (typeof(TMapping4), mappingIndexes4)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Type mappingType3,
            MappingFieldIndexInfo[] mappingIndexes3,
            Type mappingType4,
            MappingFieldIndexInfo[] mappingIndexes4,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2),
                (mappingType3, mappingIndexes3),
                (mappingType4, mappingIndexes4)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TMapping3, TMapping4, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            MappingFieldNameInfo[] mappingNames3,
            MappingFieldNameInfo[] mappingNames4,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2),
                (typeof(TMapping3), mappingNames3),
                (typeof(TMapping4), mappingNames4)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Type mappingType3,
            MappingFieldNameInfo[] mappingNames3,
            Type mappingType4,
            MappingFieldNameInfo[] mappingNames4,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2),
                (mappingType3, mappingNames3),
                (mappingType4, mappingNames4)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region multi mapping (5 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            MappingFieldIndexInfo[] mappingIndexes3,
            MappingFieldIndexInfo[] mappingIndexes4,
            MappingFieldIndexInfo[] mappingIndexes5,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2),
                (typeof(TMapping3), mappingIndexes3),
                (typeof(TMapping4), mappingIndexes4),
                (typeof(TMapping5), mappingIndexes5)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Type mappingType3,
            MappingFieldIndexInfo[] mappingIndexes3,
            Type mappingType4,
            MappingFieldIndexInfo[] mappingIndexes4,
            Type mappingType5,
            MappingFieldIndexInfo[] mappingIndexes5,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2),
                (mappingType3, mappingIndexes3),
                (mappingType4, mappingIndexes4),
                (mappingType5, mappingIndexes5)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            MappingFieldNameInfo[] mappingNames3,
            MappingFieldNameInfo[] mappingNames4,
            MappingFieldNameInfo[] mappingNames5,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2),
                (typeof(TMapping3), mappingNames3),
                (typeof(TMapping4), mappingNames4),
                (typeof(TMapping5), mappingNames5)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Type mappingType3,
            MappingFieldNameInfo[] mappingNames3,
            Type mappingType4,
            MappingFieldNameInfo[] mappingNames4,
            Type mappingType5,
            MappingFieldNameInfo[] mappingNames5,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2),
                (mappingType3, mappingNames3),
                (mappingType4, mappingNames4),
                (mappingType5, mappingNames5)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region multi mapping (6 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            MappingFieldIndexInfo[] mappingIndexes3,
            MappingFieldIndexInfo[] mappingIndexes4,
            MappingFieldIndexInfo[] mappingIndexes5,
            MappingFieldIndexInfo[] mappingIndexes6,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2),
                (typeof(TMapping3), mappingIndexes3),
                (typeof(TMapping4), mappingIndexes4),
                (typeof(TMapping5), mappingIndexes5),
                (typeof(TMapping6), mappingIndexes6)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Type mappingType3,
            MappingFieldIndexInfo[] mappingIndexes3,
            Type mappingType4,
            MappingFieldIndexInfo[] mappingIndexes4,
            Type mappingType5,
            MappingFieldIndexInfo[] mappingIndexes5,
            Type mappingType6,
            MappingFieldIndexInfo[] mappingIndexes6,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2),
                (mappingType3, mappingIndexes3),
                (mappingType4, mappingIndexes4),
                (mappingType5, mappingIndexes5),
                (mappingType6, mappingIndexes6)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            MappingFieldNameInfo[] mappingNames3,
            MappingFieldNameInfo[] mappingNames4,
            MappingFieldNameInfo[] mappingNames5,
            MappingFieldNameInfo[] mappingNames6,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2),
                (typeof(TMapping3), mappingNames3),
                (typeof(TMapping4), mappingNames4),
                (typeof(TMapping5), mappingNames5),
                (typeof(TMapping6), mappingNames6)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Type mappingType3,
            MappingFieldNameInfo[] mappingNames3,
            Type mappingType4,
            MappingFieldNameInfo[] mappingNames4,
            Type mappingType5,
            MappingFieldNameInfo[] mappingNames5,
            Type mappingType6,
            MappingFieldNameInfo[] mappingNames6,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2),
                (mappingType3, mappingNames3),
                (mappingType4, mappingNames4),
                (mappingType5, mappingNames5),
                (mappingType6, mappingNames6)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region multi mapping (7 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TMapping7">The type of the seventh object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingIndexes7">The indexes of fields to map to the seventh object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            MappingFieldIndexInfo[] mappingIndexes3,
            MappingFieldIndexInfo[] mappingIndexes4,
            MappingFieldIndexInfo[] mappingIndexes5,
            MappingFieldIndexInfo[] mappingIndexes6,
            MappingFieldIndexInfo[] mappingIndexes7,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2),
                (typeof(TMapping3), mappingIndexes3),
                (typeof(TMapping4), mappingIndexes4),
                (typeof(TMapping5), mappingIndexes5),
                (typeof(TMapping6), mappingIndexes6),
                (typeof(TMapping7), mappingIndexes7)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!, (TMapping7)values[6]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingType7">The type of the seventh object to map.</param>
        /// <param name="mappingIndexes7">The indexes of fields to map to the seventh object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Type mappingType3,
            MappingFieldIndexInfo[] mappingIndexes3,
            Type mappingType4,
            MappingFieldIndexInfo[] mappingIndexes4,
            Type mappingType5,
            MappingFieldIndexInfo[] mappingIndexes5,
            Type mappingType6,
            MappingFieldIndexInfo[] mappingIndexes6,
            Type mappingType7,
            MappingFieldIndexInfo[] mappingIndexes7,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2),
                (mappingType3, mappingIndexes3),
                (mappingType4, mappingIndexes4),
                (mappingType5, mappingIndexes5),
                (mappingType6, mappingIndexes6),
                (mappingType7, mappingIndexes7)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TMapping7">The type of the seventh object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingNames7">The indexes of fields to map to the seventh object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            MappingFieldNameInfo[] mappingNames3,
            MappingFieldNameInfo[] mappingNames4,
            MappingFieldNameInfo[] mappingNames5,
            MappingFieldNameInfo[] mappingNames6,
            MappingFieldNameInfo[] mappingNames7,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2),
                (typeof(TMapping3), mappingNames3),
                (typeof(TMapping4), mappingNames4),
                (typeof(TMapping5), mappingNames5),
                (typeof(TMapping6), mappingNames6),
                (typeof(TMapping7), mappingNames7)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!, (TMapping7)values[6]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingType7">The type of the seventh object to map.</param>
        /// <param name="mappingNames7">The indexes of fields to map to the seventh object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Type mappingType3,
            MappingFieldNameInfo[] mappingNames3,
            Type mappingType4,
            MappingFieldNameInfo[] mappingNames4,
            Type mappingType5,
            MappingFieldNameInfo[] mappingNames5,
            Type mappingType6,
            MappingFieldNameInfo[] mappingNames6,
            Type mappingType7,
            MappingFieldNameInfo[] mappingNames7,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2),
                (mappingType3, mappingNames3),
                (mappingType4, mappingNames4),
                (mappingType5, mappingNames5),
                (mappingType6, mappingNames6),
                (mappingType7, mappingNames7)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region multi mapping (8 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TMapping7">The type of the seventh object to map.</typeparam>
        /// <typeparam name="TMapping8">The type of the eighth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingIndexes7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingIndexes8">The indexes of fields to map to the eighth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            MappingFieldIndexInfo[] mappingIndexes3,
            MappingFieldIndexInfo[] mappingIndexes4,
            MappingFieldIndexInfo[] mappingIndexes5,
            MappingFieldIndexInfo[] mappingIndexes6,
            MappingFieldIndexInfo[] mappingIndexes7,
            MappingFieldIndexInfo[] mappingIndexes8,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2),
                (typeof(TMapping3), mappingIndexes3),
                (typeof(TMapping4), mappingIndexes4),
                (typeof(TMapping5), mappingIndexes5),
                (typeof(TMapping6), mappingIndexes6),
                (typeof(TMapping7), mappingIndexes7),
                (typeof(TMapping8), mappingIndexes8)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!, (TMapping7)values[6]!, (TMapping8)values[7]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingType7">The type of the seventh object to map.</param>
        /// <param name="mappingIndexes7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingType8">The type of the eighth object to map.</param>
        /// <param name="mappingIndexes8">The indexes of fields to map to the eighth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Type mappingType3,
            MappingFieldIndexInfo[] mappingIndexes3,
            Type mappingType4,
            MappingFieldIndexInfo[] mappingIndexes4,
            Type mappingType5,
            MappingFieldIndexInfo[] mappingIndexes5,
            Type mappingType6,
            MappingFieldIndexInfo[] mappingIndexes6,
            Type mappingType7,
            MappingFieldIndexInfo[] mappingIndexes7,
            Type mappingType8,
            MappingFieldIndexInfo[] mappingIndexes8,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2),
                (mappingType3, mappingIndexes3),
                (mappingType4, mappingIndexes4),
                (mappingType5, mappingIndexes5),
                (mappingType6, mappingIndexes6),
                (mappingType7, mappingIndexes7),
                (mappingType8, mappingIndexes8)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TMapping7">The type of the seventh object to map.</typeparam>
        /// <typeparam name="TMapping8">The type of the eighth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingNames7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingNames8">The indexes of fields to map to the eighth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            MappingFieldNameInfo[] mappingNames3,
            MappingFieldNameInfo[] mappingNames4,
            MappingFieldNameInfo[] mappingNames5,
            MappingFieldNameInfo[] mappingNames6,
            MappingFieldNameInfo[] mappingNames7,
            MappingFieldNameInfo[] mappingNames8,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2),
                (typeof(TMapping3), mappingNames3),
                (typeof(TMapping4), mappingNames4),
                (typeof(TMapping5), mappingNames5),
                (typeof(TMapping6), mappingNames6),
                (typeof(TMapping7), mappingNames7),
                (typeof(TMapping8), mappingNames8)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!, (TMapping7)values[6]!, (TMapping8)values[7]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingType7">The type of the seventh object to map.</param>
        /// <param name="mappingNames7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingType8">The type of the eighth object to map.</param>
        /// <param name="mappingNames8">The indexes of fields to map to the eighth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Type mappingType3,
            MappingFieldNameInfo[] mappingNames3,
            Type mappingType4,
            MappingFieldNameInfo[] mappingNames4,
            Type mappingType5,
            MappingFieldNameInfo[] mappingNames5,
            Type mappingType6,
            MappingFieldNameInfo[] mappingNames6,
            Type mappingType7,
            MappingFieldNameInfo[] mappingNames7,
            Type mappingType8,
            MappingFieldNameInfo[] mappingNames8,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2),
                (mappingType3, mappingNames3),
                (mappingType4, mappingNames4),
                (mappingType5, mappingNames5),
                (mappingType6, mappingNames6),
                (mappingType7, mappingNames7),
                (mappingType8, mappingNames8)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region multi mapping (9 objects)

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TMapping7">The type of the seventh object to map.</typeparam>
        /// <typeparam name="TMapping8">The type of the eighth object to map.</typeparam>
        /// <typeparam name="TMapping9">The type of the ninth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingIndexes7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingIndexes8">The indexes of fields to map to the eighth object.</param>
        /// <param name="mappingIndexes9">The indexes of fields to map to the ninth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldIndex<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TMapping9, TReturn>(
            this DataGenerator generator,
            MappingFieldIndexInfo[] mappingIndexes1,
            MappingFieldIndexInfo[] mappingIndexes2,
            MappingFieldIndexInfo[] mappingIndexes3,
            MappingFieldIndexInfo[] mappingIndexes4,
            MappingFieldIndexInfo[] mappingIndexes5,
            MappingFieldIndexInfo[] mappingIndexes6,
            MappingFieldIndexInfo[] mappingIndexes7,
            MappingFieldIndexInfo[] mappingIndexes8,
            MappingFieldIndexInfo[] mappingIndexes9,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TMapping9, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingIndexes1),
                (typeof(TMapping2), mappingIndexes2),
                (typeof(TMapping3), mappingIndexes3),
                (typeof(TMapping4), mappingIndexes4),
                (typeof(TMapping5), mappingIndexes5),
                (typeof(TMapping6), mappingIndexes6),
                (typeof(TMapping7), mappingIndexes7),
                (typeof(TMapping8), mappingIndexes8),
                (typeof(TMapping9), mappingIndexes9)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!, (TMapping7)values[6]!, (TMapping8)values[7]!, (TMapping9)values[8]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingIndexes1">The indexes of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingIndexes2">The indexes of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingIndexes3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingIndexes4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingIndexes5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingIndexes6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingType7">The type of the seventh object to map.</param>
        /// <param name="mappingIndexes7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingType8">The type of the eighth object to map.</param>
        /// <param name="mappingIndexes8">The indexes of fields to map to the eighth object.</param>
        /// <param name="mappingType9">The type of the ninth object to map.</param>
        /// <param name="mappingIndexes9">The indexes of fields to map to the ninth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldIndex(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldIndexInfo[] mappingIndexes1,
            Type mappingType2,
            MappingFieldIndexInfo[] mappingIndexes2,
            Type mappingType3,
            MappingFieldIndexInfo[] mappingIndexes3,
            Type mappingType4,
            MappingFieldIndexInfo[] mappingIndexes4,
            Type mappingType5,
            MappingFieldIndexInfo[] mappingIndexes5,
            Type mappingType6,
            MappingFieldIndexInfo[] mappingIndexes6,
            Type mappingType7,
            MappingFieldIndexInfo[] mappingIndexes7,
            Type mappingType8,
            MappingFieldIndexInfo[] mappingIndexes8,
            Type mappingType9,
            MappingFieldIndexInfo[] mappingIndexes9,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingIndexes1),
                (mappingType2, mappingIndexes2),
                (mappingType3, mappingIndexes3),
                (mappingType4, mappingIndexes4),
                (mappingType5, mappingIndexes5),
                (mappingType6, mappingIndexes6),
                (mappingType7, mappingIndexes7),
                (mappingType8, mappingIndexes8),
                (mappingType9, mappingIndexes9)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <typeparam name="TMapping1">The type of the first object to map.</typeparam>
        /// <typeparam name="TMapping2">The type of the second object to map.</typeparam>
        /// <typeparam name="TMapping3">The type of the third object to map.</typeparam>
        /// <typeparam name="TMapping4">The type of the fourth object to map.</typeparam>
        /// <typeparam name="TMapping5">The type of the fifth object to map.</typeparam>
        /// <typeparam name="TMapping6">The type of the sixth object to map.</typeparam>
        /// <typeparam name="TMapping7">The type of the seventh object to map.</typeparam>
        /// <typeparam name="TMapping8">The type of the eighth object to map.</typeparam>
        /// <typeparam name="TMapping9">The type of the ninth object to map.</typeparam>
        /// <typeparam name="TReturn">The type of objects to enumerate.</typeparam>
        /// <param name="generator"></param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingNames7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingNames8">The indexes of fields to map to the eighth object.</param>
        /// <param name="mappingNames9">The indexes of fields to map to the ninth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<TReturn> MapByFieldName<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TMapping9, TReturn>(
            this DataGenerator generator,
            MappingFieldNameInfo[] mappingNames1,
            MappingFieldNameInfo[] mappingNames2,
            MappingFieldNameInfo[] mappingNames3,
            MappingFieldNameInfo[] mappingNames4,
            MappingFieldNameInfo[] mappingNames5,
            MappingFieldNameInfo[] mappingNames6,
            MappingFieldNameInfo[] mappingNames7,
            MappingFieldNameInfo[] mappingNames8,
            MappingFieldNameInfo[] mappingNames9,
            Func<TMapping1, TMapping2, TMapping3, TMapping4, TMapping5, TMapping6, TMapping7, TMapping8, TMapping9, TReturn> selector
            )
        {
            var mappings = new[]
            {
                (typeof(TMapping1), mappingNames1),
                (typeof(TMapping2), mappingNames2),
                (typeof(TMapping3), mappingNames3),
                (typeof(TMapping4), mappingNames4),
                (typeof(TMapping5), mappingNames5),
                (typeof(TMapping6), mappingNames6),
                (typeof(TMapping7), mappingNames7),
                (typeof(TMapping8), mappingNames8),
                (typeof(TMapping9), mappingNames9)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector((TMapping1)values[0]!, (TMapping2)values[1]!, (TMapping3)values[2]!, (TMapping4)values[3]!, (TMapping5)values[4]!, (TMapping6)values[5]!, (TMapping7)values[6]!, (TMapping8)values[7]!, (TMapping9)values[8]!);
            }
        }

        /// <summary>
        /// Enumerates as an object of the specified type.
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="mappingType1">The type of the first object to map.</param>
        /// <param name="mappingNames1">The names of fields to map to the first object.</param>
        /// <param name="mappingType2">The type of the second object to map.</param>
        /// <param name="mappingNames2">The names of fields to map to the second object.</param>
        /// <param name="mappingType3">The type of the third object to map.</param>
        /// <param name="mappingNames3">The indexes of fields to map to the third object.</param>
        /// <param name="mappingType4">The type of the fourth object to map.</param>
        /// <param name="mappingNames4">The indexes of fields to map to the fourth object.</param>
        /// <param name="mappingType5">The type of the fifth object to map.</param>
        /// <param name="mappingNames5">The indexes of fields to map to the fifth object.</param>
        /// <param name="mappingType6">The type of the sixth object to map.</param>
        /// <param name="mappingNames6">The indexes of fields to map to the sixth object.</param>
        /// <param name="mappingType7">The type of the seventh object to map.</param>
        /// <param name="mappingNames7">The indexes of fields to map to the seventh object.</param>
        /// <param name="mappingType8">The type of the eighth object to map.</param>
        /// <param name="mappingNames8">The indexes of fields to map to the eighth object.</param>
        /// <param name="mappingType9">The type of the ninth object to map.</param>
        /// <param name="mappingNames9">The indexes of fields to map to the ninth object.</param>
        /// <param name="selector">The method that returns an object to enumerate.</param>
        /// <returns></returns>
        public static IEnumerable<object> MapByFieldName(
            this DataGenerator generator,
            Type mappingType1,
            MappingFieldNameInfo[] mappingNames1,
            Type mappingType2,
            MappingFieldNameInfo[] mappingNames2,
            Type mappingType3,
            MappingFieldNameInfo[] mappingNames3,
            Type mappingType4,
            MappingFieldNameInfo[] mappingNames4,
            Type mappingType5,
            MappingFieldNameInfo[] mappingNames5,
            Type mappingType6,
            MappingFieldNameInfo[] mappingNames6,
            Type mappingType7,
            MappingFieldNameInfo[] mappingNames7,
            Type mappingType8,
            MappingFieldNameInfo[] mappingNames8,
            Type mappingType9,
            MappingFieldNameInfo[] mappingNames9,
            Func<object?[], object> selector
            )
        {
            var mappings = new[]
            {
                (mappingType1, mappingNames1),
                (mappingType2, mappingNames2),
                (mappingType3, mappingNames3),
                (mappingType4, mappingNames4),
                (mappingType5, mappingNames5),
                (mappingType6, mappingNames6),
                (mappingType7, mappingNames7),
                (mappingType8, mappingNames8),
                (mappingType9, mappingNames9)
            };

            foreach (var values in EnumerateObjects(generator, mappings))
            {
                yield return selector(values);
            }
        }

        #endregion

        #region reading objects

        /// <summary>
        /// Reads data from the specified data generator and enumerates it as an object of the specified type.
        /// </summary>
        /// <param name="generator">The data generator.</param>
        /// <param name="mappingTypes">Combinations of mapping type and fields.</param>
        /// <returns></returns>
        private static IEnumerable<object?[]> EnumerateObjects(DataGenerator generator, (Type Type, MappingFieldIndexInfo[] FieldIndexes)[] mappingTypes)
        {
            using IDataReader reader = generator.AsDataReader();

            (Type, IDataReader)[] mappingReaders = new (Type, IDataReader)[mappingTypes.Length];

            for (int i = 0; i < mappingTypes.Length; ++i)
            {
                mappingReaders[i] = (mappingTypes[i].Type, new MappingDataReader(reader, mappingTypes[i].FieldIndexes));
            }

            return EnumerateObjects(reader, mappingReaders);
        }

        /// <summary>
        /// Reads data from the specified data generator and enumerates it as an object of the specified type.
        /// </summary>
        /// <param name="generator">The data generator.</param>
        /// <param name="mappingTypes">Combinations of mapping type and fields.</param>
        /// <returns></returns>
        private static IEnumerable<object?[]> EnumerateObjects(DataGenerator generator, (Type Type, MappingFieldNameInfo[] FieldNames)[] mappingTypes)
        {
            using IDataReader reader = generator.AsDataReader();

            (Type, IDataReader)[] mappingReaders = new (Type, IDataReader)[mappingTypes.Length];
            
            for (int i = 0; i < mappingTypes.Length; ++i)
            {
                mappingReaders[i] = (mappingTypes[i].Type, new MappingDataReader(reader, mappingTypes[i].FieldNames));
            }

            return EnumerateObjects(reader, mappingReaders);
        }

        /// <summary>
        /// Reads data from the specified data reader and enumerates it as an object of the specified type.
        /// </summary>
        /// <param name="actualReader">The data reader.</param>
        /// <param name="mappingReaders">Combinations of mapping type and data reader.</param>
        /// <returns></returns>
        private static IEnumerable<object?[]> EnumerateObjects(IDataReader actualReader, (Type Type, IDataReader DataReader)[] mappingReaders)
        {
            if (actualReader.Read())
            {
                Func<IDataReader, object>[] deserializers = new Func<IDataReader, object>[mappingReaders.Length];
                Type[] underlayTypes = new Type[mappingReaders.Length];

                for (int i = 0; i < mappingReaders.Length; ++i)
                {
                    deserializers[i] = SqlMapper.GetTypeDeserializer(mappingReaders[i].Type, mappingReaders[i].DataReader, 0, -1, false);
                    underlayTypes[i] = Nullable.GetUnderlyingType(mappingReaders[i].Type) ?? mappingReaders[i].Type;
                }

                do
                {
                    object?[] values = new object?[deserializers.Length];

                    for (int i = 0; i < deserializers.Length; ++i)
                    {
                        values[i] = ChangeType(deserializers[i](mappingReaders[i].DataReader), underlayTypes[i]);
                    }

                    yield return values;
                }
                while (actualReader.Read());
            }
        }

        #endregion

        #region convertion

        /// <summary>
        /// Changes the type of the specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object? ChangeType(object? obj, Type type)
        {
            if (obj == null || obj.GetType() == type)
            {
                return obj;
            }
            else
            {
                return Convert.ChangeType(obj, type, System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        #endregion

    }

}
