using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [DataContract]
    public class Description
    {
        private int id;
        private List<Item> listaItema;
        private int dataSet;
        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public List<Item> ListaItema { get => listaItema; set => listaItema = value; }
        [DataMember]
        public int DataSet { get => dataSet; set => dataSet = value; }
        public object WorkerProperty { get; set; }

        public Description()
        {
            Id = -1;
            listaItema = new List<Item>();
            dataSet = -1;
        }

        public Description(int id, List<Item> listaItema, int dataSet)
        {
            Id = id;
            ListaItema = listaItema;
            DataSet = dataSet;
        }


    };
}
