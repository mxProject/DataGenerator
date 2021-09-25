using System;
using System.Collections.Generic;
using System.Text;
using mxProject.Devs.DataGeneration.AdditionalFields;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="DataGeneratorBuilder"/>.
    /// </summary>
    public static class DataGeneratorBuilderExtensions
    {

        #region AddAdditionalField

        /// <summary>
        /// Add a field that returns a value generated based on the generated value.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="additionalFieldName">the field name to add.</param>
        /// <param name="additionalValueType">the value type to add.</param>
        /// <param name="valueGetter">The method to get the value of the field.</param>
        /// <returns></returns>
        public static DataGeneratorBuilder AddAdditionalField(this DataGeneratorBuilder builder, string additionalFieldName, Type additionalValueType, Func<IDataGenerationRecord, object?> valueGetter)
        {
            return builder.AddAdditionalField(new DataGeneratorAdditionalField(additionalFieldName, additionalValueType, valueGetter));
        }

        #endregion

        #region AddAdditionalTupleField

        /// <summary>
        /// Add a field that returns values generated based on the generated value.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="additionalFields">Information about the fields to add.</param>
        /// <param name="valueGetter">The method to get the values of the fields.</param>
        /// <returns></returns>
        public static DataGeneratorBuilder AddAdditionalTupleField(this DataGeneratorBuilder builder, (string fieldName, Type valueType)[] additionalFields, Func<IDataGenerationRecord, object?[]> valueGetter)
        {
            return builder.AddAdditionalTupleField(new DataGeneratorAdditionalTupleField(additionalFields.ToDataGeneratorFieldInfo(), valueGetter));
        }

        /// <summary>
        /// Add a field that returns values generated based on the generated value.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="additionalFields">Information about the fields to add.</param>
        /// <param name="valueGetter">The method to get the values of the fields.</param>
        /// <returns></returns>
        public static DataGeneratorBuilder AddAdditionalTupleField(this DataGeneratorBuilder builder, IDataGeneratorFieldInfo[] additionalFields, Func<IDataGenerationRecord, object?[]> valueGetter)
        {
            return builder.AddAdditionalTupleField(new DataGeneratorAdditionalTupleField(additionalFields, valueGetter));
        }

        #endregion

        #region AddJoinField

        /// <summary>
        /// Add a field that returns a value that corresponds to the generated value.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fieldCreator">A method to create a field.</param>
        /// <returns></returns>
        public static DataGeneratorBuilder AddJoinField(this DataGeneratorBuilder builder, Func<JoinFieldFactory, IDataGeneratorAdditionalTupleField> fieldCreator)
        {
            return builder.AddAdditionalTupleField(fieldCreator(JoinFieldFactory.Default));
        }

        #endregion

    }

}
