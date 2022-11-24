using Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsTest
{
    [TestFixture]
    public class PaljenjeIGasenjeTest
    {
        [Test]
        [TestCase(true, true, true, true)]
        [TestCase(false, true, true, true)]
        [TestCase(true, false, true, true)]
        [TestCase(true, true, false, true)]
        [TestCase(true, true, true, false)]
        [TestCase(false, false, true, true)]
        [TestCase(false, true, false, true)]
        [TestCase(false, true, true, false)]
        [TestCase(true, false, false, true)]
        [TestCase(true, false, true, false)]
        [TestCase(true, true, false, false)]
        [TestCase(false, false, false, true)]
        [TestCase(false, false, true, false)]
        [TestCase(true, false, false, false)]
        [TestCase(false, false, false, false)]

        public void PaljenjeIGasenjeKonstruktorDobriParametri(bool b1, bool b2, bool b3, bool b4)
        {
            PaljenjeIGasenje pig = new PaljenjeIGasenje(b1, b2, b3, b4);

            Assert.AreEqual(pig.UpaljenWorker_1, b1);
            Assert.AreEqual(pig.UpaljenWorker_2, b2);
            Assert.AreEqual(pig.UpaljenWorker_3, b3);
            Assert.AreEqual(pig.UpaljenWorker_4, b4);
        }

    }   
}
