using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [DataContract]
    public class Item
    {
        private int code;
        private float value;
        [DataMember]
        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        [DataMember]
        public float Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Item() { }

       
        public Item(int code, float value)
        {
           
            if (code < 1 || code > 8)
            {
                throw new ArgumentException("Code ne moze biti manji od 1 niti veci od 8");
            }
            if( (code == 2 && value <0) || (code == 2 && value >1) )
            {
                throw new ArgumentException("CODE_DIGITAL moze imati samo binarne vrednosti");
            }
            if( (value <0 || value >100) && code != 2)
            {
                throw new ArgumentException("Vrednosti su van opsega.");
            }

            this.Code = code;
            this.Value = value;
           
        }
    }
 
}
