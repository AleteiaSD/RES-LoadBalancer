using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;
using System.IO;

namespace Logger
{
    public class LoggerClass : ILogger
    {
        public void PorukaOdWritera(int id, int code, float value)
        {
            string s = "Load Balancer prima podatke od Writera: id-" + id + ", code:" + code + ", value:" + value;
            SacuvajKorisnika(s);
        }

        public void PoslatiPodaciZaReader(DateTime d1, DateTime d2, int worker)
        {
            string s = "Reader salje podatke ka workeru: " + d1.ToString() + ", " + d2.ToString() + ", " + worker;
            SacuvajKorisnika(s);
        }

        public void PrimljeniPodaciZaReader(List<CollectionDescription> lista)
        {
            string s = "Reader ispisuje podatke na konzolu. " + lista.ToString();
            SacuvajKorisnika(s);
        }

        public void SlanjePodatakaW(Description desc, int worker)
        {
            string s = "Worker" + worker + " salje podatke na obradu." + desc.ToString();
            SacuvajKorisnika(s);
        }

        public void UgasiWorker(int i)
        {
            string s = "Writer inicira paljenje novih Workera. Broj upaljenih workera " + i + ".";
            SacuvajKorisnika(s);
        }

        public void UpaliWorker(int i)
        {
            string s = "Writer inicira gasenje novih Workera. Broj upaljenih workera " + i + ".";
            SacuvajKorisnika(s);
        }

        public void UpisUBazu(CollectionDescription c, CollectionDescription c1, int dataset)
        {
            string s = "Upisani podaci u bazu [DataSet" + dataset + "]. " + c.ToString() + ", " + c1.ToString();
            SacuvajKorisnika(s);
        }

        public void Worker(Description d, int i)
        {
            string s = "Worker" + i + " primio podatke." + d.Id + ", " + d.ListaItema.ToString();
            SacuvajKorisnika(s);
        }
        public  void SacuvajKorisnika(string poruka)//ovde ga upisujem u korisnici.txt
        {
            string putanja = "C:\\Users\\TheMachine\\Desktop\\TIM41\\ProjekatRESTim41\\ProjekatRESTim41\\Logger\\Logger\\Logger.txt";
            FileStream stream = new FileStream(putanja, FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(poruka);
            sw.Close();
            stream.Close();
        }

    }
}
