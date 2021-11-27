using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using JsonSubTypes;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using mxProject.Devs.DataGeneration.Configuration.AdditionalFields;

namespace mxProject.Devs.DataGeneration.Configuration.Json
{

    /// <summary>
    /// JSON converter builder for resolving subtypes of DataGeneratorField.
    /// </summary>
    public class DataGeneratorFieldTypeConverterBuilder
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public DataGeneratorFieldTypeConverterBuilder()
        {
            DataGeneratorFieldSettingsBuilder = new JsonSubtypesConverterBuilder();
            DataGeneratorTupleFieldSettingsBuilder = new JsonSubtypesConverterBuilder();
            AdditionalFieldSettingsBuilder = new JsonSubtypesConverterBuilder();
            AdditionalTupleFieldSettingsBuilder = new JsonSubtypesConverterBuilder();
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldSettingsBuilder"></param>
        /// <param name="tupleFieldSettingsBuilder"></param>
        /// <param name="additionalFieldSettingsBuilder"></param>
        /// <param name="additionalTupleFieldSettingsBuilder"></param>
        private DataGeneratorFieldTypeConverterBuilder(JsonSubtypesConverterBuilder fieldSettingsBuilder, JsonSubtypesConverterBuilder tupleFieldSettingsBuilder, JsonSubtypesConverterBuilder additionalFieldSettingsBuilder, JsonSubtypesConverterBuilder additionalTupleFieldSettingsBuilder)
        {
            DataGeneratorFieldSettingsBuilder = fieldSettingsBuilder;
            DataGeneratorTupleFieldSettingsBuilder = tupleFieldSettingsBuilder;
            AdditionalFieldSettingsBuilder = additionalFieldSettingsBuilder;
            AdditionalTupleFieldSettingsBuilder = additionalTupleFieldSettingsBuilder;
        }

        #endregion

        #region factory method

        /// <summary>
        /// Create a default instance.
        /// </summary>
        /// <returns></returns>
        public static DataGeneratorFieldTypeConverterBuilder CreateDefault()
        {
            var fieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorFieldSettings), "FieldType");
            var tupleFieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorTupleFieldSettings), "FieldType");
            var additionalFieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorAdditionalFieldSettings), "FieldType");
            var additionalTupleFieldSettingsbuilder = JsonSubtypesConverterBuilder.Of(typeof(DataGeneratorAdditionalTupleFieldSettings), "FieldType");

            return new DataGeneratorFieldTypeConverterBuilder(fieldSettingsbuilder, tupleFieldSettingsbuilder, additionalFieldSettingsbuilder, additionalTupleFieldSettingsbuilder)
                .RegisterField<EachFieldSettings>("Each")
                .RegisterField<EachFieldSettings<bool>>("EachBoolean")
                .RegisterField<EachFieldSettings<byte>>("EachByte")
                .RegisterField<EachFieldSettings<sbyte>>("EachSByte")
                .RegisterField<EachFieldSettings<short>>("EachInt16")
                .RegisterField<EachFieldSettings<ushort>>("EachUInt16")
                .RegisterField<EachFieldSettings<int>>("EachInt32")
                .RegisterField<EachFieldSettings<uint>>("EachUInt32")
                .RegisterField<EachFieldSettings<long>>("EachInt64")
                .RegisterField<EachFieldSettings<ulong>>("EachUInt64")
                .RegisterField<EachFieldSettings<float>>("EachSingle")
                .RegisterField<EachFieldSettings<double>>("EachDouble")
                .RegisterField<EachFieldSettings<decimal>>("EachDecimal")
                .RegisterField<EachFieldSettings<DateTime>>("EachDateTime")
                .RegisterField<EachFieldSettings<DateTimeOffset>>("EachDateTimeOffset")
                .RegisterField<EachFieldSettings<TimeSpan>>("EachTimeSpan")
                .RegisterField<EachFieldSettings<char>>("EachChar")
                .RegisterField<EachFieldSettings<StringValue>>("EachStringValue")
                .RegisterField<EachFieldSettings<Guid>>("EachGuid")
                .RegisterField<EachStringFieldSettings>("EachString")
                .RegisterField<EachEnumFieldSettings>("EachEnum")

                .RegisterField<AnyFieldSettings>("Any")
                .RegisterField<AnyFieldSettings<bool>>("AnyBoolean")
                .RegisterField<AnyFieldSettings<byte>>("AnyByte")
                .RegisterField<AnyFieldSettings<sbyte>>("AnySByte")
                .RegisterField<AnyFieldSettings<short>>("AnyInt16")
                .RegisterField<AnyFieldSettings<ushort>>("AnyUInt16")
                .RegisterField<AnyFieldSettings<int>>("AnyInt32")
                .RegisterField<AnyFieldSettings<uint>>("AnyUInt32")
                .RegisterField<AnyFieldSettings<long>>("AnyInt64")
                .RegisterField<AnyFieldSettings<ulong>>("AnyUInt64")
                .RegisterField<AnyFieldSettings<float>>("AnySingle")
                .RegisterField<AnyFieldSettings<double>>("AnyDouble")
                .RegisterField<AnyFieldSettings<decimal>>("AnyDecimal")
                .RegisterField<AnyFieldSettings<DateTime>>("AnyDateTime")
                .RegisterField<AnyFieldSettings<DateTimeOffset>>("AnyDateTimeOffset")
                .RegisterField<AnyFieldSettings<TimeSpan>>("AnyTimeSpan")
                .RegisterField<AnyFieldSettings<char>>("AnyChar")
                .RegisterField<AnyFieldSettings<StringValue>>("AnyStringValue")
                .RegisterField<AnyFieldSettings<Guid>>("AnyGuid")
                .RegisterField<AnyStringFieldSettings>("AnyString")
                .RegisterField<AnyEnumFieldSettings>("AnyEnum")

                .RegisterField<RandomFieldSettings>("Random")
                .RegisterField<RandomBooleanFieldSettings>("RandomBoolean")
                .RegisterField<RandomByteFieldSettings>("RandomByte")
                .RegisterField<RandomSByteFieldSettings>("RandomSByte")
                .RegisterField<RandomInt16FieldSettings>("RandomInt16")
                .RegisterField<RandomUInt16FieldSettings>("RandomUInt16")
                .RegisterField<RandomInt32FieldSettings>("RandomInt32")
                .RegisterField<RandomUInt32FieldSettings>("RandomUInt32")
                .RegisterField<RandomInt64FieldSettings>("RandomInt64")
                .RegisterField<RandomUInt64FieldSettings>("RandomUInt64")
                .RegisterField<RandomSingleFieldSettings>("RandomSingle")
                .RegisterField<RandomDoubleFieldSettings>("RandomDouble")
                .RegisterField<RandomDecimalFieldSettings>("RandomDecimal")
                .RegisterField<RandomDateTimeFieldSettings>("RandomDateTime")
                .RegisterField<RandomDateTimeOffsetFieldSettings>("RandomDateTimeOffset")
                .RegisterField<RandomTimeSpanFieldSettings>("RandomTimeSpan")
                .RegisterField<RandomGuidFieldSettings>("RandomGuid")

                .RegisterField<SequenceFieldSettings>("Sequence")
                .RegisterField<SequenceByteFieldSettings>("SequenceByte")
                .RegisterField<SequenceSByteFieldSettings>("SequenceSByte")
                .RegisterField<SequenceInt16FieldSettings>("SequenceInt16")
                .RegisterField<SequenceUInt16FieldSettings>("SequenceUInt16")
                .RegisterField<SequenceInt32FieldSettings>("SequenceInt32")
                .RegisterField<SequenceUInt32FieldSettings>("SequenceUInt32")
                .RegisterField<SequenceInt64FieldSettings>("SequenceInt64")
                .RegisterField<SequenceUInt64FieldSettings>("SequenceUInt64")
                .RegisterField<SequenceDateTimeFieldSettings>("SequenceDateTime")
                .RegisterField<SequenceDateMonthFieldSettings>("SequenceDateMonth")
                .RegisterField<SequenceDateTimeOffsetFieldSettings>("SequenceDateTimeOffset")
                .RegisterField<SequenceDateMonthOffsetFieldSettings>("SequenceDateMonthOffset")
                .RegisterField<SequenceTimeSpanFieldSettings>("SequenceTimeSpan")

                .RegisterField<FormattedStringFieldSettings>("FormattedString")
                .RegisterField<ComputingFieldSettings>("Computing")
                
                .RegisterTupleField<DirectProductFieldSettings>("DirectProduct")
                .RegisterTupleField<EachTupleFieldSettings>("EachTuple")

                .RegisterAdditionalField<ExpressionFieldSettings>("Expression")

                .RegisterAdditionalTupleField<JoinFieldSettings>("Join")
                .RegisterAdditionalTupleField<JoinDbQueryFieldSettings>("JoinDbQuery")

                .RegisterField<DbQueryFieldSettings>("DbQueryField")
                .RegisterTupleField<DbQueryFieldsSettings>("DbQueryFields")
                ;
        }

        #endregion

        private JsonSubtypesConverterBuilder DataGeneratorFieldSettingsBuilder { get; }

        private JsonSubtypesConverterBuilder DataGeneratorTupleFieldSettingsBuilder { get; }

        private JsonSubtypesConverterBuilder AdditionalFieldSettingsBuilder { get; }

        private JsonSubtypesConverterBuilder AdditionalTupleFieldSettingsBuilder { get; }

        /// <summary>
        /// Registers the specified subtype of <see cref="DataGeneratorFieldSettings"/>.
        /// </summary>
        /// <typeparam name="T">The subtype.</typeparam>
        /// <param name="name">The name to associate with the subtype.</param>
        /// <returns></returns>
        public DataGeneratorFieldTypeConverterBuilder RegisterField<T>(string name) where T : DataGeneratorFieldSettings
        {
            DataGeneratorFieldSettingsBuilder.RegisterSubtype(typeof(T), name);
            return this;
        }

        /// <summary>
        /// Registers the specified subtype of <see cref="DataGeneratorTupleFieldSettings"/>.
        /// </summary>
        /// <typeparam name="T">The subtype.</typeparam>
        /// <param name="name">The name to associate with the subtype.</param>
        /// <returns></returns>
        public DataGeneratorFieldTypeConverterBuilder RegisterTupleField<T>(string name) where T : DataGeneratorTupleFieldSettings
        {
            DataGeneratorTupleFieldSettingsBuilder.RegisterSubtype(typeof(T), name);
            return this;
        }

        /// <summary>
        /// Registers the specified subtype of <see cref="DataGeneratorAdditionalFieldSettings"/>.
        /// </summary>
        /// <typeparam name="T">The subtype.</typeparam>
        /// <param name="name">The name to associate with the subtype.</param>
        /// <returns></returns>
        public DataGeneratorFieldTypeConverterBuilder RegisterAdditionalField<T>(string name) where T : DataGeneratorAdditionalFieldSettings
        {
            AdditionalFieldSettingsBuilder.RegisterSubtype(typeof(T), name);
            return this;
        }

        /// <summary>
        /// Registers the specified subtype of <see cref="DataGeneratorAdditionalTupleFieldSettings"/>.
        /// </summary>
        /// <typeparam name="T">The subtype.</typeparam>
        /// <param name="name">The name to associate with the subtype.</param>
        /// <returns></returns>
        public DataGeneratorFieldTypeConverterBuilder RegisterAdditionalTupleField<T>(string name) where T : DataGeneratorAdditionalTupleFieldSettings
        {
            AdditionalTupleFieldSettingsBuilder.RegisterSubtype(typeof(T), name);
            return this;
        }

        /// <summary>
        /// Creates a JSON converter.
        /// </summary>
        /// <returns></returns>
        public IList<JsonConverter> Build()
        {
            return new[] {
                DataGeneratorFieldSettingsBuilder.SerializeDiscriminatorProperty().Build(),
                DataGeneratorTupleFieldSettingsBuilder.SerializeDiscriminatorProperty().Build(),
                AdditionalFieldSettingsBuilder.SerializeDiscriminatorProperty().Build(),
                AdditionalTupleFieldSettingsBuilder.SerializeDiscriminatorProperty().Build()
            };
        }

    }

}
