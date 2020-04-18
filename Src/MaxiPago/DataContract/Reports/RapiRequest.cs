using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    [Serializable]
    [XmlRoot(ElementName = "rapi-request")]
    public class RapiRequest {

        public RapiRequest() {
            Verification = new Verification();
            ReportRequest = new ReportRequest();
        }

        public RapiRequest(string merchantId, string merchantKey) {
            Verification = new Verification(merchantId, merchantKey);
            ReportRequest = new ReportRequest();
        }

        [XmlElement("verification")]
        public Verification Verification { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("request")]
        public ReportRequest ReportRequest { get; set; }


    }
}
