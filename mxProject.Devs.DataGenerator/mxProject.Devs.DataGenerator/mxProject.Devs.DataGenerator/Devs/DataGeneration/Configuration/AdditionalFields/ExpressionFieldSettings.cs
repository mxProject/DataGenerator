using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using mxProject.Devs.DataGeneration.AdditionalFields;

namespace mxProject.Devs.DataGeneration.Configuration.AdditionalFields
{

    /// <summary>
    /// A setting for a field that returns the value of an expression.
    /// </summary>
    public class ExpressionFieldSettings : DataGeneratorAdditionalFieldSettings
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public ExpressionFieldSettings(): base()
        {
        }

        /// <summary>
        /// Gets or sets the expression text of the selector. ex) "x => x.GetInt32(0) * x.GetInt32(1)"
        /// </summary>
        [JsonProperty("Expression", Order = 11)]
        public string? Expression { get; set; }

        /// <inheritdoc/>
        protected override IDataGeneratorAdditionalField CreateFieldCore(DataGeneratorContext context)
        {
            async ValueTask<Func<IDataGenerationRecord, object?>> CreateValueGetterAsync(DataGeneratorContext context)
            {
                var func = await CSharpScriptUtility.CreateFuncAsync<Func<IDataGenerationRecord, object?>>(Expression!, context).ConfigureAwait(false);
                return func;
            }

            return new DataGeneratorAdditionalField(FieldName!, GetValueType()!, CreateValueGetterAsync(context));
        }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (Expression == null)
            {
                throw new NullReferenceException("The value of Expression property is null.");
            }
        }
    }

}
