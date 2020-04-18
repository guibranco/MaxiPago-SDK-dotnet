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

            Order order = _request.Order;
            RequestBase rBase = new RequestBase();

            if (operation.Equals("sale"))
                order.Sale = rBase;
            else if (operation.Equals("auth"))
                order.Auth = rBase;

            rBase.ReferenceNum = referenceNum;
            rBase.ProcessorId = processorId;
            rBase.Authentication = authentication;
            rBase.IpAddress = ipAddress;
            rBase.CustomerIdExt = customerIdExt;
            rBase.FraudCheck = fraudCheck;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            rBase.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;
            payment.SoftDescriptor = softDescriptor;
            payment.IataFee = iataFee;

            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            TransactionDetail detail = rBase.TransactionDetail;
            PayType payType = detail.PayType;

            CreditCard creditCard = new CreditCard();
            payType.CreditCard = creditCard;

            creditCard.CvvInd = cvvInd;
            creditCard.CvvNumber = cvvNumber;
            creditCard.ExpMonth = expMonth;
            creditCard.ExpYear = expYear;
            creditCard.Number = creditCardNumber;

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

            RequestBase sale = _request.Order.Sale;

            Billing billing = new Billing();
            sale.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Shipping shipping = new Shipping();
            sale.Shipping = shipping;

            shipping.Address1 = shippingAddress;
            shipping.Address2 = shippingAddress2;
            shipping.City = shippingCity;
            shipping.Country = shippingCountry;
            shipping.Email = shippingEmail;
            shipping.Name = shippingName;
            shipping.Phone = shippingPhone;
            shipping.Postalcode = shippingPostalCode;
            shipping.State = shippingState;

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

            RequestBase auth = _request.Order.Auth;

            Billing billing = new Billing();
            auth.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Shipping shipping = new Shipping();
            auth.Shipping = shipping;

            shipping.Address1 = shippingAddress;
            shipping.Address2 = shippingAddress2;
            shipping.City = shippingCity;
            shipping.Country = shippingCountry;
            shipping.Email = shippingEmail;
            shipping.Name = shippingName;
            shipping.Phone = shippingPhone;
            shipping.Postalcode = shippingPostalCode;
            shipping.State = shippingState;

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

            Order order = _request.Order;
            RequestBase sale = new RequestBase();
            order.Sale = sale;
            sale.ReferenceNum = referenceNum;
            sale.ProcessorId = processorId;
            sale.IpAddress = ipAddress;
            sale.CustomerIdExt = customerIdExt;

            Billing billing = new Billing();
            sale.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            sale.Payment = payment;
            payment.ChargeTotal = chargeTotal;

            TransactionDetail detail = sale.TransactionDetail;
            PayType payType = detail.PayType;

            Boleto boleto = new Boleto();
            payType.Boleto = boleto;

            boleto.ExpirationDate = expirationDate;
            boleto.Instructions = instructions;
            boleto.Number = number;

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

            Order order = _request.Order;
            RequestBase rBase = new RequestBase();

            if (operation.Equals("sale"))
                order.Sale = rBase;
            else if (operation.Equals("auth"))
                order.Auth = rBase;

            rBase.ReferenceNum = referenceNum;
            rBase.ProcessorId = processorId;
            rBase.IpAddress = ipAddress;
            rBase.FraudCheck = fraudCheck;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            rBase.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;
            payment.SoftDescriptor = softDescriptor;
            payment.IataFee = iataFee;

            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            TransactionDetail detail = rBase.TransactionDetail;
            PayType payType = detail.PayType;

            payType.OnFile = new OnFile();
            payType.OnFile.CustomerId = customerId;
            payType.OnFile.Token = token;

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

            Order order = _request.Order;
            RequestBase rBase = new RequestBase();

            if (operation.Equals("sale"))
                order.Sale = rBase;
            else if (operation.Equals("auth"))
                order.Auth = rBase;

            rBase.ReferenceNum = referenceNum;
            rBase.ProcessorId = processorId;
            rBase.IpAddress = ipAddress;
            rBase.FraudCheck = fraudCheck;

            Billing billing = new Billing();
            rBase.Billing = billing;

            billing.Address1 = billingAddress;
            billing.Address2 = billingAddress2;
            billing.City = billingCity;
            billing.Country = billingCountry;
            billing.Email = billingEmail;
            billing.Name = billingName;
            billing.Phone = billingPhone;
            billing.Postalcode = billingPostalCode;
            billing.State = billingState;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Payment payment = new Payment();
            rBase.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;
            payment.SoftDescriptor = softDescriptor;
            payment.IataFee = iataFee;

            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            TransactionDetail detail = rBase.TransactionDetail;
            PayType payType = detail.PayType;

            CreditCard creditCard = new CreditCard();
            payType.CreditCard = creditCard;

            creditCard.CvvInd = cvvInd;
            creditCard.CvvNumber = cvvNumber;
            creditCard.ExpMonth = expMonth;
            creditCard.ExpYear = expYear;
            creditCard.Number = creditCardNumber;

            rBase.SaveOnFile = new SaveOnFile();
            rBase.SaveOnFile.CustomerToken = customerToken;
            rBase.SaveOnFile.OnFileComment = onFileComment;
            rBase.SaveOnFile.OnFileEndDate = onFileEndDate;
            rBase.SaveOnFile.OnFileMaxChargeAmount = onFileMaxChargeAmount;
            rBase.SaveOnFile.OnFilePermission = onFilePermission;

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz uma Captura.
        /// </summary>
        public ResponseBase Capture(string merchantId, string merchantKey, string orderID, string referenceNum, decimal chargeTotal)
        {

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            _request = new TransactionRequest(merchantId, merchantKey);

            CaptureOrReturn capture = new CaptureOrReturn();
            _request.Order.Capture = capture;

            capture.OrderId = orderID;
            capture.ReferenceNum = referenceNum;
            capture.Payment.ChargeTotal = chargeTotal;

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz um Estorno.
        /// </summary>
        public ResponseBase Return(string merchantId, string merchantKey, string orderID, string referenceNum, decimal chargeTotal)
        {

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            _request = new TransactionRequest(merchantId, merchantKey);

            CaptureOrReturn captureOrReturn = new CaptureOrReturn();
            _request.Order.Return = captureOrReturn;

            captureOrReturn.OrderId = orderID;
            captureOrReturn.ReferenceNum = referenceNum;
            captureOrReturn.Payment.ChargeTotal = chargeTotal;

            return new Utils().SendRequest(_request, Environment);

        }

        /// <summary>
        /// Faz um Cancelamento.
        /// </summary>
        public ResponseBase Void(string merchantId, string merchantKey, string transactionID, string ipAddress)
        {

            _request = new TransactionRequest(merchantId, merchantKey);

            Void voidTransaction = new Void();
            _request.Order.Void = voidTransaction;

            voidTransaction.IpAddress = ipAddress;
            voidTransaction.TransactionId = transactionID;

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
            //ATENCAO: installments é o campo a ser usado (numberOfInstallments é referente ao Parcelamento)

            TransactionDetail detail = _request.Order.RecurringPayment.TransactionDetail;

            PayType payType = detail.PayType;

            CreditCard creditCard = new CreditCard();
            payType.CreditCard = creditCard;

            creditCard.CvvInd = cvvInd;
            creditCard.CvvNumber = cvvNumber;
            creditCard.ExpMonth = expMonth;
            creditCard.ExpYear = expYear;
            creditCard.Number = creditCardNumber;

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

            FillRecurringBase(merchantId, merchantKey, referenceNum, chargeTotal, processorId, numberOfInstallments
                    , chargeInterest, ipAddress, action, startDate, frequency, period, installments
                    , failureThreshold, currencyCode);

            TransactionDetail detail = _request.Order.RecurringPayment.TransactionDetail;
            PayType payType = detail.PayType;

            OnFile onFile = new OnFile();
            payType.OnFile = onFile;

            onFile.CustomerId = customerId;
            onFile.Token = token;

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

            _request = new TransactionRequest(merchantId, merchantKey);

            Order order = _request.Order;
            RequestBase recurringPayment = new RequestBase();
            order.RecurringPayment = recurringPayment;

            recurringPayment.ReferenceNum = referenceNum;
            recurringPayment.ProcessorId = processorId;
            recurringPayment.IpAddress = ipAddress;

            Payment payment = new Payment();
            recurringPayment.Payment = payment;
            payment.ChargeTotal = chargeTotal;
            payment.CurrencyCode = currencyCode;

            if (string.IsNullOrEmpty(numberOfInstallments))
                numberOfInstallments = "0";

            int tranInstallments = int.Parse(numberOfInstallments);

            //Verifica se vai precisar criar o nó de parcelas e juros.
            if (!string.IsNullOrEmpty(chargeInterest) && tranInstallments > 1)
            {
                payment.CreditInstallment = new CreditInstallment();
                payment.CreditInstallment.ChargeInterest = chargeInterest.ToUpper();
                payment.CreditInstallment.NumberOfInstallments = numberOfInstallments;
            }

            Recurring recurring = new Recurring();
            recurringPayment.Recurring = recurring;

            recurring.Action = action;
            recurring.FailureThreshold = failureThreshold;
            recurring.Frequency = frequency;
            recurring.Installments = installments;
            recurring.Period = period;
            recurring.StartDate = startDate;

        }

        public ResponseBase OnlineDebit(string merchantId, string merchantKey, string referenceNum, decimal chargeTotal
                                    , string processorId, string parametersUrl, string ipAddress, string customerIdExt)
        {

            _request = new TransactionRequest(merchantId, merchantKey);

            Order order = _request.Order;
            RequestBase sale = new RequestBase();
            order.Sale = sale;

            sale.ReferenceNum = referenceNum;
            sale.ProcessorId = processorId;
            sale.IpAddress = ipAddress;
            sale.CustomerIdExt = customerIdExt;

            Payment payment = new Payment();
            sale.Payment = payment;
            payment.ChargeTotal = chargeTotal;

            TransactionDetail detail = sale.TransactionDetail;
            PayType payType = detail.PayType;

            OnlineDebit debit = new OnlineDebit();
            payType.OnlineDebit = debit;

            if (parametersUrl == null)
                parametersUrl = string.Empty;

            debit.ParametersURL = parametersUrl;

            return new Utils().SendRequest(_request, Environment);

        }


    }
}
