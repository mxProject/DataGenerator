using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration
{

    /// <summary>
    /// Basic implementation of DataGeneratorField settings.
    /// </summary>
    public abstract class DataGeneratorFieldSettings : ICloneable
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected DataGeneratorFieldSettings()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        [JsonProperty("Name", Order = 1)]
        public string? FieldName { get; set; }

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
        /// Creates an instance of <see cref="IDataGeneratorField"/> interface.
        /// </summary>
        /// <exception cref="DataGeneratorFieldException">
        /// The field setting is invalid.
        /// </exception>
        /// <returns></returns>
        public IDataGeneratorField CreateField(DataGeneratorContext context)
        {
            try
            {
                Assert();
                return CreateFieldCore(context);
            }
            catch (Exception ex)
            {
                throw new DataGeneratorFieldException($"The field setting is invalid. {ex.Message} (FieldName: {FieldName})", FieldName!, ex);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorField"/> interface.
        /// </summary>
        /// <returns></returns>
        protected abstract IDataGeneratorField CreateFieldCore(DataGeneratorContext context);

        /// <summary>
        /// If the settings for this instance are invalid, an exception will be thrown.
        /// </summary>
        protected virtual void Assert()
        {
            if (FieldName == null)
            {
                throw new NullReferenceException("The value of FieldName property is null.");
            }
        }

    }

}
