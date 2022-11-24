using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Threading;

namespace Writer
{
    class Writer //Pravljenje konekcije
    {
        public Writer()
        { }
        PaljenjeIGasenje stanje = new PaljenjeIGasenje();
        //List<PaljenjeIGasenje> listaStanja = new List<PaljenjeIGasenje>();
        public void WriterThread() //thread 1
        {
            string address = "net.tcp://localhost:4000/IPodaciZaSlanje";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<IPodaciZaSlanje> channel = new ChannelFactory<IPodaciZaSlanje>(binding, address);
            IPodaciZaSlanje proxy = channel.CreateChannel();
            int id = 0;
            while (true)//slanje podataka ka Load Balanceru
            {
                try//stavio sam code na 1 i 2 zbog provere
                {
                    //Send metoda
                    int code = RandomNumberInt(1, 9);            //Ima 8 Code-ova u listi                     
                    if (code == 2)                              //CODE_DIGITAL ima vrednost 2
                    {
                        float value = (float)RandomNumberInt(0, 2);    //CODE_DIGITAL moze da ima vrednost 0 ili 1
                        proxy.PorukaOdWritera(id, code, value, stanje.UpaljenWorker_1, stanje.UpaljenWorker_2, stanje.UpaljenWorker_3, stanje.UpaljenWorker_4);
                    }
                    else
                    {
                        double valueDouble = Math.Round((GetRandomNumber(0, 100)), 3);    // SVI OSTALI CODE-OVI
                        float valueFloat = (float)valueDouble;                     // Prebacim ga u folat zbog tabele u bazi podataka
                        proxy.PorukaOdWritera(id, code, valueFloat, stanje.UpaljenWorker_1, stanje.UpaljenWorker_2, stanje.UpaljenWorker_3, stanje.UpaljenWorker_4);
                    }
                    id++;   //Povecavamo Id u tabeli u bazi podataka
                    Thread.Sleep(500);     //salje poruku na svake 2 sekunde    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void UpaliUgasiThread() //thread 2
        {
            string address = "net.tcp://localhost:4000/IPodaciZaSlanje";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<IPodaciZaSlanje> channel = new ChannelFactory<IPodaciZaSlanje>(binding, address);
            IPodaciZaSlanje proxy = channel.CreateChannel();

            while (true)//slanje podataka ka Load Balanceru
            {
                Console.WriteLine("Sta zelite da radite?");
                Console.WriteLine("1. Upali novi Worker.");
                Console.WriteLine("2. Ugasi postojeci Worker.");
                Console.Write("Vas odgovor: ");
                int caseSwitch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("==================================");

                switch (caseSwitch)
                {
                    case 1:
                        //int upali = UpaliWorkerDo();
                        PaljenjeIGasenje st1 = proxy.UpaliWorker(stanje);                       //poslali smo podatke ka Load Balanceru za paljenje Workera
                        stanje = st1;
                        Console.WriteLine("==================================");
                        break;
                    case 2:
                        //int ugasi = UgasiWorkerDo();
                        PaljenjeIGasenje st2 = proxy.UgasiWorker(stanje);                       //poslali smo podatke ka Load Balanceru za gasenje Workera
                        stanje = st2;
                        Console.WriteLine("==================================");
                        break;
                }
            }
        }
        //=============================================================================================
        public int RandomNumberInt(int min, int max) //pomocna metoda za 
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble()*(max/2.123);
        }
    }
}
