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
    /// Settings of a field that enumerates the specified values.
    /// </summary>
    [Obsolete]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class EachFieldAttribute : DataGenerationFieldAttribute
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(bool[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(bool), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(byte[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(byte), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(sbyte[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(sbyte), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(short[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(short), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(ushort[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(ushort), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(int[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(int), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(uint[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(uint), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(long[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(long), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(ulong[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(ulong), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(float[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(float), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(double[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(double), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(decimal[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(decimal), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(char[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(char), DataGeneratorUtility.ToObjectArray(values), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(string?[] values, double nullProbability = 0, string? fieldName = null)
            : this(fieldName, typeof(StringValue), DataGeneratorUtility.ConvertArray<string, object>(values, x => (StringValue)x), nullProbability)
        {
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <param name="fieldName">The field name.</param>
        public EachFieldAttribute(Guid[] values, double nullProbability = 0, string? fieldName = null)
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
        public EachFieldAttribute(Type valueType, string?[] values, double nullProbability, string? fieldName = null)
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
        protected EachFieldAttribute(string? fieldName, Type valueType, object?[] values, double nullProbability) : base(fieldName)
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
            var method = typeof(EachFieldAttribute).GetMethod(nameof(CreateTypedField), BindingFlags.NonPublic | BindingFlags.Instance);

            return (IDataGeneratorField)method.MakeGenericMethod(ValueType).Invoke(this, new object[] { member, context });
        }

        private IDataGeneratorField<T> CreateTypedField<T>(MemberInfo member, DataGeneratorContext context) where T : struct
        {
            T?[] values = ConvertValues(Values, ValueType, context).Cast<T?>().ToArray();

            return context.FieldFactory.Each<T>(FieldName ?? member.Name, values, NullProbability);
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
