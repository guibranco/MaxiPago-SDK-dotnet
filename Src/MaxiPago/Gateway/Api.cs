using System;
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

        public ApiResponse AddConsumer(String merchantId, String merchantKey, String customerIdExt, String firstName, String lastName
                                        , String address1, String address2, String city, String state, String zip, String phone, String email
                                        , String dob, String ssn, String sex)
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

        public ApiResponse DeleteConsumer(String merchantId, String merchantKey, String customerId)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "delete-consumer";
            CommandRequest commandRequest = new CommandRequest();
            request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

        public ApiResponse UpdateConsumer(String merchantId, String merchantKey, String customerId, String customerIdExt, String firstName
                                        , String lastName, String address1, String address2, String city, String state, String zip, String phone
                                        , String email, String dob, String ssn, String sex)
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

        public ApiResponse AddCardOnFile(String merchantId, String merchantKey, String customerId, String creditCardNumber, String expirationMonth
                                        , String expirationYear, String billingName, String billingAddress1, String billingAddress2, String billingCity
                                        , String billingState, String billingZip, String billingCountry, String billingPhone, String billingEmail
                                        , String onFileEndDate, String onFilePermission, String onFileComment, String onFileMaxChargeAmount)
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

        public ApiResponse DeleteCardOnFile(String merchantId, String merchantKey, String customerId, String token)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "delete-card-onfile";
            CommandRequest commandRequest = new CommandRequest();
            request.CommandRequest = commandRequest;

            commandRequest.CustomerId = customerId;
            commandRequest.Token = token;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

        public ApiResponse CancelRecurring(String merchantId, String merchantKey, String orderID)
        {

            request = new ApiRequest(merchantId, merchantKey);

            request.Command = "cancel-recurring";
            CommandRequest commandRequest = new CommandRequest();
            commandRequest.orderID = orderID;
            request.CommandRequest = commandRequest;

            return new Utils().SendRequest<ApiRequest>(request, Environment) as ApiResponse;

        }

    }
}
