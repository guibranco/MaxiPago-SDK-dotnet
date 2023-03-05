// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Payment.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    /// <summary>
    /// Class Payment.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "payment")]
    public class Payment {

        /// <summary>
        /// Gets or sets the credit installment.
        /// </summary>
        /// <value>The credit installment.</value>
        [XmlElement("creditInstallment")]
        public CreditInstallment CreditInstallment { get; set; }

        /// <summary>
        /// Shoulds the serialize credit installment.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCreditInstallment() { return CreditInstallment != null; }

        /// <summary>
        /// Gets or sets the charge total.
        /// </summary>
        /// <value>The charge total.</value>
        [XmlElement("chargeTotal")]
        public decimal ChargeTotal { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        [XmlElement("currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Shoulds the serialize currency code.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCurrencyCode() { return CurrencyCode != null; }

        /// <summary>
        /// Gets or sets the soft descriptor.
        /// </summary>
        /// <value>The soft descriptor.</value>
        [XmlElement("softDescriptor")]
        public string SoftDescriptor { get; set; }
        /// <summary>
        /// Shoulds the serialize soft descriptor.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Verifica se o valor da propriedade � nulo, se sim, n�o serializa esse campo no xml
        public bool ShouldSerializeSoftDescriptor() { return SoftDescriptor != null; }

        /// <summary>
        /// Gets or sets the iata fee.
        /// </summary>
        /// <value>The iata fee.</value>
        [XmlElement("iataFee")]
        public decimal? IataFee { get; set; }
        /// <summary>
        /// Shoulds the serialize iata fee.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// Verifica se o valor da propriedade � nulo, se sim, n�o serializa esse campo no xml
        public bool ShouldSerializeIataFee() { return IataFee != null; }

    }
}
