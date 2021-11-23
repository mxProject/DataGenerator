﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Tools.DataFountain.Models;

namespace mxProject.Tools.DataFountain.Forms.FieldEditors
{

    /// <summary>
    /// Provides the functionality needed to edit an instance of <see cref="DataGeneratorTupleFieldSettings"/>. 
    /// </summary>
    internal interface IDataGeneratorTupleFieldEditor
    {

        /// <summary>
        /// Sets the specified field for editing.
        /// </summary>
        /// <param name="settings">The field settings.</param>
        void SetFieldSettings(DataGeneratorTupleFieldSettingsState settings);

        /// <summary>
        /// Get the updated field.
        /// </summary>
        /// <returns>The field settings.</returns>
        DataGeneratorTupleFieldSettingsState UpdateFieldSettings();

        /// <summary>
        /// Gets the edited field as a new instance.
        /// </summary>
        /// <returns></returns>
        DataGeneratorTupleFieldSettings GetFieldSettingsAsNew();

        /// <summary>
        /// Validate the input values.
        /// </summary>
        /// <param name="invalidMessage">The message indicating that it is invalid.</param>
        /// <param name="invalidControl">The control with invalid value entered.</param>
        /// <returns></returns>
        bool Validate(out string? invalidMessage, out Control? invalidControl);

    }

}
