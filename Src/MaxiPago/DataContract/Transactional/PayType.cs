// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="PayType.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    /// <summary>
    /// Class PayType.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "payType")]
    public class PayType
    {

        /// <summary>
        /// Gets or sets the credit card.
        /// </summary>
        /// <value>The credit card.</value>
        [XmlElement("creditCard")]
        public CreditCard CreditCard { get; set; }
        /// <summary>
        /// Shoulds the serialize credit card.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCreditCard() { return CreditCard != null; }

        /// <summary>
        /// Gets or sets the on file.
        /// </summary>
        /// <value>The on file.</value>
        [XmlElement("onFile")]
        public OnFile OnFile { get; set; }
        /// <summary>
        /// Shoulds the serialize on file.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOnFile() { return OnFile != null; }

        /// <summary>
        /// Gets or sets the boleto.
        /// </summary>
        /// <value>The boleto.</value>
        [XmlElement("boleto")]
        public Boleto Boleto { get; set; }
        /// <summary>
        /// Shoulds the serialize boleto.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBoleto() { return Boleto != null; }

        /// <summary>
        /// Gets or sets the online debit.
        /// </summary>
        /// <value>The online debit.</value>
        [XmlElement("onlineDebit")]
        public OnlineDebit OnlineDebit { get; set; }
        /// <summary>
        /// Shoulds the serialize online debit.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOnlineDebit() { return OnlineDebit != null; }

    }
}
