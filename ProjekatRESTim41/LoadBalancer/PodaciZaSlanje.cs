using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Contracts;

namespace LoadBalancer
{
    public class PodaciZaSlanje : IPodaciZaSlanje
    {
        List<Description> listaDescriptiona = new List<Description>();
        List<Item> privremenaListaZaItem = new List<Item>();

        int brojUpaljenihWorkera = 4;
        bool w1cpy, w2cpy, w3cpy, w4cpy;
        

        public void PorukaOdWritera(int id, int code, float value, bool w1, bool w2, bool w3, bool w4)
        {
            string address = "net.tcp://localhost:4010/ILogger";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<ILogger> channel = new ChannelFactory<ILogger>(binding, address);
            ILogger proxy = channel.CreateChannel();
            proxy.PorukaOdWritera(id, code, value);


            Console.WriteLine(id + "  " + code + " " + value);
            Console.WriteLine("---------------");
            Item item = new Item(code, value);
            privremenaListaZaItem.Add(item);

            int dataSet = 0;
            if (code == 1 || code == 2) dataSet = 1;
            else if (code == 3 || code == 4) dataSet = 2;
            else if (code == 5 || code == 6) dataSet = 3;
            else if (code == 7 || code == 8) dataSet = 4;

            Description desc = new Description(id, privremenaListaZaItem, dataSet);
            listaDescriptiona.Add(desc);

            w1cpy = w1;
            w2cpy = w2;
            w3cpy = w3;
            w4cpy = w4;

            SlanjeW();
        }
        int i = 0, j = 0;
        public void SlanjeW() //slanje ka workeru
        {           
            string address = "net.tcp://localhost:4020/IObradaPodataka";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<IObradaPodataka> channel = new ChannelFactory<IObradaPodataka>(binding, address);
            IObradaPodataka proxy = channel.CreateChannel();

            string address1 = "net.tcp://localhost:4010/ILogger";
            NetTcpBinding binding1 = new NetTcpBinding();
            ChannelFactory<ILogger> channel1 = new ChannelFactory<ILogger>(binding1, address1);
            ILogger proxy1 = channel1.CreateChannel();

            if (i == 0 && w1cpy == true && brojUpaljenihWorkera >= 1)
            {
                proxy.Worker(listaDescriptiona[j++], 1);
                int p = j - 1;
                proxy1.SlanjePodatakaW(listaDescriptiona[p], 1);
                if (w2cpy == true)
                    i++;
            }
            else if (i == 1 && w2cpy == true && brojUpaljenihWorkera >= 2)
                {
                    proxy.Worker(listaDescriptiona[j++], 2);
                    int p = j - 1;
                    proxy1.SlanjePodatakaW(listaDescriptiona[p], 2);
                    if (w3cpy == true)
                        i++;
                    else
                        i = 0;
                }
            else if(i == 2 && w3cpy == true && brojUpaljenihWorkera >= 3)
                {
                    proxy.Worker(listaDescriptiona[j++], 3);
                    int p = j - 1;
                    proxy1.SlanjePodatakaW(listaDescriptiona[p], 3);
                    if (w4cpy == true)
                        i++;
                    else
                        i = 0;
                }
            else  if (i == 3 && w4cpy == true && brojUpaljenihWorkera >= 4)
                {
                    proxy.Worker(listaDescriptiona[j++], 4);
                    int p = j - 1;
                    proxy1.SlanjePodatakaW(listaDescriptiona[p], 4);
                    i = 0;
                }
            
        }
        
        public Contracts.PaljenjeIGasenje UpaliWorker(Contracts.PaljenjeIGasenje stanje)
        {
            if (stanje.UpaljenWorker_1 == false) { stanje = new Contracts.PaljenjeIGasenje(true, false, false, false); brojUpaljenihWorkera++; }
            else if (stanje.UpaljenWorker_2 == false) { stanje = new Contracts.PaljenjeIGasenje(true, true, false, false); brojUpaljenihWorkera++; }
            else if (stanje.UpaljenWorker_3 == false) { stanje = new Contracts.PaljenjeIGasenje(true, true, true, false); brojUpaljenihWorkera++; }
            else if (stanje.UpaljenWorker_4 == false) { stanje = new Contracts.PaljenjeIGasenje(true, true, true, true); brojUpaljenihWorkera++; }


            string address = "net.tcp://localhost:4010/ILogger";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<ILogger> channel = new ChannelFactory<ILogger>(binding, address);
            ILogger proxy = channel.CreateChannel();
            proxy.UpaliWorker(brojUpaljenihWorkera);
            return stanje;
        }

        public Contracts.PaljenjeIGasenje UgasiWorker(Contracts.PaljenjeIGasenje stanje)
        {
            if (stanje.UpaljenWorker_4 == true) { stanje = new Contracts.PaljenjeIGasenje(true, true, true, false); brojUpaljenihWorkera--; }
            else if (stanje.UpaljenWorker_3 == true) { stanje = new Contracts.PaljenjeIGasenje(true, true, false, false); brojUpaljenihWorkera--; }
            else if (stanje.UpaljenWorker_2 == true) { stanje = new Contracts.PaljenjeIGasenje(true, false, false, false); brojUpaljenihWorkera--; }
            else if (stanje.UpaljenWorker_1 == true) { stanje = new Contracts.PaljenjeIGasenje(false, false, false, false); brojUpaljenihWorkera--; }
            string address = "net.tcp://localhost:4010/ILogger";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<ILogger> channel = new ChannelFactory<ILogger>(binding, address);
            ILogger proxy = channel.CreateChannel();
            proxy.UpaliWorker(brojUpaljenihWorkera);
            return stanje;
        }


    }
}