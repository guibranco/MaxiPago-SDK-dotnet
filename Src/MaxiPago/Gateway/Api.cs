using MaxiPago.DataContract;
using MaxiPago.DataContract.NonTransactional;

namespace MaxiPago.Gateway
{

    public class Api : ServiceBase
    {

        public Api()
        {
            Environment = "TEST";
        }

        private ApiRequest _request;

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

        public ApiResponse DeleteConsumer(string merchantId, string merchantKey, string customerId)
        {

            _request = new ApiRequest(merchantId, merchantKey)
            {
                Command = "delete-consumer",
                CommandRequest = new CommandRequest { CustomerId = customerId }
            };
            return new Utils().SendRequest(_request, Environment) as ApiResponse;

        }

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
