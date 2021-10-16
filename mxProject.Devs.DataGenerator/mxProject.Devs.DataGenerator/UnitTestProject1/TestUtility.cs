using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Configuration;
using mxProject.Devs.DataGeneration.Configuration.Fields;
using mxProject.Devs.DataGeneration.Configuration.Json;
using Newtonsoft.Json;

using UnitTestProject1.Extensions;

namespace UnitTestProject1
{
    internal static class TestUtility
    {

        #region Json Serialization

        private static readonly JsonSerializerSettings s_JsonSerializerSettings = CreateJsonSerializerSettings();

        internal static JsonSerializerSettings CreateJsonSerializerSettings()
        {

            DataGeneratorFieldTypeConverterBuilder builder = DataGeneratorFieldTypeConverterBuilder.CreateDefault();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            foreach (var converter in builder.Build())
            {
                settings.Converters.Add(converter);
            }

            return settings;

        }

        internal static void AssertJsonSerialize(ref DataGeneratorSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, s_JsonSerializerSettings);

            Debug.WriteLine(json);
            // Debug.WriteLine(json.Replace("  ", "\t"));

            settings = JsonConvert.DeserializeObject<DataGeneratorSettings>(json, s_JsonSerializerSettings)!;
        }

        #endregion

        #region context

        internal static DataGeneratorContext CreateDataGeneratorContext()
        {
            IStringConverter stringConverter = DefaultStringConverter.Instance;
            EnumerableFactory enumerableFactory = new EnumerableFactory();
            DataGeneratorFieldFactory fieldFactory = new DataGeneratorFieldFactory(enumerableFactory);

            return new DataGeneratorContext(fieldFactory, new DefaultRandomGenerator(), stringConverter, enumerableFactory);
        }

        #endregion

        #region dump

        internal static void DumpHeader(DataGenerator generator, StringBuilder buffer)
        {
            for (int i = 0; i < generator.FieldCount; ++i)
            {
                if (i > 0) { buffer.Append('\t'); }
                buffer.Append(generator.GetFieldName(i));
            }
            buffer.AppendLine();

            for (int i = 0; i < generator.FieldCount; ++i)
            {
                if (i > 0) { buffer.Append('\t'); }
                buffer.Append(generator.GetValueType(i).Name);
            }
            buffer.AppendLine();
        }

        internal static void DumpHeader(IDataReader reader, StringBuilder buffer)
        {
            for (int i = 0; i < reader.FieldCount; ++i)
            {
                if (i > 0) { buffer.Append('\t'); }
                buffer.Append(reader.GetName(i));
            }
            buffer.AppendLine();

            for (int i = 0; i < reader.FieldCount; ++i)
            {
                if (i > 0) { buffer.Append('\t'); }
                buffer.Append(reader.GetFieldType(i).Name);
            }
            buffer.AppendLine();
        }


        internal static void DumpRecord(DataGenerator generator, StringBuilder buffer)
        {
            for (int i = 0; i < generator.FieldCount; ++i)
            {
                var value = generator.GetFieldValue(i);

                if (i > 0) { buffer.Append('\t'); }

                if (value is string s)
                {
                    buffer.Append("\"");
                    buffer.Append(s);
                    buffer.Append("\"");
                }
                else if (value is StringValue sv)
                {
                    buffer.Append("\"");
                    buffer.Append(sv);
                    buffer.Append("\"");

                    // throw new Exception($"A value of type StringValue was returned. FieldName: {record.GetFieldName(i)}");
                }
                else
                {
                    buffer.Append(value ?? "(null)");
                }
            }
            buffer.AppendLine();
        }

        internal static void DumpRecord(IDataRecord record, StringBuilder buffer)
        {
            object[] values = new object[record.FieldCount];

            record.GetValues(values);

            for (int i = 0; i < values.Length; ++i)
            {
                if (i > 0) { buffer.Append('\t'); }

                if (values[i] is string s)
                {
                    buffer.Append("\"");
                    buffer.Append(s);
                    buffer.Append("\"");
                }
                else if (values[i] is StringValue sv)
                {
                    buffer.Append("\"");
                    buffer.Append(sv);
                    buffer.Append("\"");

                    throw new Exception($"A value of type StringValue was returned. FieldName: {record.GetName(i)}");
                }
                else
                {
                    buffer.Append(values[i] ?? "(null)");
                }
            }
            buffer.AppendLine();
        }

        internal static void DumpTuple(IDataGeneratorTupleFieldEnumeration fieldSet)
        {
            object[] values = new object[fieldSet.FieldCount];

            static string ToString(object[] values)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < values.Length; ++i)
                {
                    if (i > 0) { sb.Append(", "); }
                    sb.Append(values[i]);
                }

                return sb.ToString();
            }

            while (fieldSet.GenerateNext())
            {
                fieldSet.GetValues(values);
                Debug.WriteLine(ToString(values));
            }
        }

        internal static void DumpTuple<T1, T2>(IDataGeneratorTupleFieldEnumeration<T1, T2> fieldSet)
            where T1 : struct
            where T2 : struct
        {
            while (fieldSet.GenerateNext())
            {
                var values = fieldSet.GetTypedValues();
                Debug.WriteLine(values);
            }
        }

        internal static void DumpTuple<T1, T2, T3>(IDataGeneratorTupleFieldEnumeration<T1, T2, T3> fieldSet)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            while (fieldSet.GenerateNext())
            {
                var values = fieldSet.GetTypedValues();
                Debug.WriteLine(values);
            }
        }

        #endregion

        #region assert

        internal static void AssertAreEqual(object? expected, object? actual)
        {
            if (expected is StringValue expectedString)
            {
                expected = (string)expectedString;
            }
            if (actual is StringValue actualString)
            {
                actual = (string)actualString;
            }

            Assert.AreEqual(expected, actual);
        }

        #endregion

    }
}
