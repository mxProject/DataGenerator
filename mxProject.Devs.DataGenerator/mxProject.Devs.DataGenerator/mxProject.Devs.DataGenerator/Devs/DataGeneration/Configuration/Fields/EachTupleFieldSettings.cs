using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that lists the specified tuple values in order.
    /// </summary>
    public sealed class EachTupleFieldSettings : DataGeneratorTupleFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public EachTupleFieldSettings() : base()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the fields information.
        /// </summary>
        [JsonProperty("Fields", Order = 1)]
        public DataGeneratorFieldInfo[]? Fields { get; set; }

        /// <summary>
        /// Gets or sets the tuple values.
        /// </summary>
        [JsonProperty("Values", Order = 2)]
        public string?[][]? Values { get; set; }

        /// <summary>
        /// Gets or sets probability of returning null. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("NullProb", Order = 11)]
        public double NullProbability { get; set; }

        #endregion

        #region clone

        /// <inheritdoc/>
        public override object Clone()
        {
            var clone = (EachTupleFieldSettings)base.Clone();

            clone.Fields = DataGeneratorUtility.DeepCloneArray(Fields);
            clone.Values = DataGeneratorUtility.DeepCloneArray(Values);

            return clone;
        }

        #endregion

        /// <inheritdoc/>
        public override int GetFieldCount()
        {
            if (Fields == null) { return 0; }
            return Fields.Length;
        }

        /// <inheritdoc/>
        public override string?[] GetFieldNames()
        {
            string?[] names = new string?[Fields?.Length ?? 0];

            if (Fields != null)
            {
                for (int i = 0; i < Fields.Length; ++i)
                {
                    names[i] = Fields[i]?.FieldName;
                }
            }

            return names;
        }

        /// <inheritdoc/>
        /// <exception cref="NullReferenceException">
        /// The value of Fields property is null.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// The value of Values property is null.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// The value of FieldInfo.FieldName property is null.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// The value of FieldInfo.ValueType property is null.
        /// </exception>
        protected override void Assert()
        {
            base.Assert();

            if (Fields == null)
            {
                throw new NullReferenceException("The value of Fields property is null.");
            }

            for (int i = 0; i < Fields.Length; ++i)
            {
                if (string.IsNullOrWhiteSpace(Fields[i].FieldName))
                {
                    throw new NullReferenceException(string.Format("The value of Fields[{0}].FieldName property is null.", i));
                }
                if (string.IsNullOrWhiteSpace(Fields[i].ValueType))
                {
                    throw new NullReferenceException(string.Format("The value of Fields[{0}].ValueType property is null.", i));
                }
            }

            if (Values == null)
            {
                throw new NullReferenceException("The value of Values property is null.");
            }
        }

        /// <inheritdoc/>
        protected override IDataGeneratorTupleField CreateFieldCore(DataGeneratorContext context)
        {
            Type t = typeof(EachTupleFieldSettings);

            try
            {
                if (Fields!.Length == 2)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple2));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField2));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }
                else if (Fields!.Length == 3)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!,
                    Fields[2].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple3));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField3));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }
                else if (Fields!.Length == 4)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!,
                    Fields[2].GetFieldValueType()!,
                    Fields[3].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple4));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField4));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }
                else if (Fields!.Length == 5)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!,
                    Fields[2].GetFieldValueType()!,
                    Fields[3].GetFieldValueType()!,
                    Fields[4].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple5));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField5));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }
                else if (Fields!.Length == 6)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!,
                    Fields[2].GetFieldValueType()!,
                    Fields[3].GetFieldValueType()!,
                    Fields[4].GetFieldValueType()!,
                    Fields[5].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple6));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField6));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }
                else if (Fields!.Length == 7)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!,
                    Fields[2].GetFieldValueType()!,
                    Fields[3].GetFieldValueType()!,
                    Fields[4].GetFieldValueType()!,
                    Fields[5].GetFieldValueType()!,
                    Fields[6].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple7));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField7));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }
                else if (Fields!.Length == 8)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!,
                    Fields[2].GetFieldValueType()!,
                    Fields[3].GetFieldValueType()!,
                    Fields[4].GetFieldValueType()!,
                    Fields[5].GetFieldValueType()!,
                    Fields[6].GetFieldValueType()!,
                    Fields[7].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple8));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField8));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }
                else if (Fields!.Length == 9)
                {
                    var types = new Type[] {
                    Fields[0].GetFieldValueType()!,
                    Fields[1].GetFieldValueType()!,
                    Fields[2].GetFieldValueType()!,
                    Fields[3].GetFieldValueType()!,
                    Fields[4].GetFieldValueType()!,
                    Fields[5].GetFieldValueType()!,
                    Fields[6].GetFieldValueType()!,
                    Fields[7].GetFieldValueType()!,
                    Fields[8].GetFieldValueType()!
                };
                    var tupleMethod = t.GetGenericMethod(nameof(CreateTuple9));
                    var fieldMethod = t.GetGenericMethod(nameof(CreateField9));

                    var tuples = t.InvokeStaticGenericMethod(
                        tupleMethod,
                        types,
                        this,
                        context
                        );

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        fieldMethod,
                        types,
                        tuples!,
                        this,
                        context
                        );
                }

                throw new NotSupportedException("The specified number of additional fields is not supported.");
            }
            catch (Exception ex)
            {
                throw CreateException(Fields, ex);
            }
        }

        #region (T1, T2)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField2<T1, T2>(IEnumerable<(T1?, T2?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
        {
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?)> CreateTuple2<T1, T2>(EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
        {
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1])
                    );
            }

            return tuples;
        }

        #endregion

        #region (T1, T2, T3)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField3<T1, T2, T3>(IEnumerable<(T1?, T2?, T3?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                fields[2].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?, T3?)> CreateTuple3<T1, T2, T3>(EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?, T3?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1]),
                    string.IsNullOrEmpty(values[i][2]) ? null : context.StringConverter.ConvertTo<T3>(values[i][2])
                    );
            }

            return tuples;
        }

        #endregion

        #region (T1, T2, T3, T4)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField4<T1, T2, T3, T4>(IEnumerable<(T1?, T2?, T3?, T4?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                fields[2].FieldName!,
                fields[3].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?, T3?, T4?)> CreateTuple4<T1, T2, T3, T4>(EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?, T3?, T4?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1]),
                    string.IsNullOrEmpty(values[i][2]) ? null : context.StringConverter.ConvertTo<T3>(values[i][2]),
                    string.IsNullOrEmpty(values[i][3]) ? null : context.StringConverter.ConvertTo<T4>(values[i][3])
                    );
            }

            return tuples;
        }

        #endregion

        #region (T1, T2, T3, T4, T5)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField5<T1, T2, T3, T4, T5>(IEnumerable<(T1?, T2?, T3?, T4?, T5?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                fields[2].FieldName!,
                fields[3].FieldName!,
                fields[4].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?)> CreateTuple5<T1, T2, T3, T4, T5>(EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?, T3?, T4?, T5?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1]),
                    string.IsNullOrEmpty(values[i][2]) ? null : context.StringConverter.ConvertTo<T3>(values[i][2]),
                    string.IsNullOrEmpty(values[i][3]) ? null : context.StringConverter.ConvertTo<T4>(values[i][3]),
                    string.IsNullOrEmpty(values[i][4]) ? null : context.StringConverter.ConvertTo<T5>(values[i][4])
                    );
            }

            return tuples;
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField6<T1, T2, T3, T4, T5, T6>(IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                fields[2].FieldName!,
                fields[3].FieldName!,
                fields[4].FieldName!,
                fields[5].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> CreateTuple6<T1, T2, T3, T4, T5, T6>(EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?, T3?, T4?, T5?, T6?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1]),
                    string.IsNullOrEmpty(values[i][2]) ? null : context.StringConverter.ConvertTo<T3>(values[i][2]),
                    string.IsNullOrEmpty(values[i][3]) ? null : context.StringConverter.ConvertTo<T4>(values[i][3]),
                    string.IsNullOrEmpty(values[i][4]) ? null : context.StringConverter.ConvertTo<T5>(values[i][4]),
                    string.IsNullOrEmpty(values[i][5]) ? null : context.StringConverter.ConvertTo<T6>(values[i][5])
                    );
            }

            return tuples;
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6, T7)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField7<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                fields[2].FieldName!,
                fields[3].FieldName!,
                fields[4].FieldName!,
                fields[5].FieldName!,
                fields[6].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> CreateTuple7<T1, T2, T3, T4, T5, T6, T7>(EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?, T3?, T4?, T5?, T6?, T7?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1]),
                    string.IsNullOrEmpty(values[i][2]) ? null : context.StringConverter.ConvertTo<T3>(values[i][2]),
                    string.IsNullOrEmpty(values[i][3]) ? null : context.StringConverter.ConvertTo<T4>(values[i][3]),
                    string.IsNullOrEmpty(values[i][4]) ? null : context.StringConverter.ConvertTo<T5>(values[i][4]),
                    string.IsNullOrEmpty(values[i][5]) ? null : context.StringConverter.ConvertTo<T6>(values[i][5]),
                    string.IsNullOrEmpty(values[i][6]) ? null : context.StringConverter.ConvertTo<T7>(values[i][6])
                    );
            }

            return tuples;
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6, T7, T8)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField8<T1, T2, T3, T4, T5, T6, T7, T8>(IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                fields[2].FieldName!,
                fields[3].FieldName!,
                fields[4].FieldName!,
                fields[5].FieldName!,
                fields[6].FieldName!,
                fields[7].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> CreateTuple8<T1, T2, T3, T4, T5, T6, T7, T8>(EachTupleFieldSettings settings, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1]),
                    string.IsNullOrEmpty(values[i][2]) ? null : context.StringConverter.ConvertTo<T3>(values[i][2]),
                    string.IsNullOrEmpty(values[i][3]) ? null : context.StringConverter.ConvertTo<T4>(values[i][3]),
                    string.IsNullOrEmpty(values[i][4]) ? null : context.StringConverter.ConvertTo<T5>(values[i][4]),
                    string.IsNullOrEmpty(values[i][5]) ? null : context.StringConverter.ConvertTo<T6>(values[i][5]),
                    string.IsNullOrEmpty(values[i][6]) ? null : context.StringConverter.ConvertTo<T7>(values[i][6]),
                    string.IsNullOrEmpty(values[i][7]) ? null : context.StringConverter.ConvertTo<T8>(values[i][7])
                    );
            }

            return tuples;
        }

        #endregion

        #region (T1, T2, T3, T4, T5, T6, T7, T8, T9)

        /// <summary>
        /// Creates a field.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="values"></param>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateField9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> values, EachTupleFieldSettings settings, DataGeneratorContext context)
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
            DataGeneratorFieldInfo[] fields = settings.Fields!;

            return context.FieldFactory.EachTuple(
                fields[0].FieldName!,
                fields[1].FieldName!,
                fields[2].FieldName!,
                fields[3].FieldName!,
                fields[4].FieldName!,
                fields[5].FieldName!,
                fields[6].FieldName!,
                fields[7].FieldName!,
                fields[8].FieldName!,
                values,
                settings.NullProbability
                );
        }

        /// <summary>
        /// Creates tuples.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <param name="settings"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> CreateTuple9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(EachTupleFieldSettings settings, DataGeneratorContext context)
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
            string[][] values = settings.Values!;

            var tuples = new (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)[values.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                tuples[i] = (
                    string.IsNullOrEmpty(values[i][0]) ? null : context.StringConverter.ConvertTo<T1>(values[i][0]),
                    string.IsNullOrEmpty(values[i][1]) ? null : context.StringConverter.ConvertTo<T2>(values[i][1]),
                    string.IsNullOrEmpty(values[i][2]) ? null : context.StringConverter.ConvertTo<T3>(values[i][2]),
                    string.IsNullOrEmpty(values[i][3]) ? null : context.StringConverter.ConvertTo<T4>(values[i][3]),
                    string.IsNullOrEmpty(values[i][4]) ? null : context.StringConverter.ConvertTo<T5>(values[i][4]),
                    string.IsNullOrEmpty(values[i][5]) ? null : context.StringConverter.ConvertTo<T6>(values[i][5]),
                    string.IsNullOrEmpty(values[i][6]) ? null : context.StringConverter.ConvertTo<T7>(values[i][6]),
                    string.IsNullOrEmpty(values[i][7]) ? null : context.StringConverter.ConvertTo<T8>(values[i][7]),
                    string.IsNullOrEmpty(values[i][8]) ? null : context.StringConverter.ConvertTo<T9>(values[i][8])
                    );
            }

            return tuples;
        }

        #endregion

        #region exception handling

        private const string ExceptionMessage = "Failed to activate a tuple field.";

        /// <summary>
        /// Create an exception.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        private static Exception CreateException(DataGeneratorFieldInfo[]? fields, Exception innerException)
        {
            static string BuildMessage(DataGeneratorFieldInfo[]? fields)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(ExceptionMessage);

                sb.Append("Fields: [");

                if (fields != null)
                {
                    for (int i = 0; i < fields.Length; ++i)
                    {
                        if (i > 0) { sb.Append(", "); }
                        sb.Append(fields[i].FieldName);
                    }
                }

                sb.Append("]");

                return sb.ToString();
            }

            return new Exception(BuildMessage(fields), innerException);
        }

        #endregion

        //[System.Runtime.Serialization.OnSerializing]
        //private void OnSerializing(System.Runtime.Serialization.StreamingContext context)
        //{
        //}

        //[System.Runtime.Serialization.OnSerialized]
        //private void OnSerialized(System.Runtime.Serialization.StreamingContext context)
        //{
        //}

        //[System.Runtime.Serialization.OnDeserializing]
        //private void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        //{
        //}

        //[System.Runtime.Serialization.OnDeserialized]
        //private void OnDeserialized(System.Runtime.Serialization.StreamingContext context)
        //{
        //}

    }

}
