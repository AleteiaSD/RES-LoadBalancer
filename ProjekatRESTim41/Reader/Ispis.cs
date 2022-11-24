using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;

namespace Reader
{
    public class Ispis : IIspis
    {
        public Ispis() { }

        public void PosaljiPodatke(DateTime t1, DateTime t2, int workerId)
        {
            string address = "net.tcp://localhost:4020/IObradaPodataka";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<IObradaPodataka> channel = new ChannelFactory<IObradaPodataka>(binding, address);
            IObradaPodataka proxy = channel.CreateChannel();

            List<CollectionDescription> lista = proxy.PrimiIPosaljiKaReaderu(t1, t2, workerId);
            Console.WriteLine("Lista istorijskih podataka Workera" + workerId + ":");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine("Id: " + lista[i].Id + ", code: " + lista[i].HistoricalCollection.Code + ", value: " + lista[i].HistoricalCollection.WorkerValue);
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            string address1 = "net.tcp://localhost:4010/ILogger";
            NetTcpBinding binding1 = new NetTcpBinding();
            ChannelFactory<ILogger> channel1 = new ChannelFactory<ILogger>(binding1, address1);
            ILogger proxy1 = channel1.CreateChannel();
            proxy1.PrimljeniPodaciZaReader(lista);

        }
    }
}
