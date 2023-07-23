// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="CommandRequest.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.NonTransactional
{
    /// <summary>
    /// Class CommandRequest.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "request")]
    public class CommandRequest
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Shoulds the serialize customer identifier.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return !string.IsNullOrEmpty(CustomerId);
        }

        /// <summary>
        /// Gets or sets the customer identifier ext.
        /// </summary>
        /// <value>The customer identifier ext.</value>
        [XmlElement("customerIdExt")]
        public string CustomerIdExt { get; set; }

        /// <summary>
        /// Shoulds the serialize customer identifier ext.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCustomerIdExt()
        {
            return !string.IsNullOrEmpty(CustomerIdExt);
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Shoulds the first name of the serialize.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeFirstName()
        {
            return !string.IsNullOrEmpty(FirstName);
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [XmlElement("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Shoulds the last name of the serialize.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeLastName()
        {
            return !string.IsNullOrEmpty(LastName);
        }

        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        [XmlElement("address1")]
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
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        [XmlElement("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Shoulds the serialize zip.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeZip()
        {
            return !string.IsNullOrEmpty(Zip);
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

        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        /// <value>The dob.</value>
        [XmlElement("dob")]
        public string Dob { get; set; }

        /// <summary>
        /// Shoulds the serialize dob.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeDob()
        {
            return !string.IsNullOrEmpty(Dob);
        }

        /// <summary>
        /// Gets or sets the SSN.
        /// </summary>
        /// <value>The SSN.</value>
        [XmlElement("ssn")]
        public string Ssn { get; set; }

        /// <summary>
        /// Shoulds the serialize SSN.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeSsn()
        {
            return !string.IsNullOrEmpty(CustomerIdExt);
        }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        [XmlElement("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// Shoulds the serialize sex.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeSex()
        {
            return !string.IsNullOrEmpty(CustomerIdExt);
        }

        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        /// <value>The credit card number.</value>
        [XmlElement("creditCardNumber")]
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Shoulds the serialize credit card number.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeCreditCardNumber()
        {
            return !string.IsNullOrEmpty(CreditCardNumber);
        }

        /// <summary>
        /// Gets or sets the expiration month.
        /// </summary>
        /// <value>The expiration month.</value>
        [XmlElement("expirationMonth")]
        public string ExpirationMonth { get; set; }

        /// <summary>
        /// Shoulds the serialize expiration month.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeExpirationMonth()
        {
            return !string.IsNullOrEmpty(ExpirationMonth);
        }

        /// <summary>
        /// Gets or sets the expiration year.
        /// </summary>
        /// <value>The expiration year.</value>
        [XmlElement("expirationYear")]
        public string ExpirationYear { get; set; }

        /// <summary>
        /// Shoulds the serialize expiration year.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeExpirationYear()
        {
            return !string.IsNullOrEmpty(ExpirationYear);
        }

        /// <summary>
        /// Gets or sets the name of the billing.
        /// </summary>
        /// <value>The name of the billing.</value>
        [XmlElement("billingName")]
        public string BillingName { get; set; }

        /// <summary>
        /// Shoulds the name of the serialize billing.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingName()
        {
            return !string.IsNullOrEmpty(BillingName);
        }

        /// <summary>
        /// Gets or sets the billing address1.
        /// </summary>
        /// <value>The billing address1.</value>
        [XmlElement("billingAddress1")]
        public string BillingAddress1 { get; set; }

        /// <summary>
        /// Shoulds the serialize billing address1.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingAddress1()
        {
            return !string.IsNullOrEmpty(BillingAddress1);
        }

        /// <summary>
        /// Gets or sets the billing address2.
        /// </summary>
        /// <value>The billing address2.</value>
        [XmlElement("billingAddress2")]
        public string BillingAddress2 { get; set; }

        /// <summary>
        /// Shoulds the serialize billing address2.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingAddress2()
        {
            return !string.IsNullOrEmpty(BillingAddress2);
        }

        /// <summary>
        /// Gets or sets the billing city.
        /// </summary>
        /// <value>The billing city.</value>
        [XmlElement("billingCity")]
        public string BillingCity { get; set; }

        /// <summary>
        /// Shoulds the serialize billing city.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingCity()
        {
            return !string.IsNullOrEmpty(BillingCity);
        }

        /// <summary>
        /// Gets or sets the state of the billing.
        /// </summary>
        /// <value>The state of the billing.</value>
        [XmlElement("billingState")]
        public string BillingState { get; set; }

        /// <summary>
        /// Shoulds the state of the serialize billing.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingState()
        {
            return !string.IsNullOrEmpty(BillingState);
        }

        /// <summary>
        /// Gets or sets the billing zip.
        /// </summary>
        /// <value>The billing zip.</value>
        [XmlElement("billingZip")]
        public string BillingZip { get; set; }

        /// <summary>
        /// Shoulds the serialize billing zip.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingZip()
        {
            return !string.IsNullOrEmpty(BillingZip);
        }

        /// <summary>
        /// Gets or sets the billing country.
        /// </summary>
        /// <value>The billing country.</value>
        [XmlElement("billingCountry")]
        public string BillingCountry { get; set; }

        /// <summary>
        /// Shoulds the serialize billing country.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingCountry()
        {
            return !string.IsNullOrEmpty(BillingCountry);
        }

        /// <summary>
        /// Gets or sets the billing phone.
        /// </summary>
        /// <value>The billing phone.</value>
        [XmlElement("billingPhone")]
        public string BillingPhone { get; set; }

        /// <summary>
        /// Shoulds the serialize billing phone.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingPhone()
        {
            return !string.IsNullOrEmpty(BillingPhone);
        }

        /// <summary>
        /// Gets or sets the billing email.
        /// </summary>
        /// <value>The billing email.</value>
        [XmlElement("billingEmail")]
        public string BillingEmail { get; set; }

        /// <summary>
        /// Shoulds the serialize billing email.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeBillingEmail()
        {
            return !string.IsNullOrEmpty(BillingEmail);
        }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [XmlElement("orderID")]
        public string OrderID { get; set; }

        /// <summary>
        /// Shoulds the serialize order identifier.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOrderID()
        {
            return !string.IsNullOrEmpty(OrderID);
        }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [XmlElement("token")]
        public string Token { get; set; }

        /// <summary>
        /// Shoulds the serialize token.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeToken()
        {
            return !string.IsNullOrEmpty(Token);
        }

        /// <summary>
        /// Gets or sets the on file end date.
        /// </summary>
        /// <value>The on file end date.</value>
        [XmlElement("onFileEndDate")]
        public string OnFileEndDate { get; set; }

        /// <summary>
        /// Shoulds the serialize on file end date.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOnFileEndDate()
        {
            return !string.IsNullOrEmpty(OnFileEndDate);
        }

        /// <summary>
        /// Gets or sets the on file permission.
        /// </summary>
        /// <value>The on file permission.</value>
        [XmlElement("onFilePermissions")]
        public string OnFilePermission { get; set; }

        /// <summary>
        /// Shoulds the serialize on file permission.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOnFilePermission()
        {
            return !string.IsNullOrEmpty(OnFilePermission);
        }

        /// <summary>
        /// Gets or sets the on file comment.
        /// </summary>
        /// <value>The on file comment.</value>
        [XmlElement("onFileComment")]
        public string OnFileComment { get; set; }

        /// <summary>
        /// Shoulds the serialize on file comment.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOnFileComment()
        {
            return !string.IsNullOrEmpty(OnFileComment);
        }

        /// <summary>
        /// Gets or sets the on file maximum charge amount.
        /// </summary>
        /// <value>The on file maximum charge amount.</value>
        [XmlElement("onFileMaxChargeAmount")]
        public string OnFileMaxChargeAmount { get; set; }

        /// <summary>
        /// Shoulds the serialize on file maximum charge amount.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeOnFileMaxChargeAmount()
        {
            return !string.IsNullOrEmpty(OnFileMaxChargeAmount);
        }
    }
}
