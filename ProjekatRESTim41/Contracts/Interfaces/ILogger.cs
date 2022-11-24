using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Contracts
{
    [ServiceContract]
    public interface ILogger
    {
        [OperationContract]
        void UpaliWorker(int i);
        [OperationContract]
        void UgasiWorker(int i);
        [OperationContract]
        void PorukaOdWritera(int id, int code, float value);
        [OperationContract]
        void SlanjePodatakaW(Description desc,int worker);
        [OperationContract]
        void Worker(Description d,int i);
        [OperationContract]
        void UpisUBazu(CollectionDescription c, CollectionDescription c1,int dataset);
        [OperationContract]
        void PoslatiPodaciZaReader(DateTime d1, DateTime d2, int worker);
        [OperationContract]
        void PrimljeniPodaciZaReader(List<CollectionDescription> lista);
    }
}
