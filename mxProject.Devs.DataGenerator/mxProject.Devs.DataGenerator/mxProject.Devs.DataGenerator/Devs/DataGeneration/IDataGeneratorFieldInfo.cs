using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides definitions for data generator field.
    /// </summary>
    public interface IDataGeneratorFieldInfo
    {

        /// <summary>
        /// Gets the field name.
        /// </summary>
        string FieldName { get; }

        /// <summary>
        /// Gets the value type.
        /// </summary>
        Type ValueType { get; }

    }

}
