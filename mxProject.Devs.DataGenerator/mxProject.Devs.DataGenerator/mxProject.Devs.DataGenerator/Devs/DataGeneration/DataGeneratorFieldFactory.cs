using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mxProject.Devs.DataGeneration.Fields;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Generate fields for DataGenerator.
    /// </summary>
    public partial class DataGeneratorFieldFactory
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="enumeration">The enumeration logic.</param>
        public DataGeneratorFieldFactory(EnumerableFactory? enumeration = null)
        {
            m_Enumeration = enumeration ?? EnumerableFactory.Instance;
        }

        private readonly EnumerableFactory m_Enumeration;

        /// <summary>
        /// Creates a field that returns the values retrieved from the specified enumeration.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="valueType">The value type of the field.</param>
        /// <param name="enumerateValueCount">Number of values that will be enumerated.</param>
        /// <param name="mayBeNull">A value that indicates whether it may return a null value.</param>
        /// <param name="enumeration">The enumeration of field values.</param>
        /// <returns></returns>
        public IDataGeneratorField Create(string fieldName, Type valueType, int? enumerateValueCount, bool mayBeNull, EnumerationCreator enumeration)
        {
            return new DataGeneratorField(fieldName, valueType, enumerateValueCount, mayBeNull, enumeration);
        }

        /// <summary>
        /// Creates a field that returns the values retrieved from the specified enumeration.
        /// </summary>
        /// <typeparam name="T">The value type of the field.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="enumerateValueCount">Number of values that will be enumerated.</param>
        /// <param name="mayBeNull">A value that indicates whether it may return a null value.</param>
        /// <param name="enumeration">The enumeration of field values.</param>
        /// <returns></returns>
        public IDataGeneratorField<T> Create<T>(string fieldName, int? enumerateValueCount, bool mayBeNull, EnumerationCreator<T> enumeration) where T : struct
        {
            return new DataGeneratorField<T>(fieldName, enumerateValueCount, mayBeNull, enumeration);
        }

        /// <summary>
        /// Creates a field that returns the values retrieved from the specified enumeration.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="enumerateValueCount">Number of values that will be enumerated.</param>
        /// <param name="mayBeNull">A value that indicates whether it may return a null value.</param>
        /// <param name="enumeration">The enumeration of field values.</param>
        /// <returns></returns>
        public IDataGeneratorField<StringValue> Create(string fieldName, int? enumerateValueCount, bool mayBeNull, StringEnumerationCreator enumeration)
        {
            EnumerationCreator<StringValue> ToStringValue(StringEnumerationCreator enumeration)
            {
                return async generateCount =>
                {
                    IEnumerable<string?> enumerator = await enumeration(generateCount).ConfigureAwait(false);

                    return enumerator.Select(x => x.ToStringValue());
                };
            }

            return new DataGeneratorField<StringValue>(fieldName, enumerateValueCount, mayBeNull, ToStringValue(enumeration));
        }

        /// <summary>
        /// Creates a tuple field that returns the values retrieved from the specified enumeration.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="enumeration">The enumeration of field values.</param>
        /// <returns></returns>
        public IDataGeneratorTupleFieldEnumeration<T1, T2> Create<T1, T2>(string fieldName1, string fieldName2, IEnumerable<(T1?, T2?)> enumeration) 
            where T1 : struct
            where T2 : struct
        {
            return new DataGeneratorTupleFieldEnumeration<T1, T2>(fieldName1, fieldName2, enumeration);
        }

        /// <summary>
        /// Creates a tuple field that returns the values retrieved from the specified enumeration.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="enumeration">The enumeration of field values.</param>
        /// <returns></returns>
        public IDataGeneratorTupleFieldEnumeration<T1, T2, T3> Create<T1, T2, T3>(string fieldName1, string fieldName2, string fieldName3, IEnumerable<(T1?, T2?, T3?)> enumeration)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return new DataGeneratorTupleFieldEnumeration<T1, T2, T3>(fieldName1, fieldName2, fieldName3, enumeration);
        }


        #region Random

        /// <summary>
        /// Creates a field that returns Boolean random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="trueProbability">probability of returning true. (between 0 and 1.0)</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<bool> RandomBoolean(string fieldName, double trueProbability = 0.5, double nullProbability = 0)
        {
            ValueTask<IEnumerable<bool?>> generator(int count) => new ValueTask<IEnumerable<bool?>>(m_Enumeration.RandomBooleanOrNull(count, trueProbability, nullProbability));
            return new DataGeneratorField<bool>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Byte random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<byte> RandomByte(string fieldName, byte minValue, byte maxValue, Func<byte, byte>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<byte?>> generator(int count) => new ValueTask<IEnumerable<byte?>>(m_Enumeration.RandomByteOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<byte>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Byte random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<byte> RandomByte(string fieldName, byte minValue, byte maxValue, Task<Func<byte, byte>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<byte?>> generator(int count)
            {
                return m_Enumeration.RandomByteOrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<byte>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Int16 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<short> RandomInt16(string fieldName, short minValue, short maxValue, Func<short, short>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<short?>> generator(int count) => new ValueTask<IEnumerable<short?>>(m_Enumeration.RandomInt16OrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<short>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Int16 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<short> RandomInt16(string fieldName, short minValue, short maxValue, Task<Func<short, short>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<short?>> generator(int count)
            {
                return m_Enumeration.RandomInt16OrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<short>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Int32 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<int> RandomInt32(string fieldName, int minValue, int maxValue, Func<int, int>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<int?>> generator(int count) => new ValueTask<IEnumerable<int?>>(m_Enumeration.RandomInt32OrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<int>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Int32 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<int> RandomInt32(string fieldName, int minValue, int maxValue, Task<Func<int, int>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<int?>> generator(int count)
            {
                return m_Enumeration.RandomInt32OrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<int>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Int64 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<long> RandomInt64(string fieldName, long minValue, long maxValue, Func<long, long>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<long?>> generator(int count) => new ValueTask<IEnumerable<long?>>(m_Enumeration.RandomInt64OrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<long>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Int64 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<long> RandomInt64(string fieldName, long minValue, long maxValue, Task<Func<long, long>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<long?>> generator(int count)
            {
                return m_Enumeration.RandomInt64OrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<long>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Single random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<float> RandomSingle(string fieldName, float minValue, float maxValue, Func<float, float>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<float?>> generator(int count) => new ValueTask<IEnumerable<float?>>(m_Enumeration.RandomSingleOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<float>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Single random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<float> RandomSingle(string fieldName, float minValue, float maxValue, Task<Func<float, float>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<float?>> generator(int count)
            {
                return m_Enumeration.RandomSingleOrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<float>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Double random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<double> RandomDouble(string fieldName, double minValue, double maxValue, Func<double, double>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<double?>> generator(int count) => new ValueTask<IEnumerable<double?>>(m_Enumeration.RandomDoubleOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<double>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Double random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<double> RandomDouble(string fieldName, double minValue, double maxValue, Task<Func<double, double>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<double?>> generator(int count)
            {
                return m_Enumeration.RandomDoubleOrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            } 
            return new DataGeneratorField<double>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Decimal random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<decimal> RandomDecimal(string fieldName, decimal minValue, decimal maxValue, Func<decimal, decimal>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<decimal?>> generator(int count) => new ValueTask<IEnumerable<decimal?>>(m_Enumeration.RandomDecimalOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<decimal>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Decimal random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<decimal> RandomDecimal(string fieldName, decimal minValue, decimal maxValue, Task<Func<decimal, decimal>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<decimal?>> generator(int count)
            {
                return m_Enumeration.RandomDecimalOrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            } 
            return new DataGeneratorField<decimal>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns SByte random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<sbyte> RandomSByte(string fieldName, sbyte minValue, sbyte maxValue, Func<sbyte, sbyte>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<sbyte?>> generator(int count) => new ValueTask<IEnumerable<sbyte?>>(m_Enumeration.RandomSByteOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<sbyte>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns SByte random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<sbyte> RandomSByte(string fieldName, sbyte minValue, sbyte maxValue, Task<Func<sbyte, sbyte>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<sbyte?>> generator(int count)
            {
                return m_Enumeration.RandomSByteOrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<sbyte>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns UInt16 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<ushort> RandomUInt16(string fieldName, ushort minValue, ushort maxValue, Func<ushort, ushort>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<ushort?>> generator(int count) => new ValueTask<IEnumerable<ushort?>>(m_Enumeration.RandomUInt16OrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<ushort>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns UInt16 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<ushort> RandomUInt16(string fieldName, ushort minValue, ushort maxValue, Task<Func<ushort, ushort>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<ushort?>> generator(int count)
            {
                return m_Enumeration.RandomUInt16OrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<ushort>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns UInt32 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<uint> RandomUInt32(string fieldName, uint minValue, uint maxValue, Func<uint, uint>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<uint?>> generator(int count) => new ValueTask<IEnumerable<uint?>>(m_Enumeration.RandomUInt32OrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<uint>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns UInt32 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<uint> RandomUInt32(string fieldName, uint minValue, uint maxValue, Task<Func<uint, uint>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<uint?>> generator(int count)
            {
                return m_Enumeration.RandomUInt32OrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<uint>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns UInt64 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<ulong> RandomUInt64(string fieldName, ulong minValue, ulong maxValue, Func<ulong, ulong>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<ulong?>> generator(int count) => new ValueTask<IEnumerable<ulong?>>(m_Enumeration.RandomUInt64OrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<ulong>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns UInt64 random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<ulong> RandomUInt64(string fieldName, ulong minValue, ulong maxValue, Task<Func<ulong, ulong>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<ulong?>> generator(int count)
            {
                return m_Enumeration.RandomUInt64OrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<ulong>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns DateTime random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<DateTime> RandomDateTime(string fieldName, DateTime minValue, DateTime maxValue, Func<DateTime, DateTime>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<DateTime?>> generator(int count) => new ValueTask<IEnumerable<DateTime?>>(m_Enumeration.RandomDateTimeOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<DateTime>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns DateTime random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<DateTime> RandomDateTime(string fieldName, DateTime minValue, DateTime maxValue, Task<Func<DateTime, DateTime>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<DateTime?>> generator(int count)
            {
                return m_Enumeration.RandomDateTimeOrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<DateTime>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns DateTimeOffset random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<DateTimeOffset> RandomDateTimeOffset(string fieldName, DateTimeOffset minValue, DateTimeOffset maxValue, Func<DateTimeOffset, DateTimeOffset>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<DateTimeOffset?>> generator(int count) => new ValueTask<IEnumerable<DateTimeOffset?>>(m_Enumeration.RandomDateTimeOffsetOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<DateTimeOffset>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns DateTimeOffset random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selectorAsync">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<DateTimeOffset> RandomDateTimeOffset(string fieldName, DateTimeOffset minValue, DateTimeOffset maxValue, Task<Func<DateTimeOffset, DateTimeOffset>?> selectorAsync, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<DateTimeOffset?>> generator(int count)
            {
                return m_Enumeration.RandomDateTimeOffsetOrNull(count, minValue, maxValue, nullProbability, await selectorAsync.ConfigureAwait(false));
            }
            return new DataGeneratorField<DateTimeOffset>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns TimeSpan random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TimeSpan> RandomTimeSpan(string fieldName, TimeSpan minValue, TimeSpan maxValue, Func<TimeSpan, TimeSpan>? selector = null, double nullProbability = 0)
        {
            ValueTask<IEnumerable<TimeSpan?>> generator(int count) => new ValueTask<IEnumerable<TimeSpan?>>(m_Enumeration.RandomTimeSpanOrNull(count, minValue, maxValue, nullProbability, selector));
            return new DataGeneratorField<TimeSpan>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns TimeSpan random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <param name="selector">The transform function to apply to each value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        internal IDataGeneratorField<TimeSpan> RandomTimeSpan(string fieldName, TimeSpan minValue, TimeSpan maxValue, Task<Func<TimeSpan, TimeSpan>?> selector, double nullProbability = 0)
        {
            async ValueTask<IEnumerable<TimeSpan?>> generator(int count)
            {
                return m_Enumeration.RandomTimeSpanOrNull(count, minValue, maxValue, nullProbability, await selector.ConfigureAwait(false));
            }
            return new DataGeneratorField<TimeSpan>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that returns Guid random values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<Guid> RandomGuid(string fieldName, double nullProbability = 0)
        {
            ValueTask<IEnumerable<Guid?>> generator(int count) => new ValueTask<IEnumerable<Guid?>>(m_Enumeration.RandomGuidOrNull(count, nullProbability));
            return new DataGeneratorField<Guid>(fieldName, null, nullProbability > 0, generator);
        }

        #endregion

        #region Sequence

        /// <summary>
        /// Creates a field that enumerates Byte sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<byte> SequenceByte(string fieldName, byte initialValue, byte? maximumValue = null, byte increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceByte(initialValue, maximumValue ?? byte.MaxValue, increment);
            ValueTask<IEnumerable<byte?>> generator(int count) => new ValueTask<IEnumerable<byte?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<byte>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates SByte sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<sbyte> SequenceSByte(string fieldName, sbyte initialValue, sbyte? maximumValue = null, sbyte increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceSByte(initialValue, maximumValue ?? sbyte.MaxValue, increment);
            ValueTask<IEnumerable<sbyte?>> generator(int count) => new ValueTask<IEnumerable<sbyte?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<sbyte>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates Int16 sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<short> SequenceInt16(string fieldName, short initialValue, short? maximumValue = null, short increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceInt16(initialValue, maximumValue ?? short.MaxValue, increment);
            ValueTask<IEnumerable<short?>> generator(int count) => new ValueTask<IEnumerable<short?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<short>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates UInt16 sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<ushort> SequenceUInt16(string fieldName, ushort initialValue, ushort? maximumValue = null, ushort increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceUInt16(initialValue, maximumValue ?? ushort.MaxValue, increment);
            ValueTask<IEnumerable<ushort?>> generator(int count) => new ValueTask<IEnumerable<ushort?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<ushort>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates Int32 sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<int> SequenceInt32(string fieldName, int initialValue, int? maximumValue = null, int increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceInt32(initialValue, maximumValue ?? int.MaxValue, increment);
            ValueTask<IEnumerable<int?>> generator(int count) => new ValueTask<IEnumerable<int?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<int>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates UInt32 sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<uint> SequenceUInt32(string fieldName, uint initialValue, uint? maximumValue = null, uint increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceUInt32(initialValue, maximumValue ?? int.MaxValue, increment);
            ValueTask<IEnumerable<uint?>> generator(int count) => new ValueTask<IEnumerable<uint?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<uint>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates Int64 sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<long> SequenceInt64(string fieldName, long initialValue, long? maximumValue = null, long increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceInt64(initialValue, maximumValue ?? long.MaxValue, increment);
            ValueTask<IEnumerable<long?>> generator(int count) => new ValueTask<IEnumerable<long?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<long>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates UInt64 sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<ulong> SequenceUInt64(string fieldName, ulong initialValue, ulong? maximumValue = null, ulong increment = 1, double nullProbability = 0)
        {
            int? valueCount = maximumValue.HasValue ? m_Enumeration.GetSequencialValueCount(initialValue, maximumValue.Value, increment) : null;
            var values = m_Enumeration.SequenceUInt64(initialValue, maximumValue ?? ulong.MaxValue, increment);
            ValueTask<IEnumerable<ulong?>> generator(int count) => new ValueTask<IEnumerable<ulong?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<ulong>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates DateTime sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<DateTime> SequenceDateTime(string fieldName, DateTime initialValue, DateTime maximumValue, TimeSpan increment, double nullProbability = 0)
        {
            int? valueCount = m_Enumeration.GetSequencialValueCount(initialValue, maximumValue, increment);
            var values = m_Enumeration.SequenceDateTime(initialValue, maximumValue, increment);
            ValueTask<IEnumerable<DateTime?>> generator(int count) => new ValueTask<IEnumerable<DateTime?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<DateTime>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates DateTime sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="incrementMonths">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<DateTime> SequenceDateMonth(string fieldName, DateTime initialValue, DateTime maximumValue, int incrementMonths, double nullProbability = 0)
        {
            int? valueCount = m_Enumeration.GetSequencialValueCount(initialValue, maximumValue, incrementMonths);
            var values = m_Enumeration.SequenceDateMonth(initialValue, maximumValue, incrementMonths);
            ValueTask<IEnumerable<DateTime?>> generator(int count) => new ValueTask<IEnumerable<DateTime?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<DateTime>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates DateTimeOffset sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<DateTimeOffset> SequenceDateTimeOffset(string fieldName, DateTimeOffset initialValue, DateTimeOffset maximumValue, TimeSpan increment, double nullProbability = 0)
        {
            int? valueCount = m_Enumeration.GetSequencialValueCount(initialValue, maximumValue, increment);
            var values = m_Enumeration.SequenceDateTimeOffset(initialValue, maximumValue, increment);
            ValueTask<IEnumerable<DateTimeOffset?>> generator(int count) => new ValueTask<IEnumerable<DateTimeOffset?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<DateTimeOffset>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates DateTimeOffset sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="incrementMonths">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<DateTimeOffset> SequenceDateMonthOffset(string fieldName, DateTimeOffset initialValue, DateTimeOffset maximumValue, int incrementMonths, double nullProbability = 0)
        {
            int? valueCount = m_Enumeration.GetSequencialValueCount(initialValue, maximumValue, incrementMonths);
            var values = m_Enumeration.SequenceDateMonthOffset(initialValue, maximumValue, incrementMonths);
            ValueTask<IEnumerable<DateTimeOffset?>> generator(int count) => new ValueTask<IEnumerable<DateTimeOffset?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<DateTimeOffset>(fieldName, valueCount, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates DateTimeOffset sequencial values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="initialValue">The initial value.</param>
        /// <param name="maximumValue">The maximum value.</param>
        /// <param name="increment">The amount of increase in value when creating a new sequence value.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TimeSpan> SequenceTimeSpan(string fieldName, TimeSpan initialValue, TimeSpan maximumValue, TimeSpan increment, double nullProbability = 0)
        {
            int? valueCount = m_Enumeration.GetSequencialValueCount(initialValue, maximumValue, increment);
            var values = m_Enumeration.SequenceTimeSpan(initialValue, maximumValue, increment);
            ValueTask<IEnumerable<TimeSpan?>> generator(int count) => new ValueTask<IEnumerable<TimeSpan?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<TimeSpan>(fieldName, valueCount, nullProbability > 0, generator);
        }

        #endregion

        #region Each

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<T> Each<T>(string fieldName, IEnumerable<T> values, double nullProbability = 0) where T : struct
        {
            ValueTask<IEnumerable<T?>> generator(int count) => new ValueTask<IEnumerable<T?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<T>(fieldName, values.Count(), nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<T> Each<T>(string fieldName, IEnumerable<T?> values, double nullProbability = 0) where T : struct
        {
            ValueTask<IEnumerable<T?>> generator(int count) => new ValueTask<IEnumerable<T?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<T>(fieldName, values.Count(), true, generator);
        }

        /// <summary>
        /// Creates a field that enumerates the specified values.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<StringValue> Each(string fieldName, IEnumerable<string?> values, double nullProbability = 0)
        {
            ValueTask<IEnumerable<StringValue?>> generator(int count) => new ValueTask<IEnumerable<StringValue?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count).Select(x => x));
            return new DataGeneratorField<StringValue>(fieldName, values.Count(), true, generator);
        }

        /// <summary>
        /// Creates a field that enumerates the values of the specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TEnum> EachEnum<TEnum>(string fieldName, double nullProbability = 0) where TEnum : struct, Enum
        {
            IEnumerable<TEnum> values = m_Enumeration.EachEnum<TEnum>();
            return EachEnum(fieldName, values, nullProbability);
        }

        /// <summary>
        /// Creates a field that enumerates the values of the specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TEnum> EachEnum<TEnum>(string fieldName, IEnumerable<TEnum> values, double nullProbability = 0) where TEnum : struct, Enum
        {
            ValueTask<IEnumerable<TEnum?>> generator(int count) => new ValueTask<IEnumerable<TEnum?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<TEnum>(fieldName, values.Count(), nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates the values of the specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TEnum> EachEnum<TEnum>(string fieldName, IEnumerable<TEnum?> values, double nullProbability = 0) where TEnum : struct, Enum
        {
            ValueTask<IEnumerable<TEnum?>> generator(int count) => new ValueTask<IEnumerable<TEnum?>>(m_Enumeration.EachOrNull(values, nullProbability).RepeatUntil(count));
            return new DataGeneratorField<TEnum>(fieldName, values.Count(), true, generator);
        }

        #endregion

        #region AnyOne

        /// <summary>
        /// Creates a field that enumerates any of the values contained in the specified list.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<T> AnyOne<T>(string fieldName, IList<T> values, double nullProbability = 0) where T : struct
        {
            ValueTask<IEnumerable<T?>> generator(int count) => new ValueTask<IEnumerable<T?>>(m_Enumeration.AnyOneOrNull(count, values, nullProbability));
            return new DataGeneratorField<T>(fieldName, values.Count, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates any of the values contained in the specified list.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<T> AnyOne<T>(string fieldName, IList<T?> values, double nullProbability = 0) where T : struct
        {
            ValueTask<IEnumerable<T?>> generator(int count) => new ValueTask<IEnumerable<T?>>(m_Enumeration.AnyOneOrNull(count, values, nullProbability));
            return new DataGeneratorField<T>(fieldName, values.Count, true, generator);
        }

        /// <summary>
        /// Creates a field that enumerates any of the values contained in the specified list.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<StringValue> AnyOne(string fieldName, IList<string?> values, double nullProbability = 0)
        {
            ValueTask<IEnumerable<StringValue?>> generator(int count) => new ValueTask<IEnumerable<StringValue?>>(m_Enumeration.AnyOneOrNull(count, values, nullProbability));
            return new DataGeneratorField<StringValue>(fieldName, values.Count, true, generator);
        }

        /// <summary>
        /// Creates a field that enumerates any of the values of the specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TEnum> AnyOneEnum<TEnum>(string fieldName, double nullProbability = 0) where TEnum : struct, Enum
        {
            return AnyOneEnum(fieldName, m_Enumeration.EachEnum<TEnum>().ToArray(), nullProbability);
        }

        /// <summary>
        /// Creates a field that enumerates any of the values of the specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TEnum> AnyOneEnum<TEnum>(string fieldName, IList<TEnum> values, double nullProbability = 0) where TEnum : struct, Enum
        {
            ValueTask<IEnumerable<TEnum?>> generator(int count) => new ValueTask<IEnumerable<TEnum?>>(m_Enumeration.AnyOneOrNull(count, values, nullProbability));
            return new DataGeneratorField<TEnum>(fieldName, null, nullProbability > 0, generator);
        }

        /// <summary>
        /// Creates a field that enumerates any of the values of the specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="values">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IDataGeneratorField<TEnum> AnyOneEnum<TEnum>(string fieldName, IList<TEnum?> values, double nullProbability = 0) where TEnum : struct, Enum
        {
            ValueTask<IEnumerable<TEnum?>> generator(int count) => new ValueTask<IEnumerable<TEnum?>>(m_Enumeration.AnyOneOrNull(count, values, nullProbability));
            return new DataGeneratorField<TEnum>(fieldName, null, true, generator);
        }

        #endregion

    }

}
