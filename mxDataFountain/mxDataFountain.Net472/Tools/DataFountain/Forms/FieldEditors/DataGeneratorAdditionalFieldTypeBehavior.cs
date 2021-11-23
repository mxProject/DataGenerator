using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Behavior corresponding to <see cref="DataGeneratorAdditionalFieldType"/>.
    /// </summary>
    internal class DataGeneratorAdditionalFieldTypeBehavior : DataGeneratorFieldTypeBehavior<DataGeneratorAdditionalFieldType, IDataGeneratorAdditionalFieldEditor>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldType">The field type.</param>
        /// <param name="editorCreatetor">The method to create a editor.</param>
        internal DataGeneratorAdditionalFieldTypeBehavior(DataGeneratorAdditionalFieldType fieldType, Func<DataFountainContext, IDataGeneratorAdditionalFieldEditor> editorCreatetor)
            : base(fieldType, editorCreatetor)
        {
        }
    }

}
