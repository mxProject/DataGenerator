#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using mxProject.Devs.DataGeneration.Configuration;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// 
    /// </summary>
    internal partial class DbQueryEditor : UserControl
    {

        public DbQueryEditor()
        {
            InitializeComponent();
        }

        internal void SetDbQuerySettings(DbQuerySettings? dbQuery)
        {
            txtConnectionString.Text = dbQuery?.ConnectionString;
            cmbConnectionTypeNames.Text = dbQuery?.ConnectionTypeName;
            txtCommandText.Text = dbQuery?.CommandText;
        }

        internal bool ValidateInputValues(out string? invalidMessage, out Control? invalidControl)
        {
            Control control;

            // commandText
            control = txtCommandText;

            if (!ValidationUtility.ValidateRequiredText(control.Text, out invalidMessage))
            {
                invalidControl = control;
                return false;
            }

            invalidMessage = null;
            invalidControl = null;
            return true;
        }

        internal void UpdateDbQuerySettings(DbQuerySettings dbQuery)
        {
            if (dbQuery == null) { return; }

            dbQuery.ConnectionString = txtConnectionString.Text;
            dbQuery.ConnectionTypeName = cmbConnectionTypeNames.Text;
            dbQuery.CommandText = txtCommandText.Text;
        }

    }
}
