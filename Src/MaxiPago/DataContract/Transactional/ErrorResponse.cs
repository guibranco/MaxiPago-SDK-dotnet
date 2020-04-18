using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot(ElementName = "api-error")]
    public class ErrorResponse : ResponseBase
    {

        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        [XmlElement("errorMsg")]
        public string ErrorMsg { get; set; }

    }
}
