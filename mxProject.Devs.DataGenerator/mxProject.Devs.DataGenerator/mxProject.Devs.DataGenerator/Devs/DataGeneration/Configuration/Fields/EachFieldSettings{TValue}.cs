using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{

    /// <summary>
    /// Settings for a field that lists the specified values in order.
    /// </summary>
    public sealed class EachFieldSettings<TValue> : EachFieldSettingsBase<TValue?>
        where TValue : struct
    {
        /// <summary>
        /// Creates an instance of <see cref="IDataGeneratorField"/> interface.
        /// </summary>
        /// <returns></returns>
        protected override IDataGeneratorField CreateFieldCore(DataGeneratorContext context)
        {
            return context.FieldFactory.Each(FieldName!, Values!, NullProbability);
        }
    }

}
