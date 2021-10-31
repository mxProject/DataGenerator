using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using mxProject.Devs.DataGeneration.AdditionalFields;

namespace mxProject.Devs.DataGeneration.Configuration.AdditionalFields
{

    /// <summary>
    /// A setting for a field that returns the values stored in a dictionary.
    /// </summary>
    public class JoinFieldSettings : DataGeneratorAdditionalTupleFieldSettings
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public JoinFieldSettings(): base()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the key field information."
        /// </summary>
        [JsonProperty("KeyFields", Order = 11)]
        public DataGeneratorFieldInfo[]? KeyFields { get; set; }

        /// <summary>
        /// Gets or sets the values of the additional fields.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string?[], string?[]>? AdditionalValues { get; set; }

        [JsonProperty("AdditionalValues", Order = 12)]
        private KeyValuePair<string?[], string?[]>[]? _AdditionalValues;

        #endregion

        #region clone

        /// <inheritdoc/>
        public override object Clone()
        {
            var clone = (JoinFieldSettings)base.Clone();

            clone.KeyFields = DataGeneratorUtility.DeepCloneArray(KeyFields);
            clone.AdditionalValues = DataGeneratorUtility.CloneDictionary(AdditionalValues);

            return clone;
        }

        #endregion

        /// <inheritdoc/>
        protected override IDataGeneratorAdditionalTupleField CreateFieldCore(DataGeneratorContext context)
        {
            return WithStringDictionary(KeyFields!, AdditionalFields!, AdditionalValues!, context);
        }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (KeyFields == null)
            {
                throw new NullReferenceException("The value of KeyFields property is null.");
            }

