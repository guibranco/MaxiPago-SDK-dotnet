// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Transaction.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading;
using MaxiPago.DataContract;
using MaxiPago.DataContract.Transactional;

namespace MaxiPago.Gateway
{
    /// <summary>
    /// Class Transaction.
    /// Implements the <see cref="ServiceBase" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    public class Transaction : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        public Transaction()
        {
            Environment = "TEST";
        }

        /// <summary>
        /// The request
        /// </summary>
        private TransactionRequest _request;

        /// <summary>
        /// Processes a sale transaction using the provided credit card information and merchant details.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="referenceNum">A reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged for the sale.</param>
        /// <param name="creditCardNumber">The credit card number used for the transaction.</param>
        /// <param name="expMonth">The expiration month of the credit card.</param>
        /// <param name="expYear">The expiration year of the credit card.</param>
        /// <param name="cvvInd">Indicates whether a CVV is provided.</param>
        /// <param name="cvvNumber">The CVV number of the credit card.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="numberOfInstallments">The number of installments for the payment, if applicable.</param>
        /// <param name="chargeInterest">Indicates whether interest should be charged on installments.</param>
        /// <param name="ipAddress">The IP address of the customer making the transaction.</param>
        /// <param name="customerToken">A token representing the customer, if applicable.</param>
        /// <param name="onFileEndDate">The end date for on-file payment permission, if applicable.</param>
        /// <param name="onFilePermission">Indicates whether permission is granted for on-file payments.</param>
        /// <param name="onFileComment">A comment regarding on-file payment permissions.</param>
        /// <param name="onFileMaxChargeAmount">The maximum charge amount allowed for on-file payments.</param>
        /// <param name="billingName">The name of the person being billed.</param>
        /// <param name="billingAddress">The primary billing address.</param>
        /// <param name="billingAddress2">An additional line for the billing address, if needed.</param>
        /// <param name="billingCity">The city of the billing address.</param>
        /// <param name="billingState">The state of the billing address.</param>
        /// <param name="billingPostalCode">The postal code of the billing address.</param>
        /// <param name="billingCountry">The country of the billing address.</param>
        /// <param name="billingPhone">The phone number associated with the billing address.</param>
        /// <param name="billingEmail">The email address associated with the billing account.</param>
        /// <param name="currencyCode">The currency code for the transaction (e.g., USD).</param>
        /// <param name="fraudCheck">Indicates whether a fraud check should be performed.</param>
        /// <param name="softDescriptor">A descriptor that appears on the customer's statement.</param>
        /// <param name="iataFee">An optional IATA fee associated with the transaction, if applicable.</param>
        /// <returns>A response object containing the result of the sale transaction.</returns>
        /// <remarks>
        /// This method processes a sale transaction by collecting all necessary information related to the merchant,
        /// credit card, and billing details. It then calls an internal method to handle the actual transaction processing.
        /// The response returned will indicate whether the transaction was successful or if there were any errors.
        /// This method is designed to handle various parameters related to payment processing, including installment options
        /// and fraud checks, ensuring a comprehensive approach to handling sales transactions.
        /// </remarks>
        public ResponseBase Sale(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string authentication,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerIdExt,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            FillRequestBase(
                "sale",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                creditCardNumber,
                expMonth,
                expYear,
                cvvInd,
                cvvNumber,
                authentication,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                customerIdExt,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Fills the request base for a transaction with the provided details.
        /// </summary>
        /// <param name="operation">The type of operation to perform, such as "sale" or "auth".</param>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The secret key associated with the merchant.</param>
        /// <param name="referenceNum">A reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged for the transaction.</param>
        /// <param name="creditCardNumber">The credit card number used for the transaction.</param>
        /// <param name="expMonth">The expiration month of the credit card.</param>
        /// <param name="expYear">The expiration year of the credit card.</param>
        /// <param name="cvvInd">Indicator for CVV presence.</param>
        /// <param name="cvvNumber">The CVV number of the credit card.</param>
        /// <param name="authentication">Authentication information for the transaction.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="numberOfInstallments">The number of installments for the payment, if applicable.</param>
        /// <param name="chargeInterest">Indicates whether interest should be charged on installments.</param>
        /// <param name="ipAddress">The IP address of the customer making the transaction.</param>
        /// <param name="customerIdExt">External customer identifier.</param>
        /// <param name="currencyCode">The currency code for the transaction.</param>
        /// <param name="fraudCheck">Fraud check parameters.</param>
        /// <param name="softDescriptor">A description that appears on the customer's statement.</param>
        /// <param name="iataFee">Optional IATA fee associated with the transaction.</param>
        /// <remarks>
        /// This method constructs a transaction request by populating a request base with various parameters related to the transaction.
        /// It initializes a new instance of the TransactionRequest and RequestBase classes, setting properties such as merchant credentials,
        /// payment details, and credit card information. If applicable, it also handles installment payments by creating a CreditInstallment
        /// object when there are multiple installments and interest is to be charged. The method finally assigns the constructed request
        /// base to either a sale or authorization operation based on the provided operation type.
        /// </remarks>
        private void FillRequestBase(
            string operation,
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string authentication,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerIdExt,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            _request = new TransactionRequest(merchantId, merchantKey);
            var rBase = new RequestBase
            {
                ReferenceNum = referenceNum,
                ProcessorId = processorId,
                Authentication = authentication,
                IpAddress = ipAddress,
                CustomerIdExt = customerIdExt,
                FraudCheck = fraudCheck,
                Payment = new Payment
                {
                    ChargeTotal = chargeTotal,
                    CurrencyCode = currencyCode,
                    SoftDescriptor = softDescriptor,
                    IataFee = iataFee,
                },
            };

            rBase.TransactionDetail.PayType.CreditCard = new CreditCard
            {
                CvvInd = cvvInd,
                CvvNumber = cvvNumber,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Number = creditCardNumber,
            };

            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            var tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                rBase.Payment.CreditInstallment = new CreditInstallment
                {
                    ChargeInterest = chargeInterest.ToUpper(),
                    NumberOfInstallments = numberOfInstallments,
                };
            }

            if (operation.Equals("sale"))
                _request.Order.Sale = rBase;
            else if (operation.Equals("auth"))
                _request.Order.Auth = rBase;
        }

        /// <summary>
        /// Faz uma autorização com captura.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="referenceNum">The reference number.</param>
        /// <param name="chargeTotal">The charge total.</param>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <param name="expMonth">The exp month.</param>
        /// <param name="expYear">The exp year.</param>
        /// <param name="cvvInd">The CVV ind.</param>
        /// <param name="cvvNumber">The CVV number.</param>
        /// <param name="authentication">The authentication.</param>
        /// <param name="processorId">The processor identifier.</param>
        /// <param name="numberOfInstallments">The number of installments.</param>
        /// <param name="chargeInterest">The charge interest.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="customerIdExt">The customer identifier ext.</param>
        /// <param name="billingName">Name of the billing.</param>
        /// <param name="billingAddress">The billing address.</param>
        /// <param name="billingAddress2">The billing address2.</param>
        /// <param name="billingCity">The billing city.</param>
        /// <param name="billingState">State of the billing.</param>
        /// <param name="billingPostalCode">The billing postal code.</param>
        /// <param name="billingCountry">The billing country.</param>
        /// <param name="billingPhone">The billing phone.</param>
        /// <param name="billingEmail">The billing email.</param>
        /// <param name="shippingName">Name of the shipping.</param>
        /// <param name="shippingAddress">The shipping address.</param>
        /// <param name="shippingAddress2">The shipping address2.</param>
        /// <param name="shippingCity">The shipping city.</param>
        /// <param name="shippingState">State of the shipping.</param>
        /// <param name="shippingPostalCode">The shipping postal code.</param>
        /// <param name="shippingCountry">The shipping country.</param>
        /// <param name="shippingPhone">The shipping phone.</param>
        /// <param name="shippingEmail">The shipping email.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fraudCheck">The fraud check.</param>
        /// <param name="softDescriptor">The soft descriptor.</param>
        /// <param name="iataFee">The iata fee.</param>
        /// <returns>ResponseBase.</returns>
        public ResponseBase Sale(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string authentication,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerIdExt,
            string billingName,
            string billingAddress,
            string billingAddress2,
            string billingCity,
            string billingState,
            string billingPostalCode,
            string billingCountry,
            string billingPhone,
            string billingEmail,
            string shippingName,
            string shippingAddress,
            string shippingAddress2,
            string shippingCity,
            string shippingState,
            string shippingPostalCode,
            string shippingCountry,
            string shippingPhone,
            string shippingEmail,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            FillRequestBase(
                "sale",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                creditCardNumber,
                expMonth,
                expYear,
                cvvInd,
                cvvNumber,
                authentication,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                customerIdExt,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );

            var sale = _request.Order.Sale;

            sale.Billing = new Billing
            {
                Address1 = billingAddress,
                Address2 = billingAddress2,
                City = billingCity,
                Country = billingCountry,
                Email = billingEmail,
                Name = billingName,
                Phone = billingPhone,
                Postalcode = billingPostalCode,
                State = billingState,
            };

            sale.Shipping = new Shipping
            {
                Address1 = shippingAddress,
                Address2 = shippingAddress2,
                City = shippingCity,
                Country = shippingCountry,
                Email = shippingEmail,
                Name = shippingName,
                Phone = shippingPhone,
                Postalcode = shippingPostalCode,
                State = shippingState,
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Faz uma autorização com captura passando o token do cartão já salvo na base.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="referenceNum">The reference number.</param>
        /// <param name="chargeTotal">The charge total.</param>
        /// <param name="processorId">The processor identifier.</param>
        /// <param name="token">The token.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="numberOfInstallments">The number of installments.</param>
        /// <param name="chargeInterest">The charge interest.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fraudCheck">The fraud check.</param>
        /// <param name="softDescriptor">The soft descriptor.</param>
        /// <param name="iataFee">The iata fee.</param>
        /// <returns>ResponseBase.</returns>
        public ResponseBase Sale(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string processorId,
            string token,
            string customerId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            return PayWithToken(
                "sale",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                processorId,
                token,
                customerId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );
        }

        /// <summary>
        /// Faz uma autorização com captura salvando o número de cartão automaticamente.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="referenceNum">The reference number.</param>
        /// <param name="chargeTotal">The charge total.</param>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <param name="expMonth">The exp month.</param>
        /// <param name="expYear">The exp year.</param>
        /// <param name="cvvInd">The CVV ind.</param>
        /// <param name="cvvNumber">The CVV number.</param>
        /// <param name="processorId">The processor identifier.</param>
        /// <param name="numberOfInstallments">The number of installments.</param>
        /// <param name="chargeInterest">The charge interest.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="customerToken">The customer token.</param>
        /// <param name="onFileEndDate">The on file end date.</param>
        /// <param name="onFilePermission">The on file permission.</param>
        /// <param name="onFileComment">The on file comment.</param>
        /// <param name="onFileMaxChargeAmount">The on file maximum charge amount.</param>
        /// <param name="billingName">Name of the billing.</param>
        /// <param name="billingAddress">The billing address.</param>
        /// <param name="billingAddress2">The billing address2.</param>
        /// <param name="billingCity">The billing city.</param>
        /// <param name="billingState">State of the billing.</param>
        /// <param name="billingPostalCode">The billing postal code.</param>
        /// <param name="billingCountry">The billing country.</param>
        /// <param name="billingPhone">The billing phone.</param>
        /// <param name="billingEmail">The billing email.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fraudCheck">The fraud check.</param>
        /// <param name="softDescriptor">The soft descriptor.</param>
        /// <param name="iataFee">The iata fee.</param>
        /// <returns>ResponseBase.</returns>
        public ResponseBase Sale(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerToken,
            string onFileEndDate,
            string onFilePermission,
            string onFileComment,
            string onFileMaxChargeAmount,
            string billingName,
            string billingAddress,
            string billingAddress2,
            string billingCity,
            string billingState,
            string billingPostalCode,
            string billingCountry,
            string billingPhone,
            string billingEmail,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            return PaySavingCreditCardAutomatically(
                "sale",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                creditCardNumber,
                expMonth,
                expYear,
                cvvInd,
                cvvNumber,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                customerToken,
                onFileEndDate,
                onFilePermission,
                onFileComment,
                onFileMaxChargeAmount,
                billingName,
                billingAddress,
                billingAddress2,
                billingCity,
                billingState,
                billingPostalCode,
                billingCountry,
                billingPhone,
                billingEmail,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );
        }

        /// <summary>
        /// Authenticates a credit card transaction and returns a response object.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The secret key associated with the merchant account.</param>
        /// <param name="referenceNum">A unique reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged.</param>
        /// <param name="creditCardNumber">The credit card number of the customer.</param>
        /// <param name="expMonth">The expiration month of the credit card.</param>
        /// <param name="expYear">The expiration year of the credit card.</param>
        /// <param name="cvvInd">Indicates whether the CVV is provided.</param>
        /// <param name="cvvNumber">The CVV number of the credit card.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="numberOfInstallments">The number of installments for the payment.</param>
        /// <param name="chargeInterest">Indicates whether interest should be charged.</param>
        /// <param name="ipAddress">The IP address of the customer making the transaction.</param>
        /// <param name="customerToken">A token representing the customer for recurring transactions.</param>
        /// <param name="onFileEndDate">The end date for on-file payment permissions.</param>
        /// <param name="onFilePermission">Indicates whether the merchant has permission to charge on-file payments.</param>
        /// <param name="onFileComment">A comment regarding on-file payment permissions.</param>
        /// <param name="onFileMaxChargeAmount">The maximum amount that can be charged on file.</param>
        /// <param name="billingName">The name of the person being billed.</param>
        /// <param name="billingAddress">The primary billing address.</param>
        /// <param name="billingAddress2">An optional secondary billing address.</param>
        /// <param name="billingCity">The city of the billing address.</param>
        /// <param name="billingState">The state of the billing address.</param>
        /// <param name="billingPostalCode">The postal code of the billing address.</param>
        /// <param name="billingCountry">The country of the billing address.</param>
        /// <param name="billingPhone">The phone number associated with the billing address.</param>
        /// <param name="billingEmail">The email address associated with the billing account.</param>
        /// <param name="currencyCode">The currency code for the transaction (e.g., USD).</param>
        /// <param name="fraudCheck">Indicates whether a fraud check should be performed.</param>
        /// <param name="softDescriptor">A description that appears on the customer's statement.</param>
        /// <param name="iataFee">An optional fee related to IATA (International Air Transport Association) transactions.</param>
        /// <returns>A response object containing the result of the authentication process.</returns>
        /// <remarks>
        /// This method processes a credit card authentication request by calling an internal method
        /// that handles the actual payment processing. It collects various parameters related to
        /// the transaction, including merchant details, credit card information, billing information,
        /// and optional parameters for fraud checks and IATA fees. The method ensures that all
        /// necessary data is provided to facilitate a successful authentication and returns a
        /// response object that indicates whether the transaction was successful or if there were
        /// any issues during processing.
        /// </remarks>
        public ResponseBase Auth(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string authentication,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerIdExt,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            FillRequestBase(
                "auth",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                creditCardNumber,
                expMonth,
                expYear,
                cvvInd,
                cvvNumber,
                authentication,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                customerIdExt,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Faz uma Autorização.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="referenceNum">The reference number.</param>
        /// <param name="chargeTotal">The charge total.</param>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <param name="expMonth">The exp month.</param>
        /// <param name="expYear">The exp year.</param>
        /// <param name="cvvInd">The CVV ind.</param>
        /// <param name="cvvNumber">The CVV number.</param>
        /// <param name="authentication">The authentication.</param>
        /// <param name="processorId">The processor identifier.</param>
        /// <param name="numberOfInstallments">The number of installments.</param>
        /// <param name="chargeInterest">The charge interest.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="customerIdExt">The customer identifier ext.</param>
        /// <param name="billingName">Name of the billing.</param>
        /// <param name="billingAddress">The billing address.</param>
        /// <param name="billingAddress2">The billing address2.</param>
        /// <param name="billingCity">The billing city.</param>
        /// <param name="billingState">State of the billing.</param>
        /// <param name="billingPostalCode">The billing postal code.</param>
        /// <param name="billingCountry">The billing country.</param>
        /// <param name="billingPhone">The billing phone.</param>
        /// <param name="billingEmail">The billing email.</param>
        /// <param name="shippingName">Name of the shipping.</param>
        /// <param name="shippingAddress">The shipping address.</param>
        /// <param name="shippingAddress2">The shipping address2.</param>
        /// <param name="shippingCity">The shipping city.</param>
        /// <param name="shippingState">State of the shipping.</param>
        /// <param name="shippingPostalCode">The shipping postal code.</param>
        /// <param name="shippingCountry">The shipping country.</param>
        /// <param name="shippingPhone">The shipping phone.</param>
        /// <param name="shippingEmail">The shipping email.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fraudCheck">The fraud check.</param>
        /// <param name="softDescriptor">The soft descriptor.</param>
        /// <param name="iataFee">The iata fee.</param>
        /// <returns>ResponseBase.</returns>
        public ResponseBase Auth(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string authentication,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerIdExt,
            string billingName,
            string billingAddress,
            string billingAddress2,
            string billingCity,
            string billingState,
            string billingPostalCode,
            string billingCountry,
            string billingPhone,
            string billingEmail,
            string shippingName,
            string shippingAddress,
            string shippingAddress2,
            string shippingCity,
            string shippingState,
            string shippingPostalCode,
            string shippingCountry,
            string shippingPhone,
            string shippingEmail,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            FillRequestBase(
                "auth",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                creditCardNumber,
                expMonth,
                expYear,
                cvvInd,
                cvvNumber,
                authentication,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                customerIdExt,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );

            var auth = _request.Order.Auth;

            auth.Billing = new Billing
            {
                Address1 = billingAddress,
                Address2 = billingAddress2,
                City = billingCity,
                Country = billingCountry,
                Email = billingEmail,
                Name = billingName,
                Phone = billingPhone,
                Postalcode = billingPostalCode,
                State = billingState,
            };

            auth.Shipping = new Shipping
            {
                Address1 = shippingAddress,
                Address2 = shippingAddress2,
                City = shippingCity,
                Country = shippingCountry,
                Email = shippingEmail,
                Name = shippingName,
                Phone = shippingPhone,
                Postalcode = shippingPostalCode,
                State = shippingState,
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Faz uma autorização passando o token do cartão já salvo na base.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="referenceNum">The reference number.</param>
        /// <param name="chargeTotal">The charge total.</param>
        /// <param name="processorId">The processor identifier.</param>
        /// <param name="token">The token.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="numberOfInstallments">The number of installments.</param>
        /// <param name="chargeInterest">The charge interest.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fraudCheck">The fraud check.</param>
        /// <param name="softDescriptor">The soft descriptor.</param>
        /// <param name="iataFee">The iata fee.</param>
        /// <returns>ResponseBase.</returns>
        public ResponseBase Auth(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string processorId,
            string token,
            string customerId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            return PayWithToken(
                "auth",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                processorId,
                token,
                customerId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );
        }

        /// <summary>
        /// Faz uma autorização salvando o número de cartão automaticamente.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="referenceNum">The reference number.</param>
        /// <param name="chargeTotal">The charge total.</param>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <param name="expMonth">The exp month.</param>
        /// <param name="expYear">The exp year.</param>
        /// <param name="cvvInd">The CVV ind.</param>
        /// <param name="cvvNumber">The CVV number.</param>
        /// <param name="processorId">The processor identifier.</param>
        /// <param name="numberOfInstallments">The number of installments.</param>
        /// <param name="chargeInterest">The charge interest.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="customerToken">The customer token.</param>
        /// <param name="onFileEndDate">The on file end date.</param>
        /// <param name="onFilePermission">The on file permission.</param>
        /// <param name="onFileComment">The on file comment.</param>
        /// <param name="onFileMaxChargeAmount">The on file maximum charge amount.</param>
        /// <param name="billingName">Name of the billing.</param>
        /// <param name="billingAddress">The billing address.</param>
        /// <param name="billingAddress2">The billing address2.</param>
        /// <param name="billingCity">The billing city.</param>
        /// <param name="billingState">State of the billing.</param>
        /// <param name="billingPostalCode">The billing postal code.</param>
        /// <param name="billingCountry">The billing country.</param>
        /// <param name="billingPhone">The billing phone.</param>
        /// <param name="billingEmail">The billing email.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="fraudCheck">The fraud check.</param>
        /// <param name="softDescriptor">The soft descriptor.</param>
        /// <param name="iataFee">The iata fee.</param>
        /// <returns>ResponseBase.</returns>
        public ResponseBase Auth(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerToken,
            string onFileEndDate,
            string onFilePermission,
            string onFileComment,
            string onFileMaxChargeAmount,
            string billingName,
            string billingAddress,
            string billingAddress2,
            string billingCity,
            string billingState,
            string billingPostalCode,
            string billingCountry,
            string billingPhone,
            string billingEmail,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            return PaySavingCreditCardAutomatically(
                "auth",
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                creditCardNumber,
                expMonth,
                expYear,
                cvvInd,
                cvvNumber,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                customerToken,
                onFileEndDate,
                onFilePermission,
                onFileComment,
                onFileMaxChargeAmount,
                billingName,
                billingAddress,
                billingAddress2,
                billingCity,
                billingState,
                billingPostalCode,
                billingCountry,
                billingPhone,
                billingEmail,
                currencyCode,
                fraudCheck,
                softDescriptor,
                iataFee
            );
        }

        /// <summary>
        /// Processes a Boleto payment transaction and returns the response.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="referenceNum">A reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged for the transaction.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="ipAddress">The IP address of the customer making the payment.</param>
        /// <param name="customerIdExt">An external identifier for the customer.</param>
        /// <param name="expirationDate">The expiration date of the Boleto payment.</param>
        /// <param name="number">The Boleto number.</param>
        /// <param name="instructions">Instructions for the Boleto payment.</param>
        /// <param name="billingName">The name of the billing customer.</param>
        /// <param name="billingAddress">The primary billing address.</param>
        /// <param name="billingAddress2">An optional secondary billing address.</param>
        /// <param name="billingCity">The city of the billing address.</param>
        /// <param name="billingState">The state of the billing address.</param>
        /// <param name="billingPostalCode">The postal code of the billing address.</param>
        /// <param name="billingCountry">The country of the billing address.</param>
        /// <param name="billingPhone">The phone number of the billing customer.</param>
        /// <param name="billingEmail">The email address of the billing customer.</param>
        /// <returns>A response object containing the result of the Boleto transaction.</returns>
        /// <remarks>
        /// This method constructs a transaction request for processing a Boleto payment.
        /// It initializes a new instance of a transaction request with the provided merchant credentials and sets up
        /// the order details, including billing information and payment specifics. The Boleto details such as
        /// expiration date, instructions, and number are also included in the request.
        /// Finally, it sends the request to the payment processing service and returns the response received.
        /// </remarks>
        public ResponseBase Boleto(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string processorId,
            string ipAddress,
            string customerIdExt,
            string expirationDate,
            string number,
            string instructions,
            string billingName,
            string billingAddress,
            string billingAddress2,
            string billingCity,
            string billingState,
            string billingPostalCode,
            string billingCountry,
            string billingPhone,
            string billingEmail
        )
        {
            _request = new TransactionRequest(merchantId, merchantKey);

            var order = _request.Order;
            order.Sale = new RequestBase
            {
                ReferenceNum = referenceNum,
                ProcessorId = processorId,
                IpAddress = ipAddress,
                CustomerIdExt = customerIdExt,
                Billing = new Billing
                {
                    Address1 = billingAddress,
                    Address2 = billingAddress2,
                    City = billingCity,
                    Country = billingCountry,
                    Email = billingEmail,
                    Name = billingName,
                    Phone = billingPhone,
                    Postalcode = billingPostalCode,
                    State = billingState,
                },
                Payment = new Payment { ChargeTotal = chargeTotal },
            };
            order.Sale.TransactionDetail.PayType.Boleto = new Boleto
            {
                ExpirationDate = expirationDate,
                Instructions = instructions,
                Number = number,
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Processes a payment using a token and returns a response object.
        /// </summary>
        /// <param name="operation">The type of operation to perform, either "sale" or "auth".</param>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The secret key associated with the merchant account.</param>
        /// <param name="referenceNum">A unique reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="token">The token representing the customer's payment method.</param>
        /// <param name="customerId">The unique identifier for the customer.</param>
        /// <param name="numberOfInstallments">The number of installments for the payment, if applicable.</param>
        /// <param name="chargeInterest">The interest charge for the installments, if applicable.</param>
        /// <param name="ipAddress">The IP address of the customer making the payment.</param>
        /// <param name="currencyCode">The currency code for the transaction (e.g., USD).</param>
        /// <param name="fraudCheck">A flag indicating whether to perform a fraud check.</param>
        /// <param name="softDescriptor">A description that will appear on the customer's statement.</param>
        /// <param name="iataFee">An optional fee associated with IATA transactions.</param>
        /// <returns>A response object containing the result of the payment processing.</returns>
        /// <remarks>
        /// This method constructs a payment request based on the provided parameters and sends it to the payment processor.
        /// It initializes a transaction request with merchant credentials and sets up the payment details, including charge total, currency, and optional fees.
        /// If installments are specified, it configures the installment details, including any interest charges.
        /// The method determines whether to perform a sale or authorization operation based on the provided operation parameter.
        /// Finally, it sends the constructed request to the payment processor and returns the response received.
        /// </remarks>
        private ResponseBase PayWithToken(
            string operation,
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string processorId,
            string token,
            string customerId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            _request = new TransactionRequest(merchantId, merchantKey);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var rBase = new RequestBase
            {
                ReferenceNum = referenceNum,
                ProcessorId = processorId,
                IpAddress = ipAddress,
                FraudCheck = fraudCheck,
                Payment = new Payment
                {
                    ChargeTotal = chargeTotal,
                    CurrencyCode = currencyCode,
                    SoftDescriptor = softDescriptor,
                    IataFee = iataFee,
                },
            };

            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            var tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                rBase.Payment.CreditInstallment = new CreditInstallment
                {
                    ChargeInterest = chargeInterest.ToUpper(),
                    NumberOfInstallments = numberOfInstallments,
                };
            }

            rBase.TransactionDetail.PayType.OnFile = new OnFile
            {
                CustomerId = customerId,
                Token = token,
            };
            if (operation.Equals("sale"))
                _request.Order.Sale = rBase;
            else if (operation.Equals("auth"))
                _request.Order.Auth = rBase;
            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Processes a payment transaction using a credit card and returns the response.
        /// </summary>
        /// <param name="operation">The type of operation to perform (e.g., "sale" or "auth").</param>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="referenceNum">A reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged.</param>
        /// <param name="creditCardNumber">The credit card number used for the transaction.</param>
        /// <param name="expMonth">The expiration month of the credit card.</param>
        /// <param name="expYear">The expiration year of the credit card.</param>
        /// <param name="cvvInd">Indicator for CVV presence.</param>
        /// <param name="cvvNumber">The CVV number of the credit card.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="numberOfInstallments">The number of installments for the payment.</param>
        /// <param name="chargeInterest">Indicates if interest should be charged on installments.</param>
        /// <param name="ipAddress">The IP address from which the transaction is initiated.</param>
        /// <param name="customerToken">A token representing the customer for saved payment methods.</param>
        /// <param name="onFileEndDate">The end date for saved payment permissions.</param>
        /// <param name="onFilePermission">Permission status for saved payment methods.</param>
        /// <param name="onFileComment">Comments related to saved payment methods.</param>
        /// <param name="onFileMaxChargeAmount">Maximum charge amount for saved payment methods.</param>
        /// <param name="billingName">The name of the person being billed.</param>
        /// <param name="billingAddress">The primary billing address.</param>
        /// <param name="billingAddress2">An optional secondary billing address.</param>
        /// <param name="billingCity">The city of the billing address.</param>
        /// <param name="billingState">The state of the billing address.</param>
        /// <param name="billingPostalCode">The postal code of the billing address.</param>
        /// <param name="billingCountry">The country of the billing address.</param>
        /// <param name="billingPhone">The phone number associated with the billing address.</param>
        /// <param name="billingEmail">The email address associated with the billing account.</param>
        /// <param name="currencyCode">The currency code for the transaction (e.g., "USD").</param>
        /// <param name="fraudCheck">Indicates whether a fraud check should be performed.</param>
        /// <param name="softDescriptor">A description that appears on the customer's statement.</param>
        /// <param name="iataFee">An optional fee associated with IATA transactions.</param>
        /// <returns>A response object containing the result of the payment transaction.</returns>
        /// <remarks>
        /// This method constructs a transaction request based on the provided parameters and sends it to the payment processor.
        /// It supports both sale and authorization operations, allowing for flexible payment handling.
        /// The method also handles installment payments, including optional interest charges, and manages customer billing information.
        /// The response from the payment processor is returned for further processing or logging.
        /// </remarks>
        private ResponseBase PaySavingCreditCardAutomatically(
            string operation,
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string customerToken,
            string onFileEndDate,
            string onFilePermission,
            string onFileComment,
            string onFileMaxChargeAmount,
            string billingName,
            string billingAddress,
            string billingAddress2,
            string billingCity,
            string billingState,
            string billingPostalCode,
            string billingCountry,
            string billingPhone,
            string billingEmail,
            string currencyCode,
            string fraudCheck,
            string softDescriptor,
            decimal? iataFee
        )
        {
            _request = new TransactionRequest(merchantId, merchantKey);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var rBase = new RequestBase
            {
                ReferenceNum = referenceNum,
                ProcessorId = processorId,
                IpAddress = ipAddress,
                FraudCheck = fraudCheck,
                Billing = new Billing
                {
                    Address1 = billingAddress,
                    Address2 = billingAddress2,
                    City = billingCity,
                    Country = billingCountry,
                    Email = billingEmail,
                    Name = billingName,
                    Phone = billingPhone,
                    Postalcode = billingPostalCode,
                    State = billingState,
                },
                Payment = new Payment
                {
                    ChargeTotal = chargeTotal,
                    CurrencyCode = currencyCode,
                    SoftDescriptor = softDescriptor,
                    IataFee = iataFee,
                },
                SaveOnFile = new SaveOnFile
                {
                    CustomerToken = customerToken,
                    OnFileComment = onFileComment,
                    OnFileEndDate = onFileEndDate,
                    OnFileMaxChargeAmount = onFileMaxChargeAmount,
                    OnFilePermission = onFilePermission,
                },
            };

            rBase.TransactionDetail.PayType.CreditCard = new CreditCard
            {
                CvvInd = cvvInd,
                CvvNumber = cvvNumber,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Number = creditCardNumber,
            };

            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            var tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                rBase.Payment.CreditInstallment = new CreditInstallment
                {
                    ChargeInterest = chargeInterest.ToUpper(),
                    NumberOfInstallments = numberOfInstallments,
                };
            }

            if (operation.Equals("sale"))
                _request.Order.Sale = rBase;
            else if (operation.Equals("auth"))
                _request.Order.Auth = rBase;

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Captures a payment transaction for a specified order.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="orderID">The unique identifier for the order to be captured.</param>
        /// <param name="referenceNum">A reference number associated with the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged for the order.</param>
        /// <returns>A <see cref="ResponseBase"/> object containing the result of the capture request.</returns>
        /// <remarks>
        /// This method sets the current thread's culture to "en-US" to ensure that the formatting of numbers and currencies is consistent.
        /// It creates a new transaction request using the provided merchant credentials and order details.
        /// The capture request is populated with the order ID, reference number, and charge total.
        /// Finally, it sends the request using a utility method and returns the response.
        /// </remarks>
        public ResponseBase Capture(
            string merchantId,
            string merchantKey,
            string orderID,
            string referenceNum,
            decimal chargeTotal
        )
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            _request = new TransactionRequest(merchantId, merchantKey)
            {
                Order =
                {
                    Capture = new CaptureOrReturn
                    {
                        OrderId = orderID,
                        ReferenceNum = referenceNum,
                        Payment = { ChargeTotal = chargeTotal },
                    },
                },
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Processes a return transaction for a specified order and returns the response.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="orderID">The unique identifier of the order being returned.</param>
        /// <param name="referenceNum">A reference number associated with the return transaction.</param>
        /// <param name="chargeTotal">The total amount charged for the return transaction.</param>
        /// <returns>A <see cref="ResponseBase"/> object containing the result of the return transaction.</returns>
        /// <remarks>
        /// This method sets the current thread's culture to "en-US" to ensure that the formatting of numbers and currencies is consistent.
        /// It creates a new instance of a transaction request, populating it with the provided merchant details and order information.
        /// The return transaction is then processed by sending the request to the appropriate service, and the response is returned.
        /// This method is essential for handling return transactions in a payment processing system, ensuring that all necessary details are included.
        /// </remarks>
        public ResponseBase Return(
            string merchantId,
            string merchantKey,
            string orderID,
            string referenceNum,
            decimal chargeTotal
        )
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            _request = new TransactionRequest(merchantId, merchantKey)
            {
                Order =
                {
                    Return = new CaptureOrReturn
                    {
                        OrderId = orderID,
                        ReferenceNum = referenceNum,
                        Payment = { ChargeTotal = chargeTotal },
                    },
                },
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Initiates a void transaction for a specified transaction ID.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="transactionID">The identifier of the transaction to be voided.</param>
        /// <param name="ipAddress">The IP address from which the void request is made.</param>
        /// <returns>A <see cref="ResponseBase"/> object containing the response from the void transaction request.</returns>
        /// <remarks>
        /// This method creates a new transaction request to void a specific transaction identified by <paramref name="transactionID"/>.
        /// It populates the request with the merchant's credentials and the necessary details for the void operation, including the IP address from which the request is made.
        /// The request is then sent using the <see cref="Utils.SendRequest"/> method, which handles the communication with the payment processing environment.
        /// The response from this operation will indicate whether the void was successful or if there were any issues.
        /// </remarks>
        public ResponseBase Void(
            string merchantId,
            string merchantKey,
            string transactionID,
            string ipAddress
        )
        {
            _request = new TransactionRequest(merchantId, merchantKey)
            {
                Order =
                {
                    Void = new Void { IpAddress = ipAddress, TransactionId = transactionID },
                },
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Processes a recurring payment request and returns the response.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="referenceNum">A reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged for the recurring payment.</param>
        /// <param name="customerId">The unique identifier for the customer making the payment.</param>
        /// <param name="token">The token representing the customer's payment method.</param>
        /// <param name="processorId">The identifier for the payment processor being used.</param>
        /// <param name="numberOfInstallments">The number of installments for the recurring payment.</param>
        /// <param name="chargeInterest">Indicates whether interest should be charged on the installments.</param>
        /// <param name="ipAddress">The IP address of the customer making the payment.</param>
        /// <param name="action">The action to be performed (e.g., "create", "update").</param>
        /// <param name="startDate">The start date for the recurring payments.</param>
        /// <param name="frequency">The frequency of the recurring payments (e.g., daily, weekly, monthly).</param>
        /// <param name="period">The period for which the recurring payments will be made.</param>
        /// <param name="installments">Details about the installments to be charged.</param>
        /// <param name="failureThreshold">The threshold for payment failures before stopping the recurring payments.</param>
        /// <param name="currencyCode">The currency code for the transaction (e.g., "USD").</param>
        /// <returns>A response object containing the result of the recurring payment request.</returns>
        /// <remarks>
        /// This method is responsible for setting up and processing a recurring payment transaction.
        /// It initializes the necessary parameters such as merchant details, customer information, and payment specifics.
        /// The method also configures the transaction details, including whether to charge interest and how many installments to process.
        /// After preparing the request, it sends it to the payment processing service and returns the response.
        /// This allows merchants to automate billing cycles and manage customer payments efficiently.
        /// </remarks>
        public ResponseBase Recurring(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string creditCardNumber,
            string expMonth,
            string expYear,
            string cvvInd,
            string cvvNumber,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string action,
            string startDate,
            string frequency,
            string period,
            string installments,
            string failureThreshold,
            string currencyCode
        )
        {
            FillRecurringBase(
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                action,
                startDate,
                frequency,
                period,
                installments,
                failureThreshold,
                currencyCode
            );
            //WARNING: installments é o campo a ser usado (numberOfInstallments é referente ao Parcelamento)

            var detail = _request.Order.RecurringPayment.TransactionDetail;

            detail.PayType.CreditCard = new CreditCard
            {
                CvvInd = cvvInd,
                CvvNumber = cvvNumber,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Number = creditCardNumber,
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Faz uma recorrência com token.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="referenceNum">The reference number.</param>
        /// <param name="chargeTotal">The charge total.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="token">The token.</param>
        /// <param name="processorId">The processor identifier.</param>
        /// <param name="numberOfInstallments">The number of installments.</param>
        /// <param name="chargeInterest">The charge interest.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="action">The action.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="period">The period.</param>
        /// <param name="installments">The installments.</param>
        /// <param name="failureThreshold">The failure threshold.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>ResponseBase.</returns>
        public ResponseBase Recurring(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string customerId,
            string token,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string action,
            string startDate,
            string frequency,
            string period,
            string installments,
            string failureThreshold,
            string currencyCode
        )
        {
            FillRecurringBase(
                merchantId,
                merchantKey,
                referenceNum,
                chargeTotal,
                processorId,
                numberOfInstallments,
                chargeInterest,
                ipAddress,
                action,
                startDate,
                frequency,
                period,
                installments,
                failureThreshold,
                currencyCode
            );

            _request.Order.RecurringPayment.TransactionDetail.PayType.OnFile = new OnFile
            {
                CustomerId = customerId,
                Token = token,
            };

            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Fills the recurring payment details for a transaction request.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="referenceNum">The reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged for the transaction.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="numberOfInstallments">The number of installments for the recurring payment.</param>
        /// <param name="chargeInterest">The interest charge applicable to the installments, if any.</param>
        /// <param name="ipAddress">The IP address of the customer making the transaction.</param>
        /// <param name="action">The action to be taken for the recurring payment (e.g., 'CREATE', 'UPDATE').</param>
        /// <param name="startDate">The start date for the recurring payments.</param>
        /// <param name="frequency">The frequency of the recurring payments (e.g., 'MONTHLY', 'WEEKLY').</param>
        /// <param name="period">The period for which the recurring payment is valid.</param>
        /// <param name="installments">Additional details regarding the installments.</param>
        /// <param name="failureThreshold">The threshold for payment failures before stopping the recurring payments.</param>
        /// <param name="currencyCode">The currency code for the transaction (e.g., 'USD', 'EUR').</param>
        /// <remarks>
        /// This method constructs a transaction request for a recurring payment by populating various fields
        /// such as merchant details, payment information, and installment options. It checks if the number of
        /// installments is provided; if not, it defaults to zero. The method also handles the inclusion of
        /// interest charges if applicable and ensures that all necessary details are included in the request
        /// object. The resulting transaction request can then be processed by the payment gateway.
        /// </remarks>
        private void FillRecurringBase(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string processorId,
            string numberOfInstallments,
            string chargeInterest,
            string ipAddress,
            string action,
            string startDate,
            string frequency,
            string period,
            string installments,
            string failureThreshold,
            string currencyCode
        )
        {
            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            var tranInstallments = int.Parse(numberOfInstallments);

            _request = new TransactionRequest(merchantId, merchantKey);

            var order = _request.Order;
            order.RecurringPayment = new RequestBase
            {
                ReferenceNum = referenceNum,
                ProcessorId = processorId,
                IpAddress = ipAddress,
                Payment = new Payment { ChargeTotal = chargeTotal, CurrencyCode = currencyCode },
                Recurring = new Recurring
                {
                    Action = action,
                    FailureThreshold = failureThreshold,
                    Frequency = frequency,
                    Installments = installments,
                    Period = period,
                    StartDate = startDate,
                },
            };

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                order.RecurringPayment.Payment.CreditInstallment = new CreditInstallment
                {
                    ChargeInterest = chargeInterest.ToUpper(),
                    NumberOfInstallments = numberOfInstallments,
                };
            }
        }

        /// <summary>
        /// Processes an online debit transaction and returns the response.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="referenceNum">A unique reference number for the transaction.</param>
        /// <param name="chargeTotal">The total amount to be charged for the transaction.</param>
        /// <param name="processorId">The identifier for the payment processor.</param>
        /// <param name="parametersUrl">A URL containing additional parameters for the transaction.</param>
        /// <param name="ipAddress">The IP address of the customer initiating the transaction.</param>
        /// <param name="customerIdExt">An external identifier for the customer.</param>
        /// <returns>A response object containing the result of the online debit transaction.</returns>
        /// <remarks>
        /// This method constructs a transaction request using the provided merchant credentials and transaction details.
        /// It sets up the necessary information such as the reference number, processor ID, IP address, customer ID, and charge total.
        /// The method also includes optional parameters through a URL for additional processing requirements.
        /// Finally, it sends the constructed request to the payment gateway and returns the response received from the gateway.
        /// This allows merchants to process online debit transactions securely and efficiently.
        /// </remarks>
        public ResponseBase OnlineDebit(
            string merchantId,
            string merchantKey,
            string referenceNum,
            decimal chargeTotal,
            string processorId,
            string parametersUrl,
            string ipAddress,
            string customerIdExt
        )
        {
            _request = new TransactionRequest(merchantId, merchantKey)
            {
                Order =
                {
                    Sale = new RequestBase
                    {
                        ReferenceNum = referenceNum,
                        ProcessorId = processorId,
                        IpAddress = ipAddress,
                        CustomerIdExt = customerIdExt,
                        Payment = new Payment { ChargeTotal = chargeTotal },
                    },
                },
            };
            _request.Order.Sale.TransactionDetail.PayType.OnlineDebit = new OnlineDebit
            {
                ParametersURL = parametersUrl ?? string.Empty,
            };

            return new Utils().SendRequest(_request, Environment);
        }
    }
}
