using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace mxProject.Devs.DataGeneration
{

    partial class DataGeneratorFieldFactory
    {

        /// <summary>
        /// Creates a field that returns the values read from the specified data reader. 
        /// </summary>
        /// <param name="fieldIndex">The field index.</param>
        /// <param name="reader">The data reader.</param>
        /// <returns></returns>
        public IDataGeneratorField FromDataReader(int fieldIndex, IDataReader reader)
        {
            IDataGenerationReader generationReader = reader.AsDataGenerationReader();

            var fieldName = generationReader.GetName(fieldIndex);
            var valueType = generationReader.GetValueType(fieldIndex);
            var list = generationReader.ToList(new[] { fieldIndex });

            var method = typeof(DataGeneratorFieldFactory).GetGenericMethod(nameof(FromDataReader_Field1));
            return this.InvokeGenericMethod<IDataGeneratorField>(method, new[] { valueType }, fieldName, list)!;
        }

        /// <summary>
        /// Creates a field that returns the values read from the specified data reader. 
        /// </summary>
        /// <param name="fieldName">The field name.</param>
        /// <param name="reader">The data reader.</param>
        /// <returns></returns>
        public IDataGeneratorField FromDataReader(string fieldName, IDataReader reader)
        {
            IDataGenerationReader generationReader = reader.AsDataGenerationReader();

            var fieldIndex = generationReader.GetOrdinal(fieldName);
            var valueType = generationReader.GetValueType(fieldName);
            var list = generationReader.ToList(new[] { fieldName });

            var method = typeof(DataGeneratorFieldFactory).GetGenericMethod(nameof(FromDataReader_Field1));
            return this.InvokeGenericMethod<IDataGeneratorField>(method, new[] { valueType }, fieldName, list)!;
        }

        /// <summary>
        /// Creates a tuple field that returns the values read from the specified data reader. 
        /// </summary>
        /// <param name="fieldIndexes">The field indexes.</param>
        /// <param name="reader">The data reader.</param>
        /// <returns></returns>
        public IDataGeneratorTupleField FromDataReader(int[] fieldIndexes, IDataReader reader)
        {
            IDataGenerationReader generationReader = reader.AsDataGenerationReader();

            var fieldNames = generationReader.GetNames(fieldIndexes);
            var valueTypes = generationReader.GetValueTypes(fieldIndexes);
            var list = generationReader.ToList(fieldIndexes);

            IDataGeneratorTupleField Invoke(string methodName, Type[] genericTypes, string[] fieldNames, IList values)
            {
                var method = typeof(DataGeneratorFieldFactory).GetGenericMethod(methodName);
                return this.InvokeGenericMethod<IDataGeneratorTupleField>(method, genericTypes, fieldNames, values)!;
            }

            return valueTypes.Length switch
            {
                2 => Invoke(nameof(FromDataReader_Field2), valueTypes, fieldNames, list),
                3 => Invoke(nameof(FromDataReader_Field3), valueTypes, fieldNames, list),
                4 => Invoke(nameof(FromDataReader_Field4), valueTypes, fieldNames, list),
                5 => Invoke(nameof(FromDataReader_Field5), valueTypes, fieldNames, list),
                6 => Invoke(nameof(FromDataReader_Field6), valueTypes, fieldNames, list),
                7 => Invoke(nameof(FromDataReader_Field7), valueTypes, fieldNames, list),
                8 => Invoke(nameof(FromDataReader_Field8), valueTypes, fieldNames, list),
                9 => Invoke(nameof(FromDataReader_Field9), valueTypes, fieldNames, list),
                _ => throw new NotSupportedException("The specified number of fields is not supported."),
            };
        }

        /// <summary>
        /// Creates a tuple field that returns the values read from the specified data reader. 
        /// </summary>
        /// <param name="fieldNames">The field names.</param>
        /// <param name="reader">The data reader.</param>
        /// <returns></returns>
        public IDataGeneratorTupleField FromDataReader(string[] fieldNames, IDataReader reader)
        {
            IDataGenerationReader generationReader = reader.AsDataGenerationReader();

            var valueTypes = generationReader.GetValueTypes(fieldNames);
            var list = generationReader.ToList(fieldNames);

            IDataGeneratorTupleField Invoke(string methodName, Type[] genericTypes, string[] fieldNames, IList values)
            {
                var method = typeof(DataGeneratorFieldFactory).GetGenericMethod(methodName);
                return this.InvokeGenericMethod<IDataGeneratorTupleField>(method, genericTypes, fieldNames, values)!;
            }

            return valueTypes.Length switch
            {
                2 => Invoke(nameof(FromDataReader_Field2), valueTypes, fieldNames, list),
                3 => Invoke(nameof(FromDataReader_Field3), valueTypes, fieldNames, list),
                4 => Invoke(nameof(FromDataReader_Field4), valueTypes, fieldNames, list),
                5 => Invoke(nameof(FromDataReader_Field5), valueTypes, fieldNames, list),
                6 => Invoke(nameof(FromDataReader_Field6), valueTypes, fieldNames, list),
                7 => Invoke(nameof(FromDataReader_Field7), valueTypes, fieldNames, list),
                8 => Invoke(nameof(FromDataReader_Field8), valueTypes, fieldNames, list),
                9 => Invoke(nameof(FromDataReader_Field9), valueTypes, fieldNames, list),
                _ => throw new NotSupportedException("The specified number of fields is not supported."),
            };
        }

        private IDataGeneratorField FromDataReader_Field1<T>(string fieldName, IEnumerable<T?> values)
            where T : struct
        {
            return Each(fieldName, values);
        }

        private IDataGeneratorTupleField FromDataReader_Field2<T1, T2>(string[] fieldNames, IEnumerable<(T1?, T2?)> values)
            where T1 : struct
            where T2 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], values);
        }

        private IDataGeneratorTupleField FromDataReader_Field3<T1, T2, T3>(string[] fieldNames, IEnumerable<(T1?, T2?, T3?)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], fieldNames[2], values);
        }

        private IDataGeneratorTupleField FromDataReader_Field4<T1, T2, T3, T4>(string[] fieldNames, IEnumerable<(T1?, T2?, T3?, T4?)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], fieldNames[2], fieldNames[3], values);
        }

        private IDataGeneratorTupleField FromDataReader_Field5<T1, T2, T3, T4, T5>(string[] fieldNames, IEnumerable<(T1?, T2?, T3?, T4?, T5?)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], fieldNames[2], fieldNames[3], fieldNames[4], values);
        }

        private IDataGeneratorTupleField FromDataReader_Field6<T1, T2, T3, T4, T5, T6>(string[] fieldNames, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], fieldNames[2], fieldNames[3], fieldNames[4], fieldNames[5], values);
        }

        private IDataGeneratorTupleField FromDataReader_Field7<T1, T2, T3, T4, T5, T6, T7>(string[] fieldNames, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], fieldNames[2], fieldNames[3], fieldNames[4], fieldNames[5], fieldNames[6], values);
        }

        private IDataGeneratorTupleField FromDataReader_Field8<T1, T2, T3, T4, T5, T6, T7, T8>(string[] fieldNames, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], fieldNames[2], fieldNames[3], fieldNames[4], fieldNames[5], fieldNames[6], fieldNames[7], values);
        }

        private IDataGeneratorTupleField FromDataReader_Field9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string[] fieldNames, IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> values)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            return EachTuple(fieldNames[0], fieldNames[1], fieldNames[2], fieldNames[3], fieldNames[4], fieldNames[5], fieldNames[6], fieldNames[7], fieldNames[8], values);
        }

    }

}
