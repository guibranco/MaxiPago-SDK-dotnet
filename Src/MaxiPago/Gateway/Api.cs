// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/02/2023
// ***********************************************************************
// <copyright file="Api.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MaxiPago.DataContract;
using MaxiPago.DataContract.NonTransactional;

namespace MaxiPago.Gateway
{

    /// <summary>
    /// Class Api.
    /// Implements the <see cref="ServiceBase" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    public class Api : ServiceBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Api"/> class.
        /// </summary>
        public Api()
        {
            Environment = "TEST";
        }

        /// <summary>
        /// The request
        /// </summary>
        private ApiRequest _request;

        /// <summary>
        /// Adds the consumer.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="customerIdExt">The customer identifier ext.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address1">The address1.</param>
        /// <param name="address2">The address2.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="email">The email.</param>
        /// <param name="dob">The dob.</param>
        /// <param name="ssn">The SSN.</param>
        /// <param name="sex">The sex.</param>
        /// <returns>ApiResponse.</returns>
        public ApiResponse AddConsumer(string merchantId, string merchantKey, string customerIdExt, string firstName, string lastName
                                        , string address1, string address2, string city, string state, string zip, string phone, string email
                                        , string dob, string ssn, string sex)
        {


            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "add-consumer",
                CommandRequest = new CommandRequest
                {
                    CustomerIdExt = customerIdExt,
                    FirstName = firstName,
                    LastName = lastName,
                    Address1 = address1,
                    Address2 = address2,
                    City = city,
                    State = state,
                    Zip = zip,
                    Phone = phone,
                    Email = email,
                    Dob = dob,
                    Ssn = ssn,
                    Sex = sex
                }
            };

            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }

        /// <summary>
        /// Deletes the consumer.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>ApiResponse.</returns>
        public ApiResponse DeleteConsumer(string merchantId, string merchantKey, string customerId)
        {

            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "delete-consumer",
                CommandRequest = new CommandRequest { CustomerId = customerId }
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;

        }

        /// <summary>
        /// Updates the consumer.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="customerIdExt">The customer identifier ext.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address1">The address1.</param>
        /// <param name="address2">The address2.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="email">The email.</param>
        /// <param name="dob">The dob.</param>
        /// <param name="ssn">The SSN.</param>
        /// <param name="sex">The sex.</param>
        /// <returns>ApiResponse.</returns>
        public ApiResponse UpdateConsumer(string merchantId, string merchantKey, string customerId, string customerIdExt, string firstName
                                        , string lastName, string address1, string address2, string city, string state, string zip, string phone
                                        , string email, string dob, string ssn, string sex)
        {

            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "update-consumer",
                CommandRequest = new CommandRequest
                {
                    CustomerId = customerId,
                    CustomerIdExt = customerIdExt,
                    FirstName = firstName,
                    LastName = lastName,
                    Address1 = address1,
                    Address2 = address2,
                    City = city,
                    State = state,
                    Zip = zip,
                    Phone = phone,
                    Email = email,
                    Dob = dob,
                    Ssn = ssn,
                    Sex = sex
                }
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;

        }

        /// <summary>
        /// Adds the card on file.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <param name="expirationMonth">The expiration month.</param>
        /// <param name="expirationYear">The expiration year.</param>
        /// <param name="billingName">Name of the billing.</param>
        /// <param name="billingAddress1">The billing address1.</param>
        /// <param name="billingAddress2">The billing address2.</param>
        /// <param name="billingCity">The billing city.</param>
        /// <param name="billingState">State of the billing.</param>
        /// <param name="billingZip">The billing zip.</param>
        /// <param name="billingCountry">The billing country.</param>
        /// <param name="billingPhone">The billing phone.</param>
        /// <param name="billingEmail">The billing email.</param>
        /// <param name="onFileEndDate">The on file end date.</param>
        /// <param name="onFilePermission">The on file permission.</param>
        /// <param name="onFileComment">The on file comment.</param>
        /// <param name="onFileMaxChargeAmount">The on file maximum charge amount.</param>
        /// <returns>ApiResponse.</returns>
        public ApiResponse AddCardOnFile(string merchantId, string merchantKey, string customerId, string creditCardNumber, string expirationMonth
                                        , string expirationYear, string billingName, string billingAddress1, string billingAddress2, string billingCity
                                        , string billingState, string billingZip, string billingCountry, string billingPhone, string billingEmail
                                        , string onFileEndDate, string onFilePermission, string onFileComment, string onFileMaxChargeAmount)
        {

            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "add-card-onfile",
                CommandRequest = new CommandRequest
                {
                    CustomerId = customerId,
                    CreditCardNumber = creditCardNumber,
                    ExpirationMonth = expirationMonth,
                    ExpirationYear = expirationYear,
                    BillingName = billingName,
                    BillingAddress1 = billingAddress1,
                    BillingAddress2 = billingAddress2,
                    BillingCity = billingCity,
                    BillingState = billingState,
                    BillingZip = billingZip,
                    BillingCountry = billingCountry,
                    BillingPhone = billingPhone,
                    BillingEmail = billingEmail,
                    OnFileEndDate = onFileEndDate,
                    OnFilePermission = onFilePermission,
                    OnFileComment = onFileComment,
                    OnFileMaxChargeAmount = onFileMaxChargeAmount
                }
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;

        }

        /// <summary>
        /// Deletes the card on file.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>ApiResponse.</returns>
        public ApiResponse DeleteCardOnFile(string merchantId, string merchantKey, string customerId, string token)
        {

            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "delete-card-onfile",
                CommandRequest = new CommandRequest
                {
                    CustomerId = customerId,
                    Token = token
                }
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;

        }

        /// <summary>
        /// Cancels the recurring.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns>ApiResponse.</returns>
        public ApiResponse CancelRecurring(string merchantId, string merchantKey, string orderID)
        {
            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "cancel-recurring",
                CommandRequest = new CommandRequest { OrderID = orderID }
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }

    }
}
