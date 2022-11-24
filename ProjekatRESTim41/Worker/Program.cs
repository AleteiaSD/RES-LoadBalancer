using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Obradjivac)))
            {
                string address = "net.tcp://localhost:4020/IObradaPodataka";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IObradaPodataka), binding, address);
                host.Open();
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
