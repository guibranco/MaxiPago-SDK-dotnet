// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Verification.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract 
{
    /// <summary>
    /// Class Verification.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "verification")]
    public class Verification
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Verification"/> class.
        /// </summary>
        public Verification() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Verification"/> class.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        public Verification(string merchantId, string merchantKey) {
            MerchantId = merchantId;
            MerchantKey = merchantKey;
        }

        /// <summary>
        /// Gets or sets the merchant identifier.
        /// </summary>
        /// <value>The merchant identifier.</value>
        [XmlElement("merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// Gets or sets the merchant key.
        /// </summary>
        /// <value>The merchant key.</value>
        [XmlElement("merchantKey")]
        public string MerchantKey { get; set; }

    }
}
