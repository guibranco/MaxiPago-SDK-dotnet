using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    [Serializable]
    [XmlRoot(ElementName = "transaction-request")]
    public class TransactionRequest
    {

        public TransactionRequest()
        {
            Verification = new Verification();
            Order = new Order();
            Version = "3.1.1.15";
        }


        public TransactionRequest(string merchantId, string merchantKey)
        {
            Verification = new Verification(merchantId, merchantKey);
            Order = new Order();
            Version = "3.1.1.15";
        }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("verification")]
        public Verification Verification { get; set; }

        [XmlElement("order")]
        public Order Order { get; set; }

    }
}
