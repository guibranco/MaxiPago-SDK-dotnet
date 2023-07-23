// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ApiResponse.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional
{
    /// <summary>
    /// Class ApiResponse.
    /// Implements the <see cref="MaxiPago.DataContract.ResponseBase" />
    /// </summary>
    /// <seealso cref="MaxiPago.DataContract.ResponseBase" />
    [Serializable]
    [XmlRoot(ElementName = "api-response")]
    public class ApiResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>The command.</value>
        [XmlElement("command")]
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        [XmlElement("time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        [XmlElement("result")]
        public ApiResult Result { get; set; }
    }
}
