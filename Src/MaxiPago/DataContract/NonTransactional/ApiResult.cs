using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional {
    
    public class ApiResult {

        [XmlElement(ElementName="customerId")]
        public String CustomerId { get; set; }

        [XmlElement(ElementName = "token")]
        public String Token { get; set; }

    }
}
