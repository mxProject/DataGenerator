using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration
{

    /// <summary>
    /// Basic implementation of DataGeneratorTupleField settings.
    /// </summary>
    public abstract class DataGeneratorTupleFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected DataGeneratorTupleFieldSettings()
        {
        }

        /// <summary>
        /// Gets the number of tuple fields.
        /// </summary>
        /// <returns></returns>
        public abstract int GetFieldCount();

        /// <summary>
        /// Gets the names of tuple fields.
        /// </summary>
        /// <returns></returns>
        public abstract string?[] GetFieldNames();

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorTupleField"/> interface.
        /// </summary>
        /// <exception cref="DataGeneratorFieldException">
        /// The field setting is invalid.
        /// </exception>
        /// <returns></returns>
        public IDataGeneratorTupleField CreateField(DataGeneratorContext context)
        {
            string?[] fieldNames = null!;

            static string FormatFieldNames(string?[] fieldNames)
            {
                if (fieldNames == null || fieldNames.Length == 0) { return ""; }
                return string.Join(", ", fieldNames);
            }

            try
            {
                fieldNames = GetFieldNames();

                Assert();
                return CreateFieldCore(context);
            }
            catch (Exception ex)
            {
                throw new DataGeneratorFieldException($"The field setting is invalid. {ex.Message} (FieldName: {FormatFieldNames(fieldNames)})", fieldNames, ex);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorTupleField"/> interface.
        /// </summary>
        /// <returns></returns>
        protected abstract IDataGeneratorTupleField CreateFieldCore(DataGeneratorContext context);

        /// <summary>
        /// If the settings for this instance are invalid, an exception will be thrown.
        /// </summary>
        protected virtual void Assert()
        {
        }

    }

}
