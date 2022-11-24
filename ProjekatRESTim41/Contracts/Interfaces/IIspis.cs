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
    public interface IIspis
    {
        [OperationContract]
        void PosaljiPodatke(DateTime t1, DateTime t2,int workerId);
    }
}
