using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "onFile")]
    public class OnFile
    {

        [XmlElement(ElementName = "customerId")]
        public string CustomerId { get; set; }

        [XmlElement(ElementName = "token")]
        public string Token { get; set; }

    }
}
