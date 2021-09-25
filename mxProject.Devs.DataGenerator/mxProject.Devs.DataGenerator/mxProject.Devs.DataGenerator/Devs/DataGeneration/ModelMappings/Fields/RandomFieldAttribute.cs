using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Basic implementation of a field attribute that enumerates random values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public abstract class RandomFieldAttribute : DataGenerationFieldAttribute
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="selectorDecralingType">The type in which the selector method is declared.</param>
        /// <param name="selectorMethodName">The name of the selector method.</param>
        /// <param name="fieldName">The field name.</param>
        protected RandomFieldAttribute(double nullProbability = 0, Type? selectorDecralingType = null, string? selectorMethodName = null, string? fieldName = null) : base(fieldName)
        {
            NullProbability = nullProbability;
            SelectorDecralingType = selectorDecralingType;
            SelectorMethodName = selectorMethodName;
        }

        /// <summary>
        /// Gets probability of returning null. (between 0 and 1.0)
        /// </summary>
        public double NullProbability { get; }

        /// <summary>
        /// Gets the type in which the selector method is declared.
        /// </summary>
        public Type? SelectorDecralingType { get; }

        /// <summary>
        /// Gets the name of the selector method.
        /// </summary>
        public string? SelectorMethodName { get; }

        /// <summary>
        /// Gets the selector method.
        /// </summary>
        /// <typeparam name="TMethod">The type of the selector method.</typeparam>
        /// <param name="declaringType">The type in which the selector method is declared.</param>
        /// <param name="methodName">The name of the selector method.</param>
        /// <returns></returns>
        protected static TMethod? GetSelectorMethod<TMethod>(Type? declaringType, string? methodName) where TMethod : Delegate
        {
            if (declaringType == null) { return default; }

            var method = declaringType.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            return (TMethod)Delegate.CreateDelegate(typeof(TMethod), method);
        }

    }

}
