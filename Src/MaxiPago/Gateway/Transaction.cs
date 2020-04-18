using MaxiPago.DataContract;
using MaxiPago.DataContract.Transactional;
using System.Threading;

namespace MaxiPago.Gateway
{

    public class Transaction : ServiceBase
    {

        public Transaction()
        {
            Environment = "TEST";
        }

        private TransactionRequest _request;

        /// <summary>
        /// Faz uma autorização com captura.
        /// </summary>
        public ResponseBase Sale(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string creditCardNumber
                , string expMonth, string expYear, string cvvInd, string cvvNumber, string authentication, string processorId
                , string numberOfInstallments, string chargeInterest, string ipAddress, string customerIdExt, string currencyCode
                , string fraudCheck, string softDescriptor, decimal? iataFee)
        {

            FillRequestBase("sale", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments, chargeInterest
                , ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Popula o objeto RequestBase em comum a todos.
        /// </summary>
        private void FillRequestBase(string operation, string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string creditCardNumber
                , string expMonth, string expYear, string cvvInd, string cvvNumber, string authentication, string processorId
                , string numberOfInstallments, string chargeInterest, string ipAddress, string customerIdExt, string currencyCode
                , string fraudCheck, string softDescriptor, decimal? iataFee)
        {

            _request = new TransactionRequest(merchantId, merchantKey);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
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
                    IataFee = iataFee
                }
            };

            rBase.TransactionDetail.PayType.CreditCard = new CreditCard
            {
                CvvInd = cvvInd,
                CvvNumber = cvvNumber,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Number = creditCardNumber
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
                    NumberOfInstallments = numberOfInstallments
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
        public ResponseBase Sale(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string creditCardNumber
                , string expMonth, string expYear, string cvvInd, string cvvNumber, string authentication, string processorId
                , string numberOfInstallments, string chargeInterest, string ipAddress, string customerIdExt, string billingName
                , string billingAddress, string billingAddress2, string billingCity, string billingState, string billingPostalCode
                , string billingCountry, string billingPhone, string billingEmail, string shippingName, string shippingAddress
                , string shippingAddress2, string shippingCity, string shippingState, string shippingPostalCode
                , string shippingCountry, string shippingPhone, string shippingEmail, string currencyCode, string fraudCheck
                , string softDescriptor, decimal? iataFee)
        {


            FillRequestBase("sale", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                    , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments, chargeInterest
                    , ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

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
                State = billingState
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
                State = shippingState
            };

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz uma autorização com captura passando o token do cartão já salvo na base.
        /// </summary>
        public ResponseBase Sale(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string processorId
                                , string token, string customerId, string numberOfInstallments, string chargeInterest, string ipAddress, string currencyCode
                                , string fraudCheck, string softDescriptor, decimal? iataFee)
        {


            return PayWithToken("sale", merchantId, merchantKey, referenceNum, chargeTotal, processorId, token, customerId
                                    , numberOfInstallments, chargeInterest, ipAddress, currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma autorização com captura salvando o número de cartão automaticamente.
        /// </summary>
        public ResponseBase Sale(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
                                   , string creditCardNumber, string expMonth, string expYear, string cvvInd, string cvvNumber
                                   , string processorId, string numberOfInstallments, string chargeInterest, string ipAddress
                                   , string customerToken, string onFileEndDate, string onFilePermission, string onFileComment
                                   , string onFileMaxChargeAmount, string billingName, string billingAddress, string billingAddress2
                                   , string billingCity, string billingState, string billingPostalCode, string billingCountry
                                   , string billingPhone, string billingEmail, string currencyCode, string fraudCheck
                                   , string softDescriptor, decimal? iataFee)
        {

            return PaySavingCreditCardAutomatically("sale", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                                                    , cvvInd, cvvNumber, processorId, numberOfInstallments, chargeInterest, ipAddress, customerToken
                                                    , onFileEndDate, onFilePermission, onFileComment, onFileMaxChargeAmount, billingName, billingAddress
                                                    , billingAddress2, billingCity, billingState, billingPostalCode, billingCountry, billingPhone, billingEmail
                                                    , currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma Autorização.
        /// </summary>
        public ResponseBase Auth(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string creditCardNumber
                , string expMonth, string expYear, string cvvInd, string cvvNumber, string authentication, string processorId
                , string numberOfInstallments, string chargeInterest, string ipAddress, string customerIdExt, string currencyCode
                , string fraudCheck, string softDescriptor, decimal? iataFee)
        {

            FillRequestBase("auth", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                    , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments
                    , chargeInterest, ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz uma Autorização.
        /// </summary>
        public ResponseBase Auth(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string creditCardNumber
                , string expMonth, string expYear, string cvvInd, string cvvNumber, string authentication, string processorId
                , string numberOfInstallments, string chargeInterest, string ipAddress, string customerIdExt, string billingName
                , string billingAddress, string billingAddress2, string billingCity, string billingState, string billingPostalCode
                , string billingCountry, string billingPhone, string billingEmail, string shippingName, string shippingAddress
                , string shippingAddress2, string shippingCity, string shippingState, string shippingPostalCode, string shippingCountry
                , string shippingPhone, string shippingEmail, string currencyCode, string fraudCheck, string softDescriptor, decimal? iataFee)
        {

            FillRequestBase("auth", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                    , cvvInd, cvvNumber, authentication, processorId, numberOfInstallments
                    , chargeInterest, ipAddress, customerIdExt, currencyCode, fraudCheck, softDescriptor, iataFee);

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
                State = billingState
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
                State = shippingState
            };


            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz uma autorização passando o token do cartão já salvo na base.
        /// </summary>
        public ResponseBase Auth(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string processorId
                                , string token, string customerId, string numberOfInstallments, string chargeInterest, string ipAddress, string currencyCode
                                , string fraudCheck, string softDescriptor, decimal? iataFee)
        {


            return PayWithToken("auth", merchantId, merchantKey, referenceNum, chargeTotal, processorId, token, customerId
                                    , numberOfInstallments, chargeInterest, ipAddress, currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma autorização salvando o número de cartão automaticamente.
        /// </summary>
        public ResponseBase Auth(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
                                   , string creditCardNumber, string expMonth, string expYear, string cvvInd, string cvvNumber
                                   , string processorId, string numberOfInstallments, string chargeInterest, string ipAddress
                                   , string customerToken, string onFileEndDate, string onFilePermission, string onFileComment
                                   , string onFileMaxChargeAmount, string billingName, string billingAddress, string billingAddress2
                                   , string billingCity, string billingState, string billingPostalCode, string billingCountry
                                   , string billingPhone, string billingEmail, string currencyCode, string fraudCheck
                                   , string softDescriptor, decimal? iataFee)
        {

            return PaySavingCreditCardAutomatically("auth", merchantId, merchantKey, referenceNum, chargeTotal, creditCardNumber, expMonth, expYear
                                                    , cvvInd, cvvNumber, processorId, numberOfInstallments, chargeInterest, ipAddress, customerToken
                                                    , onFileEndDate, onFilePermission, onFileComment, onFileMaxChargeAmount, billingName, billingAddress
                                                    , billingAddress2, billingCity, billingState, billingPostalCode, billingCountry, billingPhone, billingEmail
                                                    , currencyCode, fraudCheck, softDescriptor, iataFee);

        }

        /// <summary>
        /// Faz uma requisição de boleto.
        /// </summary>
        public ResponseBase Boleto(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string processorId
                                 , string ipAddress, string customerIdExt, string expirationDate, string number, string instructions
                                 , string billingName, string billingAddress, string billingAddress2, string billingCity, string billingState
                                 , string billingPostalCode, string billingCountry, string billingPhone, string billingEmail)
        {

            _request = new TransactionRequest(merchantId, merchantKey);

            var order = _request.Order;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
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
                    State = billingState
                },
                Payment = new Payment { ChargeTotal = chargeTotal }
            };
            order.Sale.TransactionDetail.PayType.Boleto = new Boleto { ExpirationDate = expirationDate, Instructions = instructions, Number = number };

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz a transação passando o token do cartão já salvo na base.
        /// </summary>
        private ResponseBase PayWithToken(string operation, string merchantId, string merchantKey, string referenceNum, decimal chargeTotal, string processorId
                                , string token, string customerId, string numberOfInstallments, string chargeInterest, string ipAddress, string currencyCode
                                , string fraudCheck, string softDescriptor, decimal? iataFee)
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
                    IataFee = iataFee
                }
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
                    NumberOfInstallments = numberOfInstallments
                };
            }

            rBase.TransactionDetail.PayType.OnFile = new OnFile { CustomerId = customerId, Token = token };
            if (operation.Equals("sale"))
                _request.Order.Sale = rBase;
            else if (operation.Equals("auth"))
                _request.Order.Auth = rBase;
            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Passa uma transação salvando o número de cartão automaticamente.
        /// </summary>
        private ResponseBase PaySavingCreditCardAutomatically(string operation, string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
                                                            , string creditCardNumber, string expMonth, string expYear, string cvvInd, string cvvNumber
                                                            , string processorId, string numberOfInstallments, string chargeInterest, string ipAddress
                                                            , string customerToken, string onFileEndDate, string onFilePermission, string onFileComment
                                                            , string onFileMaxChargeAmount, string billingName, string billingAddress, string billingAddress2
                                                            , string billingCity, string billingState, string billingPostalCode, string billingCountry
                                                            , string billingPhone, string billingEmail, string currencyCode, string fraudCheck, string softDescriptor
                                                            , decimal? iataFee)
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
                    State = billingState
                },
                Payment = new Payment
                {
                    ChargeTotal = chargeTotal,
                    CurrencyCode = currencyCode,
                    SoftDescriptor = softDescriptor,
                    IataFee = iataFee
                },
                SaveOnFile = new SaveOnFile
                {
                    CustomerToken = customerToken,
                    OnFileComment = onFileComment,
                    OnFileEndDate = onFileEndDate,
                    OnFileMaxChargeAmount = onFileMaxChargeAmount,
                    OnFilePermission = onFilePermission
                }
            };

            rBase.TransactionDetail.PayType.CreditCard = new CreditCard
            {
                CvvInd = cvvInd,
                CvvNumber = cvvNumber,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Number = creditCardNumber
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
                    NumberOfInstallments = numberOfInstallments
                };
            }

            if (operation.Equals("sale"))
                _request.Order.Sale = rBase;
            else if (operation.Equals("auth"))
                _request.Order.Auth = rBase;

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz uma Captura.
        /// </summary>
        public ResponseBase Capture(string merchantId, string merchantKey, string orderID, string referenceNum, decimal chargeTotal)
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
                        Payment = {ChargeTotal = chargeTotal}
                    }
                }
            };



            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz um Estorno.
        /// </summary>
        public ResponseBase Return(string merchantId, string merchantKey, string orderID, string referenceNum, decimal chargeTotal)
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
                        Payment = {ChargeTotal = chargeTotal}
                    }
                }
            };



            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz um Cancelamento.
        /// </summary>
        public ResponseBase Void(string merchantId, string merchantKey, string transactionID, string ipAddress)
        {

            _request = new TransactionRequest(merchantId, merchantKey)
            {
                Order =
                {
                    Void = new Void
                    {
                        IpAddress = ipAddress,
                        TransactionId = transactionID
                    }
                }
            };


            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz uma recorrência.
        /// </summary>
        public ResponseBase Recurring(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
            , string creditCardNumber, string expMonth, string expYear, string cvvInd, string cvvNumber, string processorId
            , string numberOfInstallments, string chargeInterest, string ipAddress, string action
            , string startDate, string frequency, string period, string installments, string failureThreshold
            , string currencyCode)
        {

            FillRecurringBase(merchantId, merchantKey, referenceNum, chargeTotal, processorId, numberOfInstallments
                , chargeInterest, ipAddress, action, startDate, frequency, period, installments
                , failureThreshold, currencyCode);
            //WARNING: installments é o campo a ser usado (numberOfInstallments é referente ao Parcelamento)

            var detail = _request.Order.RecurringPayment.TransactionDetail;

            detail.PayType.CreditCard = new CreditCard
            {
                CvvInd = cvvInd,
                CvvNumber = cvvNumber,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Number = creditCardNumber
            };


            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Faz uma recorrência com token.
        /// </summary>
        public ResponseBase Recurring(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
            , string customerId, string token, string processorId, string numberOfInstallments
            , string chargeInterest, string ipAddress, string action, string startDate
            , string frequency, string period, string installments, string failureThreshold
            , string currencyCode)
        {

            FillRecurringBase(merchantId, merchantKey, referenceNum, chargeTotal, processorId, numberOfInstallments,
                              chargeInterest, ipAddress, action, startDate, frequency, period, installments,
                              failureThreshold, currencyCode);

            _request.Order.RecurringPayment.TransactionDetail.PayType.OnFile =
                new OnFile { CustomerId = customerId, Token = token };


            return new Utils().SendRequest(_request, Environment);
        }

        /// <summary>
        /// Efetua o preenchimento comum aos métodos de Recorrente
        /// </summary>
        private void FillRecurringBase(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
            , string processorId, string numberOfInstallments, string chargeInterest
            , string ipAddress, string action, string startDate
            , string frequency, string period, string installments, string failureThreshold
            , string currencyCode)
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
                    StartDate = startDate
                }
            };

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                order.RecurringPayment.Payment.CreditInstallment = new CreditInstallment
                {
                    ChargeInterest = chargeInterest.ToUpper(),
                    NumberOfInstallments = numberOfInstallments
                };
            }
        }

        public ResponseBase OnlineDebit(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
                                    , string processorId, string parametersUrl, string ipAddress, string customerIdExt)
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
                        Payment = new Payment {ChargeTotal = chargeTotal},
                    }
                }
            };
            _request.Order.Sale.TransactionDetail.PayType.OnlineDebit =
                new OnlineDebit { ParametersURL = parametersUrl ?? string.Empty };

            return new Utils().SendRequest(_request, Environment);

        }


    }
}
