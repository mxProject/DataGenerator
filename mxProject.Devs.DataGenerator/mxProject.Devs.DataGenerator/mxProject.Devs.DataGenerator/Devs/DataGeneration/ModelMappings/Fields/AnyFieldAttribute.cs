using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration.ModelMappings.Fields
{

    /// <summary>
    /// Settings for a field that enumerates one of the specified values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AnyFieldAttribute : DataGenerationFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(bool[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(bool), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(byte[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(byte), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(sbyte[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(sbyte), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(short[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(short), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(ushort[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(ushort), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(int[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(int), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(uint[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(uint), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(long[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(long), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(ulong[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(ulong), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(float[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(float), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(double[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(double), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(decimal[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(decimal), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(char[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(char), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(string?[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(StringValue), DataGeneratorUtility.ConvertArray<string, object>(values, x => (StringValue)x), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public AnyFieldAttribute(Guid[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(Guid), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="valueType">The type of the field value.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        public AnyFieldAttribute(Type valueType, string?[] values, double nullProbability, string? fieldName = null)
            : this(fieldName, valueType, DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
            ValueType = valueType;
            Values = values;
            NullProbability = nullProbability;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="valueType">The type of the field value.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        protected AnyFieldAttribute(string? fieldName, Type valueType, object?[] values, double nullProbability) : base(fieldName)
        {
            ValueType = valueType;
            Values = values;
            NullProbability = nullProbability;
        }

        #endregion

        /// <summary>
        /// Gets the value type.
        /// </summary>
        public Type ValueType { get; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        public object?[]? Values { get; }

        /// <summary>
        /// Gets probability of returning null. (between 0 and 1.0)
        /// </summary>
        public double NullProbability { get; }


        #region CreateField

        /// <inheritdoc/>
        public override IDataGeneratorField CreateField(MemberInfo member, DataGeneratorContext context)
        {
            var method = typeof(AnyFieldAttribute).GetMethod(nameof(CreateTypedField), BindingFlags.NonPublic | BindingFlags.Instance);

            return (IDataGeneratorField)method.MakeGenericMethod(ValueType).Invoke(this, new object[] { member, context });
        }

        private IDataGeneratorField<T> CreateTypedField<T>(MemberInfo member, DataGeneratorContext context) where T : struct
        {
            T?[] values = ConvertValues(Values, ValueType, context).Cast<T?>().ToArray();

            return context.FieldFactory.AnyOne<T>(FieldName ?? member.Name, values, NullProbability);
        }

        /// <summary>
        /// Converts the specified value to a type that enumerates it.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="valueType">The type of the field value.</param>
        /// <param name="context">The context.</param>
        /// <returns>The converted values.</returns>
        protected virtual IEnumerable<object?> ConvertValues(object?[]? values, Type valueType, DataGeneratorContext context)
        {
            return DataGeneratorUtility.ConvertValues(values, valueType, context);
        }

        #endregion

    }

}
