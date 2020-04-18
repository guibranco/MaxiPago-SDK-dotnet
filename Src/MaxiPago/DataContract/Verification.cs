using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract 
{
    [Serializable]
    [XmlRoot(ElementName = "verification")]
    public class Verification
    {

        public Verification() { }

        public Verification(string merchantId, string merchantKey) {
            MerchantId = merchantId;
            MerchantKey = merchantKey;
        }

        [XmlElement("merchantId")]
        public string MerchantId { get; set; }

        [XmlElement("merchantKey")]
        public string MerchantKey { get; set; }

    }
}
