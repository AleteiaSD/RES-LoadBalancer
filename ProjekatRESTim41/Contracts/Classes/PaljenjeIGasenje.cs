using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class PaljenjeIGasenje
    {
        public bool UpaljenWorker_1 { get; set; }
        public bool UpaljenWorker_2 { get; set; }
        public bool UpaljenWorker_3 { get; set; }
        public bool UpaljenWorker_4 { get; set; }
        public PaljenjeIGasenje()
        {
            UpaljenWorker_1 = true;
            UpaljenWorker_2 = true;//namestio sam da samo prvi prima podatke zbog testiranja
            UpaljenWorker_3 = true;
            UpaljenWorker_4 = true;
        }

        public PaljenjeIGasenje(bool stanje1, bool stanje2, bool stanje3, bool stanje4)
        {
            UpaljenWorker_1 = stanje1;
            UpaljenWorker_2 = stanje2;
            UpaljenWorker_3 = stanje3;
            UpaljenWorker_4 = stanje4;
        }
        public PaljenjeIGasenje(PaljenjeIGasenje p)
        {
            this.UpaljenWorker_1 = p.UpaljenWorker_1;
            this.UpaljenWorker_2 = p.UpaljenWorker_2;
            this.UpaljenWorker_3 = p.UpaljenWorker_3;
            this.UpaljenWorker_4 = p.UpaljenWorker_4;
        }
    }
}
