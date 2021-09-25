using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration
{

    /// <summary>
    /// DataGenerator settings.
    /// </summary>
    public class DataGeneratorSettings
    {

        /// <summary>
        /// Gets or sets the field settings.
        /// </summary>
        [JsonProperty("Fields", Order = 1)]
        public DataGeneratorFieldSettings[]? Fields { get; set; }

        /// <summary>
        /// Gets or sets the tuple field settings.
        /// </summary>
        [JsonProperty("TupleFields", Order = 2)]
        public DataGeneratorTupleFieldSettings[]? TupleFields { get; set; }

        /// <summary>
        /// Gets or sets the additional field settings.
        /// </summary>
        [JsonProperty("AdditionalFields", Order = 3)]
        public DataGeneratorAdditionalFieldSettings[]? AdditionalFields { get; set; }

        /// <summary>
        /// Gets or sets the additional tuple field settings.
        /// </summary>
        [JsonProperty("AdditionalTupleFields", Order = 4)]
        public DataGeneratorAdditionalTupleFieldSettings[]? AdditionalTupleFields { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="DataGenerator"/> class.
        /// </summary>
        /// <returns></returns>
        public DataGeneratorBuilder CreateBuilder(DataGeneratorContext context)
        {
            DataGeneratorBuilder builder = new DataGeneratorBuilder(context.FieldFactory);

            if (Fields != null)
            {
                foreach (var field in Fields)
                {
                    builder.AddField(field.CreateField(context));
                }
            }

            if (TupleFields != null)
            {
                foreach (var field in TupleFields)
                {
                    builder.AddTupleField(field.CreateField(context));
                }
            }

            if (AdditionalFields != null)
            {
                foreach (var field in AdditionalFields)
                {
                    builder.AddAdditionalField(field.CreateField(context));
                }
            }

            if (AdditionalTupleFields != null)
            {
                foreach (var field in AdditionalTupleFields)
                {
                    builder.AddAdditionalTupleField(field.CreateField(context));
                }
            }

            return builder;
        }

    }

}
