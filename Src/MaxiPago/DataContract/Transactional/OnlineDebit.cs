using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "onlineDebit")]
    public class OnlineDebit
    {

        [XmlElement("parametersURL")]
        public string ParametersURL { get; set; }

    }
}
