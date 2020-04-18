using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional {

    [Serializable]
    [XmlRoot(ElementName = "api-request")]
    public class ApiRequest {

        public ApiRequest() {
            Verification = new Verification();
            
        }

        public ApiRequest(string merchantId, string merchantKey) {
            Verification = new Verification(merchantId, merchantKey);
            
        }

        [XmlElement("verification")]
        public Verification Verification { get; set; }

        [XmlElement("command")]
        public string Command { get; set; }

        [XmlElement("request")]
        public CommandRequest CommandRequest { get; set; }



    }
}
