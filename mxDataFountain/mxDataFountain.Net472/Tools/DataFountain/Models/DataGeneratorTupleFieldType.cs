using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Tools.DataFountain.Models
{

    /// <summary>
    /// The types of DataGeneratorTupleFieldSettings.
    /// </summary>
    internal enum DataGeneratorTupleFieldType
    {
        Unknown = 0,
        EachTuple,
        DbQuery,
        DirectProduct,
    }

}
