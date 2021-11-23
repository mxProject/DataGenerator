using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Tools.DataFountain.Models
{

    /// <summary>
    /// Kinds of DataGeneratorField.
    /// </summary>
    internal enum DataGeneratorFieldKind
    {
        Unknown = 0,
        Field,
        TupleField,
        AdditionalField,
        AdditionalTupleField,
    }
}
