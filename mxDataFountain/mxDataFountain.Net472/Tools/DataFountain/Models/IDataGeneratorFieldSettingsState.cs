#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Tools.DataFountain.Models
{

    internal interface IDataGeneratorFieldSettingsState
    {

        /// <summary>
        /// Gets the data generator field kind.
        /// </summary>
        DataGeneratorFieldKind FieldKind { get; }

        /// <summary>
        /// Gets the field names.
        /// </summary>
        /// <returns></returns>
        internal string[] GetFieldNames();

        /// <summary>
        /// Gets a value that indicates whether this field is a new field.
        /// </summary>
        bool IsNewField { get; }

    }

}
