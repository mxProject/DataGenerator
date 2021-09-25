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
    partial class EnumerableFactory
    {

        #region values

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2)> EachParallel<T1, T2>(IEnumerable<T1> values1, IEnumerable<T2> values2, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext())
                {
                    yield return (t1.Current, t2.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext())
                {
                    yield return (t1.Current, t2.Current);
                }
            }
        }

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <typeparam name="T3">The type of value stored in the third collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="values3">The third collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3)> EachParallel<T1, T2, T3>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();
                using var t3 = values3.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext() && t3.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());
                using var t3 = new SafetyEnumerator<T3>(values3.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext() | t3.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current);
                }
            }
        }

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <typeparam name="T3">The type of value stored in the third collection.</typeparam>
        /// <typeparam name="T4">The type of value stored in the fourth collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="values3">The third collection.</param>
        /// <param name="values4">The fourth collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4)> EachParallel<T1, T2, T3, T4>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();
                using var t3 = values3.GetEnumerator();
                using var t4 = values4.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext() && t3.MoveNext() && t4.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());
                using var t3 = new SafetyEnumerator<T3>(values3.GetEnumerator());
                using var t4 = new SafetyEnumerator<T4>(values4.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext() | t3.MoveNext() | t4.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current);
                }
            }
        }

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <typeparam name="T3">The type of value stored in the third collection.</typeparam>
        /// <typeparam name="T4">The type of value stored in the fourth collection.</typeparam>
        /// <typeparam name="T5">The type of value stored in the fifth collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="values3">The third collection.</param>
        /// <param name="values4">The fourth collection.</param>
        /// <param name="values5">The fifth collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5)> EachParallel<T1, T2, T3, T4, T5>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();
                using var t3 = values3.GetEnumerator();
                using var t4 = values4.GetEnumerator();
                using var t5 = values5.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext() && t3.MoveNext() && t4.MoveNext() && t5.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());
                using var t3 = new SafetyEnumerator<T3>(values3.GetEnumerator());
                using var t4 = new SafetyEnumerator<T4>(values4.GetEnumerator());
                using var t5 = new SafetyEnumerator<T5>(values5.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext() | t3.MoveNext() | t4.MoveNext() | t5.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current);
                }
            }
        }

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <typeparam name="T3">The type of value stored in the third collection.</typeparam>
        /// <typeparam name="T4">The type of value stored in the fourth collection.</typeparam>
        /// <typeparam name="T5">The type of value stored in the fifth collection.</typeparam>
        /// <typeparam name="T6">The type of value stored in the sixth collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="values3">The third collection.</param>
        /// <param name="values4">The fourth collection.</param>
        /// <param name="values5">The fifth collection.</param>
        /// <param name="values6">The sixth collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6)> EachParallel<T1, T2, T3, T4, T5, T6>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();
                using var t3 = values3.GetEnumerator();
                using var t4 = values4.GetEnumerator();
                using var t5 = values5.GetEnumerator();
                using var t6 = values6.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext() && t3.MoveNext() && t4.MoveNext() && t5.MoveNext() && t6.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());
                using var t3 = new SafetyEnumerator<T3>(values3.GetEnumerator());
                using var t4 = new SafetyEnumerator<T4>(values4.GetEnumerator());
                using var t5 = new SafetyEnumerator<T5>(values5.GetEnumerator());
                using var t6 = new SafetyEnumerator<T6>(values6.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext() | t3.MoveNext() | t4.MoveNext() | t5.MoveNext() | t6.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current);
                }
            }
        }

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <typeparam name="T3">The type of value stored in the third collection.</typeparam>
        /// <typeparam name="T4">The type of value stored in the fourth collection.</typeparam>
        /// <typeparam name="T5">The type of value stored in the fifth collection.</typeparam>
        /// <typeparam name="T6">The type of value stored in the sixth collection.</typeparam>
        /// <typeparam name="T7">The type of value stored in the seventh collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="values3">The third collection.</param>
        /// <param name="values4">The fourth collection.</param>
        /// <param name="values5">The fifth collection.</param>
        /// <param name="values6">The sixth collection.</param>
        /// <param name="values7">The seventh collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> EachParallel<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6, IEnumerable<T7> values7, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();
                using var t3 = values3.GetEnumerator();
                using var t4 = values4.GetEnumerator();
                using var t5 = values5.GetEnumerator();
                using var t6 = values6.GetEnumerator();
                using var t7 = values7.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext() && t3.MoveNext() && t4.MoveNext() && t5.MoveNext() && t6.MoveNext() && t7.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current, t7.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());
                using var t3 = new SafetyEnumerator<T3>(values3.GetEnumerator());
                using var t4 = new SafetyEnumerator<T4>(values4.GetEnumerator());
                using var t5 = new SafetyEnumerator<T5>(values5.GetEnumerator());
                using var t6 = new SafetyEnumerator<T6>(values6.GetEnumerator());
                using var t7 = new SafetyEnumerator<T7>(values7.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext() | t3.MoveNext() | t4.MoveNext() | t5.MoveNext() | t6.MoveNext() | t7.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current, t7.Current);
                }
            }
        }

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <typeparam name="T3">The type of value stored in the third collection.</typeparam>
        /// <typeparam name="T4">The type of value stored in the fourth collection.</typeparam>
        /// <typeparam name="T5">The type of value stored in the fifth collection.</typeparam>
        /// <typeparam name="T6">The type of value stored in the sixth collection.</typeparam>
        /// <typeparam name="T7">The type of value stored in the seventh collection.</typeparam>
        /// <typeparam name="T8">The type of value stored in the eighth collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="values3">The third collection.</param>
        /// <param name="values4">The fourth collection.</param>
        /// <param name="values5">The fifth collection.</param>
        /// <param name="values6">The sixth collection.</param>
        /// <param name="values7">The seventh collection.</param>
        /// <param name="values8">The eighth collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> EachParallel<T1, T2, T3, T4, T5, T6, T7, T8>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6, IEnumerable<T7> values7, IEnumerable<T8> values8, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();
                using var t3 = values3.GetEnumerator();
                using var t4 = values4.GetEnumerator();
                using var t5 = values5.GetEnumerator();
                using var t6 = values6.GetEnumerator();
                using var t7 = values7.GetEnumerator();
                using var t8 = values8.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext() && t3.MoveNext() && t4.MoveNext() && t5.MoveNext() && t6.MoveNext() && t7.MoveNext() && t8.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current, t7.Current, t8.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());
                using var t3 = new SafetyEnumerator<T3>(values3.GetEnumerator());
                using var t4 = new SafetyEnumerator<T4>(values4.GetEnumerator());
                using var t5 = new SafetyEnumerator<T5>(values5.GetEnumerator());
                using var t6 = new SafetyEnumerator<T6>(values6.GetEnumerator());
                using var t7 = new SafetyEnumerator<T7>(values7.GetEnumerator());
                using var t8 = new SafetyEnumerator<T8>(values8.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext() | t3.MoveNext() | t4.MoveNext() | t5.MoveNext() | t6.MoveNext() | t7.MoveNext() | t8.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current, t7.Current, t8.Current);
                }
            }
        }

        /// <summary>
        /// Enumerates values ​​in parallel from the specified collections.
        /// </summary>
        /// <typeparam name="T1">The type of value stored in the first collection.</typeparam>
        /// <typeparam name="T2">The type of value stored in the second collection.</typeparam>
        /// <typeparam name="T3">The type of value stored in the third collection.</typeparam>
        /// <typeparam name="T4">The type of value stored in the fourth collection.</typeparam>
        /// <typeparam name="T5">The type of value stored in the fifth collection.</typeparam>
        /// <typeparam name="T6">The type of value stored in the sixth collection.</typeparam>
        /// <typeparam name="T7">The type of value stored in the seventh collection.</typeparam>
        /// <typeparam name="T8">The type of value stored in the eighth collection.</typeparam>
        /// <typeparam name="T9">The type of value stored in the ninth collection.</typeparam>
        /// <param name="values1">The first collection.</param>
        /// <param name="values2">The second collection.</param>
        /// <param name="values3">The third collection.</param>
        /// <param name="values4">The fourth collection.</param>
        /// <param name="values5">The fifth collection.</param>
        /// <param name="values6">The sixth collection.</param>
        /// <param name="values7">The seventh collection.</param>
        /// <param name="values8">The eighth collection.</param>
        /// <param name="values9">The ninth collection.</param>
        /// <param name="exitWhenAnyCompleted">A value that indicates whether to exit when the enumeration of any collection is complete.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> EachParallel<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6, IEnumerable<T7> values7, IEnumerable<T8> values8, IEnumerable<T9> values9, bool exitWhenAnyCompleted)
        {
            if (exitWhenAnyCompleted)
            {
                using var t1 = values1.GetEnumerator();
                using var t2 = values2.GetEnumerator();
                using var t3 = values3.GetEnumerator();
                using var t4 = values4.GetEnumerator();
                using var t5 = values5.GetEnumerator();
                using var t6 = values6.GetEnumerator();
                using var t7 = values7.GetEnumerator();
                using var t8 = values8.GetEnumerator();
                using var t9 = values9.GetEnumerator();

                while (t1.MoveNext() && t2.MoveNext() && t3.MoveNext() && t4.MoveNext() && t5.MoveNext() && t6.MoveNext() && t7.MoveNext() && t8.MoveNext() && t9.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current, t7.Current, t8.Current, t9.Current);
                }
            }
            else
            {
                using var t1 = new SafetyEnumerator<T1>(values1.GetEnumerator());
                using var t2 = new SafetyEnumerator<T2>(values2.GetEnumerator());
                using var t3 = new SafetyEnumerator<T3>(values3.GetEnumerator());
                using var t4 = new SafetyEnumerator<T4>(values4.GetEnumerator());
                using var t5 = new SafetyEnumerator<T5>(values5.GetEnumerator());
                using var t6 = new SafetyEnumerator<T6>(values6.GetEnumerator());
                using var t7 = new SafetyEnumerator<T7>(values7.GetEnumerator());
                using var t8 = new SafetyEnumerator<T8>(values8.GetEnumerator());
                using var t9 = new SafetyEnumerator<T9>(values9.GetEnumerator());

                while (t1.MoveNext() | t2.MoveNext() | t3.MoveNext() | t4.MoveNext() | t5.MoveNext() | t6.MoveNext() | t7.MoveNext() | t8.MoveNext() | t9.MoveNext())
                {
                    yield return (t1.Current, t2.Current, t3.Current, t4.Current, t5.Current, t6.Current, t7.Current, t8.Current, t9.Current);
                }
            }
        }

        #endregion

        private class SafetyEnumerator<T> : IEnumerator<T>
        {
            internal SafetyEnumerator(IEnumerator<T> enumerator)
            {
                m_Enumerator = enumerator;
            }

            private readonly IEnumerator<T> m_Enumerator;
            private bool m_Completed = false;

            public T Current
            {
                get
                {
                    if (m_Completed) { return default!; }
                    return m_Enumerator.Current;
                }
            }

            object System.Collections.IEnumerator.Current => this.Current!;

            public void Dispose()
            {
                m_Enumerator.Dispose();
            }

            public bool MoveNext()
            {
                if (m_Completed) { return false; }

                if (m_Enumerator.MoveNext())
                {
                    return true;
                }
                else
                {
                    m_Completed = true;
                    return false;
                }
            }

            public void Reset()
            {
                m_Enumerator.Reset();
            }
        }
    }
}
