// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="TransactionResponse.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class TransactionResponse.
    /// Implements the <see cref="MaxiPago.DataContract.ResponseBase" />
    /// </summary>
    /// <seealso cref="MaxiPago.DataContract.ResponseBase" />
    [Serializable]
    [XmlRoot(ElementName = "transaction-response")]
    public class TransactionResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the authorization code.
        /// </summary>
        /// <value>The authorization code.</value>
        [XmlElement("authCode")]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [XmlElement("orderID")]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>The reference number.</value>
        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier.</value>
        [XmlElement("transactionID")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction timestamp.
        /// </summary>
        /// <value>The transaction timestamp.</value>
        [XmlElement("transactionTimestamp")]
        public string TransactionTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>The response code.</value>
        [XmlElement("responseCode")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>The response message.</value>
        [XmlElement("responseMessage")]
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Gets or sets the avs response code.
        /// </summary>
        /// <value>The avs response code.</value>
        [XmlElement("avsResponseCode")]
        public string AvsResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the CVV response code.
        /// </summary>
        /// <value>The CVV response code.</value>
        [XmlElement("cvvResponseCode")]
        public string CvvResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the processor return code.
        /// </summary>
        /// <value>The processor return code.</value>
        [XmlElement("processorCode")]
        public string ProcessorReturnCode { get; set; }

        /// <summary>
        /// Gets or sets the processor message.
        /// </summary>
        /// <value>The processor message.</value>
        [XmlElement("processorMessage")]
        public string ProcessorMessage { get; set; }

        /// <summary>
        /// Gets or sets the processor reference number.
        /// </summary>
        /// <value>The processor reference number.</value>
        [XmlElement("processorReferenceNumber")]
        public string ProcessorReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the processor transaction identifier.
        /// </summary>
        /// <value>The processor transaction identifier.</value>
        [XmlElement("processorTransactionID")]
        public string ProcessorTransactionID { get; set; }

        /// <summary>
        /// Gets or sets the fraud score.
        /// </summary>
        /// <value>The fraud score.</value>
        [XmlElement("fraudScore")]
        public string FraudScore { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Url de retorno do boleto, somente usado para transações de boleto.
        /// </summary>
        /// <value>The boleto URL.</value>
        [XmlElement("boletoUrl")]
        public string BoletoUrl { get; set; }

        /// <summary>
        /// Gets or sets the authentication URL.
        /// </summary>
        /// <value>The authentication URL.</value>
        [XmlElement("authenticationURL")]
        public string AuthenticationUrl { get; set; }

        /// <summary>
        /// Gets or sets the save on file.
        /// </summary>
        /// <value>The save on file.</value>
        [XmlElement("save-on-file")]
        public SaveOnFileResponse SaveOnFile { get; set; }

        /// <summary>
        /// Esse campo tem que ser oculto para os lojistas, pois é somente para o EUA, porém precisamos tratar para não dar erro.
        /// </summary>
        /// <value>The online debit URL.</value>
        //[XmlElement("partiallyApprovedAmount")]
        //public string PartiallyApprovedAmount { get; set; }
        [XmlElement("onlineDebitUrl")]
        public string OnlineDebitUrl { get; set; }
    }
}
