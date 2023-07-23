// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="TransactionRequest.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class TransactionRequest.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "transaction-request")]
    public class TransactionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRequest"/> class.
        /// </summary>
        public TransactionRequest()
        {
            Verification = new Verification();
            Order = new Order();
            Version = "3.1.1.15";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRequest"/> class.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        public TransactionRequest(string merchantId, string merchantKey)
        {
            Verification = new Verification(merchantId, merchantKey);
            Order = new Order();
            Version = "3.1.1.15";
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlElement("version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the verification.
        /// </summary>
        /// <value>The verification.</value>
        [XmlElement("verification")]
        public Verification Verification { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [XmlElement("order")]
        public Order Order { get; set; }
    }
}
