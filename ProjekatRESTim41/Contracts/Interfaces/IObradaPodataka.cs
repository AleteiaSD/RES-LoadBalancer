using Contracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface IObradaPodataka
    {

        [OperationContract]
        void Worker(Description d, int i);
        [OperationContract]
        List<CollectionDescription> PrimiIPosaljiKaReaderu(DateTime d1, DateTime d2, int workerId);

    }
}
