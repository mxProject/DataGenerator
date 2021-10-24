using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Basic implementation of settings for a field that lists the seaquencial values.
    /// </summary>
    /// <typeparam name="TValue">The type of value to enumerate.</typeparam>
    /// <typeparam name="TIncrement">The type of increment value.</typeparam>
    public abstract class SequenceFieldSettingsBase<TValue, TIncrement> : DataGeneratorFieldSettings
        where TValue : struct
        where TIncrement : struct
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected SequenceFieldSettingsBase()
        {
        }

        /// <summary>
        /// Gets or sets probability of returning null. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("NullProb", Order = 11)]
        public double NullProbability { get; set; }

        /// <summary>
        /// Gets or sets the initial value.
        /// </summary>
        [JsonProperty("Initial", Order = 12)]
        public TValue InitialValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        [JsonProperty("Max", Order = 13)]
        public TValue? MaximumValue { get; set; }

        /// <summary>
        /// Gets or sets the amount of increase in value when creating a new sequence value.
        /// </summary>
        [JsonProperty("Increment", Order = 14)]
        public TIncrement? Increment { get; set; }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (NullProbability < 0 || 1 < NullProbability)
            {
                throw new ArgumentOutOfRangeException("The value of the NullProbability property is out of range.");
            }
        }

    }

}
