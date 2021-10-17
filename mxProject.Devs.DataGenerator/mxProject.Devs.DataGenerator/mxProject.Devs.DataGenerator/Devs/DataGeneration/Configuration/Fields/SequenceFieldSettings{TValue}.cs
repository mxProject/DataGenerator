using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="byte"/> values.
    /// </summary>
    public sealed class SequenceByteFieldSettings : SequenceFieldSettingsBase<byte, byte>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceByte(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="sbyte"/> values.
    /// </summary>
    public sealed class SequenceSByteFieldSettings : SequenceFieldSettingsBase<sbyte, sbyte>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceSByte(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="short"/> values.
    /// </summary>
    public sealed class SequenceInt16FieldSettings : SequenceFieldSettingsBase<short, short>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceInt16(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="ushort"/> values.
    /// </summary>
    public sealed class SequenceUInt16FieldSettings : SequenceFieldSettingsBase<ushort, ushort>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceUInt16(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="int"/> values.
    /// </summary>
    public sealed class SequenceInt32FieldSettings : SequenceFieldSettingsBase<int, int>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceInt32(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="uint"/> values.
    /// </summary>
    public sealed class SequenceUInt32FieldSettings : SequenceFieldSettingsBase<uint, uint>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceUInt32(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="long"/> values.
    /// </summary>
    public sealed class SequenceInt64FieldSettings : SequenceFieldSettingsBase<long, long>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceInt64(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="ulong"/> values.
    /// </summary>
    public sealed class SequenceUInt64FieldSettings : SequenceFieldSettingsBase<ulong, ulong>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceUInt64(FieldName!, InitialValue, MaximumValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="DateTime"/> values.
    /// </summary>
    public sealed class SequenceDateTimeFieldSettings : SequenceFieldSettingsBase<DateTime, TimeSpan>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceDateTime(FieldName!, InitialValue, MaximumValue ?? DateTime.MaxValue, Increment ?? TimeSpan.FromDays(1), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="DateTime"/> values at monthly intervals.
    /// </summary>
    public sealed class SequenceDateMonthFieldSettings : SequenceFieldSettingsBase<DateTime, int>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceDateMonth(FieldName!, InitialValue, MaximumValue ?? DateTime.MaxValue, Increment ?? 1, NullProbability);
        }
    }
    
    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="DateTimeOffset"/> values.
    /// </summary>
    public sealed class SequenceDateTimeOffsetFieldSettings : SequenceFieldSettingsBase<DateTimeOffset, TimeSpan>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceDateTimeOffset(FieldName!, InitialValue, MaximumValue ?? DateTimeOffset.MaxValue, Increment ?? TimeSpan.FromDays(1), NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="DateTime"/> values at monthly intervals.
    /// </summary>
    public sealed class SequenceDateMonthOffsetFieldSettings : SequenceFieldSettingsBase<DateTimeOffset, int>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceDateMonthOffset(FieldName!, InitialValue, MaximumValue ?? DateTime.MaxValue, Increment ?? 1, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field that enumerates the sequential <see cref="TimeSpan"/> values.
    /// </summary>
    public sealed class SequenceTimeSpanFieldSettings : SequenceFieldSettingsBase<TimeSpan, TimeSpan>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.SequenceTimeSpan(FieldName!, InitialValue, MaximumValue ?? TimeSpan.MaxValue, Increment ?? TimeSpan.FromDays(1), NullProbability);
        }
    }

}
