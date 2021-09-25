using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration.ModelMappings.Internals
{

    /// <summary>
    /// Field information.
    /// </summary>
    [Obsolete]
    internal sealed class DataGeneratorFieldNameAndValueType : IDataGeneratorFieldInfo
    {

        internal DataGeneratorFieldNameAndValueType(string fieldName, Type valueType)
        {
            FieldName = fieldName;
            ValueType = valueType;
        }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        public Type ValueType { get; }

    }

}
