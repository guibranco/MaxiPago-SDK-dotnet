using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{

    [Serializable]
    [XmlRoot(ElementName = "header")]
    public class HeaderResponse
    {

        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        [XmlElement("errorMsg")]
        public string ErrorMsg { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("time")]
        public string Time { get; set; }

    }
}
