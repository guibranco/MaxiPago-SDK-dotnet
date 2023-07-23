// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ResultSetInfo.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{
    /// <summary>
    /// Class ResultSetInfo.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "resultSetInfo")]
    public class ResultSetInfo
    {
        /// <summary>
        /// Gets or sets the total number of records.
        /// </summary>
        /// <value>The total number of records.</value>
        [XmlElement("totalNumberOfRecords")]
        public string TotalNumberOfRecords { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        /// <value>The page token.</value>
        [XmlElement("pageToken")]
        public string PageToken { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        [XmlElement("numberOfPages")]
        public string NumberOfPages { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        [XmlElement("pageNumber")]
        public string PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the processed time.
        /// </summary>
        /// <value>The processed time.</value>
        [XmlElement("processedTime")]
        public string ProcessedTime { get; set; }
    }
}
