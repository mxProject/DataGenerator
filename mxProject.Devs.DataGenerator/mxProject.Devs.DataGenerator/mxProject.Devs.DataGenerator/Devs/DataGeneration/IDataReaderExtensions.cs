using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace mxProject.Devs.DataGeneration
{

    internal static class IDataReaderExtensions
    {

        internal static IDataGenerationReader AsDataGenerationReader(this IDataReader reader)
        {
            if (reader is IDataGenerationReader generationReader)
            {
                return generationReader;
            }
            else
            {
                return new DataReaders.DataGenerationReaderWrapper(reader);
            }
        }

        internal static string[] GetAllFieldNames(this IDataReader reader)
        {
            string[] names = new string[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                names[i] = reader.GetName(i);
            }

            return names;
        }

        internal static Type[] GetAllValueTypes(this IDataReader reader)
        {
            Type[] types = new Type[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                types[i] = DataGeneratorUtility.GetFieldValueType(reader.GetFieldType(i));
            }

            return types;
        }

        internal static string[] GetNames(this IDataReader reader, int[] fieldIndexes)
        {
            string[] names = new string[fieldIndexes.Length];

            for (int i = 0; i < fieldIndexes.Length; ++i)
            {
                names[i] = reader.GetName(fieldIndexes[i]);
            }

            return names;
        }

        internal static int[] GetOrdinals(this IDataReader reader, string[] fieldNames)
        {
            int[] indexes = new int[fieldNames.Length];

            for (int i = 0; i < fieldNames.Length; ++i)
            {
                indexes[i] = reader.GetOrdinal(fieldNames[i]);
            }

            return indexes;
        }

        internal static Type GetValueType(this IDataReader reader, int fieldIndex)
        {
            return DataGeneratorUtility.GetFieldValueType(reader.GetFieldType(fieldIndex));
        }

        internal static Type GetValueType(this IDataReader reader, string fieldName)
        {
            return DataGeneratorUtility.GetFieldValueType(reader.GetFieldType(reader.GetOrdinal(fieldName)));
        }

        internal static Type[] GetValueTypes(this IDataReader reader, int[] fieldIndexes)
        {
            Type[] types = new Type[fieldIndexes.Length];

            for (int i = 0; i < fieldIndexes.Length; ++i)
            {
                types[i] = DataGeneratorUtility.GetFieldValueType(reader.GetFieldType(fieldIndexes[i]));
            }

            return types;
        }

        internal static Type[] GetValueTypes(this IDataReader reader, string[] fieldNames)
        {
            Type[] types = new Type[fieldNames.Length];

            for (int i = 0; i < fieldNames.Length; ++i)
            {
                types[i] = DataGeneratorUtility.GetFieldValueType(reader.GetFieldType(reader.GetOrdinal(fieldNames[i])));
            }

            return types;
        }


        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary ToDictionary(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
        {
            static IDictionary Invoke(string methodName, Type[] genericTypes, IDataGenerationReader reader, int[] keyFieldIndexes, int[] valueFieldIndexes)
            {
                var method = typeof(IDataReaderExtensions).GetGenericMethod(methodName, typeof(IDataGenerationReader), typeof(int[]), typeof(int[]));
                return typeof(IDataReaderExtensions).InvokeStaticGenericMethod<IDictionary>(method, genericTypes, reader, keyFieldIndexes, valueFieldIndexes)!;
            }

            var keyTypes = reader.GetValueTypes(keyFieldIndexes);
            var valueTypes = reader.GetValueTypes(valueFieldIndexes);
            Type[] genericTypes;

            switch (keyTypes.Length)
            {
                case 1:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 2:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 3:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 4:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 5:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 6:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 7:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 8:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;

                case 9:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value1), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value2), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value3), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value4), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value5), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value6), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value7), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value8), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value9), genericTypes, reader, keyFieldIndexes, valueFieldIndexes);

                        default:
                            break;
                    }

                    break;
            }

            throw new NotSupportedException("The specified number of fields is not supported.");
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary ToDictionary(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
        {
            static IDictionary Invoke(string methodName, Type[] genericTypes, IDataGenerationReader reader, string[] keyFieldNames, string[] valueFieldNames)
            {
                var method = typeof(IDataReaderExtensions).GetGenericMethod(methodName, typeof(IDataGenerationReader), typeof(string[]), typeof(string[]));
                return typeof(IDataReaderExtensions).InvokeStaticGenericMethod<IDictionary>(method, genericTypes, reader, keyFieldNames, valueFieldNames)!;
            }

            var keyTypes = reader.GetValueTypes(keyFieldNames);
            var valueTypes = reader.GetValueTypes(valueFieldNames);
            Type[] genericTypes;

            switch (keyTypes.Length)
            {
                case 1:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key1_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 2:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key2_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 3:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key3_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 4:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key4_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 5:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key5_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 6:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key6_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 7:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key7_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 8:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key8_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;

                case 9:

                    switch (valueTypes.Length)
                    {
                        case 1:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value1), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 2:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value2), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 3:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value3), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 4:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value4), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 5:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value5), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 6:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value6), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 7:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value7), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 8:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value8), genericTypes, reader, keyFieldNames, valueFieldNames);

                        case 9:
                            genericTypes = new[]
                            {
                                keyTypes[0], keyTypes[1], keyTypes[2], keyTypes[3], keyTypes[4], keyTypes[5], keyTypes[6], keyTypes[7], keyTypes[8],
                                valueTypes[0], valueTypes[1], valueTypes[2], valueTypes[3], valueTypes[4], valueTypes[5], valueTypes[6], valueTypes[7], valueTypes[8]
                            };
                            return Invoke(nameof(ToDictionary_Key9_Value9), genericTypes, reader, keyFieldNames, valueFieldNames);

                        default:
                            break;
                    }

                    break;
            }

            throw new NotSupportedException("The specified number of fields is not supported.");
        }



        #region ToDictionary<TKey, TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> ToDictionary_Key1_Value1<TKey, TValue>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            int valueFieldIndex
            )
            where TKey : struct
            where TValue : struct
        {
            Dictionary<TKey, TValue?> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var value = reader.GetRawValue<TValue>(valueFieldIndex);

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = value;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> ToDictionary_Key1_Value1<TKey, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key1_Value1<TKey, TValue>(
                reader,
                keyFieldIndexes[0],
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> ToDictionary_Key1_Value1<TKey, TValue>(
            this IDataGenerationReader reader,
            string keyFieldName,
            string valueFieldName
            )
            where TKey : struct
            where TValue : struct
        {
            Dictionary<TKey, TValue?> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawValue<TValue>(valueFieldName);

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, TValue?> ToDictionary_Key1_Value1<TKey, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key1_Value1<TKey, TValue>(
                reader,
                keyFieldNames[0],
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> ToDictionary_Key1_Value2<TKey, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> ToDictionary_Key1_Value2<TKey, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key1_Value2<TKey, TValue1, TValue2>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> ToDictionary_Key1_Value2<TKey, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?)> ToDictionary_Key1_Value2<TKey, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key1_Value2<TKey, TValue1, TValue2>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> ToDictionary_Key1_Value3<TKey, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> ToDictionary_Key1_Value3<TKey, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key1_Value3<TKey, TValue1, TValue2, TValue3>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> ToDictionary_Key1_Value3<TKey, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> ToDictionary_Key1_Value3<TKey, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key1_Value3<TKey, TValue1, TValue2, TValue3>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key1_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 5);

            return ToDictionary_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key1_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key1_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key1_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key1_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndex"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key1_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int keyFieldIndex,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldIndex);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                AssertKeyValue(key, keyFieldIndex);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key1_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 1);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key1_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                keyFieldIndexes[0],
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldName"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key1_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string keyFieldName,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawValue<TKey>(keyFieldName);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                AssertKeyValue(key, keyFieldName);

                dic[key!.Value] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key1_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 1);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key1_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                keyFieldNames[0],
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> ToDictionary_Key2_Value1<TKey1, TKey2, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> ToDictionary_Key2_Value1<TKey1, TKey2, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key2_Value1<TKey1, TKey2, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> ToDictionary_Key2_Value1<TKey1, TKey2, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), TValue?> ToDictionary_Key2_Value1<TKey1, TKey2, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key2_Value1<TKey1, TKey2, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> ToDictionary_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> ToDictionary_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> ToDictionary_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> ToDictionary_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key2_Value2<TKey1, TKey2, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 5);

            return ToDictionary_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldIndexes.field1, keyFieldIndexes.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 2);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2>(keyFieldNames.field1, keyFieldNames.field2);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 2);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?, TKey3?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> ToDictionary_Key3_Value1<TKey1, TKey2, TKey3, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> ToDictionary_Key3_Value1<TKey1, TKey2, TKey3, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key3_Value1<TKey1, TKey2, TKey3, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> ToDictionary_Key3_Value1<TKey1, TKey2, TKey3, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> ToDictionary_Key3_Value1<TKey1, TKey2, TKey3, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key3_Value1<TKey1, TKey2, TKey3, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> ToDictionary_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> ToDictionary_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> ToDictionary_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> ToDictionary_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 5);

            return ToDictionary_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldIndexes.field1, keyFieldIndexes.field2, keyFieldIndexes.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 3);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames.field1, keyFieldNames.field2, keyFieldNames.field3);
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 3);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> ToDictionary_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> ToDictionary_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> ToDictionary_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> ToDictionary_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key4_Value1<TKey1, TKey2, TKey3, TKey4, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> ToDictionary_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> ToDictionary_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> ToDictionary_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> ToDictionary_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 5);

            return ToDictionary_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 4);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 4);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> ToDictionary_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> ToDictionary_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> ToDictionary_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> ToDictionary_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key5_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> ToDictionary_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> ToDictionary_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> ToDictionary_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> ToDictionary_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 5);

            return ToDictionary_Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 5);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 5);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> ToDictionary_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> ToDictionary_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> ToDictionary_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> ToDictionary_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key6_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> ToDictionary_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> ToDictionary_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> ToDictionary_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> ToDictionary_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 6);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 6);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> ToDictionary_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> ToDictionary_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> ToDictionary_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> ToDictionary_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key7_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> ToDictionary_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> ToDictionary_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> ToDictionary_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> ToDictionary_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 7);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 7);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> ToDictionary_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> ToDictionary_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> ToDictionary_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> ToDictionary_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key8_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> ToDictionary_Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> ToDictionary_Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> ToDictionary_Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> ToDictionary_Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 8);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 8);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion


        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndex"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> ToDictionary_Key9_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            int valueFieldIndex
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawValue<TValue>(valueFieldIndex);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> ToDictionary_Key9_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 1);

            return ToDictionary_Key9_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                valueFieldIndexes[0]
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> ToDictionary_Key9_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            string valueFieldName
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawValue<TValue>(valueFieldName);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> ToDictionary_Key9_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 1);

            return ToDictionary_Key9_Value1<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                valueFieldNames[0]
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> ToDictionary_Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldIndexes.field1, valueFieldIndexes.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> ToDictionary_Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 2);

            return ToDictionary_Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> ToDictionary_Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2>(valueFieldNames.field1, valueFieldNames.field2);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> ToDictionary_Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 2);

            return ToDictionary_Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2, int field3) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldIndexes.field1, valueFieldIndexes.field2, valueFieldIndexes.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 3);

            return ToDictionary_Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2, string field3) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> dic = new();

            while (reader.Read())
            {
                var keys = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3>(valueFieldNames.field1, valueFieldNames.field2, valueFieldNames.field3);

                dic[keys] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> ToDictionary_Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 3);

            return ToDictionary_Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2, int field3, int field4) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 4);

            return ToDictionary_Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2, string field3, string field4) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> ToDictionary_Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 4);

            return ToDictionary_Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> ToDictionary_Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 5);

            return ToDictionary_Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 6);

            return ToDictionary_Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> ToDictionary_Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 6);

            return ToDictionary_Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 7);

            return ToDictionary_Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> ToDictionary_Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 7);

            return ToDictionary_Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 8);

            return ToDictionary_Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> ToDictionary_Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 8);

            return ToDictionary_Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7])
                );
        }

        #endregion

        #region ToDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)>

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) keyFieldIndexes,
            (int field1, int field2, int field3, int field4, int field5, int field6, int field7, int field8, int field9) valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldIndexes.field1,
                    keyFieldIndexes.field2,
                    keyFieldIndexes.field3,
                    keyFieldIndexes.field4,
                    keyFieldIndexes.field5,
                    keyFieldIndexes.field6,
                    keyFieldIndexes.field7,
                    keyFieldIndexes.field8,
                    keyFieldIndexes.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldIndexes.field1,
                    valueFieldIndexes.field2,
                    valueFieldIndexes.field3,
                    valueFieldIndexes.field4,
                    valueFieldIndexes.field5,
                    valueFieldIndexes.field6,
                    valueFieldIndexes.field7,
                    valueFieldIndexes.field8,
                    valueFieldIndexes.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldIndexes"></param>
        /// <param name="valueFieldIndexes"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            int[] keyFieldIndexes,
            int[] valueFieldIndexes
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldIndexes, 9);
            AssertFieldCount(valueFieldIndexes, 9);

            return ToDictionary_Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldIndexes[0], keyFieldIndexes[1], keyFieldIndexes[2], keyFieldIndexes[3], keyFieldIndexes[4], keyFieldIndexes[5], keyFieldIndexes[6], keyFieldIndexes[7], keyFieldIndexes[8]),
                (valueFieldIndexes[0], valueFieldIndexes[1], valueFieldIndexes[2], valueFieldIndexes[3], valueFieldIndexes[4], valueFieldIndexes[5], valueFieldIndexes[6], valueFieldIndexes[7], valueFieldIndexes[8])
                );
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) keyFieldNames,
            (string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string field9) valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            Dictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> dic = new();

            while (reader.Read())
            {
                var key = reader.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(
                    keyFieldNames.field1,
                    keyFieldNames.field2,
                    keyFieldNames.field3,
                    keyFieldNames.field4,
                    keyFieldNames.field5,
                    keyFieldNames.field6,
                    keyFieldNames.field7,
                    keyFieldNames.field8,
                    keyFieldNames.field9
                    );
                var values = reader.GetRawTuple<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                    valueFieldNames.field1,
                    valueFieldNames.field2,
                    valueFieldNames.field3,
                    valueFieldNames.field4,
                    valueFieldNames.field5,
                    valueFieldNames.field6,
                    valueFieldNames.field7,
                    valueFieldNames.field8,
                    valueFieldNames.field9
                    );

                dic[key] = values;
            }

            return dic;
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a dictionary. 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TKey9"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="reader"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="valueFieldNames"></param>
        /// <returns></returns>
        internal static IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> ToDictionary_Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            this IDataGenerationReader reader,
            string[] keyFieldNames,
            string[] valueFieldNames
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
            where TValue9 : struct
        {
            AssertFieldCount(keyFieldNames, 9);
            AssertFieldCount(valueFieldNames, 9);

            return ToDictionary_Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
                reader,
                (keyFieldNames[0], keyFieldNames[1], keyFieldNames[2], keyFieldNames[3], keyFieldNames[4], keyFieldNames[5], keyFieldNames[6], keyFieldNames[7], keyFieldNames[8]),
                (valueFieldNames[0], valueFieldNames[1], valueFieldNames[2], valueFieldNames[3], valueFieldNames[4], valueFieldNames[5], valueFieldNames[6], valueFieldNames[7], valueFieldNames[8])
                );
        }

        #endregion



        /// <summary>
        /// Reads data from the specified data reader and creates a list.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fieldIndexes"></param>
        /// <returns></returns>
        internal static IList ToList(this IDataGenerationReader reader, int[] fieldIndexes)
        {
            static IList Invoke(string methodName, Type[] genericTypes, IDataGenerationReader reader, int[] fieldIndexes)
            {
                var method = typeof(IDataReaderExtensions).GetGenericMethod(methodName, typeof(IDataGenerationReader), typeof(int[]));
                return typeof(IDataReaderExtensions).InvokeStaticGenericMethod<IList>(method, genericTypes, reader, fieldIndexes)!;
            }

            var valueTypes = reader.GetValueTypes(fieldIndexes);

            return fieldIndexes.Length switch
            {
                1 => Invoke(nameof(ToList_Field1), valueTypes, reader, fieldIndexes),
                2 => Invoke(nameof(ToList_Field2), valueTypes, reader, fieldIndexes),
                3 => Invoke(nameof(ToList_Field3), valueTypes, reader, fieldIndexes),
                4 => Invoke(nameof(ToList_Field4), valueTypes, reader, fieldIndexes),
                5 => Invoke(nameof(ToList_Field5), valueTypes, reader, fieldIndexes),
                6 => Invoke(nameof(ToList_Field6), valueTypes, reader, fieldIndexes),
                7 => Invoke(nameof(ToList_Field7), valueTypes, reader, fieldIndexes),
                8 => Invoke(nameof(ToList_Field8), valueTypes, reader, fieldIndexes),
                9 => Invoke(nameof(ToList_Field9), valueTypes, reader, fieldIndexes),
                _ => throw new NotSupportedException("The specified number of fields is not supported."),
            };
        }

        /// <summary>
        /// Reads data from the specified data reader and creates a list.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fieldNames"></param>
        /// <returns></returns>
        internal static IList ToList(this IDataGenerationReader reader, string[] fieldNames)
        {
            static IList Invoke(string methodName, Type[] genericTypes, IDataGenerationReader reader, int[] fieldIndexes)
            {
                var method = typeof(IDataReaderExtensions).GetGenericMethod(methodName, typeof(IDataGenerationReader), typeof(int[]));
                return typeof(IDataReaderExtensions).InvokeStaticGenericMethod<IList>(method, genericTypes, reader, fieldIndexes)!;
            }

            var valueTypes = reader.GetValueTypes(fieldNames);
            var fieldIndexes = reader.GetOrdinals(fieldNames);

            return fieldNames.Length switch
            {
                1 => Invoke(nameof(ToList_Field1), valueTypes, reader, fieldIndexes),
                2 => Invoke(nameof(ToList_Field2), valueTypes, reader, fieldIndexes),
                3 => Invoke(nameof(ToList_Field3), valueTypes, reader, fieldIndexes),
                4 => Invoke(nameof(ToList_Field4), valueTypes, reader, fieldIndexes),
                5 => Invoke(nameof(ToList_Field5), valueTypes, reader, fieldIndexes),
                6 => Invoke(nameof(ToList_Field6), valueTypes, reader, fieldIndexes),
                7 => Invoke(nameof(ToList_Field7), valueTypes, reader, fieldIndexes),
                8 => Invoke(nameof(ToList_Field8), valueTypes, reader, fieldIndexes),
                9 => Invoke(nameof(ToList_Field9), valueTypes, reader, fieldIndexes),
                _ => throw new NotSupportedException("The specified number of fields is not supported."),
            };
        }

        #region ToList<T>

        private static IList<T?> ToList_Field1<T>(IDataGenerationReader reader, int[] fieldIndexes)
            where T : struct
        {
            List<T?> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawValue<T>(fieldIndexes[0]));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2>

        private static IList<(T1?, T2?)> ToList_Field2<T1, T2>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
        {
            List<(T1?, T2?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2>(fieldIndexes));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2, T3>

        private static IList<(T1?, T2?, T3?)> ToList_Field3<T1, T2, T3>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            List<(T1?, T2?, T3?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2, T3>(fieldIndexes));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2, T3, T4>

        private static IList<(T1?, T2?, T3?, T4?)> ToList_Field4<T1, T2, T3, T4>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            List<(T1?, T2?, T3?, T4?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2, T3, T4>(fieldIndexes));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2, T3, T4, T5>

        private static IList<(T1?, T2?, T3?, T4?, T5?)> ToList_Field5<T1, T2, T3, T4, T5>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            List<(T1?, T2?, T3?, T4?, T5?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2, T3, T4, T5>(fieldIndexes));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2, T3, T4, T5, T6>

        private static IList<(T1?, T2?, T3?, T4?, T5?, T6?)> ToList_Field6<T1, T2, T3, T4, T5, T6>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            List<(T1?, T2?, T3?, T4?, T5?, T6?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2, T3, T4, T5, T6>(fieldIndexes));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2, T3, T4, T5, T6, T7>

        private static IList<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> ToList_Field7<T1, T2, T3, T4, T5, T6, T7>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            List<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2, T3, T4, T5, T6, T7>(fieldIndexes));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2, T3, T4, T5, T6, T7, T8>

        private static IList<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> ToList_Field8<T1, T2, T3, T4, T5, T6, T7, T8>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            List<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>(fieldIndexes));
            }

            return list;
        }

        #endregion

        #region ToList<T1, T2, T3, T4, T5, T6, T7, T8, T9>

        private static IList<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> ToList_Field9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IDataGenerationReader reader, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            List<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> list = new();

            while (reader.Read())
            {
                list.Add(reader.GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(fieldIndexes));
            }

            return list;
        }

        #endregion


        private static void AssertKeyValue<TKey>(TKey? keyValue, int keyFieldIndex)
            where TKey : struct
        {
            if (!keyValue.HasValue)
            {
                throw new InvalidOperationException($"The value of the key field is null. keyFieldIndex = {keyFieldIndex}");
            }
        }

        private static void AssertKeyValue<TKey>(TKey? keyValue, string keyFieldName)
            where TKey : struct
        {
            if (!keyValue.HasValue)
            {
                throw new InvalidOperationException($"The value of the key field is null. keyFieldName = {keyFieldName}");
            }
        }

        private static void AssertFieldCount(int[] fieldIndexes, int expectedCount)
        {
            if (fieldIndexes.Length != expectedCount)
            {
                throw new ArgumentException("The number of fields specified does not match.", nameof(fieldIndexes));
            }
        }

        private static void AssertFieldCount(string[] fieldNames, int expectedCount)
        {
            if (fieldNames.Length != expectedCount)
            {
                throw new ArgumentException("The number of fields specified does not match.", nameof(fieldNames));
            }
        }

    }

}
