using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "boleto")]
    public class Boleto
    {

        [XmlElement(ElementName = "expirationDate")]
        public string ExpirationDate { get; set; }

        [XmlElement(ElementName = "number")]
        public string Number { get; set; }

        [XmlElement(ElementName = "instructions")]
        public string Instructions { get; set; }

    }
}
