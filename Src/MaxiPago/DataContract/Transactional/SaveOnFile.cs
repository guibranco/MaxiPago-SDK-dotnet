// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="SaveOnFile.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional {

    /// <summary>
    /// Class SaveOnFile.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "saveOnFile")]
    public class SaveOnFile {

        /// <summary>
        /// ID único do cadastro, retornado quando o cliente foi adicionado à base (customerId).
        /// </summary>
        /// <value>The customer token.</value>
        [XmlElement(ElementName="customerToken")]
        public string CustomerToken { get; set; }

        /// <summary>
        /// Data limite para manter o cartão na base, Formato MM/DD/AAAA.
        /// </summary>
        /// <value>The on file end date.</value>
        [XmlElement(ElementName = "onFileEndDate")]
        public string OnFileEndDate { get; set; }

        /// <summary>
        /// Duração limite do uso do cartão salvo, ongoing = indefinidamente, use_once = apenas uma vez após a 1a. cobrança
        /// </summary>
        /// <value>The on file permission.</value>
        [XmlElement(ElementName = "onFilePermissions")]
        public string OnFilePermission { get; set; }

        /// <summary>
        /// Comentários adicionais sobre este cartão
        /// </summary>
        /// <value>The on file comment.</value>
        [XmlElement(ElementName = "onFileComment")]
        public string OnFileComment { get; set; }

        /// <summary>
        /// Valor máximo que é permitido cobrar deste cartão
        /// </summary>
        /// <value>The on file maximum charge amount.</value>
        [XmlElement(ElementName = "onFileMaxChargeAmount")]
        public string OnFileMaxChargeAmount { get; set; }

    }
}
