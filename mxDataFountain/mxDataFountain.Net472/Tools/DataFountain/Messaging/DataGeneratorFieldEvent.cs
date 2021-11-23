using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration.Configuration;

namespace mxProject.Tools.DataFountain.Messaging
{

    /// <summary>
    /// Events related to <see cref="DataGeneratorFieldSettings"/>.
    /// </summary>
    internal enum DataGeneratorFieldEvent
    {
        Unknown = 0,

        /// <summary>
        /// Occurs when a field is selected.
        /// </summary>
        Selected,

        /// <summary>
        /// Occurs when a new field starts editing.
        /// </summary>
        StartEdit,

        /// <summary>
        /// Occurs when a new field is added.
        /// </summary>
        Added,

        /// <summary>
        /// Occurs when a field is updated. 
        /// </summary>
        Updated,

        /// <summary>
        /// Occurs when a field is removed.
        /// </summary>
        Removed,
    }

}
