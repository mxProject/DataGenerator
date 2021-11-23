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
using System.Reflection;

namespace mxProject.Tools.DataFountain.Forms
{

    internal partial class VersionForm : Form
    {
        internal VersionForm()
        {
            InitializeComponent();
        }

        internal new DialogResult ShowDialog(IWin32Window owner)
        {
            static System.Drawing.Icon? GetOwnerIcon(IWin32Window owner)
            {
                if (owner is Form frm) { return frm.Icon; }
                return null;
            }

            try
            {
                var icon = GetOwnerIcon(owner);

                if (icon != null)
                {
                    this.Icon = icon;
                    pictureBox1.Image = icon.ToBitmap();
                }

                lblVersion.Text = GetVersion();

                return base.ShowDialog(owner);
            }
            catch (Exception ex)
            {
                FormUtility.ShowErrorMessageBox(this, ex.Message);
                return DialogResult.Abort;
            }
        }

        private string GetVersion()
        {
            AssemblyFileVersionAttribute attr = (AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyFileVersionAttribute));
            return attr.Version;
        }

    }
}
