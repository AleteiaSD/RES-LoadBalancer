using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Classes
{
    [DataContract]
    public class WorkerProperty
    {
        private int code;
        private float workerValue;
        [DataMember]
        public int Code { get => code; set => code = value; }
        [DataMember]
        public float WorkerValue { get => workerValue; set => workerValue = value; }

        public WorkerProperty(int code, float workerValue)
        {
            if (code < 1 || code > 8)
            {
                throw new ArgumentException("Code ne moze biti manji od 1 niti veci od 8");
            }
            if ((code == 2 && workerValue < 0) || (code == 2 && workerValue > 1))
            {
                throw new ArgumentException("CODE_DIGITAL moze imati samo binarne vrednosti");
            }
            if ((workerValue < 0 || workerValue > 100) && code != 2)
            {
                throw new ArgumentException("Vrednosti su van opsega.");
            }
            Code = code;
            WorkerValue = workerValue;
        }
        public WorkerProperty()
        {

            Code = 0;
            WorkerValue = -1;
        }
    }
}
