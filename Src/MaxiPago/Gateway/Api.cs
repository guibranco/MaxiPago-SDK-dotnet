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
        /// Adds a consumer's information to the system and returns the API response.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="customerIdExt">The external customer identifier.</param>
        /// <param name="firstName">The first name of the consumer.</param>
        /// <param name="lastName">The last name of the consumer.</param>
        /// <param name="address1">The primary address of the consumer.</param>
        /// <param name="address2">The secondary address of the consumer (optional).</param>
        /// <param name="city">The city where the consumer resides.</param>
        /// <param name="state">The state where the consumer resides.</param>
        /// <param name="zip">The postal code for the consumer's address.</param>
        /// <param name="phone">The phone number of the consumer.</param>
        /// <param name="email">The email address of the consumer.</param>
        /// <param name="dob">The date of birth of the consumer.</param>
        /// <param name="ssn">The social security number of the consumer.</param>
        /// <param name="sex">The gender of the consumer.</param>
        /// <returns>An instance of <see cref="ApiResponse"/> containing the result of the add consumer operation.</returns>
        /// <remarks>
        /// This method constructs an API request to add a new consumer's information to the system.
        /// It requires various details about the consumer, including personal identification and contact information.
        /// The method utilizes an instance of the ApiRequest class to encapsulate the necessary data and sends this request
        /// to the API using a utility method. The response from the API is then returned as an ApiResponse object,
        /// which can be used to determine if the operation was successful or if any errors occurred.
        /// </remarks>
        public ApiResponse AddConsumer(
            string merchantId,
            string merchantKey,
            string customerIdExt,
            string firstName,
            string lastName,
            string address1,
            string address2,
            string city,
            string state,
            string zip,
            string phone,
            string email,
            string dob,
            string ssn,
            string sex
        )
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
                    Sex = sex,
                },
            };

            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }

        /// <summary>
        /// Deletes a consumer based on the provided identifiers.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="customerId">The unique identifier for the customer to be deleted.</param>
        /// <returns>An instance of <see cref="ApiResponse"/> indicating the result of the delete operation.</returns>
        /// <remarks>
        /// This method constructs an API request to delete a consumer by setting the appropriate command and customer ID.
        /// It utilizes the <see cref="Utils.SendRequest"/> method to send the request to the server and returns the response.
        /// The operation is dependent on the validity of the provided merchant credentials and customer ID.
        /// Ensure that the customer ID corresponds to an existing consumer; otherwise, the deletion may fail.
        /// </remarks>
        public ApiResponse DeleteConsumer(string merchantId, string merchantKey, string customerId)
        {
            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "delete-consumer",
                CommandRequest = new CommandRequest { CustomerId = customerId },
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }

        /// <summary>
        /// Updates the consumer's information in the system.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="customerId">The unique identifier for the customer to be updated.</param>
        /// <param name="customerIdExt">An external identifier for the customer.</param>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <param name="address1">The primary address of the customer.</param>
        /// <param name="address2">The secondary address of the customer (optional).</param>
        /// <param name="city">The city where the customer resides.</param>
        /// <param name="state">The state where the customer resides.</param>
        /// <param name="zip">The postal code for the customer's address.</param>
        /// <param name="phone">The phone number of the customer.</param>
        /// <param name="email">The email address of the customer.</param>
        /// <param name="dob">The date of birth of the customer.</param>
        /// <param name="ssn">The social security number of the customer.</param>
        /// <param name="sex">The gender of the customer.</param>
        /// <returns>An instance of <see cref="ApiResponse"/> containing the result of the update operation.</returns>
        /// <remarks>
        /// This method constructs an API request to update a consumer's information based on the provided parameters.
        /// It initializes an ApiRequest object with the necessary merchant credentials and command details.
        /// The command is set to "update-consumer", and all relevant consumer information is encapsulated in a CommandRequest object.
        /// The request is then sent to the server using a utility method, and an ApiResponse is returned, indicating success or failure.
        /// This method is essential for maintaining up-to-date consumer records in the system.
        /// </remarks>
        public ApiResponse UpdateConsumer(
            string merchantId,
            string merchantKey,
            string customerId,
            string customerIdExt,
            string firstName,
            string lastName,
            string address1,
            string address2,
            string city,
            string state,
            string zip,
            string phone,
            string email,
            string dob,
            string ssn,
            string sex
        )
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
                    Sex = sex,
                },
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }

        /// <summary>
        /// Adds a credit card on file for a specified customer.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="customerId">The unique identifier for the customer.</param>
        /// <param name="creditCardNumber">The credit card number to be added.</param>
        /// <param name="expirationMonth">The expiration month of the credit card.</param>
        /// <param name="expirationYear">The expiration year of the credit card.</param>
        /// <param name="billingName">The name on the billing account.</param>
        /// <param name="billingAddress1">The primary billing address.</param>
        /// <param name="billingAddress2">The secondary billing address (optional).</param>
        /// <param name="billingCity">The city of the billing address.</param>
        /// <param name="billingState">The state of the billing address.</param>
        /// <param name="billingZip">The ZIP code of the billing address.</param>
        /// <param name="billingCountry">The country of the billing address.</param>
        /// <param name="billingPhone">The phone number associated with the billing account.</param>
        /// <param name="billingEmail">The email address associated with the billing account.</param>
        /// <param name="onFileEndDate">The end date for keeping the card on file.</param>
        /// <param name="onFilePermission">Permission status for keeping the card on file.</param>
        /// <param name="onFileComment">Any comments regarding the card on file.</param>
        /// <param name="onFileMaxChargeAmount">The maximum charge amount allowed for this card on file.</param>
        /// <returns>An instance of <see cref="ApiResponse"/> indicating the result of the operation.</returns>
        /// <remarks>
        /// This method constructs an API request to add a credit card on file for a specified customer.
        /// It requires various details such as merchant credentials, customer information, and billing details.
        /// The method then sends this request to the appropriate API endpoint and returns the response.
        /// The response will indicate whether the operation was successful or if there were any errors encountered during the process.
        /// </remarks>
        public ApiResponse AddCardOnFile(
            string merchantId,
            string merchantKey,
            string customerId,
            string creditCardNumber,
            string expirationMonth,
            string expirationYear,
            string billingName,
            string billingAddress1,
            string billingAddress2,
            string billingCity,
            string billingState,
            string billingZip,
            string billingCountry,
            string billingPhone,
            string billingEmail,
            string onFileEndDate,
            string onFilePermission,
            string onFileComment,
            string onFileMaxChargeAmount
        )
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
                    OnFileMaxChargeAmount = onFileMaxChargeAmount,
                },
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }

        /// <summary>
        /// Deletes a card on file for a specified customer.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="customerId">The unique identifier for the customer whose card is to be deleted.</param>
        /// <param name="token">The token representing the card to be deleted.</param>
        /// <returns>An instance of <see cref="ApiResponse"/> containing the result of the delete operation.</returns>
        /// <remarks>
        /// This method constructs an API request to delete a card on file for a specific customer using the provided merchant credentials.
        /// It initializes an <see cref="ApiRequest"/> object with the necessary command and parameters, then sends the request using the
        /// <see cref="Utils.SendRequest"/> method. The response from the API call is returned as an <see cref="ApiResponse"/> object.
        /// This method assumes that the API endpoint is correctly configured and that the provided credentials are valid.
        /// </remarks>
        public ApiResponse DeleteCardOnFile(
            string merchantId,
            string merchantKey,
            string customerId,
            string token
        )
        {
            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "delete-card-onfile",
                CommandRequest = new CommandRequest { CustomerId = customerId, Token = token },
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }

        /// <summary>
        /// Cancels a recurring order based on the provided merchant credentials and order ID.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The secret key associated with the merchant account.</param>
        /// <param name="orderID">The identifier of the order to be canceled.</param>
        /// <returns>An instance of <see cref="ApiResponse"/> representing the result of the cancellation request.</returns>
        /// <remarks>
        /// This method constructs an API request to cancel a recurring order by initializing an <see cref="ApiRequest"/>
        /// with the provided merchant ID and key, along with the specified order ID. The command for the request is set
        /// to "cancel-recurring". After setting up the request, it sends the request to the API using the
        /// <see cref="Utils.SendRequest"/> method. The response from the API is cast to an <see cref="ApiResponse"/>
        /// object, which contains information about the success or failure of the cancellation operation.
        /// </remarks>
        public ApiResponse CancelRecurring(string merchantId, string merchantKey, string orderID)
        {
            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "cancel-recurring",
                CommandRequest = new CommandRequest { OrderID = orderID },
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;
        }
    }
}
