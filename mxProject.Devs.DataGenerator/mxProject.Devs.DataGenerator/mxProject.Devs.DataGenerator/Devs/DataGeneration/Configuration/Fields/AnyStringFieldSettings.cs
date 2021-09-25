using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that enumerates one of the specified string values.
    /// </summary>
    public sealed class AnyStringFieldSettings : EachFieldSettingsBase<string>
    {
        /// <inheritdoc/>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.AnyOne(FieldName!, Values!, NullProbability);
        }
    }

}
