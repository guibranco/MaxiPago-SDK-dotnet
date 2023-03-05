// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="OnlineDebit.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{

    /// <summary>
    /// Class OnlineDebit.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "onlineDebit")]
    public class OnlineDebit
    {

        /// <summary>
        /// Gets or sets the parameters URL.
        /// </summary>
        /// <value>The parameters URL.</value>
        [XmlElement("parametersURL")]
        public string ParametersURL { get; set; }

    }
}
