using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public class CollectionDescription
    {
        private int id;
        private int dataSet;
        private WorkerProperty historicalCollection;
        private DateTime timestamp;
        private int workerId;


        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public int DataSet { get => dataSet; set => dataSet = value; }
        [DataMember]
        public WorkerProperty HistoricalCollection { get => historicalCollection; set => historicalCollection = value; }
        [DataMember]
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        [DataMember]
        public int WorkerId { get => workerId; set => workerId = value; }

        public CollectionDescription(int id, int dataSet, WorkerProperty historicalCollection,DateTime time,int workerId)
        {
            Id = id;
            DataSet = dataSet;
            HistoricalCollection = historicalCollection;
            Timestamp = time;
            WorkerId = workerId;
        }
        public CollectionDescription()
        {
            Id = -5;
            DataSet = -5;
            HistoricalCollection = new WorkerProperty();
            Timestamp = new DateTime();
            WorkerId = -5;
        }
    }
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
