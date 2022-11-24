using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contracts;

namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Ispis ispis = new Ispis();
            while (true)
            {

                Console.WriteLine("DateTime FORMAT: [13.6.2020. 21:11:07]");
                Console.WriteLine("Unesite DateTime1: ");
                DateTime d1 = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Unesite DateTime2: ");
                DateTime d2 = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Koji Worker zelite da iscitate[1-4]:");
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("DT1: " + d1.ToString());
                Console.WriteLine("DT2: " + d2.ToString());
                ispis.PosaljiPodatke(d1, d2, id);

                string address = "net.tcp://localhost:4010/ILogger";
                NetTcpBinding binding = new NetTcpBinding();
                ChannelFactory<ILogger> channel = new ChannelFactory<ILogger>(binding, address);
                ILogger proxy = channel.CreateChannel();
                proxy.PoslatiPodaciZaReader(d1, d2, id);
            }



        }
    }
}
