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
    /// Extension methods for <see cref="DataGeneratorAdditionalTupleFieldSettings"/>.
    /// </summary>
    internal static class DataGeneratorAdditionalTupleFieldSettingsExtensions
    {

        /// <summary>
        /// Gets the field type.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        internal static DataGeneratorAdditionalTupleFieldType GetFieldType(this DataGeneratorAdditionalTupleFieldSettings? settings)
        {
            if (settings is JoinFieldSettings) { return DataGeneratorAdditionalTupleFieldType.Join; }
            if (settings is JoinDbQueryFieldSettings) { return DataGeneratorAdditionalTupleFieldType.JoinDbQuery; }

            return DataGeneratorAdditionalTupleFieldType.Unknown;
        }

    }
}
