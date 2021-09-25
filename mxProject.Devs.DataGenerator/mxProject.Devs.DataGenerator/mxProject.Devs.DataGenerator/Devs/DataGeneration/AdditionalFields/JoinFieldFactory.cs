﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mxProject.Devs.DataGeneration.AdditionalFields
{

    /// <summary>
    /// Creates a field that returns a value that corresponds to the generated value.
    /// </summary>
    public sealed class JoinFieldFactory
    {

        internal readonly static JoinFieldFactory Default = new JoinFieldFactory();

        #region IDictionary<TKey, TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue>(
            string keyFieldName,
            string additionalFieldName,
            IDictionary<TKey, TValue> additionalValues
            )
            where TKey : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue>(
            string keyFieldName,
            string additionalFieldName,
            IDictionary<TKey, TValue?> additionalValues
            )
            where TKey : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());
        
            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2, TValue3)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionary<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string keyFieldName,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryGetValue((TKey)key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2), TValue> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);
                    
                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey2<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2, TKey3), TValue> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), TValue> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
            string[] keyFieldNames,
            string additionalFieldName,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TValue?> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return new object?[] { found };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (key.HasAllValues() && additionalValues.TryGetValue(key.ToValueOrDefault(), out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithDictionaryKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> additionalValues)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = GetKeyTuple(rec, keyFieldNames, additionalValues);

                    if (additionalValues.TryGetValue(key, out var found))
                    {
                        return found.ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(additionalValues);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, additionalValues.GetValueTypes());

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues));
        }

        #endregion




        #region ILookup<TKey, TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of first value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue>(string keyFieldName, string additionalFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            where TKey : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, TValue?> selector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return new object?[] { selector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2, TValue3>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2, TValue3, TValue4>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldName">The key field name.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookup<TKey, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string keyFieldName, string[] additionalFieldNames, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string keyFieldName, ILookup<TKey, TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetValue(keyFieldName);

                    if (key != null && additionalValues.TryFirst((TKey)key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldName, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey2<TKey1, TKey2, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2, TKey3), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey3<TKey1, TKey2, TKey3, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2, TKey3, TKey4), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey4<TKey1, TKey2, TKey3, TKey4, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey5<TKey1, TKey2, TKey3, TKey4, TKey5, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TValue : struct
        {
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion



        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue">The type of value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue>(string[] keyFieldNames, string additionalFieldName, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, TValue?> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return new object?[] { valueSelector(found) };
                    }
                    else
                    {
                        return new object?[] { null };
                    }
                };
            }

            var fieldInfo = new DataGeneratorFieldInfo(additionalFieldName, DataGeneratorUtility.GetFieldValueType(typeof(TValue)));

            return new DataGeneratorAdditionalTupleField(new[] { fieldInfo }, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2, TValue3>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2, TValue3, TValue4>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion

        #region ILookup<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        /// <summary>
        /// Creates a field that returns the value stored in the specified dictionary.
        /// </summary>
        /// <typeparam name="TKey1">The type of first key of the additional values.</typeparam>
        /// <typeparam name="TKey2">The type of second key of the additional values.</typeparam>
        /// <typeparam name="TKey3">The type of third key of the additional values.</typeparam>
        /// <typeparam name="TKey4">The type of fourth key of the additional values.</typeparam>
        /// <typeparam name="TKey5">The type of fifth key of the additional values.</typeparam>
        /// <typeparam name="TKey6">The type of sixth key of the additional values.</typeparam>
        /// <typeparam name="TKey7">The type of seventh key of the additional values.</typeparam>
        /// <typeparam name="TKey8">The type of eighth key of the additional values.</typeparam>
        /// <typeparam name="TKey9">The type of ninth key of the additional values.</typeparam>
        /// <typeparam name="TElement">The type of element to be looked up.</typeparam>
        /// <typeparam name="TValue1">The type of first value of the additional values.</typeparam>
        /// <typeparam name="TValue2">The type of second value of the additional values.</typeparam>
        /// <typeparam name="TValue3">The type of third value of the additional values.</typeparam>
        /// <typeparam name="TValue4">The type of fourth value of the additional values.</typeparam>
        /// <typeparam name="TValue5">The type of fifth value of the additional values.</typeparam>
        /// <typeparam name="TValue6">The type of sixth value of the additional values.</typeparam>
        /// <typeparam name="TValue7">The type of seventh value of the additional values.</typeparam>
        /// <typeparam name="TValue8">The type of eighth value of the additional values.</typeparam>
        /// <typeparam name="TValue9">The type of ninth value of the additional values.</typeparam>
        /// <param name="keyFieldNames">The key field names.</param>
        /// <param name="additionalFieldNames">the field names to add.</param>
        /// <param name="additionalValues">The values of the additional fields.</param>
        /// <param name="valueSelector">The method for getting a value from a looked-up element.</param>
        /// <returns></returns>
        public DataGeneratorAdditionalTupleField WithLookupKey9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(string[] keyFieldNames, string[] additionalFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
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
            static Func<IDataGenerationRecord, object?[]> CreateValueGetter(string[] keyFieldNames, ILookup<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TElement> additionalValues, Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> valueSelector)
            {
                return (IDataGenerationRecord rec) =>
                {
                    var key = rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);

                    if (additionalValues.TryFirst(key, out var found))
                    {
                        return valueSelector(found).ToObjectArray();
                    }
                    else
                    {
                        return CreateNullValueArray(valueSelector);
                    }
                };
            }

            var fieldInfo = DataGeneratorFieldInfo.CreateFields(additionalFieldNames, GetReturnValueTypes(valueSelector));

            return new DataGeneratorAdditionalTupleField(fieldInfo, CreateValueGetter(keyFieldNames, additionalValues, valueSelector));
        }

        #endregion


        #region GetKeyTuple

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?) GetKeyTuple<TKey1, TKey2, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?) GetKeyTuple<TKey1, TKey2, TKey3, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);
        }

        /// <summary>
        /// 
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
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?) GetKeyTuple<TKey1, TKey2, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?) GetKeyTuple<TKey1, TKey2, TKey3, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7>(keyFieldNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <typeparam name="TKey3"></typeparam>
        /// <typeparam name="TKey4"></typeparam>
        /// <typeparam name="TKey5"></typeparam>
        /// <typeparam name="TKey6"></typeparam>
        /// <typeparam name="TKey7"></typeparam>
        /// <typeparam name="TKey8"></typeparam>
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8>(keyFieldNames);
        }

        /// <summary>
        /// 
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
        /// <typeparam name="TAnyValue"></typeparam>
        /// <param name="rec"></param>
        /// <param name="keyFieldNames"></param>
        /// <param name="_"></param>
        /// <returns></returns>
        private static (TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?) GetKeyTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TAnyValue>(IDataGenerationRecord rec, string[] keyFieldNames, IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?, TKey6?, TKey7?, TKey8?, TKey9?), TAnyValue> _)
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TKey6 : struct
            where TKey7 : struct
            where TKey8 : struct
            where TKey9 : struct
        {
            return rec.GetRawTuple<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9>(keyFieldNames);
        }

        #endregion

        #region CreateNullValueArray

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2>(IDictionary<TAnyKey, (TValue1?, TValue2?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2, TValue3>(IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2, TValue3, TValue4>(IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 4);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5>(IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 6);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 7);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAnyKey"></typeparam>
        /// <typeparam name="TValue1"></typeparam>
        /// <typeparam name="TValue2"></typeparam>
        /// <typeparam name="TValue3"></typeparam>
        /// <typeparam name="TValue4"></typeparam>
        /// <typeparam name="TValue5"></typeparam>
        /// <typeparam name="TValue6"></typeparam>
        /// <typeparam name="TValue7"></typeparam>
        /// <typeparam name="TValue8"></typeparam>
        /// <typeparam name="TValue9"></typeparam>
        /// <param name="_"></param>
        /// <returns></returns>
        private static object?[] CreateNullValueArray<TAnyKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(IDictionary<TAnyKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> _)
        {
            return (object?[])Array.CreateInstance(typeof(object), 9);
        }

        #endregion

        #region GetReturnValueTypes

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2>(Func<TElement, (TValue1?, TValue2?)> _)
            where TValue1 : struct
            where TValue2 : struct
        {
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2))
            };
        }

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2, TValue3>(Func<TElement, (TValue1?, TValue2?, TValue3?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3))
            };
        }

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2, TValue3, TValue4>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4))
            };
        }

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5))
            };
        }

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6))
            };
        }

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7))
            };
        }

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue8))
            };
        }

        private static Type[] GetReturnValueTypes<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> _)
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
            return new[]
            {
                DataGeneratorUtility.GetFieldValueType(typeof(TValue1)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue2)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue3)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue4)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue5)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue6)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue7)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue8)),
                DataGeneratorUtility.GetFieldValueType(typeof(TValue9))
            };
        }

        #endregion

        #region CreateNullValueArray

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2>(Func<TElement, (TValue1?, TValue2?)> _)
            where TValue1 : struct
            where TValue2 : struct
        {
            return (object?[])Array.CreateInstance(typeof(object), 2);
        }

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2, TValue3>(Func<TElement, (TValue1?, TValue2?, TValue3?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            return (object?[])Array.CreateInstance(typeof(object), 3);
        }

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2, TValue3, TValue4>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            return (object?[])Array.CreateInstance(typeof(object), 4);
        }

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2, TValue3, TValue4, TValue5>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
        {
            return (object?[])Array.CreateInstance(typeof(object), 5);
        }

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
        {
            return (object?[])Array.CreateInstance(typeof(object), 6);
        }

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
        {
            return (object?[])Array.CreateInstance(typeof(object), 7);
        }

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?)> _)
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
            where TValue5 : struct
            where TValue6 : struct
            where TValue7 : struct
            where TValue8 : struct
        {
            return (object?[])Array.CreateInstance(typeof(object), 8);
        }

        private static object?[] CreateNullValueArray<TElement, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(Func<TElement, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7?, TValue8?, TValue9?)> _)
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
            return (object?[])Array.CreateInstance(typeof(object), 9);
        }

        #endregion

    }

}