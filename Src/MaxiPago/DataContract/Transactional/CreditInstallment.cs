using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    [Serializable]
    [XmlRoot("creditInstallment")]
    public class CreditInstallment
    {

        [XmlElement("numberOfInstallments")]
        public string NumberOfInstallments { get; set; }

        [XmlElement("chargeInterest")]
        public string ChargeInterest { get; set; }

    }


}
