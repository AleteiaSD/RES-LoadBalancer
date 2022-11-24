using Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractsTest.ClassesTest
{
    [TestFixture]
    public class DescriptionTest
    {
        [Test]
        public void KonstruktorBezParametara()
        {
            Assert.DoesNotThrow(() =>
            {
                Description dd = new Description();
                Assert.IsNotNull(dd);
                
            });
        }
        
        
        
    }

   


}
