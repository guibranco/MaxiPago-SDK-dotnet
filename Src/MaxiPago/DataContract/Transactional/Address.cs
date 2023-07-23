// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Address.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Transactional
{
    /// <summary>
    /// Class Address.
    /// </summary>
    [Serializable]
    public class Address
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Shoulds the name of the serialize.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeName()
        {
            return !string.IsNullOrEmpty(Name);
        }

        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        [XmlElement("address")]
        public string Address1 { get; set; }

        /// <summary>
        /// Shoulds the serialize address1.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeAddress1()
        {
            return !string.IsNullOrEmpty(Address1);
        }

        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>The address2.</value>
        [XmlElement("address2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Shoulds the serialize address2.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeAddress2()
        {
            return !string.IsNullOrEmpty(Address2);
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// Shoulds the serialize city.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCity()
        {
            return !string.IsNullOrEmpty(City);
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// Shoulds the state of the serialize.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeState()
        {
            return !string.IsNullOrEmpty(State);
        }

        /// <summary>
        /// Gets or sets the postalcode.
        /// </summary>
        /// <value>The postalcode.</value>
        [XmlElement("postalcode")]
        public string Postalcode { get; set; }

        /// <summary>
        /// Shoulds the serialize postalcode.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializePostalcode()
        {
            return !string.IsNullOrEmpty(Postalcode);
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// Shoulds the serialize country.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCountry()
        {
            return !string.IsNullOrEmpty(Country);
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Shoulds the serialize phone.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializePhone()
        {
            return !string.IsNullOrEmpty(Phone);
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Shoulds the serialize email.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeEmail()
        {
            return !string.IsNullOrEmpty(Email);
        }
    }
}
