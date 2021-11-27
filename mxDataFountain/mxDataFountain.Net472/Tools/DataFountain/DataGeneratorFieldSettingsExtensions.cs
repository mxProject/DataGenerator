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
    /// Extension methods for <see cref="DataGeneratorFieldSettings"/>.
    /// </summary>
    internal static class DataGeneratorFieldSettingsExtensions
    {

        /// <summary>
        /// Gets the field type.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        internal static DataGeneratorFieldType GetFieldType(this DataGeneratorFieldSettings? settings)
        {
            if (settings is AnyFieldSettings) { return DataGeneratorFieldType.Any; }
            if (settings is EachFieldSettings) { return DataGeneratorFieldType.Each; }
            if (settings is RandomFieldSettings) { return DataGeneratorFieldType.Random; }
            if (settings is SequenceFieldSettings) { return DataGeneratorFieldType.Sequence; }
            if (settings is DbQueryFieldSettings) { return DataGeneratorFieldType.DbQuery; }
            if (settings is FormattedStringFieldSettings) { return DataGeneratorFieldType.FormattedString; }
            if (settings is ComputingFieldSettings) { return DataGeneratorFieldType.Computing; }

            return DataGeneratorFieldType.Unknown;
        }

        internal static DataGeneratorFieldSettings[] CreateClones(this DataGeneratorFieldSettings[] settings)
        {
            DataGeneratorFieldSettings[] clones = new DataGeneratorFieldSettings[settings.Length];

            for (int i = 0; i < settings.Length; ++i)
            {
                clones[i] = (settings[i]?.Clone() as DataGeneratorFieldSettings)!;
            }

            return clones;
        }
    }
}
