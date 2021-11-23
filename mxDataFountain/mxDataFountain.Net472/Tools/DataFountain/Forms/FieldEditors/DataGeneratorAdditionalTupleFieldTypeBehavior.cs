using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Behavior corresponding to <see cref="DataGeneratorAdditionalTupleFieldType"/>.
    /// </summary>
    internal class DataGeneratorAdditionalTupleFieldTypeBehavior : DataGeneratorFieldTypeBehavior<DataGeneratorAdditionalTupleFieldType, IDataGeneratorAdditionalTupleFieldEditor>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldType">The field type.</param>
        /// <param name="editorCreatetor">The method to create a editor.</param>
        internal DataGeneratorAdditionalTupleFieldTypeBehavior(DataGeneratorAdditionalTupleFieldType fieldType, Func<DataFountainContext, IDataGeneratorAdditionalTupleFieldEditor> editorCreatetor)
            : base(fieldType, editorCreatetor)
        {
        }
    }

}
