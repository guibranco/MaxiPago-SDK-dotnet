using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "payType")]
    public class PayType
    {

        [XmlElement("creditCard")]
        public CreditCard CreditCard { get; set; }
        public bool ShouldSerializeCreditCard() { return CreditCard != null; }

        [XmlElement("onFile")]
        public OnFile OnFile { get; set; }
        public bool ShouldSerializeOnFile() { return OnFile != null; }

        [XmlElement("boleto")]
        public Boleto Boleto { get; set; }
        public bool ShouldSerializeBoleto() { return Boleto != null; }

        [XmlElement("onlineDebit")]
        public OnlineDebit OnlineDebit { get; set; }
        public bool ShouldSerializeOnlineDebit() { return OnlineDebit != null; }

    }
}
