using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional
{

    public class ApiResult
    {

        [XmlElement(ElementName = "customerId")]
        public string CustomerId { get; set; }

        [XmlElement(ElementName = "token")]
        public string Token { get; set; }

    }
}
