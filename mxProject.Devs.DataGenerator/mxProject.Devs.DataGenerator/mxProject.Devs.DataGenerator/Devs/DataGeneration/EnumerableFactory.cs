using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Data;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Enumeration Factory.
    /// </summary>
    public partial class EnumerableFactory
    {

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="random">The random value generation logic.</param>
        public EnumerableFactory(IRandomGenerator? random = null)
        {
            m_RandomGenerator = random ?? DefaultRandomGenerator.Instance;
        }

        /// <summary>
        /// Singleton instance.
        /// </summary>
        internal static readonly EnumerableFactory Instance = new EnumerableFactory();

        /// <summary>
        /// Gets the random value generation logic.
        /// </summary>
        private IRandomGenerator RandomGenerator
        {
            get { return m_RandomGenerator ?? DefaultRandomGenerator.Instance; }
        }
        private readonly IRandomGenerator? m_RandomGenerator;

        /// <summary>
        /// Gets whether it is expected to return null.
        /// </summary>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        private bool ExcectingNull(double nullProbability)
        {
            if (nullProbability <= 0) { return false; }
            if (nullProbability >= 1) { return true; }

            return RandomGenerator.NextDouble(0, 1) <= nullProbability;
        }

        #region EachOrNull

        /// <summary>
        /// Enumerates the specified value or null.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<T?> EachOrNull<T>(IEnumerable<T> values, double nullProbability) where T : struct
        {
            foreach (var value in values)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Enumerates the specified value or null.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<T?> EachOrNull<T>(IEnumerable<T?> values, double nullProbability) where T : struct
        {
            if (nullProbability == 0)
            {
                return values;
            }
            else
            {
                return main(this, values, nullProbability);
            }

            static IEnumerable<T?> main(EnumerableFactory @this, IEnumerable<T?> values, double nullProbability)
            {
                foreach (var value in values)
                {
                    if (@this.ExcectingNull(nullProbability))
                    {
                        yield return null;
                    }
                    else
                    {
                        yield return value;
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the specified value or null.
        /// </summary>
        /// <param name="values">The values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<StringValue?> EachOrNull(IEnumerable<string?> values, double nullProbability)
        {
            foreach (var value in values)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else if (value == null)
                {
                    yield return null;
                }
                else
                {
                    yield return value;
                }
            }
        }


        #endregion

        #region EachEnum

        /// <summary>
        /// Enumerates the values of the specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <returns></returns>
        public IEnumerable<TEnum> EachEnum<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }

        /// <summary>
        /// Enumerates the values of the specified enumeration type.
        /// </summary>
        /// <param name="enumType">The enumeration type.</param>
        /// <returns></returns>
        public IEnumerable<Enum> EachEnum(Type enumType)
        {
            return Enum.GetValues(enumType).Cast<Enum>();
        }

        #endregion

        #region AnyOne

        /// <summary>
        /// Enumerates any of the values contained in the specified list.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="expectedValues">The list containing the values to enumerate.</param>
        /// <returns></returns>
        public IEnumerable<T> AnyOne<T>(int count, IList<T> expectedValues) where T : struct
        {
            for (int i = 0; i < count; ++i)
            {
                yield return expectedValues[NextAnyIndex(expectedValues.Count)];
            }
        }

        /// <summary>
        /// Enumerates any of the values contained in the specified list.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="expectedValues">The list containing the values to enumerate.</param>
        /// <returns></returns>
        public IEnumerable<T?> AnyOne<T>(int count, IList<T?> expectedValues) where T : struct
        {
            for (int i = 0; i < count; ++i)
            {
                yield return expectedValues[NextAnyIndex(expectedValues.Count)];
            }
        }

        /// <summary>
        /// Enumerates any of the values contained in the specified list.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="expectedValues">The list containing the values to enumerate.</param>
        /// <returns></returns>
        public IEnumerable<StringValue?> AnyOne(int count, IList<string?> expectedValues)
        {
            for (int i = 0; i < count; ++i)
            {
                string? value = expectedValues[NextAnyIndex(expectedValues.Count)];
                if (value == null)
                {
                    yield return null;
                }
                else
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Gets a new next index for AnyOne.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <returns></returns>
        private int NextAnyIndex(int count)
        {
            // return RandomGenerator.NextInt32(0, count - 1);
            return (int)Math.Round(RandomGenerator.NextDouble(0, count - 1));
        }

        #endregion

        #region AnyOneOrNull

        /// <summary>
        /// Enumerates any of the values contained in the specified list or null.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="expectedValues">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<T?> AnyOneOrNull<T>(int count, IList<T> expectedValues, double nullProbability) where T : struct
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    yield return expectedValues[NextAnyIndex(expectedValues.Count)];
                }
            }
        }

        /// <summary>
        /// Enumerates any of the values contained in the specified list or null.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="expectedValues">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<T?> AnyOneOrNull<T>(int count, IList<T?> expectedValues, double nullProbability) where T : struct
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    yield return expectedValues[NextAnyIndex(expectedValues.Count)];
                }
            }
        }

        /// <summary>
        /// Enumerates any of the values contained in the specified list or null.
        /// </summary>
        /// <param name="count">The number of values to enumerate.</param>
        /// <param name="expectedValues">The list containing the values to enumerate.</param>
        /// <param name="nullProbability">Probability of returning null. (between 0 and 1.0)</param>
        /// <returns></returns>
        public IEnumerable<StringValue?> AnyOneOrNull(int count, IList<string?> expectedValues, double nullProbability)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ExcectingNull(nullProbability))
                {
                    yield return null;
                }
                else
                {
                    string? value = expectedValues[NextAnyIndex(expectedValues.Count)];

                    if (value == null)
                    {
                        yield return null;
                    }
                    else
                    {
                        yield return value;
                    }
                }
            }
        }

        #endregion

    }

}
