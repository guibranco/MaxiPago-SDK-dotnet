using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "billing")]
    public class Billing : Address { }
}
