// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ApiRequest.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional {

    /// <summary>
    /// Class ApiRequest.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "api-request")]
    public class ApiRequest {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        public ApiRequest() {
            Verification = new Verification();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        public ApiRequest(string merchantId, string merchantKey) {
            Verification = new Verification(merchantId, merchantKey);
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
        /// Gets or sets the command request.
        /// </summary>
        /// <value>The command request.</value>
        [XmlElement("request")]
        public CommandRequest CommandRequest { get; set; }
    }
}
