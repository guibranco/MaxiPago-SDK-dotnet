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

        private ApiRequest request;

        public ApiResponse AddConsumer(string merchantId, string merchantKey, string customerIdExt, string firstName, string lastName
                                        , string address1, string address2, string city, string state, string zip, string phone, string email
                                        , string dob, string ssn, string sex)
        {


            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "add-consumer";
            CommandRequest commandRequest = new CommandRequest();
            request.CommandRequest = commandRequest;

            commandRequest.CustomerIdExt = customerIdExt;
            commandRequest.FirstName = firstName;
            commandRequest.LastName = lastName;
            commandRequest.Address1 = address1;
            commandRequest.Address2 = address2;
            commandRequest.City = city;
            commandRequest.State = state;
            commandRequest.Zip = zip;
            commandRequest.Phone = phone;
            commandRequest.Email = email;
            commandRequest.Dob = dob;
            commandRequest.Ssn = ssn;
            commandRequest.Sex = sex;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;
        }

        public ApiResponse DeleteConsumer(string merchantId, string merchantKey, string customerId)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "delete-consumer";
            CommandRequest commandRequest = new CommandRequest();
            request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

        public ApiResponse UpdateConsumer(string merchantId, string merchantKey, string customerId, string customerIdExt, string firstName
                                        , string lastName, string address1, string address2, string city, string state, string zip, string phone
                                        , string email, string dob, string ssn, string sex)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "update-consumer";
            CommandRequest commandRequest = new CommandRequest();
            request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;
            commandRequest.CustomerIdExt = customerIdExt;
            commandRequest.FirstName = firstName;
            commandRequest.LastName = lastName;
            commandRequest.Address1 = address1;
            commandRequest.Address2 = address2;
            commandRequest.City = city;
            commandRequest.State = state;
            commandRequest.Zip = zip;
            commandRequest.Phone = phone;
            commandRequest.Email = email;
            commandRequest.Dob = dob;
            commandRequest.Ssn = ssn;
            commandRequest.Sex = sex;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

        public ApiResponse AddCardOnFile(string merchantId, string merchantKey, string customerId, string creditCardNumber, string expirationMonth
                                        , string expirationYear, string billingName, string billingAddress1, string billingAddress2, string billingCity
                                        , string billingState, string billingZip, string billingCountry, string billingPhone, string billingEmail
                                        , string onFileEndDate, string onFilePermission, string onFileComment, string onFileMaxChargeAmount)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "add-card-onfile";
            CommandRequest commandRequest = new CommandRequest();
            request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;
            commandRequest.CreditCardNumber = creditCardNumber;
            commandRequest.ExpirationMonth = expirationMonth;
            commandRequest.ExpirationYear = expirationYear;
            commandRequest.BillingName = billingName;
            commandRequest.BillingAddress1 = billingAddress1;
            commandRequest.BillingAddress2 = billingAddress2;
            commandRequest.BillingCity = billingCity;
            commandRequest.BillingState = billingState;
            commandRequest.BillingZip = billingZip;
            commandRequest.BillingCountry = billingCountry;
            commandRequest.BillingPhone = billingPhone;
            commandRequest.BillingEmail = billingEmail;
            commandRequest.OnFileEndDate = onFileEndDate;
            commandRequest.OnFilePermission = onFilePermission;
            commandRequest.OnFileComment = onFileComment;
            commandRequest.OnFileMaxChargeAmount = onFileMaxChargeAmount;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

        public ApiResponse DeleteCardOnFile(string merchantId, string merchantKey, string customerId, string token)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "delete-card-onfile";
            CommandRequest commandRequest = new CommandRequest();
            request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;
            commandRequest.Token = token;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

        public ApiResponse CancelRecurring(string merchantId, string merchantKey, string orderID)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "cancel-recurring";
            CommandRequest commandRequest = new CommandRequest();
            commandRequest.OrderID = orderID;
            request.CommandRequest = commandRequest;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

    }
}
