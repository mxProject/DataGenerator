using Microsoft.VisualStudio.TestTools.UnitTesting;
using mxProject.Devs.DataGeneration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class TestConvert
    {
        [TestMethod]
        public async Task Convert()
        {
            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            using var field = await factory.RandomByte("randomByte", 1, 255, nullProbability: 0.25)
                .Convert(x => x.HasValue ? (int)x.Value * 100 : (int?)null)
                .CreateTypedEnumerationAsync(100)
                .ConfigureAwait(false);

            Assert.AreEqual("randomByte", field.FieldName);
            Assert.AreEqual(typeof(int), field.ValueType);

            while(field.GenerateNext())
            {
                Debug.WriteLine($"{field.GetTypedValue()}");
            }
        }

        [TestMethod]
        public async Task ConvertToString()
        {
            DataGeneratorFieldFactory factory = new DataGeneratorFieldFactory();

            using var field = await factory.RandomByte("randomByte", 1, 255, nullProbability: 0.25)
                .ConvertToString(x => $"{x:d5}")
                .CreateTypedEnumerationAsync(100)
                .ConfigureAwait(false);

            Assert.AreEqual("randomByte", field.FieldName);
            Assert.AreEqual(typeof(StringValue), field.ValueType);

            while (field.GenerateNext())
            {
                Debug.WriteLine($"{field.GetTypedValue()}");
            }
        }
    }
}
