using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="bool"/> values.
    /// </summary>
    public sealed class RandomBooleanFieldSettings : RandomFieldSettingsBase<bool>
    {
        /// <summary>
        /// Gets or sets probability of returning true. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("TrueProb", Order = 203)]
        public double TrueProbability { get; set; }

        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomBoolean(FieldName!, TrueProbability, NullProbability);
        }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (TrueProbability < 0 || 1 < TrueProbability)
            {
                throw new ArgumentOutOfRangeException("The value of the TrueProbability property is out of range. ");
            }
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="byte"/> values.
    /// </summary>
    public sealed class RandomByteFieldSettings : RandomNumericFieldSettingsBase<byte>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomByte(FieldName!, MinimumValue ?? byte.MinValue, MaximumValue ?? byte.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="sbyte"/> values.
    /// </summary>
    public sealed class RandomSByteFieldSettings : RandomNumericFieldSettingsBase<sbyte>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomSByte(FieldName!, MinimumValue ?? sbyte.MinValue, MaximumValue ?? sbyte.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="short"/> values.
    /// </summary>
    public sealed class RandomInt16FieldSettings : RandomNumericFieldSettingsBase<short>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomInt16(FieldName!, MinimumValue ?? short.MinValue, MaximumValue ?? short.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="ushort"/> values.
    /// </summary>
    public sealed class RandomUInt16FieldSettings : RandomNumericFieldSettingsBase<ushort>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomUInt16(FieldName!, MinimumValue ?? ushort.MinValue, MaximumValue ?? ushort.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="int"/> values.
    /// </summary>
    public sealed class RandomInt32FieldSettings : RandomNumericFieldSettingsBase<int>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomInt32(FieldName!, MinimumValue ?? int.MinValue, MaximumValue ?? int.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="uint"/> values.
    /// </summary>
    public sealed class RandomUInt32FieldSettings : RandomNumericFieldSettingsBase<uint>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomUInt32(FieldName!, MinimumValue ?? uint.MinValue, MaximumValue ?? uint.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="long"/> values.
    /// </summary>
    public sealed class RandomInt64FieldSettings : RandomNumericFieldSettingsBase<long>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomInt64(FieldName!, MinimumValue ?? long.MinValue, MaximumValue ?? long.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="ulong"/> values.
    /// </summary>
    public sealed class RandomUInt64FieldSettings : RandomNumericFieldSettingsBase<ulong>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomUInt64(FieldName!, MinimumValue ?? ulong.MinValue, MaximumValue ?? ulong.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="float"/> values.
    /// </summary>
    public sealed class RandomSingleFieldSettings : RandomNumericFieldSettingsBase<float>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomSingle(FieldName!, MinimumValue ?? float.MinValue, MaximumValue ?? float.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="double"/> values.
    /// </summary>
    public sealed class RandomDoubleFieldSettings : RandomNumericFieldSettingsBase<double>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomDouble(FieldName!, MinimumValue ?? double.MinValue, MaximumValue ?? double.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="decimal"/> values.
    /// </summary>
    public sealed class RandomDecimalFieldSettings : RandomNumericFieldSettingsBase<decimal>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomDecimal(FieldName!, MinimumValue ?? decimal.MinValue, MaximumValue ?? decimal.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="DateTime"/> values.
    /// </summary>
    public sealed class RandomDateTimeFieldSettings : RandomNumericFieldSettingsBase<DateTime>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomDateTime(FieldName!, MinimumValue ?? DateTime.MinValue, MaximumValue ?? DateTime.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="DateTimeOffset"/> values.
    /// </summary>
    public sealed class RandomDateTimeOffsetFieldSettings : RandomNumericFieldSettingsBase<DateTimeOffset>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomDateTimeOffset(FieldName!, MinimumValue ?? DateTimeOffset.MinValue, MaximumValue ?? DateTimeOffset.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="TimeSpan"/> values.
    /// </summary>
    public sealed class RandomTimeSpanFieldSettings : RandomNumericFieldSettingsBase<TimeSpan>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomTimeSpan(FieldName!, MinimumValue ?? TimeSpan.MinValue, MaximumValue ?? TimeSpan.MaxValue, CreateSelectorAsync(context), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the random <see cref="Guid"/> values.
    /// </summary>
    public sealed class RandomGuidFieldSettings : RandomFieldSettingsBase<Guid>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.RandomGuid(FieldName!, NullProbability);
        }
    }

}
