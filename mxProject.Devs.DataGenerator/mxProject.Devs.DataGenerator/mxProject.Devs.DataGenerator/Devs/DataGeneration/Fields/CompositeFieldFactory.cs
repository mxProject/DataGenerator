using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.Fields
{

    /// <summary>
    /// Creates a field that generates values based on composite fields.
    /// </summary>
    public static class CompositeFieldFactory
    {

        #region FormattedString

        /// <summary>
        /// Creates a field that enumerates string values formatted with the specified format string.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="formatString">The composite format string. Field names are not supported. Specify by field index.</param>
        /// <param name="argumentFields">The fields that generates the value of the argument applied to the format string.</param>
        /// <param name="context">The context.</param>
        /// <param name="nullProbability">A value that indicates probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public static IDataGeneratorField CreateFormattedStringField(string fieldName, string formatString, IEnumerable<IDataGeneratorField> argumentFields, DataGeneratorContext context, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<object?>> EnumerationCreator(int generateCount)
            {
                DataGeneratorBuilder builder = new DataGeneratorBuilder(context.FieldFactory);

                foreach (var field in argumentFields)
                {
                    builder.AddField(field);
                }

                static IEnumerable<object?> GetValues(System.Data.IDataReader reader, string formatString, double nullProbability, DataGeneratorContext context)
                {
                    object?[] values = new object?[reader.FieldCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);

                        if (context.RandomGenerator.NextDouble(0, 1) <= nullProbability)
                        {
                            yield return null;
                        }
                        else
                        {
                            yield return string.Format(formatString, values);
                        }
                    }
                }

                using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

                return GetValues(reader, formatString, nullProbability, context);
            }

            return new DataGeneratorField(fieldName, typeof(StringValue), null, false, EnumerationCreator);
        }

        #endregion

        #region Computing

        /// <summary>
        /// Creates a field that enumerates string values formatted with the specified format string.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="expression">The expression text. ex) "(x, y) => x * y"</param>
        /// <param name="argumentFields">The fields that generates the value of the argument applied to the expression text.</param>
        /// <param name="context">The context.</param>
        /// <param name="nullProbability">A value that indicates probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public static IDataGeneratorField CreateComputingField(string fieldName, string expression, IEnumerable<IDataGeneratorField> argumentFields, DataGeneratorContext context, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<object?>> EnumerationCreator(int generateCount)
            {
                DataGeneratorBuilder builder = new DataGeneratorBuilder(context.FieldFactory);
                List<Type> valueTypes = new();

                foreach (var field in argumentFields)
                {
                    builder.AddField(field);
                    valueTypes.Add(DataGeneratorUtility.GetClrValueType(field.ValueType));
                }

                using var reader = await builder.BuildAsDataReaderAsync(generateCount).ConfigureAwait(false);

                return await GetValuesAsync(MakeFuncType(valueTypes.ToArray()), reader, expression, nullProbability, context).ConfigureAwait(false);
            }

            return new DataGeneratorField(fieldName, typeof(StringValue), null, false, EnumerationCreator);
        }

        private static ValueTask<IEnumerable<object?>> GetValuesAsync(Type funcType, System.Data.IDataReader reader, string expression, double nullProbability, DataGeneratorContext context)
        {
            var t = typeof(CompositeFieldFactory);
            var method = t.GetGenericMethod(nameof(GetValuesAsyncCore));

            return (ValueTask<IEnumerable<object?>>)t.InvokeStaticGenericMethod(method, new[] { funcType }, reader, expression, nullProbability, context)!;
        }

        private async static ValueTask<IEnumerable<object?>> GetValuesAsyncCore<TFunc>(System.Data.IDataReader reader, string expression, double nullProbability, DataGeneratorContext context)
             where TFunc : Delegate
        {
            static IEnumerable<object?> GetValues(System.Data.IDataReader reader, TFunc func, double nullProbability, DataGeneratorContext context)
            {
                object?[] values = new object?[reader.FieldCount];

                while (reader.Read())
                {
                    reader.GetValues(values);

                    if (context.RandomGenerator.NextDouble(0, 1) <= nullProbability)
                    {
                        yield return null;
                    }
                    else
                    {
                        yield return func.DynamicInvoke(values);
                    }
                }
            }

            var func = await CSharpScriptUtility.CreateFuncAsync<TFunc>(expression, context).ConfigureAwait(false);

            return GetValues(reader, func, nullProbability, context);
        }

        private static Type MakeFuncType(params Type[] argumentTypes)
        {
            if (argumentTypes.Length > 9)
            {
                throw new NotSupportedException("The specified number of fields is not supported.");
            }

            var t = typeof(CompositeFieldFactory);
            var method = t.GetGenericMethod(nameof(MakeFuncTypeCore));

            Type[] types;

            if (argumentTypes.Length == 9)
            {
                types = argumentTypes;
            }
            else
            {
                types = new Type[9];

                argumentTypes.CopyTo(types, 0);

                for (int i = argumentTypes.Length; i < types.Length; ++i)
                {
                    types[i] = typeof(MissingType);
                }
            }

            return (Type)t.InvokeStaticGenericMethod(method, types)!;
        }

        private static Type MakeFuncTypeCore<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            if (typeof(TArg1) == typeof(MissingType)) { return typeof(Func<object?>); }
            if (typeof(TArg2) == typeof(MissingType)) { return typeof(Func<TArg1, object?>); }
            if (typeof(TArg3) == typeof(MissingType)) { return typeof(Func<TArg1, TArg2, object?>); }
            if (typeof(TArg4) == typeof(MissingType)) { return typeof(Func<TArg1, TArg2, TArg3, object?>); }
            if (typeof(TArg5) == typeof(MissingType)) { return typeof(Func<TArg1, TArg2, TArg3, TArg4, object?>); }
            if (typeof(TArg6) == typeof(MissingType)) { return typeof(Func<TArg1, TArg2, TArg3, TArg4, TArg5, object?>); }
            if (typeof(TArg7) == typeof(MissingType)) { return typeof(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, object?>); }
            if (typeof(TArg8) == typeof(MissingType)) { return typeof(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, object?>); }
            if (typeof(TArg9) == typeof(MissingType)) { return typeof(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, object?>); }
            return typeof(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, object?>);
        }

        private struct MissingType
        {
        }

        #endregion

    }

}
