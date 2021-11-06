using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration
{
    /// <summary>
    /// Basic implementation of additional field settings.
    /// </summary>
    public abstract class DataGeneratorAdditionalTupleFieldSettings : ICloneable
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected DataGeneratorAdditionalTupleFieldSettings()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the additional field information.
        /// </summary>
        [JsonProperty("AdditionalFields", Order = 1)]
        public DataGeneratorFieldInfo[]? AdditionalFields { get; set; }

        #endregion

        #region clone

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            var clone = (DataGeneratorAdditionalTupleFieldSettings)MemberwiseClone();

            clone.AdditionalFields = DataGeneratorUtility.DeepCloneArray(AdditionalFields);

            return clone;
        }

        #endregion
        
        /// <summary>
        /// Gets the additional field names;
        /// </summary>
        /// <returns></returns>
        public virtual string?[] GetAdditionalFieldNames()
        {
            if (AdditionalFields == null) { return new string[] { }; }

            string?[] names = new string[AdditionalFields.Length];

            for (int i = 0; i < AdditionalFields.Length; ++i)
            {
                names[i] = AdditionalFields[i]?.FieldName;
            }

            return names;
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorAdditionalTupleField"/> interface.
        /// </summary>
        /// <exception cref="DataGeneratorFieldException">
        /// The field setting is invalid.
        /// </exception>
        /// <returns></returns>
        public IDataGeneratorAdditionalTupleField CreateField(DataGeneratorContext context)
        {
            try
            {
                Assert();
                return CreateFieldCore(context);
            }
            catch (Exception ex)
            {
                string?[] fieldNames = GetAdditionalFieldNames();
                throw new DataGeneratorFieldException($"The field setting is invalid. {ex.Message} (FieldName: {string.Join(", ", fieldNames)})", fieldNames, ex);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorAdditionalTupleField"/> interface.
        /// </summary>
        /// <returns></returns>
        protected abstract IDataGeneratorAdditionalTupleField CreateFieldCore(DataGeneratorContext context);

        /// <summary>
        /// If the settings for this instance are invalid, an exception will be thrown.
        /// </summary>
        protected virtual void Assert()
        {
            if (AdditionalFields == null)
            {
                throw new NullReferenceException("The value of AdditionalFields property is null.");
            }
        }

    }

}
