// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="RapiResponse.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{
    /// <summary>
    /// Class RapiResponse.
    /// Implements the <see cref="MaxiPago.DataContract.ResponseBase" />
    /// </summary>
    /// <seealso cref="MaxiPago.DataContract.ResponseBase" />
    [Serializable]
    [XmlRoot(ElementName = "rapi-response")]
    public class RapiResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        [XmlElement("header")]
        public HeaderResponse Header { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [XmlElement("result")]
        public ReportResult Result { get; set; }
    }
}
