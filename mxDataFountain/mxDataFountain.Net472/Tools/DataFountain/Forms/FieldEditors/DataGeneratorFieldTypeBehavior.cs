#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Behavior corresponding to <see cref="DataGeneratorFieldType"/>.
    /// </summary>
    internal class DataGeneratorFieldTypeBehavior : DataGeneratorFieldTypeBehavior<DataGeneratorFieldType, IDataGeneratorFieldEditor>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldType">The field type.</param>
        /// <param name="editorCreatetor">The method to create a editor.</param>
        internal protected DataGeneratorFieldTypeBehavior(DataGeneratorFieldType fieldType, Func<DataFountainContext, IDataGeneratorFieldEditor> editorCreatetor)
            : base(fieldType, editorCreatetor)
        {
        }
    }

    /// <summary>
    /// Behavior corresponding to field type.
    /// </summary>
    /// <typeparam name="TType">The type of the field type.</typeparam>
    /// <typeparam name="TEditor">The type of the field editor.</typeparam>
    internal class DataGeneratorFieldTypeBehavior<TType, TEditor>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="fieldType">The field type.</param>
        /// <param name="editorCreatetor">The method to create a editor.</param>
        internal protected DataGeneratorFieldTypeBehavior(TType fieldType, Func<DataFountainContext, TEditor> editorCreatetor)
        {
            FieldType = fieldType;
            m_EditorCreatetor = editorCreatetor;
        }

        /// <summary>
        /// Gets the field type.
        /// </summary>
        internal TType FieldType { get; }

        private readonly Func<DataFountainContext, TEditor> m_EditorCreatetor;

        /// <summary>
        /// Creates a new editor.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        internal TEditor CreateEditor(DataFountainContext context)
        {
            return m_EditorCreatetor(context);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return FieldType?.ToString()!;
        }
    }

}
