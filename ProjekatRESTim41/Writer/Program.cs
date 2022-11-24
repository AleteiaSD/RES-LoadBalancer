using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contracts;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            Thread t1 = new Thread(writer.WriterThread);
            Thread t2 = new Thread(writer.UpaliUgasiThread);
            t1.Start();
            t2.Start();
        }
    }
}