            if (AdditionalValues == null)
            {
                throw new NullReferenceException("The value of AdditionalValues property is null.");
            }
        }

        #region serialize

        [System.Runtime.Serialization.OnSerializing]
        private void OnSerializing(System.Runtime.Serialization.StreamingContext context)
        {
            _AdditionalValues = AdditionalValues?.ToKeyValuePairs();
        }

        [System.Runtime.Serialization.OnSerialized]
        private void OnSerialized(System.Runtime.Serialization.StreamingContext context)
        {
            _AdditionalValues = null;
        }

        [System.Runtime.Serialization.OnDeserializing]
        private void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        {
        }

        [System.Runtime.Serialization.OnDeserialized]
        private void OnDeserialized(System.Runtime.Serialization.StreamingContext context)
        {
            AdditionalValues = _AdditionalValues?.ToDictionary();
            _AdditionalValues = null;
        }

        #endregion

        #region field activation

        /// <summary>
        /// Create an field.
        /// </summary>
        /// <param name="keyFields"></param>
        /// <param name="additionalFields"></param>
        /// <param name="additionalValues"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private DataGeneratorAdditionalTupleField WithStringDictionary(IDataGeneratorFieldInfo[] keyFields, IDataGeneratorFieldInfo[] additionalFields, IDictionary<string?[], string?[]> additionalValues, DataGeneratorContext context)
        {
            static string[] GetFieldNames(IDataGeneratorFieldInfo[] fields)
            {
                string[] names = new string[fields.Length ];

                for (int i = 0; i < fields.Length; ++i)
                {
                    names[i] = fields[i].FieldName;
                }

                return names;
            }

            static Type[] GetValueTypes(IDataGeneratorFieldInfo[] fields)
            {
                Type[] types = new Type[fields.Length];

                for (int i = 0; i < fields.Length; ++i)
                {
                    types[i] = fields[i].ValueType;
                }

                return types;
            }

            static Type[] GetNullableValueTypes(IDataGeneratorFieldInfo[] keyFields, IDataGeneratorFieldInfo[] additionalFields)
            {
                Type[] types = new Type[keyFields.Length + additionalFields.Length];

                if (keyFields.Length == 1)
                {
                    types[0] = keyFields[0].ValueType;
                }
                else
                {
                    for (int i = 0; i < keyFields.Length; ++i)
                    {
                        types[i] = keyFields[i].ValueType;
                    }
                }

                for (int i = 0; i < additionalFields.Length; ++i)
                {
                    types[i+ keyFields.Length] = additionalFields[i].ValueType;
                }

                return types;
            }

            try
            {
                string[] keyFieldNames = GetFieldNames(keyFields);
                string[] additionalFieldNames = GetFieldNames(additionalFields);
                Type[] keyTypes = GetValueTypes(keyFields);
                Type[] additionalTypes = GetValueTypes(additionalFields);
                Type[] fieldValueTypes = GetNullableValueTypes(keyFields, additionalFields);
                System.Collections.IDictionary dictionary = additionalValues.Parse(keyTypes, additionalTypes, context.StringConverter);

                return WithStringDictionaryCore(keyFieldNames, additionalFieldNames, fieldValueTypes, dictionary, context);

            }
            catch (Exception ex)
            {
                throw CreateException(keyFields, additionalFields, ex);
            }
        }

        private DataGeneratorAdditionalTupleField WithStringDictionaryCore(string[] keyFieldNames, string[] additionalFieldNames, Type[] valueTypes, System.Collections.IDictionary additionalValues, DataGeneratorContext context)
        {
            static System.Reflection.MethodInfo GetMethod(string[] keyFieldNames, string[] additionalFieldNames)
            {
                Type t = typeof(JoinFieldSettings);

                switch (keyFieldNames.Length)
                {
                    case 1:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key_Value));
                            case 2: return t.GetGenericMethod(nameof(Key_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key_Value9));
                        }

                        break;

                    case 2:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key2_Value));
                            case 2: return t.GetGenericMethod(nameof(Key2_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key2_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key2_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key2_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key2_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key2_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key2_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key2_Value9));
                        }

                        break;

                    case 3:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key3_Value));
                            case 2: return t.GetGenericMethod(nameof(Key3_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key3_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key3_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key3_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key3_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key3_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key3_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key3_Value9));
                        }

                        break;

                    case 4:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key4_Value));
                            case 2: return t.GetGenericMethod(nameof(Key4_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key4_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key4_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key4_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key4_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key4_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key4_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key4_Value9));
                        }

                        break;

                    case 5:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key5_Value));
                            case 2: return t.GetGenericMethod(nameof(Key5_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key5_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key5_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key5_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key5_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key5_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key5_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key5_Value9));
                        }

                        break;

                    case 6:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key6_Value));
                            case 2: return t.GetGenericMethod(nameof(Key6_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key6_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key6_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key6_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key6_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key6_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key6_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key6_Value9));
                        }

                        break;

                    case 7:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key7_Value));
                            case 2: return t.GetGenericMethod(nameof(Key7_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key7_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key7_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key7_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key7_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key7_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key7_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key7_Value9));
                        }

                        break;

                    case 8:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key8_Value));
                            case 2: return t.GetGenericMethod(nameof(Key8_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key8_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key8_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key8_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key8_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key8_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key8_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key8_Value9));
                        }

                        break;

                    case 9:

                        switch (additionalFieldNames.Length)
                        {
                            case 1: return t.GetGenericMethod(nameof(Key9_Value));
                            case 2: return t.GetGenericMethod(nameof(Key9_Value2));
                            case 3: return t.GetGenericMethod(nameof(Key9_Value3));
                            case 4: return t.GetGenericMethod(nameof(Key9_Value4));
                            case 5: return t.GetGenericMethod(nameof(Key9_Value5));
                            case 6: return t.GetGenericMethod(nameof(Key9_Value6));
                            case 7: return t.GetGenericMethod(nameof(Key9_Value7));
                            case 8: return t.GetGenericMethod(nameof(Key9_Value8));
                            case 9: return t.GetGenericMethod(nameof(Key9_Value9));
                        }

                        break;
                }

                throw new NotSupportedException("The specified number of additional fields is not supported.");
            }

            System.Reflection.MethodInfo method = GetMethod(keyFieldNames, additionalFieldNames);

            return (DataGeneratorAdditionalTupleField)typeof(JoinFieldSettings).InvokeStaticGenericMethod(
                method,
                valueTypes,
                keyFieldNames,
                additionalFieldNames,
                additionalValues
                )!;

        }

        #endregion

        #region IDictionary<TKey, TValue>

        private static DataGeneratorAdditionalTupleField Key_Value<TKey, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<TKey, TValue?> additionalValues
            )
            where TKey : struct
            where TValue : struct
        {
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key_Value2<TKey, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key_Value3<TKey, TValue1, TValue2, TValue3>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
        {
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key_Value4<TKey, TValue1, TValue2, TValue3, TValue4>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?)> additionalValues
            )
            where TKey : struct
            where TValue1 : struct
            where TValue2 : struct
            where TValue3 : struct
            where TValue4 : struct
        {
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key_Value5<TKey, TValue1, TValue2, TValue3, TValue4, TValue5>(
            string[] keyFieldNames,
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
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key_Value6<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
            string[] keyFieldNames,
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
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key_Value7<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
            string[] keyFieldNames,
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
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key_Value8<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<TKey, (TValue1?, TValue2?, TValue3?, TValue4?, TValue5?, TValue6?, TValue7? ,TValue8?)> additionalValues
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
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<TKey, (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key_Value9<TKey, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
            string[] keyFieldNames,
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
            return JoinFieldFactory.Default.WithDictionary(keyFieldNames[0], additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), TValue>

        private static DataGeneratorAdditionalTupleField Key2_Value<TKey1, TKey2, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue : struct
        {
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key2_Value2<TKey1, TKey2, TValue1, TValue2>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?), (TValue1?, TValue2?)> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TValue1 : struct
            where TValue2 : struct
        {
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key2_Value3<TKey1, TKey2, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key2_Value4<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key2_Value5<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key2_Value6<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key2_Value7<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key2_Value8<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key2_Value9<TKey1, TKey2, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey2(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), TValue>

        private static DataGeneratorAdditionalTupleField Key3_Value<TKey1, TKey2, TKey3, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TValue : struct
        {
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key3_Value2<TKey1, TKey2, TKey3, TValue1, TValue2>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key3_Value3<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key3_Value4<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key3_Value5<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key3_Value6<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key3_Value7<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key3_Value8<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key3_Value9<TKey1, TKey2, TKey3, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey3(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), TValue>

        private static DataGeneratorAdditionalTupleField Key4_Value<TKey1, TKey2, TKey3, TKey4, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TValue : struct
        {
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key4_Value2<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key4_Value3<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key4_Value4<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key4_Value5<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key4_Value6<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key4_Value7<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key4_Value8<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key4_Value9<TKey1, TKey2, TKey3, TKey4, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey4(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), TValue>

        private static DataGeneratorAdditionalTupleField Key5_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
            IDictionary<(TKey1?, TKey2?, TKey3?, TKey4?, TKey5?), TValue?> additionalValues
            )
            where TKey1 : struct
            where TKey2 : struct
            where TKey3 : struct
            where TKey4 : struct
            where TKey5 : struct
            where TValue : struct
        {
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key5_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key5_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key5_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key5_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key5_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key5_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key5_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key5_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey5(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), TValue>

        private static DataGeneratorAdditionalTupleField Key6_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key6_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key6_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key6_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key6_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key6_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key6_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key6_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key6_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey6(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), TValue>

        private static DataGeneratorAdditionalTupleField Key7_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key7_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key7_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key7_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key7_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key7_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key7_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key7_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key7_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey7(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), TValue>

        private static DataGeneratorAdditionalTupleField Key8_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key8_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key8_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key8_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key8_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key8_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key8_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key8_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key8_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey8(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), TValue>

        private static DataGeneratorAdditionalTupleField Key9_Value<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue>(
            string[] keyFieldNames,
            string[] additionalFieldNames,
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames[0], additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2)>

        private static DataGeneratorAdditionalTupleField Key9_Value2<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3)>

        private static DataGeneratorAdditionalTupleField Key9_Value3<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4)>

        private static DataGeneratorAdditionalTupleField Key9_Value4<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5)>

        private static DataGeneratorAdditionalTupleField Key9_Value5<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>

        private static DataGeneratorAdditionalTupleField Key9_Value6<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>

        private static DataGeneratorAdditionalTupleField Key9_Value7<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>

        private static DataGeneratorAdditionalTupleField Key9_Value8<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region IDictionary<(TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9), (TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>

        private static DataGeneratorAdditionalTupleField Key9_Value9<TKey1, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TKey8, TKey9, TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(
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
            return JoinFieldFactory.Default.WithDictionaryKey9(keyFieldNames, additionalFieldNames, additionalValues);
        }

        #endregion

        #region exception

        private const string ExceptionMessage = "Failed to activate a tuple field.";

        /// <summary>
        /// Create an exception.
        /// </summary>
        /// <param name="keyFields"></param>
        /// <param name="additionalFields"></param>
        /// <param name="keyException"></param>
        /// <returns></returns>
        private static Exception CreateException(IDataGeneratorFieldInfo[] keyFields, IDataGeneratorFieldInfo[] additionalFields, Exception keyException)
        {
            static string BuildMessage(IDataGeneratorFieldInfo[] keyFields, IDataGeneratorFieldInfo[] additionalFields)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(ExceptionMessage);

                sb.Append("KeyFields: ");

                if (keyFields != null)
                {
                    for (int i = 0; i < keyFields.Length; ++i)
                    {
                        if (i > 0) { sb.Append(", "); }
                        sb.Append(keyFields[i].FieldName);
                    }
                }

                sb.Append(", AdditionalFields: ");

                if (additionalFields != null)
                {
                    for (int i = 0; i < additionalFields.Length; ++i)
                    {
                        if (i > 0) { sb.Append(", "); }
                        sb.Append(additionalFields[i]?.FieldName);
                    }
                }

                return sb.ToString();
            }

            return new Exception(BuildMessage(keyFields, additionalFields), keyException);
        }

        #endregion

    }

}
