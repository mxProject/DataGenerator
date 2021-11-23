#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using mxProject.Devs.DataGeneration;

namespace mxProject.Tools.DataFountain.Forms
{

    /// <summary>
    /// Extension methods for <see cref="DataGridView"/>.
    /// </summary>
    internal static class DataGridViewExtensions
    {

        /// <summary>
        /// Clears the error text in all cells.
        /// </summary>
        /// <param name="grid"></param>
        internal static void ClearCellErrorText(this DataGridView grid)
        {
            for (int r = 0; r < grid.Rows.Count; ++r)
            {
                for (int c = 0; c < grid.Columns.Count; ++c)
                {
                    grid[c, r].ErrorText = null;
                }
            }
        }

        /// <summary>
        /// Validates if the row is entered.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateEnteredRows(this DataGridView grid, out string? invalidMessage)
        {
            if (grid.Rows.Count == (grid.AllowUserToAddRows ? 1 : 0))
            {
                invalidMessage = "No rows have been entered.";
                return false;
            }

            invalidMessage = null;
            return true;
        }

        /// <summary>
        /// Validates that the values in the specified column are unique. 
        /// </summary>
        /// <returns></returns>
        internal static bool ValidateColumnValuesIsUnique(this DataGridView grid, int columnIndex, bool nullable, out string? invalidMessage)
        {
            HashSet<string> founds = new();

            for (int r = 0; r < grid.Rows.Count; ++r)
            {
                string text = grid[columnIndex, r].Value?.ToString() ?? "";

                if (nullable && string.IsNullOrEmpty(text)) { continue; }

                if (founds.Contains(text))
                {
                    invalidMessage = "The value is duplicated.";
                    grid[columnIndex, r].ErrorText = invalidMessage;
                    return false;
                }

                founds.Add(text);
            }

            invalidMessage = null;
            return true;
        }

        ///// <summary>
        ///// Validates that the value in the specified column is valid as a field type.
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="columnIndex"></param>
        ///// <param name="nullable"></param>
        ///// <param name="invalidMessage"></param>
        ///// <returns></returns>
        //internal static bool ValidateAsFieldValueType(this DataGridView grid, int columnIndex, bool nullable, out string? invalidMessage)
        //{
        //    for (int r = 0; r < grid.Rows.Count; ++r)
        //    {
        //        if (grid.Rows[r].IsNewRow) { continue; }

        //        string text = grid[columnIndex, r].Value?.ToString() ?? "";

        //        if (nullable && string.IsNullOrEmpty(text)) { continue; }

        //        if (!ValidationUtility.ValidateAsValueTypeName(text, out invalidMessage))
        //        {
        //            grid[columnIndex, r].ErrorText = invalidMessage;
        //            return false;
        //        }
        //    }

        //    invalidMessage = null;
        //    return true;
        //}

        /// <summary>
        /// Validates that the value in the specified column is valid as a field type.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnIndex"></param>
        /// <param name="nullable"></param>
        /// <param name="executor"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateAsFieldValueType(this DataGridView grid, int columnIndex, bool nullable, Executions.IExecutor executor, out string? invalidMessage)
        {
            for (int r = 0; r < grid.Rows.Count; ++r)
            {
                if (grid.Rows[r].IsNewRow) { continue; }

                string text = grid[columnIndex, r].Value?.ToString() ?? "";

                if (nullable && string.IsNullOrEmpty(text)) { continue; }

                if (!executor.ValidateAsValueTypeName(text, out invalidMessage))
                {
                    grid[columnIndex, r].ErrorText = invalidMessage;
                    return false;
                }
            }

            invalidMessage = null;
            return true;
        }

        ///// <summary>
        ///// Validates that the value in the specified column is valid as a value in the field.
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="columnIndex"></param>
        ///// <param name="valueType"></param>
        ///// <param name="stringConverter"></param>
        ///// <param name="invalidMessage"></param>
        ///// <returns></returns>
        //internal static bool ValidateAsFieldValue(this DataGridView grid, int columnIndex, Type valueType, IStringConverter stringConverter, out string? invalidMessage)
        //{

        //    for (int r = 0; r < grid.Rows.Count; ++r)
        //    {
        //        string? text = grid.Rows[r].Cells[columnIndex].Value?.ToString();

        //        try
        //        {
        //            if (!string.IsNullOrEmpty(text))
        //            {
        //                var _ = stringConverter.ConvertTo(text, valueType);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            grid.Rows[r].Cells[columnIndex].ErrorText = ex.Message;
        //            invalidMessage = ex.Message;
        //            return false;
        //        }
        //    }

        //    invalidMessage = null;
        //    return true;

        //}

        /// <summary>
        /// Validates that the value in the specified column is valid as a value in the field.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnIndex"></param>
        /// <param name="valueTypeName"></param>
        /// <param name="executor"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        internal static bool ValidateAsFieldValue(this DataGridView grid, int columnIndex, string valueTypeName, Executions.IExecutor executor, out string? invalidMessage)
        {

            for (int r = 0; r < grid.Rows.Count; ++r)
            {
                string? text = grid.Rows[r].Cells[columnIndex].Value?.ToString();

                try
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        if (!executor.ValidateAsFieldValue(text!, valueTypeName, out invalidMessage))
                        {
                            grid.Rows[r].Cells[columnIndex].ErrorText = invalidMessage;
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    grid.Rows[r].Cells[columnIndex].ErrorText = ex.Message;
                    invalidMessage = ex.Message;
                    return false;
                }
            }

            invalidMessage = null;
            return true;

        }

    }

}
