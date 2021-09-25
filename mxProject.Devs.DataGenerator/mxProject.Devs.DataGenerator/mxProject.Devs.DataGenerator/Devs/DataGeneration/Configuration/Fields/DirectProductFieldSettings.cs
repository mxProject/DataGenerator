using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates the direct product.
    /// </summary>
    public sealed class DirectProductFieldSettings : DataGeneratorTupleFieldSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public DirectProductFieldSettings() : base()
        {
        }

        /// <summary>
        /// Gets or sets the field settings.
        /// </summary>
        [JsonProperty("Fields", Order = 1)]
        public DataGeneratorFieldSettings[]? Fields { get; set; }

        /// <inheritdoc/>
        public override int GetFieldCount()
        {
            return Fields?.Length ?? 0;
        }

        /// <inheritdoc/>
        public override string?[] GetFieldNames()
        {
            string?[] names = new string?[Fields?.Length ?? 0];

            if (Fields != null)
            {
                for (int i = 0; i < Fields.Length; ++i)
                {
                    names[i] = Fields[i]?.FieldName;
                }
            }

            return names;
        }

        /// <inheritdoc/>
        protected override IDataGeneratorTupleField CreateFieldCore(DataGeneratorContext context)
        {
            IDataGeneratorField[] fields = new IDataGeneratorField[Fields!.Length];

            for (int i = 0; i < Fields.Length; ++i)
            {
                fields[i] = Fields[i].CreateField(context);
            }

            return DirectProductFieldFactory.CreateTupleField(fields, context);
        }

        /// <inheritdoc/>
        /// <exception cref="NullReferenceException">
        /// The value of Fields property is null.
        /// </exception>
        protected override void Assert()
        {
            base.Assert();

            if (Fields == null)
            {
                throw new NullReferenceException("The value of Fields property is null.");
            }
        }

    }

}
