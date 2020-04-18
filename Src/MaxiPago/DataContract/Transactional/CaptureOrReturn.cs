using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {
    
    [Serializable]
    public class CaptureOrReturn {

        public CaptureOrReturn() {
            Payment = new Payment();
        }

        [XmlElement("orderID")]
        public string OrderId { get; set; }

        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        [XmlElement("payment")]
        public Payment Payment { get; set; }

    }
}
