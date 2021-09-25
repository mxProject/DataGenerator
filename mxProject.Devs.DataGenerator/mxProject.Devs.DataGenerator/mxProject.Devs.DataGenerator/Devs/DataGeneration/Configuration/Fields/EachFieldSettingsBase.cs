using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Basic implementation of settings for a field that lists the specified values in order.
    /// </summary>
    public abstract class EachFieldSettingsBase<TValue> : DataGeneratorFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected EachFieldSettingsBase()
        {
        }

        /// <summary>
        /// Gets or sets probability of returning null. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("NullProb", Order = 11)]
        public double NullProbability { get; set; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        [JsonProperty("Values", Order = 12)]
        public TValue?[]? Values { get; set; }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

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
        protected virtual int GetValuesCount()
        {
            return Values?.Length ?? 0;
        }
    }

}
