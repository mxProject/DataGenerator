#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.AdditionalFields;
using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain
{

    /// <summary>
    /// Extension methods for <see cref="DataGeneratorAdditionalFieldSettings"/>.
    /// </summary>
    internal static class DataGeneratorAdditionalFieldSettingsExtensions
    {

        /// <summary>
        /// Gets the field type.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        internal static DataGeneratorAdditionalFieldType GetFieldType(this DataGeneratorAdditionalFieldSettings? settings)
        {
            if (settings is ExpressionFieldSettings) { return DataGeneratorAdditionalFieldType.Expression; }
            
            return DataGeneratorAdditionalFieldType.Unknown;
        }

    }
}
