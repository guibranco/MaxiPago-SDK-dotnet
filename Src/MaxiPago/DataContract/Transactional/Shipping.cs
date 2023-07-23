// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Shipping.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class Shipping.
    /// Implements the <see cref="MaxiPago.DataContract.Transactional.Address" />
    /// </summary>
    /// <seealso cref="MaxiPago.DataContract.Transactional.Address" />
    [Serializable]
    [XmlRoot(ElementName = "shipping")]
    public class Shipping : Address { }
}
