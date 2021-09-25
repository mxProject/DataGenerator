using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

using mxProject.Devs.DataGeneration;
using mxProject.Devs.DataGeneration.Fields;

using UnitTestProject1.Extensions;
using UnitTestProject1.SampleValues;

namespace UnitTestProject1
{

    [TestClass]
    public class TestDirectProduct
    {

        #region 2 collections

        [TestMethod]
        public void Collection2()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();

            EnumerateCore(factory.DirectProduct(values1, values2), GetProductCount(values1, values2));
        }

        #endregion

        #region 3 collections

        [TestMethod]
        public void Collection3()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();

            EnumerateCore(factory.DirectProduct(values1, values2, values3), GetProductCount(values1, values2, values3));
        }

        #endregion

        #region 4 collections

        [TestMethod]
        public void Collection4()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();

            EnumerateCore(factory.DirectProduct(values1, values2, values3, values4), GetProductCount(values1, values2, values3, values4));
        }

        #endregion

        #region 5 collections

        [TestMethod]
        public void Collection5()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();

            EnumerateCore(factory.DirectProduct(values1, values2, values3, values4, values5), GetProductCount(values1, values2, values3, values4, values5));
        }

        #endregion

        #region 6 collections

        [TestMethod]
        public void Collection6()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();

            EnumerateCore(factory.DirectProduct(values1, values2, values3, values4, values5, values6), GetProductCount(values1, values2, values3, values4, values5, values6));
        }

        #endregion

        #region 7 collections

        [TestMethod]
        public void Collection7()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();

            EnumerateCore(factory.DirectProduct(values1, values2, values3, values4, values5, values6, values7), GetProductCount(values1, values2, values3, values4, values5, values6, values7));
        }

        #endregion

        #region 8 collections

        [TestMethod]
        public void Collection8()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();
            var values8 = SampleDirectProductValues.GetValues8();

            EnumerateCore(factory.DirectProduct(values1, values2, values3, values4, values5, values6, values7, values8), GetProductCount(values1, values2, values3, values4, values5, values6, values7, values8));
        }

        #endregion

        #region 9 collections

        [TestMethod]
        public void Collection9()
        {
            EnumerableFactory factory = new();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();
            var values8 = SampleDirectProductValues.GetValues8();
            var values9 = SampleDirectProductValues.GetValues9();

            EnumerateCore(factory.DirectProduct(values1, values2, values3, values4, values5, values6, values7, values8, values9), GetProductCount(values1, values2, values3, values4, values5, values6, values7, values8, values9));
        }

        #endregion

        private static void EnumerateCore(IEnumerable collection, int expectedCount)
        {
            int count = 0;

            foreach (var result in collection)
            {
                Debug.WriteLine(result);
                ++count;
            }

            Assert.AreEqual(expectedCount, count);
        }

        private static int GetProductCount(params IList[] lists)
        {
            int count = 1;

            for (int i = 0; i < lists.Length; ++i)
            {
                count *= lists[i].Count;
            }

            return count;
        }


        #region 2 fields

        [TestMethod]
        public async Task Field2()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    Assert.AreEqual(true, product.GenerateNext());
                    AssertValues(product, values1[i1], values2[i2]);
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        #region 3 fields

        [TestMethod]
        public async Task Field3()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1),
                context.FieldFactory.Each("field3", values3, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2, values3)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    for (int i3 = 0; i3 < values3.Length; ++i3)
                    {
                        Assert.AreEqual(true, product.GenerateNext());
                        AssertValues(product, values1[i1], values2[i2], values3[i3]);
                    }
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        #region 4 fields

        [TestMethod]
        public async Task Field4()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1),
                context.FieldFactory.Each("field3", values3, 0.1),
                context.FieldFactory.Each("field4", values4, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2, values3, values4)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    for (int i3 = 0; i3 < values3.Length; ++i3)
                    {
                        for (int i4 = 0; i4 < values4.Length; ++i4)
                        {
                            Assert.AreEqual(true, product.GenerateNext());
                            AssertValues(product, values1[i1], values2[i2], values3[i3], values4[i4]);
                        }
                    }
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        #region 5 fields

        [TestMethod]
        public async Task Field5()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1),
                context.FieldFactory.Each("field3", values3, 0.1),
                context.FieldFactory.Each("field4", values4, 0.1),
                context.FieldFactory.Each("field5", values5, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2, values3, values4, values5)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    for (int i3 = 0; i3 < values3.Length; ++i3)
                    {
                        for (int i4 = 0; i4 < values4.Length; ++i4)
                        {
                            for (int i5 = 0; i5 < values5.Length; ++i5)
                            {
                                Assert.AreEqual(true, product.GenerateNext());
                                AssertValues(product, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5]);
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        #region 6 fields

        [TestMethod]
        public async Task Field6()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1),
                context.FieldFactory.Each("field3", values3, 0.1),
                context.FieldFactory.Each("field4", values4, 0.1),
                context.FieldFactory.Each("field5", values5, 0.1),
                context.FieldFactory.Each("field6", values6, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2, values3, values4, values5, values6)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    for (int i3 = 0; i3 < values3.Length; ++i3)
                    {
                        for (int i4 = 0; i4 < values4.Length; ++i4)
                        {
                            for (int i5 = 0; i5 < values5.Length; ++i5)
                            {
                                for (int i6 = 0; i6 < values6.Length; ++i6)
                                {
                                    Assert.AreEqual(true, product.GenerateNext());
                                    AssertValues(product, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6]);
                                }
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        #region 7 fields

        [TestMethod]
        public async Task Field7()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1),
                context.FieldFactory.Each("field3", values3, 0.1),
                context.FieldFactory.Each("field4", values4, 0.1),
                context.FieldFactory.Each("field5", values5, 0.1),
                context.FieldFactory.Each("field6", values6, 0.1),
                context.FieldFactory.Each("field7", values7, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2, values3, values4, values5, values6, values7)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    for (int i3 = 0; i3 < values3.Length; ++i3)
                    {
                        for (int i4 = 0; i4 < values4.Length; ++i4)
                        {
                            for (int i5 = 0; i5 < values5.Length; ++i5)
                            {
                                for (int i6 = 0; i6 < values6.Length; ++i6)
                                {
                                    for (int i7 = 0; i7 < values7.Length; ++i7)
                                    {
                                        Assert.AreEqual(true, product.GenerateNext());
                                        AssertValues(product, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7]);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        #region 8 fields

        [TestMethod]
        public async Task Field8()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();
            var values8 = SampleDirectProductValues.GetValues8();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1),
                context.FieldFactory.Each("field3", values3, 0.1),
                context.FieldFactory.Each("field4", values4, 0.1),
                context.FieldFactory.Each("field5", values5, 0.1),
                context.FieldFactory.Each("field6", values6, 0.1),
                context.FieldFactory.Each("field7", values7, 0.1),
                context.FieldFactory.Each("field8", values8, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2, values3, values4, values5, values6, values7, values8)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    for (int i3 = 0; i3 < values3.Length; ++i3)
                    {
                        for (int i4 = 0; i4 < values4.Length; ++i4)
                        {
                            for (int i5 = 0; i5 < values5.Length; ++i5)
                            {
                                for (int i6 = 0; i6 < values6.Length; ++i6)
                                {
                                    for (int i7 = 0; i7 < values7.Length; ++i7)
                                    {
                                        for (int i8 = 0; i8 < values8.Length; ++i8)
                                        {
                                            Assert.AreEqual(true, product.GenerateNext());
                                            AssertValues(product, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7], values8[i8]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        #region 9 fields

        [TestMethod]
        public async Task Field9()
        {
            DataGeneratorContext context = new DataGeneratorContext();

            var values1 = SampleDirectProductValues.GetValues1();
            var values2 = SampleDirectProductValues.GetValues2();
            var values3 = SampleDirectProductValues.GetValues3();
            var values4 = SampleDirectProductValues.GetValues4();
            var values5 = SampleDirectProductValues.GetValues5();
            var values6 = SampleDirectProductValues.GetValues6();
            var values7 = SampleDirectProductValues.GetValues7();
            var values8 = SampleDirectProductValues.GetValues8();
            var values9 = SampleDirectProductValues.GetValues9();

            var fields = new IDataGeneratorField[]
            {
                context.FieldFactory.Each("field1", values1, 0.1),
                context.FieldFactory.Each("field2", values2, 0.1),
                context.FieldFactory.Each("field3", values3, 0.1),
                context.FieldFactory.Each("field4", values4, 0.1),
                context.FieldFactory.Each("field5", values5, 0.1),
                context.FieldFactory.Each("field6", values6, 0.1),
                context.FieldFactory.Each("field7", values7, 0.1),
                context.FieldFactory.Each("field8", values8, 0.1),
                context.FieldFactory.Each("field9", values9, 0.1)
            };

            using var product = await DirectProductFieldFactory.CreateTupleField(fields, context).CreateEnumerationAsync(GetProductCount(values1, values2, values3, values4, values5, values6, values7, values8, values9)).ConfigureAwait(false);

            TestUtility.DumpTuple(product);

            product.Reset();

            for (int i1 = 0; i1 < values1.Length; ++i1)
            {
                for (int i2 = 0; i2 < values2.Length; ++i2)
                {
                    for (int i3 = 0; i3 < values3.Length; ++i3)
                    {
                        for (int i4 = 0; i4 < values4.Length; ++i4)
                        {
                            for (int i5 = 0; i5 < values5.Length; ++i5)
                            {
                                for (int i6 = 0; i6 < values6.Length; ++i6)
                                {
                                    for (int i7 = 0; i7 < values7.Length; ++i7)
                                    {
                                        for (int i8 = 0; i8 < values8.Length; ++i8)
                                        {
                                            for (int i9 = 0; i9 < values9.Length; ++i9)
                                            {
                                                Assert.AreEqual(true, product.GenerateNext());
                                                AssertValues(product, values1[i1], values2[i2], values3[i3], values4[i4], values5[i5], values6[i6], values7[i7], values8[i8], values9[i9]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(false, product.GenerateNext());
        }

        #endregion

        private static void AssertValues(IDataGeneratorTupleFieldEnumeration enumerator, params object?[] expectedValues)
        {
            object?[] values = new object?[enumerator.FieldCount];

            for (int i = 0; i < enumerator.FieldCount; ++i)
            {
                if (enumerator.IsNullValue(i))
                {
                    Assert.IsNull(enumerator.GetValue(i));
                }
                else
                {
                    Assert.AreEqual(expectedValues[i], enumerator.GetValue(i));
                }
            }

            enumerator.GetValues(values);

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] != null)
                {
                    Assert.AreEqual(expectedValues[i], values[i]);
                }
            }
        }


    }

}
