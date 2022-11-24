using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    public interface IPodaciZaSlanje
    {
        [OperationContract]
        void PorukaOdWritera(int id, int code, float value, bool w1, bool w2, bool w3, bool w4); //salje ka Load Balanceru     

        [OperationContract]
        PaljenjeIGasenje UpaliWorker(PaljenjeIGasenje stanje);

        [OperationContract]
        PaljenjeIGasenje UgasiWorker(PaljenjeIGasenje stanje);
    }
}
