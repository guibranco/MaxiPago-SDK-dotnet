using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{

    [Serializable]
    [XmlRoot(ElementName = "result")]
    public class ReportResult
    {

        [XmlElement("requestToken")]
        public string RequestToken { get; set; }

        [XmlElement("statusMessage")]
        public string StatusMessage { get; set; }

        [XmlElement("resultSetInfo")]
        public ResultSetInfo ResultSetInfo { get; set; }

        [XmlElement("records")]
        public Records Records { get; set; }

    }
}
