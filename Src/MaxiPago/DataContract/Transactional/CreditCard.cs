// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="CreditCard.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class CreditCard.
    /// </summary>
    [Serializable]
    [XmlRoot("creditCard")]
    public class CreditCard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCard"/> class.
        /// </summary>
        public CreditCard()
        {
            _ecommInd = "eci";
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [XmlElement("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the exp month.
        /// </summary>
        /// <value>The exp month.</value>
        [XmlElement("expMonth")]
        public string ExpMonth { get; set; }

        /// <summary>
        /// Gets or sets the exp year.
        /// </summary>
        /// <value>The exp year.</value>
        [XmlElement("expYear")]
        public string ExpYear { get; set; }

        /// <summary>
        /// Gets or sets the CVV ind.
        /// </summary>
        /// <value>The CVV ind.</value>
        [XmlElement("cvvInd")]
        public string CvvInd { get; set; }

        /// <summary>
        /// Gets or sets the CVV number.
        /// </summary>
        /// <value>The CVV number.</value>
        [XmlElement("cvvNumber")]
        public string CvvNumber { get; set; }

        /// <summary>
        /// The ecomm ind
        /// </summary>
        private string _ecommInd;

        /// <summary>
        /// Gets or sets the e comm ind.
        /// </summary>
        /// <value>The e comm ind.</value>
        [XmlElement("eCommInd")]
        public string ECommInd
        {
            get => _ecommInd;
            // ReSharper disable once ValueParameterNotUsed
            set { }
        }
    }
}
