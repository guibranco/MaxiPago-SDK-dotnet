// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="CaptureOrReturn.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    /// <summary>
    /// Class CaptureOrReturn.
    /// </summary>
    [Serializable]
    public class CaptureOrReturn {

        /// <summary>
        /// Initializes a new instance of the <see cref="CaptureOrReturn"/> class.
        /// </summary>
        public CaptureOrReturn() {
            Payment = new Payment();
        }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [XmlElement("orderID")]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>The reference number.</value>
        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>The payment.</value>
        [XmlElement("payment")]
        public Payment Payment { get; set; }

    }
}
