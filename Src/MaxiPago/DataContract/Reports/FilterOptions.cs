// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="FilterOptions.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{
    /// <summary>
    /// Class FilterOptions.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "filterOptions")]
    public class FilterOptions
    {
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier.</value>
        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [XmlElement("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        [XmlElement("period")]
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        [XmlElement("pageSize")]
        public string PageSize { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        [XmlElement("startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        [XmlElement("endDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        [XmlElement("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        [XmlElement("endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the order by.
        /// </summary>
        /// <value>The name of the order by.</value>
        [XmlElement("orderByName")]
        public string OrderByName { get; set; }

        /// <summary>
        /// Gets or sets the order by direction.
        /// </summary>
        /// <value>The order by direction.</value>
        [XmlElement("orderByDirection")]
        public string OrderByDirection { get; set; }

        /// <summary>
        /// Gets or sets the start record number.
        /// </summary>
        /// <value>The start record number.</value>
        [XmlElement("startRecordNumber")]
        public string StartRecordNumber { get; set; }

        /// <summary>
        /// Gets or sets the end record number.
        /// </summary>
        /// <value>The end record number.</value>
        [XmlElement("endRecordNumber")]
        public string EndRecordNumber { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        [XmlElement("pageNumber")]
        public string PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        /// <value>The page token.</value>
        [XmlElement("pageToken")]
        public string PageToken { get; set; }
    }
}
