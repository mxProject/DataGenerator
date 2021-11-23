#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain
{

    /// <summary>
    /// Extension methods for <see cref="DataGeneratorTupleFieldSettings"/>.
    /// </summary>
    internal static class DataGeneratorTupleFieldSettingsExtensions
    {

        /// <summary>
        /// Gets the field type.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        internal static DataGeneratorTupleFieldType GetFieldType(this DataGeneratorTupleFieldSettings? settings)
        {
            if (settings is EachTupleFieldSettings) { return DataGeneratorTupleFieldType.EachTuple; }
            if (settings is DbQueryFieldsSettings) { return DataGeneratorTupleFieldType.DbQuery; }
            if (settings is DirectProductFieldSettings) { return DataGeneratorTupleFieldType.DirectProduct; }

            return DataGeneratorTupleFieldType.Unknown;
        }

    }
}
