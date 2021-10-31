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
    /// Settings for a tuple field that lists ths values read from the specified database query.
    /// </summary>
    public sealed class DbQueryFieldsSettings : DataGeneratorTupleFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public DbQueryFieldsSettings() : base()
        {
        }

        #region properties

        /// <summary>
        /// Gets or sets the fields information.
        /// </summary>
        [JsonProperty("FieldNames", Order = 1)]
        public string[]? FieldNames { get; set; }

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
            var clone = (DbQueryFieldsSettings)base.Clone();

            clone.FieldNames = DataGeneratorUtility.CloneArray(FieldNames);
            clone.DbQuerySettings = DataGeneratorUtility.Clone(DbQuerySettings);

            return clone;
        }

        #endregion

        /// <inheritdoc/>
        public override int GetFieldCount()
        {
            if (FieldNames == null) { return 0; }
            return FieldNames.Length;
        }

        /// <inheritdoc/>
        public override string?[] GetFieldNames()
        {
            string?[] names = new string?[FieldNames?.Length ?? 0];

            if (FieldNames != null)
            {
                for (int i = 0; i < FieldNames.Length; ++i)
                {
                    names[i] = FieldNames[i];
                }
            }

            return names;
        }

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

            if (FieldNames == null)
            {
                throw new NullReferenceException("The value of FieldNames property is null.");
            }

            for (int i = 0; i < FieldNames.Length; ++i)
            {
                if (string.IsNullOrWhiteSpace(FieldNames[i]))
                {
                    throw new NullReferenceException(string.Format("The value of FieldNames[{0}] is null.", i));
                }
            }

            if (DbQuerySettings == null)
            {
                throw new NullReferenceException("The value of DbQuerySettings property is null.");
            }
        }

        /// <inheritdoc/>
        protected override IDataGeneratorTupleField CreateFieldCore(DataGeneratorContext context)
        {
            try
            {
                using var reader = DbQuerySettings!.CreateDataReader(context);
                return context.FieldFactory.FromDataReader(FieldNames!, reader);
            }
            catch (Exception ex)
            {
                throw CreateException(FieldNames, ex);
            }
        }

        #region exception handling

        private const string ExceptionMessage = "Failed to activate a tuple field.";

        /// <summary>
        /// Create an exception.
        /// </summary>
        /// <param name="fieldNames"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        private static Exception CreateException(string[]? fieldNames, Exception innerException)
        {
            static string BuildMessage(string[]? fieldNames)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(ExceptionMessage);

                sb.Append("Fields: [");

                if (fieldNames != null)
                {
                    for (int i = 0; i < fieldNames.Length; ++i)
                    {
                        if (i > 0) { sb.Append(", "); }
                        sb.Append(fieldNames[i]);
                    }
                }

                sb.Append("]");

                return sb.ToString();
            }

            return new Exception(BuildMessage(fieldNames), innerException);
        }

        #endregion

    }

}
