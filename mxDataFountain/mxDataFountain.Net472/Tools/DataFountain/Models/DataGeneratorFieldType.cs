using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Tools.DataFountain.Models
{

    /// <summary>
    /// The types of DataGeneratorFieldSettings.
    /// </summary>
    internal enum DataGeneratorFieldType
    {
        Unknown = 0,
        Any,
        Each,
        Random,
        Sequence,
        Expression,
        DbQuery
    }

}
