using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.ServiceModel;
using System.Threading;

namespace LoadBalancer
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(PodaciZaSlanje)))
            {
                string address = "net.tcp://localhost:4000/IPodaciZaSlanje";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPodaciZaSlanje), binding, address);
                host.Open();
                Console.ReadKey();
                host.Close();
            }
        }
        
    }
}
