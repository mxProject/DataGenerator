#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

using mxProject.Tools.DataFountain.Configurations;

namespace mxProject.Tools.DataFountain.Controllers
{

    internal delegate void NotifyProgress(int generatedDataCount);

    internal class CsvFileWriter
    {
        internal CsvFileWriter(CsvSettings csvSettings)
        {
            CsvSettings = csvSettings;
        }

        private CsvSettings CsvSettings { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="filePath"></param>
        /// <param name="onProgress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException">
        /// </exception>
        internal async Task OutputAsync(IDataReader reader, string filePath, NotifyProgress? onProgress = null, CancellationToken cancellation = default)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            using StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding(CsvSettings.Encoding));

            await OutputAsync(reader, writer, onProgress, cancellation).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="onProgress"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException">
        /// </exception>
        private async Task OutputAsync(IDataReader reader, TextWriter writer, NotifyProgress? onProgress = null, CancellationToken cancellation = default)
        {
            CsvConfiguration configuration = new CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture)
            {
                Delimiter = new string(CsvSettings.Delimiter, 1),
                Quote = CsvSettings.Quote,
                Escape = CsvSettings.Quote,
                NewLine = CsvSettings.NewLine,
                Encoding = Encoding.GetEncoding(CsvSettings.Encoding),
                ShouldQuote = x =>
                {
                    if (CsvSettings.ShouldQuote) { return true; }
                    if (x.Field == null) { return false; }
                    return x.Field.Contains(CsvSettings.Delimiter);
                }
            };

            using CsvWriter csvWriter = new CsvWriter(writer, configuration);

            if (CsvSettings.WithHeader)
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    csvWriter.WriteField(reader.GetName(i));
                }

                await csvWriter.NextRecordAsync().ConfigureAwait(false);
            }

            object[] values = new object[reader.FieldCount];

            int count = 0;

            while (reader.Read())
            {
                if (cancellation.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }

                reader.GetValues(values);

                for (int i = 0; i < values.Length; ++i)
                {
                    csvWriter.WriteField(values[i]);
                }

                await csvWriter.NextRecordAsync().ConfigureAwait(false);

                ++count;

                onProgress?.Invoke(count);
            }

            await csvWriter.FlushAsync().ConfigureAwait(false);
        }

    }

}
