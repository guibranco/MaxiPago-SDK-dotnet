// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Order.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class Order.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "order")]
    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order() {
            ClientData = new ClientData();
        }

        /// <summary>
        /// Gets or sets the sale.
        /// </summary>
        /// <value>The sale.</value>
        [XmlElement("sale")]
        public RequestBase Sale { get; set; }

        /// <summary>
        /// Gets or sets the authentication.
        /// </summary>
        /// <value>The authentication.</value>
        [XmlElement("auth")]
        public RequestBase Auth { get; set; }

        /// <summary>
        /// Gets or sets the capture.
        /// </summary>
        /// <value>The capture.</value>
        [XmlElement("capture")]
        public CaptureOrReturn Capture { get; set; }

        /// <summary>
        /// Gets or sets the return.
        /// </summary>
        /// <value>The return.</value>
        [XmlElement("return")]
        public CaptureOrReturn Return { get; set; }

        /// <summary>
        /// Gets or sets the void.
        /// </summary>
        /// <value>The void.</value>
        [XmlElement("void")]
        public Void Void { get; set; }

        /// <summary>
        /// Gets or sets the recurring payment.
        /// </summary>
        /// <value>The recurring payment.</value>
        [XmlElement("recurringPayment")]
        public RequestBase RecurringPayment { get; set; }

        /// <summary>
        /// Gets or sets the client data.
        /// </summary>
        /// <value>The client data.</value>
        [XmlElement("clientData")]
        public ClientData ClientData { get; set; }

    }
}
