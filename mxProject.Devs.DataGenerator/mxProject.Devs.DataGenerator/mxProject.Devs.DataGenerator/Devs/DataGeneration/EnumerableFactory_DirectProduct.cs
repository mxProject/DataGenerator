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
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2)> DirectProduct<T1, T2>(IEnumerable<T1> values1, IEnumerable<T2> values2)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();

            return from v1 in list1
                   from v2 in list2
                   select (v1, v2);
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <param name="values3">The third enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3)> DirectProduct<T1, T2, T3>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();
            var list3 = values3.AsList();

            return from v1 in list1
                   from v2 in list2
                   from v3 in list3
                   select (v1, v2, v3);
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <param name="values3">The third enumeration.</param>
        /// <param name="values4">The fourth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4)> DirectProduct<T1, T2, T3, T4>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();
            var list3 = values3.AsList();
            var list4 = values4.AsList();

            return from v1 in list1
                   from v2 in list2
                   from v3 in list3
                   from v4 in list4
                   select (v1, v2, v3, v4);
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <param name="values3">The third enumeration.</param>
        /// <param name="values4">The fourth enumeration.</param>
        /// <param name="values5">The fifth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5)> DirectProduct<T1, T2, T3, T4, T5>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();
            var list3 = values3.AsList();
            var list4 = values4.AsList();
            var list5 = values5.AsList();

            return from v1 in list1
                   from v2 in list2
                   from v3 in list3
                   from v4 in list4
                   from v5 in list5
                   select (v1, v2, v3, v4, v5);
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <param name="values3">The third enumeration.</param>
        /// <param name="values4">The fourth enumeration.</param>
        /// <param name="values5">The fifth enumeration.</param>
        /// <param name="values6">The sixth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6)> DirectProduct<T1, T2, T3, T4, T5, T6>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();
            var list3 = values3.AsList();
            var list4 = values4.AsList();
            var list5 = values5.AsList();
            var list6 = values6.AsList();

            return from v1 in list1
                   from v2 in list2
                   from v3 in list3
                   from v4 in list4
                   from v5 in list5
                   from v6 in list6
                   select (v1, v2, v3, v4, v5, v6);
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <param name="values3">The third enumeration.</param>
        /// <param name="values4">The fourth enumeration.</param>
        /// <param name="values5">The fifth enumeration.</param>
        /// <param name="values6">The sixth enumeration.</param>
        /// <param name="values7">The seventh enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> DirectProduct<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6, IEnumerable<T7> values7)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();
            var list3 = values3.AsList();
            var list4 = values4.AsList();
            var list5 = values5.AsList();
            var list6 = values6.AsList();
            var list7 = values7.AsList();

            return from v1 in list1
                   from v2 in list2
                   from v3 in list3
                   from v4 in list4
                   from v5 in list5
                   from v6 in list6
                   from v7 in list7
                   select (v1, v2, v3, v4, v5, v6, v7);
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <param name="values3">The third enumeration.</param>
        /// <param name="values4">The fourth enumeration.</param>
        /// <param name="values5">The fifth enumeration.</param>
        /// <param name="values6">The sixth enumeration.</param>
        /// <param name="values7">The seventh enumeration.</param>
        /// <param name="values8">The eighth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> DirectProduct<T1, T2, T3, T4, T5, T6, T7, T8>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6, IEnumerable<T7> values7, IEnumerable<T8> values8)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();
            var list3 = values3.AsList();
            var list4 = values4.AsList();
            var list5 = values5.AsList();
            var list6 = values6.AsList();
            var list7 = values7.AsList();
            var list8 = values8.AsList();

            return from v1 in list1
                   from v2 in list2
                   from v3 in list3
                   from v4 in list4
                   from v5 in list5
                   from v6 in list6
                   from v7 in list7
                   from v8 in list8
                   select (v1, v2, v3, v4, v5, v6, v7, v8);
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
        /// <typeparam name="T9">The type of object to enumerate in the ninth enumeration.</typeparam>
        /// <param name="values1">The first enumeration.</param>
        /// <param name="values2">The second enumeration.</param>
        /// <param name="values3">The third enumeration.</param>
        /// <param name="values4">The fourth enumeration.</param>
        /// <param name="values5">The fifth enumeration.</param>
        /// <param name="values6">The sixth enumeration.</param>
        /// <param name="values7">The seventh enumeration.</param>
        /// <param name="values8">The eighth enumeration.</param>
        /// <param name="values9">The ninth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> DirectProduct<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IEnumerable<T1> values1, IEnumerable<T2> values2, IEnumerable<T3> values3, IEnumerable<T4> values4, IEnumerable<T5> values5, IEnumerable<T6> values6, IEnumerable<T7> values7, IEnumerable<T8> values8, IEnumerable<T9> values9)
        {
            var list1 = values1.AsList();
            var list2 = values2.AsList();
            var list3 = values3.AsList();
            var list4 = values4.AsList();
            var list5 = values5.AsList();
            var list6 = values6.AsList();
            var list7 = values7.AsList();
            var list8 = values8.AsList();
            var list9 = values9.AsList();

            return from v1 in list1
                   from v2 in list2
                   from v3 in list3
                   from v4 in list4
                   from v5 in list5
                   from v6 in list6
                   from v7 in list7
                   from v8 in list8
                   from v9 in list9
                   select (v1, v2, v3, v4, v5, v6, v7, v8, v9);
        }

        #endregion

        #region func

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2)> DirectProduct<T1, T2>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    yield return (v1, v2);
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3)> DirectProduct<T1, T2, T3>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2, Func<IEnumerable<T3>> values3)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        yield return (v1, v2, v3);
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4)> DirectProduct<T1, T2, T3, T4>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2, Func<IEnumerable<T3>> values3, Func<IEnumerable<T4>> values4)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            yield return (v1, v2, v3, v4);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5)> DirectProduct<T1, T2, T3, T4, T5>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2, Func<IEnumerable<T3>> values3, Func<IEnumerable<T4>> values4, Func<IEnumerable<T5>> values5)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                yield return (v1, v2, v3, v4, v5);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6)> DirectProduct<T1, T2, T3, T4, T5, T6>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2, Func<IEnumerable<T3>> values3, Func<IEnumerable<T4>> values4, Func<IEnumerable<T5>> values5, Func<IEnumerable<T6>> values6)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    yield return (v1, v2, v3, v4, v5, v6);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <param name="values7">The method to create the seventh enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7)> DirectProduct<T1, T2, T3, T4, T5, T6, T7>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2, Func<IEnumerable<T3>> values3, Func<IEnumerable<T4>> values4, Func<IEnumerable<T5>> values5, Func<IEnumerable<T6>> values6, Func<IEnumerable<T7>> values7)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    foreach (var v7 in values7())
                                    {
                                        yield return (v1, v2, v3, v4, v5, v6, v7);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <param name="values7">The method to create the seventh enumeration.</param>
        /// <param name="values8">The method to create the eighth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8)> DirectProduct<T1, T2, T3, T4, T5, T6, T7, T8>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2, Func<IEnumerable<T3>> values3, Func<IEnumerable<T4>> values4, Func<IEnumerable<T5>> values5, Func<IEnumerable<T6>> values6, Func<IEnumerable<T7>> values7, Func<IEnumerable<T8>> values8)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    foreach (var v7 in values7())
                                    {
                                        foreach (var v8 in values8())
                                        {
                                            yield return (v1, v2, v3, v4, v5, v6, v7, v8);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
        /// <typeparam name="T9">The type of object to enumerate in the ninth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <param name="values7">The method to create the seventh enumeration.</param>
        /// <param name="values8">The method to create the eighth enumeration.</param>
        /// <param name="values9">The method to create the ninth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> DirectProduct<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<IEnumerable<T1>> values1, Func<IEnumerable<T2>> values2, Func<IEnumerable<T3>> values3, Func<IEnumerable<T4>> values4, Func<IEnumerable<T5>> values5, Func<IEnumerable<T6>> values6, Func<IEnumerable<T7>> values7, Func<IEnumerable<T8>> values8, Func<IEnumerable<T9>> values9)
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    foreach (var v7 in values7())
                                    {
                                        foreach (var v8 in values8())
                                        {
                                            foreach (var v9 in values9())
                                            {
                                                yield return (v1, v2, v3, v4, v5, v6, v7, v8, v9);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region func ( returns nullable )

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?)> DirectProduct<T1, T2>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2)
            where T1 : struct
            where T2 : struct
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    yield return (v1, v2);
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?, T3?)> DirectProduct<T1, T2, T3>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2, Func<IEnumerable<T3?>> values3)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        yield return (v1, v2, v3);
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?, T3?, T4?)> DirectProduct<T1, T2, T3, T4>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2, Func<IEnumerable<T3?>> values3, Func<IEnumerable<T4?>> values4)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            yield return (v1, v2, v3, v4);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?, T3?, T4?, T5?)> DirectProduct<T1, T2, T3, T4, T5>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2, Func<IEnumerable<T3?>> values3, Func<IEnumerable<T4?>> values4, Func<IEnumerable<T5?>> values5)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                yield return (v1, v2, v3, v4, v5);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?)> DirectProduct<T1, T2, T3, T4, T5, T6>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2, Func<IEnumerable<T3?>> values3, Func<IEnumerable<T4?>> values4, Func<IEnumerable<T5?>> values5, Func<IEnumerable<T6?>> values6)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    yield return (v1, v2, v3, v4, v5, v6);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <param name="values7">The method to create the seventh enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)> DirectProduct<T1, T2, T3, T4, T5, T6, T7>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2, Func<IEnumerable<T3?>> values3, Func<IEnumerable<T4?>> values4, Func<IEnumerable<T5?>> values5, Func<IEnumerable<T6?>> values6, Func<IEnumerable<T7?>> values7)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    foreach (var v7 in values7())
                                    {
                                        yield return (v1, v2, v3, v4, v5, v6, v7);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <param name="values7">The method to create the seventh enumeration.</param>
        /// <param name="values8">The method to create the eighth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?)> DirectProduct<T1, T2, T3, T4, T5, T6, T7, T8>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2, Func<IEnumerable<T3?>> values3, Func<IEnumerable<T4?>> values4, Func<IEnumerable<T5?>> values5, Func<IEnumerable<T6?>> values6, Func<IEnumerable<T7?>> values7, Func<IEnumerable<T8?>> values8)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    foreach (var v7 in values7())
                                    {
                                        foreach (var v8 in values8())
                                        {
                                            yield return (v1, v2, v3, v4, v5, v6, v7, v8);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Enumerates the direct product of the specified enumerations.
        /// </summary>
        /// <typeparam name="T1">The type of object to enumerate in the first enumeration.</typeparam>
        /// <typeparam name="T2">The type of object to enumerate in the second enumeration.</typeparam>
        /// <typeparam name="T3">The type of object to enumerate in the third enumeration.</typeparam>
        /// <typeparam name="T4">The type of object to enumerate in the fourth enumeration.</typeparam>
        /// <typeparam name="T5">The type of object to enumerate in the fifth enumeration.</typeparam>
        /// <typeparam name="T6">The type of object to enumerate in the sixth enumeration.</typeparam>
        /// <typeparam name="T7">The type of object to enumerate in the seventh enumeration.</typeparam>
        /// <typeparam name="T8">The type of object to enumerate in the eighth enumeration.</typeparam>
        /// <typeparam name="T9">The type of object to enumerate in the ninth enumeration.</typeparam>
        /// <param name="values1">The method to create the first enumeration.</param>
        /// <param name="values2">The method to create the second enumeration.</param>
        /// <param name="values3">The method to create the third enumeration.</param>
        /// <param name="values4">The method to create the fourth enumeration.</param>
        /// <param name="values5">The method to create the fifth enumeration.</param>
        /// <param name="values6">The method to create the sixth enumeration.</param>
        /// <param name="values7">The method to create the seventh enumeration.</param>
        /// <param name="values8">The method to create the eighth enumeration.</param>
        /// <param name="values9">The method to create the ninth enumeration.</param>
        /// <returns></returns>
        public IEnumerable<(T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?)> DirectProduct<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<IEnumerable<T1?>> values1, Func<IEnumerable<T2?>> values2, Func<IEnumerable<T3?>> values3, Func<IEnumerable<T4?>> values4, Func<IEnumerable<T5?>> values5, Func<IEnumerable<T6?>> values6, Func<IEnumerable<T7?>> values7, Func<IEnumerable<T8?>> values8, Func<IEnumerable<T9?>> values9)
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
            foreach (var v1 in values1())
            {
                foreach (var v2 in values2())
                {
                    foreach (var v3 in values3())
                    {
                        foreach (var v4 in values4())
                        {
                            foreach (var v5 in values5())
                            {
                                foreach (var v6 in values6())
                                {
                                    foreach (var v7 in values7())
                                    {
                                        foreach (var v8 in values8())
                                        {
                                            foreach (var v9 in values9())
                                            {
                                                yield return (v1, v2, v3, v4, v5, v6, v7, v8, v9);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

    }
}
