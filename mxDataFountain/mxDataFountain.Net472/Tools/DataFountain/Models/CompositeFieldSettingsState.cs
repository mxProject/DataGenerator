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

    internal class CompositeFieldSettingsState : DataGeneratorFieldSettingsState
    {
        internal CompositeFieldSettingsState() : base()
        {
        }

        internal CompositeFieldSettingsState(CompositeFieldSettingsBase settings) : base(settings)
        {
        }

        internal CompositeFieldSettingsBase? CompositeField { get => Settings as CompositeFieldSettingsBase; }

        internal int IndexOf(DataGeneratorFieldSettings innerField)
        {
            if (Settings is not CompositeFieldSettingsBase composite) { return -1; }

            if (composite.ArgumentFields == null) { return -1; }

            return Array.IndexOf(composite.ArgumentFields, innerField);
        }

        internal IEnumerable<CompositeInnerFieldSettingsState> CreateInnerFields()
        {
            if (Settings is not CompositeFieldSettingsBase composite) { yield break; }

            if (composite.ArgumentFields != null)
            {
                foreach (var field in composite.ArgumentFields)
                {
                    yield return new CompositeInnerFieldSettingsState(field, this);
                }
            }
        }

        internal int? AddInnerField(DataGeneratorFieldSettings fieldSettings)
        {
            if (Settings is not CompositeFieldSettingsBase composite) { return null; }

            DataGeneratorFieldSettings[] fields;

            if (composite.ArgumentFields == null)
            {
                fields = new DataGeneratorFieldSettings[] { fieldSettings };
            }
            else
            {
                fields = new DataGeneratorFieldSettings[composite.ArgumentFields.Length + 1];

                composite.ArgumentFields.CopyTo(fields, 0);

#pragma warning disable IDE0056
                fields[fields.Length - 1] = fieldSettings;
#pragma warning restore IDE0056
            }

            composite.ArgumentFields = fields;

            return fields.Length - 1;
        }

        internal void UpdateInnerField(DataGeneratorFieldSettings fieldSettings, int index)
        {
            if (Settings is CompositeFieldSettingsBase composite)
            {
                if (composite.ArgumentFields != null)
                {
                    composite.ArgumentFields[index] = fieldSettings;
                }
            }
        }

        internal bool RemoveInnerField(DataGeneratorFieldSettings fieldSettings)
        {
            if (Settings is not CompositeFieldSettingsBase composite) { return false; }

            if (composite.ArgumentFields == null) { return false; }

            int index = Array.IndexOf(composite.ArgumentFields, fieldSettings);

            if (index < 0) { return false; }

            DataGeneratorFieldSettings[] fields = new DataGeneratorFieldSettings[composite.ArgumentFields.Length - 1];

            int i = 0;

            foreach (var field in composite.ArgumentFields)
            {
                if (field == fieldSettings) { continue; }
                fields[i] = field;
                ++i;
            }

            composite.ArgumentFields = fields;

            return true;
        }
    }

}
