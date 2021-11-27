#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;

namespace mxProject.Tools.DataFountain.Models
{

    internal class DataGeneratorSettingsState
    {
        internal DataGeneratorSettingsState(DataGeneratorSettings settings)
        {
            Original = settings;

            Fields = new List<DataGeneratorFieldSettingsState>();

            if (settings.Fields != null)
            {
                foreach (var field in settings.Fields)
                {
                    if (field is CompositeFieldSettingsBase composite)
                    {
                        Fields.Add(new CompositeFieldSettingsState(composite));
                    }
                    else
                    {
                        Fields.Add(new DataGeneratorFieldSettingsState(field));
                    }
                }
            }

            TupleFields = new List<DataGeneratorTupleFieldSettingsState>();

            if (settings.TupleFields != null)
            {
                foreach (var field in settings.TupleFields)
                {
                    if (field is DirectProductFieldSettings directProduct)
                    {
                        TupleFields.Add(new DirectProductFieldSettingsState(directProduct));
                    }
                    else
                    {
                        TupleFields.Add(new DataGeneratorTupleFieldSettingsState(field));
                    }
                }
            }

            AdditionalFields = new List<DataGeneratorAdditionalFieldSettingsState>();

            if (settings.AdditionalFields != null)
            {
                foreach (var field in settings.AdditionalFields)
                {
                    AdditionalFields.Add(new DataGeneratorAdditionalFieldSettingsState(field));
                }
            }

            AdditionalTupleFields = new List<DataGeneratorAdditionalTupleFieldSettingsState>();

            if (settings.AdditionalTupleFields != null)
            {
                foreach (var field in settings.AdditionalTupleFields)
                {
                    AdditionalTupleFields.Add(new DataGeneratorAdditionalTupleFieldSettingsState(field));
                }
            }

        }

        internal DataGeneratorSettings Original { get; }

        internal IList<DataGeneratorFieldSettingsState> Fields { get; }

        internal IList<DataGeneratorTupleFieldSettingsState> TupleFields { get; }

        internal IList<DataGeneratorAdditionalFieldSettingsState> AdditionalFields { get; }

        internal IList<DataGeneratorAdditionalTupleFieldSettingsState> AdditionalTupleFields { get; }

        internal void AddField(IDataGeneratorFieldSettingsState field)
        {
            if (field is DataGeneratorFieldSettingsState singleField)
            {
                Fields.Add(singleField);
            }
            else if (field is DataGeneratorTupleFieldSettingsState tupleField)
            {
                TupleFields.Add(tupleField);
            }
            else if (field is DataGeneratorAdditionalFieldSettingsState additionalField)
            {
                AdditionalFields.Add(additionalField);
            }
            else if (field is DataGeneratorAdditionalTupleFieldSettingsState additionalTupleField)
            {
                AdditionalTupleFields.Add(additionalTupleField);
            }
        }

        internal bool RemoveField(IDataGeneratorFieldSettingsState field)
        {
            if (field is DataGeneratorFieldSettingsState singleField)
            {
                return Fields.Remove(singleField);
            }
            else if (field is DataGeneratorTupleFieldSettingsState tupleField)
            {
                return TupleFields.Remove(tupleField);
            }
            else if (field is DataGeneratorAdditionalFieldSettingsState additionalField)
            {
                return AdditionalFields.Remove(additionalField);
            }
            else if (field is DataGeneratorAdditionalTupleFieldSettingsState additionalTupleField)
            {
                return AdditionalTupleFields.Remove(additionalTupleField);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a new generator settings.
        /// </summary>
        /// <returns></returns>
        internal DataGeneratorSettings CreateSettings()
        {
            DataGeneratorSettings settings = new();

            static DataGeneratorFieldSettings[] GetFieldSettings(IList<DataGeneratorFieldSettingsState> states)
            {
                List<DataGeneratorFieldSettings> list = new();

                foreach (var state in states)
                {
                    if (state.Settings != null) { list.Add(state.Settings); }
                }

                return list.ToArray();
            }

            static DataGeneratorTupleFieldSettings[] GetTupleFieldSettings(IList<DataGeneratorTupleFieldSettingsState> states)
            {
                List<DataGeneratorTupleFieldSettings> list = new();

                foreach (var state in states)
                {
                    if (state.Settings != null) { list.Add(state.Settings); }
                }

                return list.ToArray();
            }

            static DataGeneratorAdditionalFieldSettings[] GetAdditionalFieldSettings(IList<DataGeneratorAdditionalFieldSettingsState> states)
            {
                List<DataGeneratorAdditionalFieldSettings> list = new();

                foreach (var state in states)
                {
                    if (state.Settings != null) { list.Add(state.Settings); }
                }

                return list.ToArray();
            }

            static DataGeneratorAdditionalTupleFieldSettings[] GetAdditionalTupleFieldSettings(IList<DataGeneratorAdditionalTupleFieldSettingsState> states)
            {
                List<DataGeneratorAdditionalTupleFieldSettings> list = new();

                foreach (var state in states)
                {
                    if (state.Settings != null) { list.Add(state.Settings); }
                }

                return list.ToArray();
            }

            settings.Fields = GetFieldSettings(Fields);
            settings.TupleFields = GetTupleFieldSettings(TupleFields);
            settings.AdditionalFields = GetAdditionalFieldSettings(AdditionalFields);
            settings.AdditionalTupleFields = GetAdditionalTupleFieldSettings(AdditionalTupleFields);

            return settings;
        }

        /// <summary>
        /// Creates a new generator settings json.
        /// </summary>
        /// <param name="needIndent"></param>
        /// <returns></returns>
        internal string CreateSettingsJson(bool needIndent)
        {
            var converter = mxProject.Devs.DataGeneration.Configuration.Json.DataGeneratorFieldTypeConverterBuilder.CreateDefault().Build();

            Newtonsoft.Json.Formatting formatting = needIndent ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;

            return Newtonsoft.Json.JsonConvert.SerializeObject(CreateSettings(), formatting, converter.ToArray());
        }

    }

}
