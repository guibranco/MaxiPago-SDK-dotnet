using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot("creditCard")]
    public class CreditCard
    {

        public CreditCard()
        {
            _ecommInd = "eci";
        }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("expMonth")]
        public string ExpMonth { get; set; }

        [XmlElement("expYear")]
        public string ExpYear { get; set; }

        [XmlElement("cvvInd")]
        public string CvvInd { get; set; }

        [XmlElement("cvvNumber")]
        public string CvvNumber { get; set; }

        private string _ecommInd;

        [XmlElement("eCommInd")]
        public string ECommInd
        {
            get => _ecommInd;
            // ReSharper disable once ValueParameterNotUsed
            set { }
        }

    }
}
