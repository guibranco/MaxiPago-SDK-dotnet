using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{

    [Serializable]
    [XmlRoot(ElementName = "request")]
    public class ReportRequest
    {

        public ReportRequest()
        {
            FilterOptions = new FilterOptions();
        }

        [XmlElement("filterOptions")]
        public FilterOptions FilterOptions { get; set; }

        [XmlElement("requestToken")]
        public string RequestToken { get; set; }


    }
}
