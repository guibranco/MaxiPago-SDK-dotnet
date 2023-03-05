// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="RapiRequest.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    /// <summary>
    /// Class RapiRequest.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "rapi-request")]
    public class RapiRequest {

        /// <summary>
        /// Initializes a new instance of the <see cref="RapiRequest"/> class.
        /// </summary>
        public RapiRequest() {
            Verification = new Verification();
            ReportRequest = new ReportRequest();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RapiRequest"/> class.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        public RapiRequest(string merchantId, string merchantKey) {
            Verification = new Verification(merchantId, merchantKey);
            ReportRequest = new ReportRequest();
        }

        /// <summary>
        /// Gets or sets the verification.
        /// </summary>
        /// <value>The verification.</value>
        [XmlElement("verification")]
        public Verification Verification { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        [XmlElement("command")]
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets the report request.
        /// </summary>
        /// <value>The report request.</value>
        [XmlElement("request")]
        public ReportRequest ReportRequest { get; set; }


    }
}
