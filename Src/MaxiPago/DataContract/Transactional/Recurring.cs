// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Recurring.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class Recurring.
    /// </summary>
    public class Recurring
    {
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [XmlElement("startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        [XmlElement("period")]
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets the frequency.
        /// </summary>
        /// <value>The frequency.</value>
        [XmlElement("frequency")]
        public string Frequency { get; set; }

        /// <summary>
        /// Gets or sets the installments.
        /// </summary>
        /// <value>The installments.</value>
        [XmlElement("installments")]
        public string Installments { get; set; }

        /// <summary>
        /// Gets or sets the failure threshold.
        /// </summary>
        /// <value>The failure threshold.</value>
        [XmlElement("failureThreshold")]
        public string FailureThreshold { get; set; }
    }
}
