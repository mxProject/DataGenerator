#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Json;

namespace mxProject.Tools.DataFountain.Configurations
{

    /// <summary>
    /// Project settings.
    /// </summary>
    public sealed class DataFountainProjectSettings : ICloneable
    {

        /// <summary>
        /// Gets or sets the generator settings.
        /// </summary>
        public DataGeneratorSettings? DataGeneratorSettings { get; set; }

        /// <summary>
        /// Gets or sets the executor settings.
        /// </summary>
        public ExecutorSettings? ExecutorSettings { get; set; }

        /// <summary>
        /// Gets or sets the csv settings.
        /// </summary>
        public CsvSettings? CsvSettings { get; set; }

        #region clone

        /// <inheritdoc/>
        public object Clone()
        {
            DataFountainProjectSettings obj = new();

            obj.DataGeneratorSettings = (DataGeneratorSettings)DataGeneratorSettings?.Clone()!;
            obj.ExecutorSettings = (ExecutorSettings)ExecutorSettings?.Clone()!;
            obj.CsvSettings = (CsvSettings)CsvSettings?.Clone()!;

            return obj;
        }

        #endregion

        #region serialization

        internal void Serialize(string filePath)
        {
            using StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            Serialize(writer);
        }

        internal void Serialize(TextWriter writer)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented, GetJsonConverters());

            writer.WriteLine(json);
            writer.Flush();
        }

        internal static DataFountainProjectSettings Deserialize(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath, Encoding.UTF8);
            return Deserialize(reader);
        }

        internal static DataFountainProjectSettings Deserialize(TextReader reader)
        {
            var json = reader.ReadToEnd();

            return (DataFountainProjectSettings)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(DataFountainProjectSettings), GetJsonConverters())!;
        }

        internal static Newtonsoft.Json.JsonConverter[] GetJsonConverters()
        {
            DataGeneratorFieldTypeConverterBuilder builder = DataGeneratorFieldTypeConverterBuilder.CreateDefault();
            return builder.Build().ToArray();
        }

        #endregion

    }

}
