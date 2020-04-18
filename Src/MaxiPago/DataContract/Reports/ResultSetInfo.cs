using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{

    [Serializable]
    [XmlRoot(ElementName = "resultSetInfo")]
    public class ResultSetInfo
    {

        [XmlElement("totalNumberOfRecords")]
        public string TotalNumberOfRecords { get; set; }

        [XmlElement("pageToken")]
        public string PageToken { get; set; }

        [XmlElement("numberOfPages")]
        public string NumberOfPages { get; set; }

        [XmlElement("pageNumber")]
        public string PageNumber { get; set; }

        [XmlElement("processedTime")]
        public string ProcessedTime { get; set; }

    }
}
