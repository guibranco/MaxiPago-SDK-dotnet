﻿// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ApiResult.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional
{
    /// <summary>
    /// Class ApiResult.
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [XmlElement(ElementName = "customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [XmlElement(ElementName = "token")]
        public string Token { get; set; }
    }
}
