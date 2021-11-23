#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mxProject.Tools.DataFountain.Forms
{

    /// <summary>
    /// Helper for dropdown combobox.
    /// </summary>
    internal class DataGridViewDropDownComboBoxHelper
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnIndex"></param>
        internal DataGridViewDropDownComboBoxHelper(DataGridView grid, int columnIndex)
        {
            m_Grid = grid;
            m_ColumnIndex = columnIndex;

            grid.EditingControlShowing += (sender, e) =>
            {
                if (grid.CurrentCell.ColumnIndex == m_ColumnIndex && e.Control is DataGridViewComboBoxEditingControl combo)
                {
                    combo.DropDownStyle = ComboBoxStyle.DropDown;
                }
            };

            grid.CellValidating += (sender, e) =>
            {
                if (e.ColumnIndex == m_ColumnIndex && grid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn combo)
                {
                    AddItemIfNotExists(combo, e.FormattedValue);

                    grid[e.ColumnIndex, e.RowIndex].Value = e.FormattedValue;
                }
            };
        }

        private readonly DataGridView m_Grid;
        private readonly int m_ColumnIndex;

        /// <summary>
        /// Adds the specified value to the list, If it is not in the list.
        /// </summary>
        /// <param name="value"></param>
        public void AddItemIfNotExists(object? value)
        {
            AddItemIfNotExists(m_Grid.Columns[m_ColumnIndex] as DataGridViewComboBoxColumn, value);
        }

        /// <summary>
        /// Adds the specified value to the list, If it is not in the list.
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="value"></param>
        private void AddItemIfNotExists(DataGridViewComboBoxColumn? comboBox, object? value)
        {
            if (comboBox == null) { return; }
            if (value == null) { return; }

            if (!comboBox.Items.Contains(value))
            {
                comboBox.Items.Add(value);
            }
        }

        /// <summary>
        /// Adds the specified values to the list, If they are not in the list.
        /// </summary>
        /// <param name="values"></param>
        public void AddItemsIfNotExists(IEnumerable<object?> values)
        {
            AddItemsIfNotExists(m_Grid.Columns[m_ColumnIndex] as DataGridViewComboBoxColumn, values);
        }

        /// <summary>
        /// Adds the specified values to the list, If they are not in the list.
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="values"></param>
        private void AddItemsIfNotExists(DataGridViewComboBoxColumn? comboBox, IEnumerable<object?> values)
        {
            if (comboBox == null) { return; }
            if (values == null) { return; }

            foreach (var value in values)
            {
                AddItemIfNotExists(comboBox, value);
            }
        }

    }

}
