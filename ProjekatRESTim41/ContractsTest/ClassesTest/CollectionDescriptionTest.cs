using Contracts;
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
    public class CollectionDescriptionTest
    {
        [Test]
        public void KonstruktorBezParametara()
        {
            Assert.DoesNotThrow(() =>
            {
                CollectionDescription cd = new CollectionDescription();
                Assert.IsNotNull(cd);

            });
        }
    }
}
