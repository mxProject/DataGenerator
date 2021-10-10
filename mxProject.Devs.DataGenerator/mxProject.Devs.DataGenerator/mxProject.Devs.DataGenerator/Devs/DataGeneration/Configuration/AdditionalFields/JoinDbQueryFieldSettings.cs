using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using mxProject.Devs.DataGeneration.AdditionalFields;

namespace mxProject.Devs.DataGeneration.Configuration.AdditionalFields
{

    /// <summary>
    /// A setting for a field that returns the values read from a database query.
    /// </summary>
    public class JoinDbQueryFieldSettings : DataGeneratorAdditionalTupleFieldSettings
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public JoinDbQueryFieldSettings() : base()
        {
            AdditionalFields = new DataGeneratorFieldInfo[] { };
        }

        /// <summary>
        /// Gets or sets the reference key field names.
        /// </summary>
        [JsonProperty("ReferenceKeys", Order = 11)]
        public string[]? ReferenceKeyFieldNames { get; set; }

        /// <summary>
        /// Gets or sets the additional key field names.
        /// </summary>
        [JsonProperty("AdditionalKeys", Order = 12)]
        public string[]? AdditionalKeyFieldNames { get; set; }

        /// <summary>
        /// Gets or sets the additional value field names.
        /// </summary>
        [JsonProperty("AdditionalValues", Order = 13)]
        public string[]? AdditionalValueFieldNames { get; set; }

        /// <summary>
        /// Gets or sets the database query settings.
        /// </summary>
        [JsonProperty("DbQuery", Order = 14)]
        public DbQuerySettings? DbQuerySettings { get; set; }

        /// <inheritdoc/>
        protected override IDataGeneratorAdditionalTupleField CreateFieldCore(DataGeneratorContext context)
        {
            using IDataReader reader = DbQuerySettings!.CreateDataReader(context);
            return JoinFieldFactory.Default.WithDataReader(ReferenceKeyFieldNames!, AdditionalKeyFieldNames!, AdditionalValueFieldNames!, reader);
        }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (ReferenceKeyFieldNames == null)
            {
                throw new NullReferenceException($"The value of {nameof(ReferenceKeyFieldNames)} property is null.");
            }

            if (AdditionalKeyFieldNames == null)
            {
                throw new NullReferenceException($"The value of {nameof(AdditionalKeyFieldNames)} property is null.");
            }

            if (AdditionalValueFieldNames == null)
            {
                throw new NullReferenceException($"The value of {nameof(AdditionalValueFieldNames)} property is null.");
            }

            if (DbQuerySettings == null)
            {
                throw new NullReferenceException($"The value of {nameof(DbQuerySettings)} property is null.");
            }

            try
            {
                DbQuerySettings.Assert();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException($"The value of {nameof(DbQuerySettings)} property is invalid. {ex.Message}", ex);
            }
        }

    }

}
