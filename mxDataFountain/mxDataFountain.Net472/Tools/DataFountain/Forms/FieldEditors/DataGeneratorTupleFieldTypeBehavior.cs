using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Behavior corresponding to <see cref="DataGeneratorTupleFieldType"/>.
    /// </summary>
    internal class DataGeneratorTupleFieldTypeBehavior : DataGeneratorFieldTypeBehavior<DataGeneratorTupleFieldType, IDataGeneratorTupleFieldEditor>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldType">The field type.</param>
        /// <param name="editorCreatetor">The method to create a editor.</param>
        internal DataGeneratorTupleFieldTypeBehavior(DataGeneratorTupleFieldType fieldType, Func<DataFountainContext, IDataGeneratorTupleFieldEditor> editorCreatetor)
            : base(fieldType, editorCreatetor)
        {
        }
    }

}
