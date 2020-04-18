using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "transactionDetail")]
    public class TransactionDetail
    {

        public TransactionDetail()
        {
            PayType = new PayType();
        }

        [XmlElement("payType")]
        public PayType PayType { get; set; }

    }
}
