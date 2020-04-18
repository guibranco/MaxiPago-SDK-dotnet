using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    [Serializable]
    [XmlRoot(ElementName = "payment")]
    public class Payment {

        [XmlElement("creditInstallment")]
        public CreditInstallment CreditInstallment { get; set; }

        public bool ShouldSerializeCreditInstallment() { return CreditInstallment != null; }

        [XmlElement("chargeTotal")]
        public decimal ChargeTotal { get; set; }

        [XmlElement("currencyCode")]
        public string CurrencyCode { get; set; }

        public bool ShouldSerializeCurrencyCode() { return CurrencyCode != null; }
        
        [XmlElement("softDescriptor")]
        public string SoftDescriptor { get; set; }
        /// Verifica se o valor da propriedade é nulo, se sim, não serializa esse campo no xml
        public bool ShouldSerializeSoftDescriptor() { return SoftDescriptor != null; }

        [XmlElement("iataFee")]
        public decimal? IataFee { get; set; }
        /// Verifica se o valor da propriedade é nulo, se sim, não serializa esse campo no xml
        public bool ShouldSerializeIataFee() { return IataFee != null; }

    }
}
