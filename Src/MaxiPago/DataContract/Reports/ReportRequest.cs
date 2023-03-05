// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ReportRequest.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{

    /// <summary>
    /// Class ReportRequest.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "request")]
    public class ReportRequest
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportRequest"/> class.
        /// </summary>
        public ReportRequest()
        {
            FilterOptions = new FilterOptions();
        }

        /// <summary>
        /// Gets or sets the filter options.
        /// </summary>
        /// <value>The filter options.</value>
        [XmlElement("filterOptions")]
        public FilterOptions FilterOptions { get; set; }

        /// <summary>
        /// Gets or sets the request token.
        /// </summary>
        /// <value>The request token.</value>
        [XmlElement("requestToken")]
        public string RequestToken { get; set; }


    }
}
