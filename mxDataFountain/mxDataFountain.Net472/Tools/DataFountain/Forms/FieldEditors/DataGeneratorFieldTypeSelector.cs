#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Behavior corresponding to field type.
    /// </summary>
    /// <typeparam name="TType">The type of the field type.</typeparam>
    /// <typeparam name="TBehavior">The type of the field type behavior.</typeparam>
    /// <typeparam name="TEditor">The type of the field editor.</typeparam>
    internal class DataGeneratorFieldTypeSelector<TType, TBehavior, TEditor>
        where TType : Enum
        where TBehavior : DataGeneratorFieldTypeBehavior<TType, TEditor>
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="onFieldTypeChanged"></param>
        /// <param name="onFieldEditorChanged"></param>
        internal DataGeneratorFieldTypeSelector(DataFountainContext context, Action<TType>? onFieldTypeChanged = null, Action<TEditor?>? onFieldEditorChanged = null)
        {
            m_Context = context;
            m_OnFieldTypeChanged = onFieldTypeChanged;
            m_OnFieldEditorChanged = onFieldEditorChanged;
        }

        private readonly DataFountainContext m_Context;
        private readonly Action<TType>? m_OnFieldTypeChanged;
        private readonly Action<TEditor?>? m_OnFieldEditorChanged;

        #region field type

        private readonly Dictionary<TType, TBehavior> m_Behaviors = new();

        /// <summary>
        /// Registers the specified field type.
        /// </summary>
        /// <param name="fieldType"></param>
        /// <param name="behavior"></param>
        internal void RegisterFieldType(TType fieldType, TBehavior behavior)
        {
            m_Behaviors[fieldType] = behavior;
        }

        /// <summary>
        /// Unregisters the specified field type.
        /// </summary>
        /// <param name="fieldType"></param>
        internal void UnregisterFieldType(TType fieldType)
        {
            m_Behaviors.Remove(fieldType);
        }

        /// <summary>
        /// Gets the registered field types.
        /// </summary>
        /// <returns></returns>
        internal TType[] GetFieldTypes()
        {
            return m_Behaviors.Keys.ToArray();
        }

        /// <summary>
        /// Gets or sets the selected field type.
        /// </summary>
        internal TType SelectedFieldType
        {
            get { return m_SelectedFieldType; }
            set
            {
                if (object.Equals(m_SelectedFieldType, value)) { return; }
                m_SelectedFieldType = value;
                OnSelectedFieldTypeChanged();
            }
        }
        private TType m_SelectedFieldType = default!;

        private void OnSelectedFieldTypeChanged()
        {
            if (m_Behaviors.TryGetValue(m_SelectedFieldType, out var behavior))
            {
                CurrentEditor = behavior.CreateEditor(m_Context);
            }
            else
            {
                CurrentEditor = default;
            }

            m_OnFieldTypeChanged?.Invoke(m_SelectedFieldType);
        }

        #endregion

        #region editor

        /// <summary>
        /// Gets the current field editor.
        /// </summary>
        internal TEditor? CurrentEditor
        {
            get { return m_CurrentEditor; }
            private set
            {
                if (object.Equals(m_CurrentEditor, value)) { return; }
                m_CurrentEditor = value;
                OnCurrentEditorChanged();
            }
        }
        private TEditor? m_CurrentEditor;

        private void OnCurrentEditorChanged()
        {
            m_OnFieldEditorChanged?.Invoke(m_CurrentEditor);
        }

        #endregion

    }

}
