using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace mxProject.Tools.DataFountain.Forms
{

    /// <summary>
    /// ImageList containing the icons used by this application.
    /// </summary>
    internal class IconImageList : IDisposable
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        private IconImageList()
        {
            InitIcons();
        }

        /// <summary>
        /// Singleton instance.
        /// </summary>
        internal readonly static IconImageList Singleton = new IconImageList();

        /// <inheritdoc />
        public void Dispose()
        {
            ImageList.Dispose();
        }

        /// <summary>
        /// ImageList
        /// </summary>
        internal readonly ImageList ImageList = new ImageList();

        private void InitIcons()
        {
            ImageList.ImageSize = new Size(22, 22);
            ImageList.Images.Add(global::mxProject.Properties.Resources.FieldGroup);
            ImageList.Images.Add(global::mxProject.Properties.Resources.Field);
            ImageList.Images.Add(global::mxProject.Properties.Resources.TupleField);
            ImageList.Images.Add(global::mxProject.Properties.Resources.Add);
            ImageList.Images.Add(global::mxProject.Properties.Resources.Remove);
            ImageList.Images.Add(global::mxProject.Properties.Resources.Edit);
            ImageList.Images.Add(global::mxProject.Properties.Resources.Search);
        }

        internal Image GetImage(IconImageIndex index)
        {
            return ImageList.Images[(int)index];
        }

    }

    /// <summary>
    /// The indexes of the icons used by this application.
    /// </summary>
    internal enum IconImageIndex
    {
        FieldGroup = 0,
        Field,
        TupleField,
        Add,
        Remove,
        Edit,
        Search
    }

}
