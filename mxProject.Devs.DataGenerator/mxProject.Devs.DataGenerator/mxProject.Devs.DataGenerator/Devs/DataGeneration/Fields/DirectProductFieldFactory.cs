using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Factory methods that instantiates a DataGeneratorTupleField that generates values based on DirectProduct.
    /// </summary>
    public static class DirectProductFieldFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// fields is null.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// The specified number of fields is not supported.
        /// </exception>
        public static IDataGeneratorTupleField CreateTupleField(IDataGeneratorField[] fields, DataGeneratorContext context)
        {
            if (fields == null)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            Type t = typeof(DirectProductFieldFactory);

            try
            {
                if (fields.Length == 2)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct2));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType },
                        fields[0],
                        fields[1],
                        context
                        );
                }
                else if (fields.Length == 3)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct3));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType, fields[2].ValueType },
                        fields[0],
                        fields[1],
                        fields[2],
                        context
                        );
                }
                else if (fields.Length == 4)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct4));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType, fields[2].ValueType, fields[3].ValueType },
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        context
                        );
                }
                else if (fields.Length == 5)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct5));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType, fields[2].ValueType, fields[3].ValueType, fields[4].ValueType },
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        fields[4],
                        context
                        );
                }
                else if (fields.Length == 6)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct6));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType, fields[2].ValueType, fields[3].ValueType, fields[4].ValueType, fields[5].ValueType },
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        fields[4],
                        fields[5],
                        context
                        );
                }
                else if (fields.Length == 7)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct7));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType, fields[2].ValueType, fields[3].ValueType, fields[4].ValueType, fields[5].ValueType, fields[6].ValueType },
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        fields[4],
                        fields[5],
                        fields[6],
                        context
                        );
                }
                else if (fields.Length == 8)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct8));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType, fields[2].ValueType, fields[3].ValueType, fields[4].ValueType, fields[5].ValueType, fields[6].ValueType, fields[7].ValueType },
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        fields[4],
                        fields[5],
                        fields[6],
                        fields[7],
                        context
                        );
                }
                else if (fields.Length == 9)
                {
                    var method = t.GetGenericMethod(nameof(CreateTupleField_DirectProduct9));

                    return t.InvokeStaticGenericMethod<IDataGeneratorTupleField>(
                        method,
                        new[] { fields[0].ValueType, fields[1].ValueType, fields[2].ValueType, fields[3].ValueType, fields[4].ValueType, fields[5].ValueType, fields[6].ValueType, fields[7].ValueType, fields[8].ValueType },
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        fields[4],
                        fields[5],
                        fields[6],
                        fields[7],
                        fields[8],
                        context
                        );
                }

                throw new NotSupportedException("The specified number of fields is not supported.");
            }
            catch (Exception ex)
            {
                throw CreateException(fields, ex);
            }
        }



        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct2<T1, T2>(IDataGeneratorField field1, IDataGeneratorField field2, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
        {
            static TupleEnumerationCreator<T1, T2> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                CreateCreator(field1, field2, context));
        }

        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="field3">The third field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct3<T1, T2, T3>(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            static TupleEnumerationCreator<T1, T2, T3> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount3 = field3.IsFixedLength ? field3.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);
                    var enumeration3 = await ((IDataGeneratorField<T3>)field3).CreateTypedEnumerationAsync(enumerationCount3).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?, T3?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2),
                        () => EnumerateFieldValues(enumeration3)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2, T3>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                field3.FieldName, field3.MayBeNull,
                CreateCreator(field1, field2, field3, context));
        }

        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="field3">The third field.</param>
        /// <param name="field4">The fourth field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct4<T1, T2, T3, T4>(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            static TupleEnumerationCreator<T1, T2, T3, T4> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount3 = field3.IsFixedLength ? field3.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount4 = field4.IsFixedLength ? field4.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);
                    var enumeration3 = await ((IDataGeneratorField<T3>)field3).CreateTypedEnumerationAsync(enumerationCount3).ConfigureAwait(false);
                    var enumeration4 = await ((IDataGeneratorField<T4>)field4).CreateTypedEnumerationAsync(enumerationCount4).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?, T3?, T4?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2),
                        () => EnumerateFieldValues(enumeration3),
                        () => EnumerateFieldValues(enumeration4)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2, T3, T4>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                field3.FieldName, field3.MayBeNull,
                field4.FieldName, field4.MayBeNull,
                CreateCreator(field1, field2, field3, field4, context));
        }

        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="field3">The third field.</param>
        /// <param name="field4">The fourth field.</param>
        /// <param name="field5">The fifth field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct5<T1, T2, T3, T4, T5>(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            static TupleEnumerationCreator<T1, T2, T3, T4, T5> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount3 = field3.IsFixedLength ? field3.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount4 = field4.IsFixedLength ? field4.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount5 = field5.IsFixedLength ? field5.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);
                    var enumeration3 = await ((IDataGeneratorField<T3>)field3).CreateTypedEnumerationAsync(enumerationCount3).ConfigureAwait(false);
                    var enumeration4 = await ((IDataGeneratorField<T4>)field4).CreateTypedEnumerationAsync(enumerationCount4).ConfigureAwait(false);
                    var enumeration5 = await ((IDataGeneratorField<T5>)field5).CreateTypedEnumerationAsync(enumerationCount5).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?, T3?, T4?, T5?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2),
                        () => EnumerateFieldValues(enumeration3),
                        () => EnumerateFieldValues(enumeration4),
                        () => EnumerateFieldValues(enumeration5)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2, T3, T4, T5>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                field3.FieldName, field3.MayBeNull,
                field4.FieldName, field4.MayBeNull,
                field5.FieldName, field5.MayBeNull,
                CreateCreator(field1, field2, field3, field4, field5, context));
        }

        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="field3">The third field.</param>
        /// <param name="field4">The fourth field.</param>
        /// <param name="field5">The fifth field.</param>
        /// <param name="field6">The sixth field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct6<T1, T2, T3, T4, T5, T6>(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            static TupleEnumerationCreator<T1, T2, T3, T4, T5, T6> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount3 = field3.IsFixedLength ? field3.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount4 = field4.IsFixedLength ? field4.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount5 = field5.IsFixedLength ? field5.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount6 = field6.IsFixedLength ? field6.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);
                    var enumeration3 = await ((IDataGeneratorField<T3>)field3).CreateTypedEnumerationAsync(enumerationCount3).ConfigureAwait(false);
                    var enumeration4 = await ((IDataGeneratorField<T4>)field4).CreateTypedEnumerationAsync(enumerationCount4).ConfigureAwait(false);
                    var enumeration5 = await ((IDataGeneratorField<T5>)field5).CreateTypedEnumerationAsync(enumerationCount5).ConfigureAwait(false);
                    var enumeration6 = await ((IDataGeneratorField<T6>)field6).CreateTypedEnumerationAsync(enumerationCount6).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?, T3?, T4?, T5?, T6?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2),
                        () => EnumerateFieldValues(enumeration3),
                        () => EnumerateFieldValues(enumeration4),
                        () => EnumerateFieldValues(enumeration5),
                        () => EnumerateFieldValues(enumeration6)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                field3.FieldName, field3.MayBeNull,
                field4.FieldName, field4.MayBeNull,
                field5.FieldName, field5.MayBeNull,
                field6.FieldName, field6.MayBeNull,
                CreateCreator(field1, field2, field3, field4, field5, field6, context));
        }

        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="field3">The third field.</param>
        /// <param name="field4">The fourth field.</param>
        /// <param name="field5">The fifth field.</param>
        /// <param name="field6">The sixth field.</param>
        /// <param name="field7">The seventh field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct7<T1, T2, T3, T4, T5, T6, T7>(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, IDataGeneratorField field7, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            static TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, IDataGeneratorField field7, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount3 = field3.IsFixedLength ? field3.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount4 = field4.IsFixedLength ? field4.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount5 = field5.IsFixedLength ? field5.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount6 = field6.IsFixedLength ? field6.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount7 = field7.IsFixedLength ? field7.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);
                    var enumeration3 = await ((IDataGeneratorField<T3>)field3).CreateTypedEnumerationAsync(enumerationCount3).ConfigureAwait(false);
                    var enumeration4 = await ((IDataGeneratorField<T4>)field4).CreateTypedEnumerationAsync(enumerationCount4).ConfigureAwait(false);
                    var enumeration5 = await ((IDataGeneratorField<T5>)field5).CreateTypedEnumerationAsync(enumerationCount5).ConfigureAwait(false);
                    var enumeration6 = await ((IDataGeneratorField<T6>)field6).CreateTypedEnumerationAsync(enumerationCount6).ConfigureAwait(false);
                    var enumeration7 = await ((IDataGeneratorField<T7>)field7).CreateTypedEnumerationAsync(enumerationCount7).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?, T3?, T4?, T5?, T6?, T7?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2),
                        () => EnumerateFieldValues(enumeration3),
                        () => EnumerateFieldValues(enumeration4),
                        () => EnumerateFieldValues(enumeration5),
                        () => EnumerateFieldValues(enumeration6),
                        () => EnumerateFieldValues(enumeration7)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                field3.FieldName, field3.MayBeNull,
                field4.FieldName, field4.MayBeNull,
                field5.FieldName, field5.MayBeNull,
                field6.FieldName, field6.MayBeNull,
                field7.FieldName, field7.MayBeNull,
                CreateCreator(field1, field2, field3, field4, field5, field6, field7, context));
        }

        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="field3">The third field.</param>
        /// <param name="field4">The fourth field.</param>
        /// <param name="field5">The fifth field.</param>
        /// <param name="field6">The sixth field.</param>
        /// <param name="field7">The seventh field.</param>
        /// <param name="field8">The eighth field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct8<T1, T2, T3, T4, T5, T6, T7, T8>(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, IDataGeneratorField field7, IDataGeneratorField field8, DataGeneratorContext context)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            static TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, IDataGeneratorField field7, IDataGeneratorField field8, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount3 = field3.IsFixedLength ? field3.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount4 = field4.IsFixedLength ? field4.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount5 = field5.IsFixedLength ? field5.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount6 = field6.IsFixedLength ? field6.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount7 = field7.IsFixedLength ? field7.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount8 = field8.IsFixedLength ? field8.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);
                    var enumeration3 = await ((IDataGeneratorField<T3>)field3).CreateTypedEnumerationAsync(enumerationCount3).ConfigureAwait(false);
                    var enumeration4 = await ((IDataGeneratorField<T4>)field4).CreateTypedEnumerationAsync(enumerationCount4).ConfigureAwait(false);
                    var enumeration5 = await ((IDataGeneratorField<T5>)field5).CreateTypedEnumerationAsync(enumerationCount5).ConfigureAwait(false);
                    var enumeration6 = await ((IDataGeneratorField<T6>)field6).CreateTypedEnumerationAsync(enumerationCount6).ConfigureAwait(false);
                    var enumeration7 = await ((IDataGeneratorField<T7>)field7).CreateTypedEnumerationAsync(enumerationCount7).ConfigureAwait(false);
                    var enumeration8 = await ((IDataGeneratorField<T8>)field8).CreateTypedEnumerationAsync(enumerationCount8).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2),
                        () => EnumerateFieldValues(enumeration3),
                        () => EnumerateFieldValues(enumeration4),
                        () => EnumerateFieldValues(enumeration5),
                        () => EnumerateFieldValues(enumeration6),
                        () => EnumerateFieldValues(enumeration7),
                        () => EnumerateFieldValues(enumeration8)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                field3.FieldName, field3.MayBeNull,
                field4.FieldName, field4.MayBeNull,
                field5.FieldName, field5.MayBeNull,
                field6.FieldName, field6.MayBeNull,
                field7.FieldName, field7.MayBeNull,
                field8.FieldName, field8.MayBeNull,
                CreateCreator(field1, field2, field3, field4, field5, field6, field7, field8, context));
        }

        /// <summary>
        /// Create a tuple field.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <typeparam name="T9">The value type of the ninth field.</typeparam>
        /// <param name="field1">The first field.</param>
        /// <param name="field2">The second field.</param>
        /// <param name="field3">The third field.</param>
        /// <param name="field4">The fourth field.</param>
        /// <param name="field5">The fifth field.</param>
        /// <param name="field6">The sixth field.</param>
        /// <param name="field7">The seventh field.</param>
        /// <param name="field8">The eighth field.</param>
        /// <param name="field9">The ninth field.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IDataGeneratorTupleField CreateTupleField_DirectProduct9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, IDataGeneratorField field7, IDataGeneratorField field8, IDataGeneratorField field9, DataGeneratorContext context)
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
            static TupleEnumerationCreator<T1, T2, T3, T4, T5, T6, T7, T8, T9> CreateCreator(IDataGeneratorField field1, IDataGeneratorField field2, IDataGeneratorField field3, IDataGeneratorField field4, IDataGeneratorField field5, IDataGeneratorField field6, IDataGeneratorField field7, IDataGeneratorField field8, IDataGeneratorField field9, DataGeneratorContext context)
            {
                return async generationCount =>
                {
                    int enumerationCount1 = field1.IsFixedLength ? field1.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount2 = field2.IsFixedLength ? field2.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount3 = field3.IsFixedLength ? field3.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount4 = field4.IsFixedLength ? field4.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount5 = field5.IsFixedLength ? field5.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount6 = field6.IsFixedLength ? field6.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount7 = field7.IsFixedLength ? field7.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount8 = field8.IsFixedLength ? field8.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    int enumerationCount9 = field9.IsFixedLength ? field9.GetEnumerateValueCount().GetValueOrDefault() : generationCount;
                    var enumeration1 = await ((IDataGeneratorField<T1>)field1).CreateTypedEnumerationAsync(enumerationCount1).ConfigureAwait(false);
                    var enumeration2 = await ((IDataGeneratorField<T2>)field2).CreateTypedEnumerationAsync(enumerationCount2).ConfigureAwait(false);
                    var enumeration3 = await ((IDataGeneratorField<T3>)field3).CreateTypedEnumerationAsync(enumerationCount3).ConfigureAwait(false);
                    var enumeration4 = await ((IDataGeneratorField<T4>)field4).CreateTypedEnumerationAsync(enumerationCount4).ConfigureAwait(false);
                    var enumeration5 = await ((IDataGeneratorField<T5>)field5).CreateTypedEnumerationAsync(enumerationCount5).ConfigureAwait(false);
                    var enumeration6 = await ((IDataGeneratorField<T6>)field6).CreateTypedEnumerationAsync(enumerationCount6).ConfigureAwait(false);
                    var enumeration7 = await ((IDataGeneratorField<T7>)field7).CreateTypedEnumerationAsync(enumerationCount7).ConfigureAwait(false);
                    var enumeration8 = await ((IDataGeneratorField<T8>)field8).CreateTypedEnumerationAsync(enumerationCount8).ConfigureAwait(false);
                    var enumeration9 = await ((IDataGeneratorField<T9>)field9).CreateTypedEnumerationAsync(enumerationCount9).ConfigureAwait(false);

                    return context.EnumerableFactory.DirectProduct<T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?>(
                        () => EnumerateFieldValues(enumeration1),
                        () => EnumerateFieldValues(enumeration2),
                        () => EnumerateFieldValues(enumeration3),
                        () => EnumerateFieldValues(enumeration4),
                        () => EnumerateFieldValues(enumeration5),
                        () => EnumerateFieldValues(enumeration6),
                        () => EnumerateFieldValues(enumeration7),
                        () => EnumerateFieldValues(enumeration8),
                        () => EnumerateFieldValues(enumeration9)
                        ).RepeatUntil(generationCount);
                };
            }

            return new DataGeneratorTupleField<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                field1.FieldName, field1.MayBeNull,
                field2.FieldName, field2.MayBeNull,
                field3.FieldName, field3.MayBeNull,
                field4.FieldName, field4.MayBeNull,
                field5.FieldName, field5.MayBeNull,
                field6.FieldName, field6.MayBeNull,
                field7.FieldName, field7.MayBeNull,
                field8.FieldName, field8.MayBeNull,
                field9.FieldName, field9.MayBeNull,
                CreateCreator(field1, field2, field3, field4, field5, field6, field7, field8, field9, context));
        }

        /// <summary>
        /// Enumerates the values of the specified field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        private static IEnumerable<T?> EnumerateFieldValues<T>(IDataGeneratorFieldEnumeration<T> field) where T : struct
        {
            field.Reset();

            while (field.GenerateNext())
            {
                yield return field.GetTypedValue();
            }
        }

        #region exception handling

        private const string ExceptionMessage = "Failed to activate a tuple field.";

        /// <summary>
        /// Create an exception.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="keyException"></param>
        /// <returns></returns>
        private static Exception CreateException(IDataGeneratorField[] fields, Exception keyException)
        {
            static string BuildMessage(IDataGeneratorField[] fields)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(ExceptionMessage);

                sb.Append("Fields: [");

                for (int i = 0; i < fields.Length; ++i)
                {
                    if (i > 0) { sb.Append(", "); }
                    sb.Append(fields[i].FieldName);
                }

                sb.Append("]");

                return sb.ToString();
            }

            return new Exception(BuildMessage(fields), keyException);
        }

        #endregion

    }

}
