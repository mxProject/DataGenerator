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

    internal class DirectProductFieldSettingsState : DataGeneratorTupleFieldSettingsState
    {
        internal DirectProductFieldSettingsState() : base()
        {
        }

        internal DirectProductFieldSettingsState(DirectProductFieldSettings settings) : base(settings)
        {
        }

        internal static DirectProductFieldSettingsState CreateNew()
        {
            DirectProductFieldSettings fieldSettings = new DirectProductFieldSettings()
            {
                Fields = new DataGeneratorFieldSettings[] { }
            };
            return new DirectProductFieldSettingsState(fieldSettings);
        }

        internal DirectProductFieldSettings? DirectProduct { get => Settings as DirectProductFieldSettings; }

        internal int IndexOf(DataGeneratorFieldSettings innerField)
        {
            if (Settings is not DirectProductFieldSettings directProduct) { return -1; }

            if (directProduct.Fields == null) { return -1; }

            return Array.IndexOf(directProduct.Fields, innerField);
        }

        internal IEnumerable<DirectProductInnerFieldSettingsState> CreateInnerFields()
        {
            if (Settings is not DirectProductFieldSettings directProduct) { yield break; }

            if (directProduct.Fields != null)
            {
                foreach (var field in directProduct.Fields)
                {
                    yield return new DirectProductInnerFieldSettingsState(field, this);
                }
            }
        }

        internal int? AddInnerField(DataGeneratorFieldSettings fieldSettings)
        {
            if (Settings is not DirectProductFieldSettings directProduct) { return null; }

            DataGeneratorFieldSettings[] fields;

            if (directProduct.Fields == null)
            {
                fields = new DataGeneratorFieldSettings[] { fieldSettings };
            }
            else
            {
                fields = new DataGeneratorFieldSettings[directProduct.Fields.Length + 1];

                directProduct.Fields.CopyTo(fields, 0);

#pragma warning disable IDE0056
                fields[fields.Length - 1] = fieldSettings;
#pragma warning restore IDE0056
            }

            directProduct.Fields = fields;

            return fields.Length - 1;
        }

        internal void UpdateInnerField(DataGeneratorFieldSettings fieldSettings, int index)
        {
            if (Settings is DirectProductFieldSettings directProduct)
            {
                if (directProduct.Fields != null)
                {
                    directProduct.Fields[index] = fieldSettings;
                }
            }
        }

        internal bool RemoveInnerField(DataGeneratorFieldSettings fieldSettings)
        {
            if (Settings is not DirectProductFieldSettings directProduct) { return false; }

            if (directProduct.Fields == null) { return false; }

            int index = Array.IndexOf(directProduct.Fields, fieldSettings);

            if (index < 0) { return false; }

            DataGeneratorFieldSettings[] fields = new DataGeneratorFieldSettings[directProduct.Fields.Length - 1];

            int i = 0;

            foreach (var field in directProduct.Fields)
            {
                if (field == fieldSettings) { continue; }
                fields[i] = field;
                ++i;
            }

            directProduct.Fields = fields;

            return true;
        }
    }

}
