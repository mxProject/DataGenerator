#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace mxProject.Tools.DataFountain.Executions
{

    /// <summary>
    /// It provides the functionality needed to execute data generation.
    /// </summary>
    internal interface IExecutor : IDisposable
    {

        #region setup

        void Setup(ExecutorSetupArgs args);

        #endregion

        #region validation

        /// <summary>
        /// Validates that the spedified text is valid as a type name.
        /// </summary>
        /// <param name="valueTypeName"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        bool ValidateAsValueTypeName(string valueTypeName, out string? invalidMessage);

        /// <summary>
        /// Gets whether the specified type is an enum.
        /// </summary>
        /// <param name="valueTypeName"></param>
        /// <returns></returns>
        bool IsEnumType(string valueTypeName);

        /// <summary>
        /// Validates that the value in the specified text is valid as a value in the field.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="valueTypeName"></param>
        /// <param name="invalidMessage"></param>
        /// <returns></returns>
        bool ValidateAsFieldValue(string text, string valueTypeName, out string? invalidMessage);

        #endregion

        #region generation

        /// <summary>
        /// Generates and previews the value of the current generator.
        /// </summary>
        /// <param name="generatorSettingsJson"></param>
        /// <param name="generatingCount"></param>
        void ShowPreview(string generatorSettingsJson, int? generatingCount);

        /// <summary>
        /// Generates the values of the current generator and outputs them to the specified csv file.
        /// </summary>
        /// <param name="generatorSettingsJson"></param>
        /// <param name="csvSettings"></param>
        void OutputCsv(string generatorSettingsJson, Configurations.CsvSettings csvSettings);

        #endregion

    }

}
