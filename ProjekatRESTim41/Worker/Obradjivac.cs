using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace Worker
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Obradjivac : IObradaPodataka
    {
          List<CollectionDescription> listaCollection = new List<CollectionDescription>();       
          int bazaBrojac1 = 0, bazaBrojac2 = 0, bazaBrojac3 = 0, bazaBrojac4 = 0;
          int idPretposlednjeg1 = 0, idPretposlednjeg2 = 0, idPretposlednjeg3 = 0, idPretposlednjeg4 = 0;
          int idPoslednjeg1 = 0, idPoslednjeg2 = 0, idPoslednjeg3 = 0, idPoslednjeg4 = 0;
          bool upisanDS1 = false, upisanDS2 = false, upisanDS3 = false, upisanDS4 = false;

        public void Worker(Description d, int idWorkera)
        {
            string address = "net.tcp://localhost:4010/ILogger";
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<ILogger> channel = new ChannelFactory<ILogger>(binding, address);
            ILogger proxy = channel.CreateChannel();
            proxy.Worker(d, idWorkera);

            Console.WriteLine("WORKER " + idWorkera + ": Id: " + d.Id + ", code: " + d.ListaItema[d.Id].Code + ", value: " + d.ListaItema[d.Id].Value);
            WorkerProperty w = new WorkerProperty(d.ListaItema[d.Id].Code, d.ListaItema[d.Id].Value);
            CollectionDescription c = new CollectionDescription(d.Id, d.DataSet, w, DateTime.Now, idWorkera);
            listaCollection.Add(c);          
            ProveraUpisa();
        }        
        public void UpisUBazu(CollectionDescription c, CollectionDescription c1)
        {
            string stevan = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\TheMachine\\Desktop\\TIM41\\" +
                "ProjekatRESTim41\\ProjekatRESTim41\\Contracts\\Database.mdf;Integrated Security=True";
            string aleksandra = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\aleks\\OneDrive\\Dokumenti\\GitHub\\TIM41" +
                "\\ProjekatRESTim41\\ProjekatRESTim41\\Contracts\\Database.mdf;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(stevan);
                conn.Open();
                string spojeno = Spojeno(c);//String spojeno u koji cemo da stavimo value koju mozemo da upisemo u tabelu, 
                                            //Imace separator '.' umesto ',' jer SqlCommand prima 3 parametra, 
                                            //',' u pocetnom obliku pravi problem pa je potrebno upisati u tabelu sa '.' 
                string spojeno1 = Spojeno(c1);  
                string timestamp = GetTimestamp(DateTime.Now);

                if (c.DataSet == 1 || c.DataSet == -1 || c1.DataSet == 1 || c1.DataSet == -1)
                {
                    idPretposlednjeg1 = c.Id;
                    idPoslednjeg1 = c1.Id;
                    listaCollection[idPretposlednjeg1].DataSet = -1;
                    listaCollection[idPoslednjeg1].DataSet = -1;
                    string values = "values(" + bazaBrojac1 + ", " + c.HistoricalCollection.Code + ", " + spojeno + ", " + c1.HistoricalCollection.Code + ", " + spojeno1 + ", " + timestamp + ");"; //Pomocni string kako bi smo sve mogli da upisemo u 58. liniju 
                    ++bazaBrojac1;
                    SqlCommand cmd = new SqlCommand("insert into DataSet1 (Id, Code1, Value1, Code2, Value2, Timestamp1) " + values, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (c.DataSet == 2 || c.DataSet == -2 || c1.DataSet == 2 || c1.DataSet == -2)
                {
                    idPretposlednjeg2 = c.Id;
                    idPoslednjeg2 = c1.Id;
                    listaCollection[idPretposlednjeg1].DataSet = -2;
                    listaCollection[idPoslednjeg1].DataSet = -2;
                    string values = "values(" + bazaBrojac2 + ", " + c.HistoricalCollection.Code + ", " + spojeno + ", " + c1.HistoricalCollection.Code + ", " + spojeno1 + ", " + timestamp + ");"; //Pomocni string kako bi smo sve mogli da upisemo u 58. liniju 
                    ++bazaBrojac2;
                    SqlCommand cmd = new SqlCommand("insert into DataSet2 (Id, Code3, Value3, Code4, Value4, Timestamp2) " + values, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (c.DataSet == 3 || c.DataSet == -3 || c1.DataSet == 3 || c1.DataSet == -3)
                {
                    idPretposlednjeg3 = c.Id;
                    idPoslednjeg3 = c1.Id;
                    listaCollection[idPretposlednjeg1].DataSet = -3;
                    listaCollection[idPoslednjeg1].DataSet = -3;
                    string values = "values(" + bazaBrojac3 + ", " + c.HistoricalCollection.Code + ", " + spojeno + ", " + c1.HistoricalCollection.Code + ", " + spojeno1 + ", " + timestamp + ");"; //Pomocni string kako bi smo sve mogli da upisemo u 58. liniju 
                    ++bazaBrojac3;
                    SqlCommand cmd = new SqlCommand("insert into DataSet3 (Id, Code5, Value5, Code6, Value6, Timestamp3) " + values, conn);
                    cmd.ExecuteNonQuery();
                }
                else if (c.DataSet == 4 || c.DataSet == -4 || c1.DataSet == 4 || c1.DataSet == -4)
                {
                    idPretposlednjeg4 = c.Id;
                    idPoslednjeg4 = c1.Id;
                    listaCollection[idPretposlednjeg1].DataSet = -4;
                    listaCollection[idPoslednjeg1].DataSet = -4;
                    string values = "values(" + bazaBrojac4 + ", " + c.HistoricalCollection.Code + ", " + spojeno + ", " + c1.HistoricalCollection.Code + ", " + spojeno1 + ", " + timestamp + ");"; //Pomocni string kako bi smo sve mogli da upisemo u 58. liniju 
                    ++bazaBrojac4;
                    SqlCommand cmd = new SqlCommand("insert into DataSet4 (Id, Code7, Value7, Code8, Value8, Timestamp4) " + values, conn);
                    cmd.ExecuteNonQuery();
                }
                if(c.DataSet<0)
                Console.WriteLine("Podaci upisani u tabelu DataSet" + c.DataSet*-1);
                else
                Console.WriteLine("Podaci upisani u tabelu DataSet" + c.DataSet);
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                conn.Close();

                string address = "net.tcp://localhost:4010/ILogger";
                NetTcpBinding binding = new NetTcpBinding();
                ChannelFactory<ILogger> channel = new ChannelFactory<ILogger>(binding, address);
                ILogger proxy = channel.CreateChannel();
                proxy.UpisUBazu(c, c1, c.DataSet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public string Spojeno(CollectionDescription c)
        {
            char[] delimetersChar = { '.', ',' };                               //Izbacujemo zarez
            string text = c.HistoricalCollection.WorkerValue.ToString();    //Ovde nam text sadrzi value vrednost u pocetnom obliku 13,364
            string spojeno = "", zarez = ",", tacka = ".";                                                //String spojeno u koji cemo da stavimo value koju mozemo da upisemo u tabelu, Imace separator '.' umesto ',' jer SqlCommand prima 3 parametra, ',' u pocetnom obliku pravi problem pa je potrebno upisati u tabelu sa '.' 
            if (c.HistoricalCollection.Code == 2)   //Ako primimo CODE_DIGITAL parametar, on ce biti u obliku 0,0 ili 1,0
            {
                if (c.HistoricalCollection.Code == 2)
                {
                    string[] splitovano = text.Split(delimetersChar);       //Potrebno je odstraniti sve iza ',', odstranimo ','           
                    spojeno = splitovano[0];                                //Uzimamo samo prvi deo posle Split-ovanja
                }
                else if ((text.Contains(zarez) || text.Contains(tacka)))
                    spojeno = TextSpojeno(c);               
            }
            else
            {
                if ((text.Contains(zarez) || text.Contains(tacka)))
                    spojeno = TextSpojeno(c);
            }
            return spojeno;
        }

        public string TextSpojeno(CollectionDescription c)
        {
            string text = c.HistoricalCollection.WorkerValue.ToString();
            char[] delimetersChar = { '.', ',' };
            string zarez = ",";
            string tacka = ".";
            string spojeno = "";
            if ((text.Contains(zarez) || text.Contains(tacka)))
            {
                string[] splitovano = text.Split(delimetersChar);
                //Odstranimo ','          
                if (splitovano[0] != "" && splitovano[1] != "")         //Provera da li je stigao ceo broj ili sa ','-om                
                    spojeno = splitovano[0] + "." + splitovano[1];      //Spojimo ih sa '.'                
                else if (splitovano[0] != "")                    //Ako je stigao ceo broj                
                    spojeno = splitovano[0];                            //Upisemo                
                else
                    spojeno = "0";                                      //Slucaj za rezervu                
            }
            return spojeno;
        }

        public void ProveraUpisa()
        {

            int trenutni = listaCollection.Count - 1; //onaj koji je sad stigao, njega proveravam sa listom            
            if (listaCollection.Count >= 2)
            {
                for (int i = 0; i < listaCollection.Count; i++)
                {
                    if (listaCollection[trenutni].DataSet == 1 && upisanDS1 == false && listaCollection[i].DataSet == 1)//da li je isti data set
                    {
                        upisanDS1 = UpisiPrviput(trenutni, i, 1);
                    }//ako mi je upisanDS1 = true, onda u bazi imam podatak koji je slican trenutnom
                    else if (listaCollection[trenutni].DataSet == 1 && upisanDS1 == true)
                    {//proveravam za code 1, code 2 se ignorise
                        if ((listaCollection[trenutni].HistoricalCollection.Code == listaCollection[idPretposlednjeg1].HistoricalCollection.Code &&
                            (listaCollection[trenutni].HistoricalCollection.WorkerValue < listaCollection[idPretposlednjeg1].HistoricalCollection.WorkerValue * 0.98 || listaCollection[trenutni].HistoricalCollection.WorkerValue > listaCollection[idPretposlednjeg1].HistoricalCollection.WorkerValue * 1.02)))
                        {
                            UpisUBazu(listaCollection[trenutni], listaCollection[idPoslednjeg1]);
                            upisanDS1 = true;
                        }
                        else if (listaCollection[trenutni].HistoricalCollection.Code == 2) // ako je code digital samo upisi bez provere
                        {
                            UpisUBazu(listaCollection[idPretposlednjeg1], listaCollection[trenutni]);
                            upisanDS1 = true;
                        }
                    }


                    else if (listaCollection[trenutni].DataSet == 2 && upisanDS2 == false && listaCollection[i].DataSet == 2)//da li je isti data set
                    {
                        upisanDS2 = UpisiPrviput(trenutni, i, 2);
                    }
                    else if (listaCollection[trenutni].DataSet == 2 && upisanDS2 == true)                   //ako mi je upisanDS1 = true, onda u bazi imam podatak koji je slican trenutnom
                    {
                        DeadBand(trenutni, 2, idPretposlednjeg2, idPoslednjeg2);            //proveravam za code 3 i 4
                        upisanDS2 = true;
                    }
                    else if (listaCollection[trenutni].DataSet == 3 && upisanDS3 == false && listaCollection[i].DataSet == 3)//da li je isti data set
                    {
                        upisanDS3 = UpisiPrviput(trenutni, i, 3);
                    }
                    else if (listaCollection[trenutni].DataSet == 3 && upisanDS3 == true)                   //ako mi je upisanDS1 = true, onda u bazi imam podatak koji je slican trenutnom
                    {
                        DeadBand(trenutni, 3, idPretposlednjeg3, idPoslednjeg3);             //proveravam za code 5 i 6
                        upisanDS3 = true;
                    }
                    else if (listaCollection[trenutni].DataSet == 4 && upisanDS4 == false && listaCollection[i].DataSet == 4)//da li je isti data set
                    {
                        upisanDS4 = UpisiPrviput(trenutni, i, 4);
                    }
                    else if (listaCollection[trenutni].DataSet == 4 && upisanDS4 == true)           //ako mi je upisanDS1 = true, onda u bazi imam podatak koji je slican trenutnom
                    {
                        DeadBand(trenutni, 4, idPretposlednjeg4, idPoslednjeg4);     //proveravam za code 7 i 8
                        upisanDS4 = true;
                    }
                }

            }
        }
        public bool UpisiPrviput(int trenutni, int i, int dataSet)
        {
            if (listaCollection[trenutni].HistoricalCollection.Code != listaCollection[i].HistoricalCollection.Code)// da li je Value razlicit                                  
            {//kad naidjem na par podataka koje mogu da upisem
                if (listaCollection[trenutni].HistoricalCollection.Code > listaCollection[i].HistoricalCollection.Code)
                    UpisUBazu(listaCollection[i], listaCollection[trenutni]);

                if (listaCollection[trenutni].HistoricalCollection.Code < listaCollection[i].HistoricalCollection.Code)
                    UpisUBazu(listaCollection[trenutni], listaCollection[i]);
                return true; ;
            }
            return false;
        }
        public void DeadBand(int trenutni, int dataSet, int idPretposlednjeg, int idPoslednjeg)
        {
            if ((listaCollection[trenutni].HistoricalCollection.Code == listaCollection[idPretposlednjeg].HistoricalCollection.Code &&
                (listaCollection[trenutni].HistoricalCollection.WorkerValue < listaCollection[idPretposlednjeg].HistoricalCollection.WorkerValue * 0.98 || listaCollection[trenutni].HistoricalCollection.WorkerValue > listaCollection[idPretposlednjeg].HistoricalCollection.WorkerValue * 1.02)))
            {
                UpisUBazu(listaCollection[trenutni], listaCollection[idPoslednjeg]);
            }
            if ((listaCollection[trenutni].HistoricalCollection.Code == listaCollection[idPoslednjeg].HistoricalCollection.Code &&
                (listaCollection[trenutni].HistoricalCollection.WorkerValue < listaCollection[idPoslednjeg].HistoricalCollection.WorkerValue * 0.98 || listaCollection[trenutni].HistoricalCollection.WorkerValue > listaCollection[idPoslednjeg].HistoricalCollection.WorkerValue * 1.02)))
            {
                UpisUBazu(listaCollection[idPretposlednjeg], listaCollection[trenutni]);
            }
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        List<CollectionDescription> listaZaSlanje = new List<CollectionDescription>(); // treba uvek novu listu da napravim da bih pravilno ispisao na readeru

        public List<CollectionDescription> PrimiIPosaljiKaReaderu(DateTime d1, DateTime d2, int workerId)
        {
            listaZaSlanje = new List<CollectionDescription>();// treba uvek novu listu da napravim da bih pravilno ispisao na readeru

            for (int i = 0; i < listaCollection.Count; i++)
            {

                if ((listaCollection[i].Timestamp > d1 && listaCollection[i].Timestamp < d2) && listaCollection[i].WorkerId == workerId)
                {
                    listaZaSlanje.Add(listaCollection[i]);
                }

            }
            return listaZaSlanje;

        }
    }
}