using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSubTypes;

namespace mxProject.Devs.DataGeneration.Configuration
{

    /// <summary>
    /// Basic implementation of enumerable settings.
    /// </summary>
    public abstract class EnumerableSettings
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected EnumerableSettings()
        {
        }

        /// <summary>
        /// Gets the type of the value to enumerate.
        /// </summary>
        [JsonIgnore]
        public abstract Type ValueType { get; }

        /// <summary>
        /// Gets the number of values that will be enumerated.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public abstract int? GetEnumerateValueCount(DataGeneratorContext context);

        /// <summary>
        /// Creates an instance of <see cref="IEnumerable{Object}"/>.
        /// </summary>
        /// <param name="generateCount">Number of values to generate.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public abstract ValueTask<IEnumerable<object?>> CreateEnumerableAsync(int generateCount, DataGeneratorContext context);

    }

    /// <summary>
    /// Basic implementation of enumerable settings.
    /// </summary>
    /// <typeparam name="T">The type of the value to enumerate.</typeparam>
    public abstract class EnumerableSettings<T> : EnumerableSettings where T : struct
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        protected EnumerableSettings() : base()
        {
        }

        /// <inheritdoc/>
        [JsonIgnore]
        public override Type ValueType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// Creates an instance of <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <returns></returns>
        public abstract ValueTask<IEnumerable<T?>> CreateTypedEnumerableAsync(int generateCount, DataGeneratorContext context);

        /// <inheritdoc/>
        public override async ValueTask<IEnumerable<object?>> CreateEnumerableAsync(int generateCount, DataGeneratorContext context)
        {
            var typed = await CreateTypedEnumerableAsync(generateCount, context).ConfigureAwait(false);

            return typed.Select(x => x.HasValue ? (object)x.Value : (object?)null);
        }

    }

}
