// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Void.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class Void.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "void")]
    public class Void
    {
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier.</value>
        [XmlElement("transactionID")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>The ip address.</value>
        [XmlElement("ipAddress")]
        public string IpAddress { get; set; }
    }
}
