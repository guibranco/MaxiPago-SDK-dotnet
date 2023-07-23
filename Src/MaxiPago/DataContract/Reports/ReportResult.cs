// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ReportResult.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{
    /// <summary>
    /// Class ReportResult.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "result")]
    public class ReportResult
    {
        /// <summary>
        /// Gets or sets the request token.
        /// </summary>
        /// <value>The request token.</value>
        [XmlElement("requestToken")]
        public string RequestToken { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        [XmlElement("statusMessage")]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the result set information.
        /// </summary>
        /// <value>The result set information.</value>
        [XmlElement("resultSetInfo")]
        public ResultSetInfo ResultSetInfo { get; set; }

        /// <summary>
        /// Gets or sets the records.
        /// </summary>
        /// <value>The records.</value>
        [XmlElement("records")]
        public Records Records { get; set; }
    }
}
