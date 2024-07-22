using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    [Serializable]
    [XmlRoot(ElementName = "pixPayment")]
    public class PixPayment
    {
        [XmlElement("pixKey")]
        public string PixKey { get; set; }
    }
}