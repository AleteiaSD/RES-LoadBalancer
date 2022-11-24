using Contracts.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsTest.ClassesTest
{
    [TestFixture]
    public class WorkerPropertyTest
    {
        [Test]
        [TestCase(1, 23.43f)]
        [TestCase(1, 100)]
        [TestCase(1, 10)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 98.99f)]
        [TestCase(3, 100)]
        [TestCase(3, 10)]
        [TestCase(3, 0)]
        [TestCase(4, 10.543f)]
        [TestCase(4, 100)]
        [TestCase(4, 10)]
        [TestCase(4, 0)]
        [TestCase(5, 55.55f)]
        [TestCase(5, 100)]
        [TestCase(5, 10)]
        [TestCase(5, 0)]
        [TestCase(6, 78.321f)]
        [TestCase(6, 100)]
        [TestCase(6, 10)]
        [TestCase(6, 0)]
        [TestCase(7, 43.234f)]
        [TestCase(7, 100)]
        [TestCase(7, 10)]
        [TestCase(7, 0)]
        [TestCase(8, 48.123f)]
        [TestCase(8, 100)]
        [TestCase(8, 10)]
        [TestCase(8, 0)]
        public void WorkerPropertyKonstruktorDobriParametri(int code, float value)
        {
            WorkerProperty item = new WorkerProperty(code, value);

            Assert.AreEqual(item.Code, code);
            Assert.AreEqual(item.WorkerValue, value);
        }

        [Test]
        [TestCase(1, 101f)]
        [TestCase(1, -128.27f)]
        [TestCase(1, 3254.000f)]
        [TestCase(2, 32.123f)]
        [TestCase(2, -11.11f)]
        [TestCase(2, 2f)]
        [TestCase(3, 125f)]
        [TestCase(3, -65.765f)]
        [TestCase(3, 432.677f)]
        [TestCase(4, 199.100f)]
        [TestCase(4, -165.788f)]
        [TestCase(4, 232.232f)]
        [TestCase(5, 199.100f)]
        [TestCase(5, -1.111f)]
        [TestCase(5, 12432.677f)]
        [TestCase(6, 199.100f)]
        [TestCase(6, -666.666f)]
        [TestCase(6, 666.666f)]
        [TestCase(7, 199.100f)]
        [TestCase(7, -0.125f)]
        [TestCase(7, 101.101f)]
        [TestCase(8, 199.100f)]
        [TestCase(8, -23.232f)]
        [TestCase(8, 123.123f)]
        public void WorkerPropertyKonstruktorLosiParametri(int code, float value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                WorkerProperty desc = new WorkerProperty(code, value);
            }
            );
        }
    }
   }
