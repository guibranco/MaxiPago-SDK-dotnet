// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="CreditInstallment.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class CreditInstallment.
    /// </summary>
    [Serializable]
    [XmlRoot("creditInstallment")]
    public class CreditInstallment
    {
        /// <summary>
        /// Gets or sets the number of installments.
        /// </summary>
        /// <value>The number of installments.</value>
        [XmlElement("numberOfInstallments")]
        public string NumberOfInstallments { get; set; }

        /// <summary>
        /// Gets or sets the charge interest.
        /// </summary>
        /// <value>The charge interest.</value>
        [XmlElement("chargeInterest")]
        public string ChargeInterest { get; set; }
    }
}
