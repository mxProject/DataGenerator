using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that lists the specified values in order.
    /// </summary>
    public sealed class EachFieldSettings : DataGeneratorFieldSettings
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        public EachFieldSettings()
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
        /// Gets or sets the values.
        /// </summary>
        [JsonProperty("Values", Order = 13)]
        public string?[]? Values { get; set; }

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
                throw new ArgumentOutOfRangeException("The value of the NullProbability property is out of range.");
            }

            if (GetValuesCount() == 0)
            {
                throw new NullReferenceException("No value has been set for the Values property.");
            }
        }

        /// <summary>
        /// Gets the number of values to enumerate.
        /// </summary>
        /// <returns></returns>
        private int GetValuesCount()
        {
            return Values?.Length ?? 0;
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorField"/> interface.
        /// </summary>
        /// <returns></returns>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            var method = typeof(EachFieldSettings).GetGenericMethod(nameof(CreateField));
            return this.InvokeGenericMethod<IDataGeneratorField>(method, new[] { DataGeneratorUtility.GetFieldValueType(Type.GetType(ValueTypeName)) }, context);
        }

        private IDataGeneratorField CreateField<T>(DataGeneratorContext context) where T : struct
        {
            T?[] values = new T?[Values!.Length];

            for (int i = 0; i < values.Length; ++i)
            {
                if (!string.IsNullOrEmpty(Values[i]))
                {
                    values[i] = context.StringConverter.ConvertTo<T>(Values[i]);
                }
            }

            return context.FieldFactory.Each(FieldName!, values, NullProbability);
        }

    }

}
