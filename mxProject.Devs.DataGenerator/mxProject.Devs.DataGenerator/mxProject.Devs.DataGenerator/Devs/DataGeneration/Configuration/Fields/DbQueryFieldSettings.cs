using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that lists ths values read from the specified database query.
    /// </summary>
    public sealed class DbQueryFieldSettings : DataGeneratorFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public DbQueryFieldSettings() : base()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the database query settings.
        /// </summary>
        [JsonProperty("DbQuery", Order = 2)]
        public DbQuerySettings? DbQuerySettings { get; set; }

        #endregion

        #region clone

        /// <inheritdoc/>
        public override object Clone()
        {
            var clone = (DbQueryFieldSettings)base.Clone();

            clone.DbQuerySettings = DataGeneratorUtility.Clone(DbQuerySettings);

            return clone;
        }

        #endregion

        /// <inheritdoc/>
        /// <exception cref="NullReferenceException">
        /// The value of Fields property is null.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// The value of Values property is null.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// The value of FieldInfo.FieldName property is null.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// The value of FieldInfo.ValueType property is null.
        /// </exception>
        protected override void Assert()
        {
            base.Assert();

            if (DbQuerySettings == null)
            {
                throw new NullReferenceException("The value of DbQuerySettings property is null.");
            }
        }

        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            try
            {
                using var reader = DbQuerySettings!.CreateDataReader(context);
                return context.FieldFactory.FromDataReader(FieldName!, reader);
            }
            catch (Exception ex)
            {
                throw CreateException(FieldName, ex);
            }
        }

        #region exception handling

        private const string ExceptionMessage = "Failed to activate a tuple field.";

        /// <summary>
        /// Create an exception.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        private static Exception CreateException(string? fieldName, Exception innerException)
        {
            static string BuildMessage(string? fieldName)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(ExceptionMessage);

                sb.Append($"Field: {fieldName}");

                return sb.ToString();
            }

            return new Exception(BuildMessage(fieldName), innerException);
        }

        #endregion

    }

}
