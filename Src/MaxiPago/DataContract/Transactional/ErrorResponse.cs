// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ErrorResponse.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class ErrorResponse.
    /// Implements the <see cref="MaxiPago.DataContract.ResponseBase" />
    /// </summary>
    /// <seealso cref="MaxiPago.DataContract.ResponseBase" />
    [Serializable]
    [XmlRoot(ElementName = "api-error")]
    public class ErrorResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [XmlElement("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error MSG.
        /// </summary>
        /// <value>The error MSG.</value>
        [XmlElement("errorMsg")]
        public string ErrorMsg { get; set; }
    }
}
