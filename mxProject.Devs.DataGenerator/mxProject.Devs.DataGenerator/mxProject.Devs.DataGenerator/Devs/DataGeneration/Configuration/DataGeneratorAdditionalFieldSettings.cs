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
    public abstract class DataGeneratorAdditionalFieldSettings : ICloneable
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected DataGeneratorAdditionalFieldSettings()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the additional field name.
        /// </summary>
        [JsonProperty("FieldName", Order = 1)]
        public string? FieldName { get; set; }

        /// <summary>
        /// Gets or sets the type of the additional field.
        /// </summary>
        [JsonProperty("ValueType", Order = 2)]
        public string? ValueType { get; set; }

        #endregion

        #region clone

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        /// <summary>
        /// Gets the type of the additional field.
        /// </summary>
        /// <returns></returns>
        internal Type? GetValueType()
        {
            if (string.IsNullOrWhiteSpace(ValueType)) { return null!; }

            return DataGeneratorUtility.GetFieldValueType(Type.GetType(ValueType));
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorAdditionalField"/> interface.
        /// </summary>
        /// <exception cref="DataGeneratorFieldException">
        /// The field setting is invalid.
        /// </exception>
        /// <returns></returns>
        public IDataGeneratorAdditionalField CreateField(DataGeneratorContext context)
        {
            try
            {
                Assert();
                return CreateFieldCore(context);
            }
            catch (Exception ex)
            {
                throw new DataGeneratorFieldException($"The field setting is invalid. {ex.Message} (FieldName: {FieldName})", FieldName, ex);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorAdditionalField"/> interface.
        /// </summary>
        /// <returns></returns>
        protected abstract IDataGeneratorAdditionalField CreateFieldCore(DataGeneratorContext context);

        /// <summary>
        /// If the settings for this instance are invalid, an exception will be thrown.
        /// </summary>
        protected virtual void Assert()
        {
            if (FieldName == null)
            {
                throw new NullReferenceException("The value of FieldName property is null.");
            }

            if (GetValueType() == null)
            {
                throw new NullReferenceException("The value of ValueType property could not be resolved.");
            }
        }

    }

}
