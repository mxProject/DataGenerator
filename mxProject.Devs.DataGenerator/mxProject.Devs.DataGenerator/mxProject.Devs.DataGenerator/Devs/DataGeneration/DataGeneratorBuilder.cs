using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Buffers;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;
using System.Data;
using System.Threading.Tasks;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// DataGeneratorBuilder.
    /// </summary>
    public class DataGeneratorBuilder
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="factory">The field factory.</param>
        public DataGeneratorBuilder(DataGeneratorFieldFactory? factory = null)
        {
            m_Factory = factory ?? new DataGeneratorFieldFactory();
        }

        private readonly DataGeneratorFieldFactory m_Factory;

        #region all fields

        private readonly List<IDataGeneratorFieldAccessor> m_AllFields = new();
        private readonly HashSet<string> m_AllFieldNames = new();

        /// <summary>
        /// Gets the field count.
        /// </summary>
        public int FieldCount
        {
            get
            {
                return m_AllFields.Count + m_AdditionalFields.Count;
            }
        }

        /// <summary>
        /// Gets the name of the specified field.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        public string GetFieldName(int index)
        {
            if (index < m_AllFields.Count)
            {
                return m_AllFields[index].FieldName;
            }
            else
            {
                index -= m_AllFields.Count;
                return m_AdditionalFields[index].FieldName;
            }
        }

        /// <summary>
        /// Gets the value type of the specified field.
        /// </summary>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        public Type GetValueType(int index)
        {
            if (index < m_AllFields.Count)
            {
                return m_AllFields[index].ValueType;
            }
            else
            {
                index -= m_AllFields.Count;
                return m_AdditionalFields[index].ValueType;
            }
        }

        /// <summary>
        /// Normalizes the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string NormalizeFieldName(string name)
        {
            return DataGenerator.NormalizeFieldName(name);
        }

        /// <summary>
        /// Asserts the specified field name.
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        private void AssertFieldName(string? fieldName)
        {
            if (fieldName == null)
            {
                throw new NullReferenceException("The field name is null.");
            }

            if (m_AllFieldNames.Contains(NormalizeFieldName(fieldName)))
            {
                throw new DuplicateNameException($"The field name is already registered. Name: '{fieldName}'");
            }
        }

        #endregion

        #region generator fields

        private readonly List<IDataGeneratorField> m_Fields = new();
        private readonly List<IDataGeneratorTupleField> m_TupleFields = new();

        /// <summary>
        /// Adds the specified field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <exception cref="ArgumentNullException">
        /// The spacified field is null.
        /// </exception>
        public DataGeneratorBuilder AddField(IDataGeneratorField field)
        {
            if (field == null) { throw new ArgumentNullException(nameof(field)); }

            AssertField(field);

            m_Fields.Add(field);

            m_AllFields.Add(new Internals.DataGeneratorFieldAccessor(field));

            m_AllFieldNames.Add(NormalizeFieldName(field.FieldName));

            return this;
        }

        /// <summary>
        /// Asserts the specified field.
        /// </summary>
        /// <param name="field">The field.</param>
        private void AssertField(IDataGeneratorField field)
        {
            AssertFieldName(field.FieldName);
        }

        /// <summary>
        /// Adds the specified tuple field.
        /// </summary>
        /// <param name="tuple">The field.</param>
        /// <exception cref="ArgumentNullException">
        /// The spacified field is null.
        /// </exception>
        public DataGeneratorBuilder AddTupleField(IDataGeneratorTupleField tuple)
        {
            if (tuple == null) { throw new ArgumentNullException(nameof(tuple)); }

            AssertTupleField(tuple);

            m_TupleFields.Add(tuple);

            var body = new Internals.DataGeneratorTupleFieldAccessorBody(tuple);

            for (int i = 0; i < tuple.FieldCount; ++i)
            {
                m_AllFields.Add(new Internals.DataGeneratorTupleFieldAccessor(body, i));

                m_AllFieldNames.Add(NormalizeFieldName(tuple.GetFieldName(i)));
            }

            return this;
        }

        /// <summary>
        /// Asserts the specified field.
        /// </summary>
        /// <param name="field">The field.</param>
        private void AssertTupleField(IDataGeneratorTupleField field)
        {
            HashSet<string> names = new();

            for (int i = 0; i < field.FieldCount; ++i)
            {
                var name = field.GetFieldName(i);

                AssertFieldName(name);

                name = NormalizeFieldName(name);

                if (names.Contains(name))
                {
                    throw new DuplicateNameException($"The field name is already registered. Name: '{field.GetFieldName(i)}'");
                }

                names.Add(name);
            }

        }

        /// <summary>
        /// Adds the field created by the specified method.
        /// </summary>
        /// <param name="fieldCreator">The method to create field.</param>
        /// <returns></returns>
        public DataGeneratorBuilder AddField(Func<DataGeneratorFieldFactory, IDataGeneratorField> fieldCreator)
        {
            return AddField(fieldCreator(m_Factory));
        }

        /// <summary>
        /// Adds the tuple field created by the specified method.
        /// </summary>
        /// <param name="fieldCreator">The method to create field.</param>
        /// <remarks></remarks>
        public DataGeneratorBuilder AddTupleField(Func<DataGeneratorFieldFactory, IDataGeneratorTupleField> fieldCreator)
        {
            return AddTupleField(fieldCreator(m_Factory));
        }

        #endregion

        #region additional fields

        private readonly List<IDataGeneratorAdditionalField> m_AdditionalFields = new();
        private readonly List<IDataGeneratorAdditionalTupleField> m_AdditionalTupleFields = new();

        /// <summary>
        /// Adds the specified additional field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public DataGeneratorBuilder AddAdditionalField(IDataGeneratorAdditionalField field)
        {
            if (field == null) { throw new ArgumentNullException(nameof(field)); }

            AssertFieldName(field.FieldName);

            m_AdditionalFields.Add(field);

            m_AllFieldNames.Add(NormalizeFieldName(field.FieldName));

            return this;
        }

        /// <summary>
        /// Adds the specified additional tuple field.
        /// </summary>
        /// <param name="tuple">The tuple field.</param>
        /// <returns></returns>
        public DataGeneratorBuilder AddAdditionalTupleField(IDataGeneratorAdditionalTupleField tuple)
        {
            if (tuple == null) { throw new ArgumentNullException(nameof(tuple)); }

            AssertAdditionalTupleField(tuple);

            m_AdditionalTupleFields.Add(tuple);

            for (int i = 0; i < tuple.FieldCount; ++i)
            {
                m_AllFieldNames.Add(NormalizeFieldName(tuple.GetFieldName(i)));
            }

            return this;
        }

        /// <summary>
        /// Asserts the specified field.
        /// </summary>
        /// <param name="field">The field.</param>
        private void AssertAdditionalTupleField(IDataGeneratorAdditionalTupleField field)
        {
            HashSet<string> names = new();

            for (int i = 0; i < field.FieldCount; ++i)
            {
                var name = field.GetFieldName(i);

                AssertFieldName(name);

                name = NormalizeFieldName(name);

                if (names.Contains(name))
                {
                    throw new DuplicateNameException($"The field name is already registered. Name: '{field.GetFieldName(i)}'");
                }

                names.Add(name);
            }

        }

        #endregion

        #region build

        /// <summary>
        /// Creates an instance of DataGenerator.
        /// </summary>
        /// <param name="generateCount">Number of values to generate.</param>
        /// <returns></returns>
        public async ValueTask<DataGenerator> BuildAsync(int generateCount)
        {
            foreach (var field in m_AllFields)
            {
                await field.InitializeAsync(generateCount).ConfigureAwait(false);
            }

            var generator = new DataGenerator(m_AllFields);

            foreach (var field in m_AdditionalFields)
            {
                var info = new DataGeneratorFieldInfo(field.FieldName, field.ValueType);

                generator.AddAdditionalField(info, await field.CreateValueGetterAsync().ConfigureAwait(false));
            }

            foreach (var tuple in m_AdditionalTupleFields)
            {
                for (int i = 0; i < tuple.FieldCount; ++i)
                {
                    var info = new DataGeneratorFieldInfo(tuple.GetFieldName(i), tuple.GetValueType(i));
                    var valueGetter = await tuple.CreateValueGetterAsync().ConfigureAwait(false);

                    int fieldIndex = i;

                    generator.AddAdditionalField(info, rec =>
                    {
                        var values = valueGetter(rec);
                        if (values == null) { return null; }
                        return values[fieldIndex];
                    });
                }
            }

            return generator;
        }

        /// <summary>
        /// Creates an instance of DataGenerator and returns DataReader that wraps the DataGenerator.
        /// </summary>
        /// <param name="generateCount">Number of values to generate.</param>
        /// <returns></returns>
        public async ValueTask<IDataGenerationReader> BuildAsDataReaderAsync(int generateCount)
        {
            DataGenerator generator = await BuildAsync(generateCount).ConfigureAwait(false);

            return generator.AsDataReader();
        }

        #endregion

        #region factory method

        /// <summary>
        /// Creates a DataGeneratorBuilder from the attributes defined for the specified type.
        /// </summary>
        /// <param name="modelType">The type of the data model.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        [Obsolete]
        public static DataGeneratorBuilder FromType(Type modelType, DataGeneratorContext context)
        {
            return ModelMappings.Internals.DataGeneratorTypeLoader.FromType(modelType, context);
        }

        #endregion

    }

}
