using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates the enum values.
    /// </summary>
    public sealed class EachEnumFieldSettings : EachFieldSettingsBase<string>
    {

        /// <summary>
        /// Gets or sets the enum type name.
        /// </summary>
        [JsonProperty("EnumType", Order = 13)]
        public string? EnumTypeName { get; set; }

        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            var method = typeof(EachEnumFieldSettings).GetMethod(nameof(CreateEnumField), BindingFlags.NonPublic | BindingFlags.Instance);

            return (IDataGeneratorField)method.MakeGenericMethod(Type.GetType(EnumTypeName)).Invoke(this, new object[] { context });
        }

        /// <inheritdoc/>
        protected override int GetValuesCount()
        {
            if (Values != null)
            {
                return Values.Length;
            }
            else
            {
                return Enum.GetValues(Type.GetType(EnumTypeName)).Length;
            }
        }

        private IDataGeneratorField<T> CreateEnumField<T>(DataGeneratorContext context) where T : struct, Enum
        {
            T?[]? values = DataGeneratorUtility.ToEnumArrayOrAllValues<T>(Values);

            return context.FieldFactory.EachEnum<T>(FieldName!, values, NullProbability);
        }
    }

    /// <summary>
    /// Settings for a field to enumerate the specified enum values.
    /// </summary>
    /// <typeparam name="TEnum">The type of value to enumerate.</typeparam>
    public sealed class EachEnumFieldSettings<TEnum> : EachFieldSettingsBase<TEnum> where TEnum : struct, Enum
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.EachEnum(FieldName!, Values!, NullProbability);
        }
    }
}
