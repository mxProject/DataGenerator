using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{
    /// <summary>
    /// Settings for a field that enumerates the random values.
    /// </summary>
    public class RandomFieldSettings : DataGeneratorFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public RandomFieldSettings()
        {
        }

        /// <summary>
        /// Gets or sets the value type name.
        /// </summary>
        [JsonProperty("ValueType", Order = 11)]
        public string? ValueTypeName { get; set; }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        [JsonProperty("Min", Order = 12)]
        public string? MinimumValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        [JsonProperty("Max", Order = 13)]
        public string? MaximumValue { get; set; }

        /// <summary>
        /// Gets or sets probability of returning null. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("NullProb", Order = 14)]
        public double NullProbability { get; set; }

        /// <summary>
        /// Gets or sets the expression text of the selector. ex) "x => System.Round(x, 1)"
        /// </summary>
        [JsonProperty("Selector", Order = 15)]
        public string? SelectorExpression { get; set; }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (ValueTypeName == null)
            {
                throw new NullReferenceException("The value of the ValueTypeName property is null.");
            }

            if (NullProbability < 0 || 1 < NullProbability)
            {
                throw new ArgumentOutOfRangeException("");
            }
        }

        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            var type = DataGeneratorUtility.GetFieldValueType(Type.GetType(ValueTypeName));

            if (type == typeof(bool))
            {
                return context.FieldFactory.RandomBoolean(FieldName!, 0.5, NullProbability);
            }
            else if (type == typeof(byte))
            {
                var min = context.StringConverter.ConvertToOrNull<byte>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<byte>(MaximumValue);
                return context.FieldFactory.RandomByte(FieldName!, min ?? byte.MinValue, max ?? byte.MaxValue, CreateSelectorAsync<byte>(context), NullProbability);
            }
            else if (type == typeof(sbyte))
            {
                var min = context.StringConverter.ConvertToOrNull<sbyte>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<sbyte>(MaximumValue);
                return context.FieldFactory.RandomSByte(FieldName!, min ?? sbyte.MinValue, max ?? sbyte.MaxValue, CreateSelectorAsync<sbyte>(context), NullProbability);
            }
            else if (type == typeof(short))
            {
                var min = context.StringConverter.ConvertToOrNull<short>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<short>(MaximumValue);
                return context.FieldFactory.RandomInt16(FieldName!, min ?? short.MinValue, max ?? short.MaxValue, CreateSelectorAsync<short>(context), NullProbability);
            }
            else if (type == typeof(ushort))
            {
                var min = context.StringConverter.ConvertToOrNull<ushort>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<ushort>(MaximumValue);
                return context.FieldFactory.RandomUInt16(FieldName!, min ?? ushort.MinValue, max ?? ushort.MaxValue, CreateSelectorAsync<ushort>(context), NullProbability);
            }
            else if (type == typeof(int))
            {
                var min = context.StringConverter.ConvertToOrNull<short>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<short>(MaximumValue);
                return context.FieldFactory.RandomInt32(FieldName!, min ?? int.MinValue, max ?? int.MaxValue, CreateSelectorAsync<int>(context), NullProbability);
            }
            else if (type == typeof(uint))
            {
                var min = context.StringConverter.ConvertToOrNull<uint>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<uint>(MaximumValue);
                return context.FieldFactory.RandomUInt32(FieldName!, min ?? uint.MinValue, max ?? uint.MaxValue, CreateSelectorAsync<uint>(context), NullProbability);
            }
            else if (type == typeof(long))
            {
                var min = context.StringConverter.ConvertToOrNull<long>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<long>(MaximumValue);
                return context.FieldFactory.RandomInt64(FieldName!, min ?? long.MinValue, max ?? long.MaxValue, CreateSelectorAsync<long>(context), NullProbability);
            }
            else if (type == typeof(ulong))
            {
                var min = context.StringConverter.ConvertToOrNull<ulong>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<ulong>(MaximumValue);
                return context.FieldFactory.RandomUInt64(FieldName!, min ?? ulong.MinValue, max ?? ulong.MaxValue, CreateSelectorAsync<ulong>(context), NullProbability);
            }
            else if (type == typeof(float))
            {
                var min = context.StringConverter.ConvertToOrNull<float>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<float>(MaximumValue);
                return context.FieldFactory.RandomSingle(FieldName!, min ?? float.MinValue, max ?? float.MaxValue, CreateSelectorAsync<float>(context), NullProbability);
            }
            else if (type == typeof(double))
            {
                var min = context.StringConverter.ConvertToOrNull<double>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<double>(MaximumValue);
                return context.FieldFactory.RandomDouble(FieldName!, min ?? double.MinValue, max ?? double.MaxValue, CreateSelectorAsync<double>(context), NullProbability);
            }
            else if (type == typeof(decimal))
            {
                var min = context.StringConverter.ConvertToOrNull<decimal>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<decimal>(MaximumValue);
                return context.FieldFactory.RandomDecimal(FieldName!, min ?? decimal.MinValue, max ?? decimal.MaxValue, CreateSelectorAsync<decimal>(context), NullProbability);
            }
            else if (type == typeof(DateTime))
            {
                var min = context.StringConverter.ConvertToOrNull<DateTime>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<DateTime>(MaximumValue);
                return context.FieldFactory.RandomDateTime(FieldName!, min ?? DateTime.MinValue, max ?? DateTime.MaxValue, CreateSelectorAsync<DateTime>(context), NullProbability);
            }
            else if (type == typeof(DateTimeOffset))
            {
                var min = context.StringConverter.ConvertToOrNull<DateTimeOffset>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<DateTimeOffset>(MaximumValue);
                return context.FieldFactory.RandomDateTimeOffset(FieldName!, min ?? DateTimeOffset.MinValue, max ?? DateTimeOffset.MaxValue, CreateSelectorAsync<DateTimeOffset>(context), NullProbability);
            }
            else if (type == typeof(TimeSpan))
            {
                var min = context.StringConverter.ConvertToOrNull<TimeSpan>(MinimumValue);
                var max = context.StringConverter.ConvertToOrNull<TimeSpan>(MaximumValue);
                return context.FieldFactory.RandomTimeSpan(FieldName!, min ?? TimeSpan.MinValue, max ?? TimeSpan.MaxValue, CreateSelectorAsync<TimeSpan>(context), NullProbability);
            }
            else if (type == typeof(Guid))
            {
                return context.FieldFactory.RandomGuid(FieldName!, NullProbability);
            }
            else
            {
                throw new NotSupportedException();
            }

        }

        /// <summary>
        /// Creates a selector from the expression text set in <see cref="SelectorExpression"/> property.
        /// </summary>
        /// <returns>A selector.</returns>
        private Task<Func<TValue, TValue>?> CreateSelectorAsync<TValue>(DataGeneratorContext context)
        {
            if (string.IsNullOrWhiteSpace(SelectorExpression)) { return Task.FromResult((Func<TValue, TValue>?)null); }

            return CSharpScriptUtility.CreateFuncAsync<Func<TValue, TValue>?>(SelectorExpression!, context);
        }

    }

}
