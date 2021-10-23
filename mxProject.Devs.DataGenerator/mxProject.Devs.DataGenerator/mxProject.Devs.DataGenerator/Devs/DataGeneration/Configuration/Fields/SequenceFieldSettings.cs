using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates the sequential values.
    /// </summary>
    public class SequenceFieldSettings : DataGeneratorFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public SequenceFieldSettings()
        {
        }

        /// <summary>
        /// Gets or sets the value type name.
        /// </summary>
        [JsonProperty("ValueType", Order = 11)]
        public string? ValueTypeName { get; set; }

        /// <summary>
        /// Gets or sets probability of returning null. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("NullProb", Order = 12)]
        public double NullProbability { get; set; }

        /// <summary>
        /// Gets or sets the initial value.
        /// </summary>
        [JsonProperty("Initial", Order = 13)]
        public string? InitialValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        [JsonProperty("Max", Order = 14)]
        public string? MaximumValue { get; set; }

        /// <summary>
        /// Gets or sets the amount of increase in value when creating a new sequence value.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If ValueTypeName is "System.DateTime" or "System.DateTimePffset", the string value that can be converted to int type is considered as the number of months, otherwise it is converted to TimeSpan type. 
        /// </para>
        /// </remarks>
        [JsonProperty("Increment", Order = 15)]
        public string? Increment { get; set; }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (ValueTypeName == null)
            {
                throw new NullReferenceException("The value of the ValueTypeName property is null.");
            }

            if (InitialValue == null)
            {
                throw new NullReferenceException("The value of the InitialValue property is null.");
            }

            if (MaximumValue == null)
            {
                throw new NullReferenceException("The value of the MaximumValue property is null.");
            }

            if (NullProbability < 0 || 1 < NullProbability)
            {
                throw new ArgumentOutOfRangeException("The value of the NullProbability property is out of range.");
            }
        }

        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            var type = DataGeneratorUtility.GetFieldValueType(Type.GetType(ValueTypeName));

            if (type == typeof(byte))
            {
                var initial = context.StringConverter.ConvertTo<byte>(InitialValue);
                var max = context.StringConverter.ConvertTo<byte>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? (byte)1 : context.StringConverter.ConvertTo<byte>(Increment);
                return context.FieldFactory.SequenceByte(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(sbyte))
            {
                var initial = context.StringConverter.ConvertTo<sbyte>(InitialValue);
                var max = context.StringConverter.ConvertTo<sbyte>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? (sbyte)1 : context.StringConverter.ConvertTo<sbyte>(Increment);
                return context.FieldFactory.SequenceSByte(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(short))
            {
                var initial = context.StringConverter.ConvertTo<short>(InitialValue);
                var max = context.StringConverter.ConvertTo<short>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? (short)1 : context.StringConverter.ConvertTo<short>(Increment);
                return context.FieldFactory.SequenceInt16(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(ushort))
            {
                var initial = context.StringConverter.ConvertTo<ushort>(InitialValue);
                var max = context.StringConverter.ConvertTo<ushort>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? (ushort)1 : context.StringConverter.ConvertTo<ushort>(Increment);
                return context.FieldFactory.SequenceUInt16(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(int))
            {
                var initial = context.StringConverter.ConvertTo<int>(InitialValue);
                var max = context.StringConverter.ConvertTo<int>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? 1 : context.StringConverter.ConvertTo<int>(Increment);
                return context.FieldFactory.SequenceInt32(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(uint))
            {
                var initial = context.StringConverter.ConvertTo<uint>(InitialValue);
                var max = context.StringConverter.ConvertTo<uint>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? 1 : context.StringConverter.ConvertTo<uint>(Increment);
                return context.FieldFactory.SequenceUInt32(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(long))
            {
                var initial = context.StringConverter.ConvertTo<long>(InitialValue);
                var max = context.StringConverter.ConvertTo<long>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? 1 : context.StringConverter.ConvertTo<long>(Increment);
                return context.FieldFactory.SequenceInt64(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(ulong))
            {
                var initial = context.StringConverter.ConvertTo<ulong>(InitialValue);
                var max = context.StringConverter.ConvertTo<ulong>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? 1 : context.StringConverter.ConvertTo<ulong>(Increment);
                return context.FieldFactory.SequenceUInt64(FieldName!, initial, max, increment, NullProbability);
            }
            else if (type == typeof(DateTime))
            {
                var initial = context.StringConverter.ConvertTo<DateTime>(InitialValue);
                var max = context.StringConverter.ConvertTo<DateTime>(MaximumValue);

                if (int.TryParse(Increment, out int months))
                {
                    return context.FieldFactory.SequenceDateMonth(FieldName!, initial, max, months, NullProbability);
                }
                else
                {
                    var increment = string.IsNullOrEmpty(Increment) ? TimeSpan.FromDays(1) : context.StringConverter.ConvertTo<TimeSpan>(Increment);
                    return context.FieldFactory.SequenceDateTime(FieldName!, initial, max, increment, NullProbability);
                }
            }
            else if (type == typeof(DateTimeOffset))
            {
                var initial = context.StringConverter.ConvertTo<DateTimeOffset>(InitialValue);
                var max = context.StringConverter.ConvertTo<DateTimeOffset>(MaximumValue);

                if (int.TryParse(Increment, out int months))
                {
                    return context.FieldFactory.SequenceDateMonthOffset(FieldName!, initial, max, months, NullProbability);
                }
                else
                {
                    var increment = string.IsNullOrEmpty(Increment) ? TimeSpan.FromDays(1) : context.StringConverter.ConvertTo<TimeSpan>(Increment);
                    return context.FieldFactory.SequenceDateTimeOffset(FieldName!, initial, max, increment, NullProbability);
                }
            }
            else if (type == typeof(TimeSpan))
            {
                var initial = context.StringConverter.ConvertTo<TimeSpan>(InitialValue);
                var max = context.StringConverter.ConvertTo<TimeSpan>(MaximumValue);
                var increment = string.IsNullOrEmpty(Increment) ? TimeSpan.FromDays(1) : context.StringConverter.ConvertTo<TimeSpan>(Increment);
                return context.FieldFactory.SequenceTimeSpan(FieldName!, initial, max, increment, NullProbability);
            }
            else
            {
                throw new NotSupportedException($"The specified type is not supported. ValueTypeName: {ValueTypeName}");
            }
        }

    }

}
