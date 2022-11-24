using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(LoggerClass)))
            {
                string address = "net.tcp://localhost:4010/ILogger";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(ILogger), binding, address);
                host.Open();
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
