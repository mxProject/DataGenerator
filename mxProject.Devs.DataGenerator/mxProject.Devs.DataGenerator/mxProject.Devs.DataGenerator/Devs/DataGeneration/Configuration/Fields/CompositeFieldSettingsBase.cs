using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Basic implementation of settings for a field that generates a value from composite fields.
    /// </summary>
    public abstract class CompositeFieldSettingsBase : DataGeneratorFieldSettings
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected CompositeFieldSettingsBase() : base()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the argument field settings.
        /// </summary>
        [JsonProperty("ArgumentFields", Order = 11)]
        public DataGeneratorFieldSettings[]? ArgumentFields { get; set; }

        /// <summary>
        /// Gets or sets probability of returning null. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("NullProb", Order = 12)]
        public double NullProbability { get; set; }

        #endregion

        #region clone

        /// <inheritdoc/>
        public override object Clone()
        {
            var clone = (CompositeFieldSettingsBase)base.Clone();

            clone.ArgumentFields = DataGeneratorUtility.DeepCloneArray(ArgumentFields);

            return clone;
        }

        #endregion

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (ArgumentFields == null)
            {
                throw new NullReferenceException("The value of Fields property is null.");
            }

            if (NullProbability < 0 || 1 < NullProbability)
            {
                throw new ArgumentOutOfRangeException("The value of the NullProbability property is out of range.");
            }
        }

    }

}
