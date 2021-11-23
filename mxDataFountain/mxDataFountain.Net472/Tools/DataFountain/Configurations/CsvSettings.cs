using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxProject.Tools.DataFountain.Configurations
{

    /// <summary>
    /// Csv settings.
    /// </summary>
    [Serializable]
    public class CsvSettings : ICloneable
    {

        /// <summary>
        /// Gets or sets the delimiter.
        /// </summary>
        public char Delimiter { get; set; } = ',';

        /// <summary>
        /// Gets the wellknown delimiter charactors.
        /// </summary>
        /// <returns></returns>
        internal static char[] GetKnownDelimiters()
        {
            return new[] { ',', '\t' };
        }

        /// <summary>
        /// Gets or sets the quote.
        /// </summary>
        public char Quote { get; set; } = '"';

        /// <summary>
        /// Gets or sets whether the value of the field is always quoted.
        /// </summary>
        public bool ShouldQuote { get; set; } = false;

        /// <summary>
        /// Gets or sets the newline charactors.
        /// </summary>
        public string NewLine { get; set; } = Environment.NewLine;

        /// <summary>
        /// Gets the wellknown newline charactors.
        /// </summary>
        /// <returns></returns>
        internal static string[] GetKnownNewLines()
        {
            return new[] { "\r\n", "\n", "\r" };
        }

        /// <summary>
        /// Gets or sets the encoding name.
        /// </summary>
        public string Encoding { get; set; } = "utf-8";

        /// <summary>
        /// Gets the wellknown encoding names.
        /// </summary>
        /// <returns></returns>
        internal static string[] GetKnownEncodings()
        {
            return new[] { "utf-8", "utf-16", "shift_jis" };
        }

        /// <summary>
        /// Gets or sets whether to output the header.
        /// </summary>
        public bool WithHeader = true;

        #region clone

        /// <inheritdoc/>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

    }

}
