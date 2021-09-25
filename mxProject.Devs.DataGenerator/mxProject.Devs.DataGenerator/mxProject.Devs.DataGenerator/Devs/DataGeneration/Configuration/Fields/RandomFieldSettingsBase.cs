using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace mxProject.Devs.DataGeneration.Configuration.Fields
{
    /// <summary>
    /// Basic implementation of settings for a field that lists the random values.
    /// </summary>
    public abstract class RandomFieldSettingsBase<TValue> : DataGeneratorFieldSettings
        where TValue : struct
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected RandomFieldSettingsBase()
        {
        }

        /// <summary>
        /// Gets or sets probability of returning null. (between 0 and 1.0)
        /// </summary>
        [JsonProperty("NullProb", Order = 11)]
        public double NullProbability { get; set; }

        /// <inheritdoc/>
        protected override void Assert()
        {
            base.Assert();

            if (NullProbability < 0 || 1 < NullProbability)
            {
                throw new ArgumentOutOfRangeException("");
            }
        }

    }

    /// <summary>
    /// Basic implementation of settings for a field that lists the random values.
    /// </summary>
    public abstract class RandomNumericFieldSettingsBase<TValue> : RandomFieldSettingsBase<TValue>
        where TValue : struct
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected RandomNumericFieldSettingsBase()
        {
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        [JsonProperty("Min", Order = 12)]
        public TValue? MinimumValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        [JsonProperty("Max", Order = 13)]
        public TValue? MaximumValue { get; set; }

        /// <summary>
        /// Gets or sets the expression text of the selector. ex) "x => System.Round(x, 1)"
        /// </summary>
        [JsonProperty("Selector", Order = 14)]
        public string? SelectorExpression { get; set; }

        /// <summary>
        /// Creates a selector from the expression text set in <see cref="SelectorExpression"/> property.
        /// </summary>
        /// <returns>A selector.</returns>
        protected Task<Func<TValue, TValue>?> CreateSelectorAsync(DataGeneratorContext context)
        {
            if (string.IsNullOrWhiteSpace(SelectorExpression)) { return Task.FromResult((Func<TValue, TValue>?)null); }

            return CSharpScriptUtility.CreateFuncAsync<Func<TValue, TValue>?>(SelectorExpression!, context);
        }

    }

}
