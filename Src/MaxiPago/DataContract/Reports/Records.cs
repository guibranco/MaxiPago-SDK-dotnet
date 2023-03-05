// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Records.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports {

    /// <summary>
    /// Class Records.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "records")]
    public class Records {

        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>The record.</value>
        [XmlElement("record")]
        public List<Record> Record { get; set; }

    }
}
