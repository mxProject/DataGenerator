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

    /// <summary>
    /// 
    /// </summary>
    internal class DirectProductInnerFieldSettingsState : DataGeneratorFieldSettingsState
    {
        internal DirectProductInnerFieldSettingsState(DirectProductFieldSettingsState owner) : base()
        {
            Owner = owner;
        }

        internal DirectProductInnerFieldSettingsState(DataGeneratorFieldSettings settings, DirectProductFieldSettingsState owner) : base(settings)
        {
            Owner = owner;
            Index = owner.IndexOf(settings);
        }

        internal DirectProductFieldSettingsState Owner { get; }

        internal int? Index { get; private set; }

        internal void ApplyToOwner()
        {
            if (this.Settings == null) { return; }

            if (Index.HasValue && Index.Value >= 0)
            {
                Owner.UpdateInnerField(this.Settings, Index.Value);
            }
            else
            {
                Index = Owner.AddInnerField(this.Settings);
            }
        }

        internal void RemoveFromOwner()
        {
            if (this.Settings == null) { return; }

            Owner.RemoveInnerField(this.Settings);
            Index = null;
        }

    }

}
