using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Json;

namespace mxProject.Tools.DataFountain
{

    /// <summary>
    /// Extension methods for <see cref="DataGeneratorSettings"/>.
    /// </summary>
    internal static class DataGeneratorSettingsExtensions
    {
        internal static string ToJson(this DataGeneratorSettings generatorSettings)
        {
            var converter = DataGeneratorFieldTypeConverterBuilder.CreateDefault().Build();

            return Newtonsoft.Json.JsonConvert.SerializeObject(generatorSettings, Newtonsoft.Json.Formatting.Indented, converter.ToArray());
        }

    }

}
