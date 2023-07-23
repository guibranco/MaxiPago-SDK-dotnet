// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="RequestBase.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class RequestBase.
    /// </summary>
    [Serializable]
    public class RequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBase"/> class.
        /// </summary>
        public RequestBase()
        {
            Payment = new Payment();
            TransactionDetail = new TransactionDetail();
        }

        /// <summary>
        /// Gets or sets the processor identifier.
        /// </summary>
        /// <value>The processor identifier.</value>
        [XmlElement("processorID")]
        public string ProcessorId { get; set; }

        /// <summary>
        /// Gets or sets the authentication.
        /// </summary>
        /// <value>The authentication.</value>
        [XmlElement("authentication")]
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>The reference number.</value>
        [XmlElement("referenceNum")]
        public string ReferenceNum { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>The ip address.</value>
        [XmlElement("ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the fraud check.
        /// </summary>
        /// <value>The fraud check.</value>
        [XmlElement("fraudCheck")]
        public string FraudCheck { get; set; }

        // Verifica se o valor da propriedade é nulo, se sim, não serialize esse campo no xml
        /// <summary>
        /// Shoulds the serialize fraud check.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeFraudCheck()
        {
            return FraudCheck != null;
        }

        //[XmlElement("invoiceNumber")]
        //public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the billing.
        /// </summary>
        /// <value>The billing.</value>
        [XmlElement("billing")]
        public Billing Billing { get; set; }

        /// <summary>
        /// Shoulds the serialize billing.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBilling()
        {
            return Billing != null;
        }

        /// <summary>
        /// Gets or sets the shipping.
        /// </summary>
        /// <value>The shipping.</value>
        [XmlElement("shipping")]
        public Shipping Shipping { get; set; }

        /// <summary>
        /// Shoulds the serialize shipping.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeShipping()
        {
            return Shipping != null;
        }

        /// <summary>
        /// Gets or sets the transaction detail.
        /// </summary>
        /// <value>The transaction detail.</value>
        [XmlElement("transactionDetail")]
        public TransactionDetail TransactionDetail { get; set; }

        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>The payment.</value>
        [XmlElement("payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// Gets or sets the recurring.
        /// </summary>
        /// <value>The recurring.</value>
        [XmlElement("recurring")]
        public Recurring Recurring { get; set; }

        /// <summary>
        /// Gets or sets the save on file.
        /// </summary>
        /// <value>The save on file.</value>
        [XmlElement("saveOnFile")]
        public SaveOnFile SaveOnFile { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier ext.
        /// </summary>
        /// <value>The customer identifier ext.</value>
        [XmlElement("customerIdExt")]
        public string CustomerIdExt { get; set; }

        /// <summary>
        /// Shoulds the serialize customer identifier ext.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCustomerIdExt()
        {
            return !string.IsNullOrEmpty(CustomerIdExt);
        }
    }
}
