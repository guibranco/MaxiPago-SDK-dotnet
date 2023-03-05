// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ClientData.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    /// <summary>
    /// Class ClientData.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "clientData")]
    public class ClientData
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientData"/> class.
        /// </summary>
        public ClientData()
        {
            _comments = ".NetPlugin v1.1";
        }

        /// <summary>
        /// Gets or sets the custom field1.
        /// </summary>
        /// <value>The custom field1.</value>
        [XmlElement("customField1")]
        public string CustomField1 { get; set; }

        /// <summary>
        /// Gets or sets the custom field2.
        /// </summary>
        /// <value>The custom field2.</value>
        [XmlElement("customField2")]
        public string CustomField2 { get; set; }

        /// <summary>
        /// Gets or sets the custom field3.
        /// </summary>
        /// <value>The custom field3.</value>
        [XmlElement("customField3")]
        public string CustomField3 { get; set; }

        /// <summary>
        /// Gets or sets the custom field4.
        /// </summary>
        /// <value>The custom field4.</value>
        [XmlElement("customField4")]
        public string CustomField4 { get; set; }

        /// <summary>
        /// Gets or sets the custom field5.
        /// </summary>
        /// <value>The custom field5.</value>
        [XmlElement("customField5")]
        public string CustomField5 { get; set; }

        /// <summary>
        /// The comments
        /// </summary>
        private string _comments;

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        [XmlElement("comments")]
        public string Comments
        {
            get => _comments;
            // ReSharper disable once ValueParameterNotUsed
            set { }
        }

    }
}
