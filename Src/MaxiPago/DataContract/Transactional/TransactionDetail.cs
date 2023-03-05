// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="TransactionDetail.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    /// <summary>
    /// Class TransactionDetail.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "transactionDetail")]
    public class TransactionDetail
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetail"/> class.
        /// </summary>
        public TransactionDetail()
        {
            PayType = new PayType();
        }

        /// <summary>
        /// Gets or sets the type of the pay.
        /// </summary>
        /// <value>The type of the pay.</value>
        [XmlElement("payType")]
        public PayType PayType { get; set; }

    }
}
