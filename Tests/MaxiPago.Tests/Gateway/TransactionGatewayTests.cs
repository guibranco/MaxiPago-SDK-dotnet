using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.Transactional;
using MaxiPago.Gateway;
using NSubstitute;
using Xunit;

namespace MaxiPago.Tests.Gateway
{
    public class TransactionGatewayTests
    {
        private static readonly Faker Faker = new();
        private readonly IUtils _utils;
        private readonly Transaction _transaction;

        public TransactionGatewayTests()
        {
            _utils = Substitute.For<IUtils>();
            _transaction = new Transaction(_utils);
        }

        // ── helpers ──────────────────────────────────────────────────────────

        private static string MerchantId() => Faker.Random.AlphaNumeric(8);

        private static string MerchantKey() => Faker.Random.AlphaNumeric(32);

        private static string ReferenceNum() => Faker.Random.AlphaNumeric(12);

        private static decimal ChargeTotal() => Faker.Finance.Amount(1, 9999);

        private static string CardNumber() => Faker.Finance.CreditCardNumber();

        private static string IpAddress() => Faker.Internet.Ip();

        private static string ProcessorId() => Faker.Random.AlphaNumeric(4);

        private void SetupTransactionResponse() =>
            _utils
                .SendRequest(Arg.Any<TransactionRequest>(), Arg.Any<string>())
                .Returns(new TransactionResponse { ResponseCode = "0" });

        // ── environment ───────────────────────────────────────────────────────

        [Fact]
        public void DefaultConstructor_SetsEnvironmentToTest()
        {
            var transaction = new Transaction();
            transaction.Environment.Should().Be("TEST");
        }

        [Fact]
        public void InjectedConstructor_SetsEnvironmentToTest()
        {
            _transaction.Environment.Should().Be("TEST");
        }

        // ── Sale (basic) ──────────────────────────────────────────────────────

        [Fact]
        public void Sale_Basic_SendsSaleOperation()
        {
            SetupTransactionResponse();
            var referenceNum = ReferenceNum();
            var chargeTotal = ChargeTotal();

            _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                referenceNum,
                chargeTotal,
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                null,
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale != null
                        && r.Order.Sale.ReferenceNum == referenceNum
                        && r.Order.Sale.Payment.ChargeTotal == chargeTotal
                    ),
                    "TEST"
                );
        }

        [Fact]
        public void Sale_Basic_SetsCreditCardDetails()
        {
            SetupTransactionResponse();
            var cardNumber = CardNumber();

            _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                cardNumber,
                "06",
                "2028",
                "1",
                "456",
                null,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                null,
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.TransactionDetail.PayType.CreditCard.Number == cardNumber
                        && r.Order.Sale.TransactionDetail.PayType.CreditCard.ExpMonth == "06"
                        && r.Order.Sale.TransactionDetail.PayType.CreditCard.ExpYear == "2028"
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void Sale_Basic_SetsMerchantCredentials()
        {
            SetupTransactionResponse();
            var merchantId = MerchantId();
            var merchantKey = MerchantKey();

            _transaction.Sale(
                merchantId,
                merchantKey,
                ReferenceNum(),
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                null,
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Verification.MerchantId == merchantId
                        && r.Verification.MerchantKey == merchantKey
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void Sale_Basic_ReturnsTransactionResponse()
        {
            var expected = new TransactionResponse { ResponseCode = "0", OrderId = "ORD-001" };
            _utils.SendRequest(Arg.Any<TransactionRequest>(), Arg.Any<string>()).Returns(expected);

            var result = _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                null,
                "BRL",
                null,
                null,
                null
            );

            result.Should().BeSameAs(expected);
            result.IsTransactionResponse.Should().BeTrue();
        }

        [Fact]
        public void Sale_WithInstallments_SetsCreditInstallment()
        {
            SetupTransactionResponse();

            _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "3",
                "Y",
                IpAddress(),
                null,
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.Payment.CreditInstallment != null
                        && r.Order.Sale.Payment.CreditInstallment.NumberOfInstallments == "3"
                        && r.Order.Sale.Payment.CreditInstallment.ChargeInterest == "Y"
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void Sale_WithSingleInstallment_DoesNotSetCreditInstallment()
        {
            SetupTransactionResponse();

            _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "1",
                "Y",
                IpAddress(),
                null,
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r => r.Order.Sale.Payment.CreditInstallment == null),
                    Arg.Any<string>()
                );
        }

        // ── Sale with billing/shipping ────────────────────────────────────────

        [Fact]
        public void Sale_WithBillingShipping_PopulatesBillingAddress()
        {
            SetupTransactionResponse();
            var billingName = Faker.Person.FullName;
            var billingCity = Faker.Address.City();

            _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                null,
                billingName,
                Faker.Address.StreetAddress(),
                null,
                billingCity,
                Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(),
                "BR",
                Faker.Phone.PhoneNumber(),
                Faker.Internet.Email(),
                Faker.Person.FullName,
                Faker.Address.StreetAddress(),
                null,
                Faker.Address.City(),
                Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(),
                "BR",
                Faker.Phone.PhoneNumber(),
                Faker.Internet.Email(),
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.Billing != null
                        && r.Order.Sale.Billing.Name == billingName
                        && r.Order.Sale.Billing.City == billingCity
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void Sale_WithBillingShipping_PopulatesShippingAddress()
        {
            SetupTransactionResponse();
            var shippingName = Faker.Person.FullName;

            _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                null,
                Faker.Person.FullName,
                Faker.Address.StreetAddress(),
                null,
                Faker.Address.City(),
                Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(),
                "BR",
                Faker.Phone.PhoneNumber(),
                Faker.Internet.Email(),
                shippingName,
                Faker.Address.StreetAddress(),
                null,
                Faker.Address.City(),
                Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(),
                "BR",
                Faker.Phone.PhoneNumber(),
                Faker.Internet.Email(),
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.Shipping != null && r.Order.Sale.Shipping.Name == shippingName
                    ),
                    Arg.Any<string>()
                );
        }

        // ── Sale with token ───────────────────────────────────────────────────

        [Fact]
        public void Sale_WithToken_SetsOnFilePayType()
        {
            SetupTransactionResponse();
            var customerId = Faker.Random.AlphaNumeric(10);
            var token = Faker.Random.AlphaNumeric(20);

            _transaction.Sale(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                ProcessorId(),
                token,
                customerId,
                "1",
                null,
                IpAddress(),
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.TransactionDetail.PayType.OnFile != null
                        && r.Order.Sale.TransactionDetail.PayType.OnFile.CustomerId == customerId
                        && r.Order.Sale.TransactionDetail.PayType.OnFile.Token == token
                    ),
                    Arg.Any<string>()
                );
        }

        // ── Auth ──────────────────────────────────────────────────────────────

        [Fact]
        public void Auth_Basic_SendsAuthOperation()
        {
            SetupTransactionResponse();
            var referenceNum = ReferenceNum();

            _transaction.Auth(
                MerchantId(),
                MerchantKey(),
                referenceNum,
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                null,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                null,
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Auth != null && r.Order.Auth.ReferenceNum == referenceNum
                    ),
                    "TEST"
                );
        }

        [Fact]
        public void Auth_WithToken_SetsOnFilePayType()
        {
            SetupTransactionResponse();
            var customerId = Faker.Random.AlphaNumeric(10);
            var token = Faker.Random.AlphaNumeric(20);

            _transaction.Auth(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                ProcessorId(),
                token,
                customerId,
                "1",
                null,
                IpAddress(),
                "BRL",
                null,
                null,
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Auth.TransactionDetail.PayType.OnFile != null
                        && r.Order.Auth.TransactionDetail.PayType.OnFile.Token == token
                    ),
                    Arg.Any<string>()
                );
        }

        // ── Capture ───────────────────────────────────────────────────────────

        [Fact]
        public void Capture_SendsCaptureWithCorrectOrderId()
        {
            SetupTransactionResponse();
            var orderId = Faker.Random.AlphaNumeric(12);
            var chargeTotal = ChargeTotal();

            _transaction.Capture(MerchantId(), MerchantKey(), orderId, ReferenceNum(), chargeTotal);

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Capture != null
                        && r.Order.Capture.OrderId == orderId
                        && r.Order.Capture.Payment.ChargeTotal == chargeTotal
                    ),
                    "TEST"
                );
        }

        [Fact]
        public void Capture_ReturnsResponse()
        {
            var expected = new TransactionResponse { ResponseCode = "0" };
            _utils.SendRequest(Arg.Any<TransactionRequest>(), Arg.Any<string>()).Returns(expected);

            var result = _transaction.Capture(
                MerchantId(),
                MerchantKey(),
                Faker.Random.AlphaNumeric(12),
                ReferenceNum(),
                ChargeTotal()
            );

            result.Should().BeSameAs(expected);
        }

        // ── Return ────────────────────────────────────────────────────────────

        [Fact]
        public void Return_SendsReturnWithCorrectOrderId()
        {
            SetupTransactionResponse();
            var orderId = Faker.Random.AlphaNumeric(12);
            var chargeTotal = ChargeTotal();

            _transaction.Return(MerchantId(), MerchantKey(), orderId, ReferenceNum(), chargeTotal);

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Return != null
                        && r.Order.Return.OrderId == orderId
                        && r.Order.Return.Payment.ChargeTotal == chargeTotal
                    ),
                    "TEST"
                );
        }

        // ── Void ──────────────────────────────────────────────────────────────

        [Fact]
        public void Void_SendsVoidWithTransactionId()
        {
            SetupTransactionResponse();
            var transactionId = Faker.Random.AlphaNumeric(15);
            var ipAddress = IpAddress();

            _transaction.Void(MerchantId(), MerchantKey(), transactionId, ipAddress);

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Void != null
                        && r.Order.Void.TransactionId == transactionId
                        && r.Order.Void.IpAddress == ipAddress
                    ),
                    "TEST"
                );
        }

        // ── Boleto ────────────────────────────────────────────────────────────

        [Fact]
        public void Boleto_SetsBoletoPayType()
        {
            SetupTransactionResponse();
            var expirationDate = "2030-12-31";
            var boletoNumber = Faker.Random.AlphaNumeric(10);

            _transaction.Boleto(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                ProcessorId(),
                IpAddress(),
                null,
                expirationDate,
                boletoNumber,
                "Pay at any bank",
                Faker.Person.FullName,
                Faker.Address.StreetAddress(),
                null,
                Faker.Address.City(),
                Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(),
                "BR",
                Faker.Phone.PhoneNumber(),
                Faker.Internet.Email()
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.TransactionDetail.PayType.Boleto != null
                        && r.Order.Sale.TransactionDetail.PayType.Boleto.ExpirationDate
                            == expirationDate
                        && r.Order.Sale.TransactionDetail.PayType.Boleto.Number == boletoNumber
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void Boleto_PopulatesBillingInfo()
        {
            SetupTransactionResponse();
            var billingName = Faker.Person.FullName;

            _transaction.Boleto(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                ProcessorId(),
                IpAddress(),
                null,
                "2030-12-31",
                Faker.Random.AlphaNumeric(10),
                "Pay at any bank",
                billingName,
                Faker.Address.StreetAddress(),
                null,
                Faker.Address.City(),
                Faker.Address.StateAbbr(),
                Faker.Address.ZipCode(),
                "BR",
                Faker.Phone.PhoneNumber(),
                Faker.Internet.Email()
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.Billing != null && r.Order.Sale.Billing.Name == billingName
                    ),
                    Arg.Any<string>()
                );
        }

        // ── Recurring ─────────────────────────────────────────────────────────

        [Fact]
        public void Recurring_WithCreditCard_SetsCreditCardPayType()
        {
            SetupTransactionResponse();
            var cardNumber = CardNumber();

            _transaction.Recurring(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                cardNumber,
                "12",
                "2030",
                "1",
                "123",
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                "new",
                "2024-01-01",
                "1",
                "monthly",
                "12",
                "3",
                "BRL"
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.RecurringPayment != null
                        && r.Order.RecurringPayment.TransactionDetail.PayType.CreditCard != null
                        && r.Order.RecurringPayment.TransactionDetail.PayType.CreditCard.Number
                            == cardNumber
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void Recurring_WithCreditCard_SetsRecurringSchedule()
        {
            SetupTransactionResponse();

            _transaction.Recurring(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                CardNumber(),
                "12",
                "2030",
                "1",
                "123",
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                "new",
                "2024-01-01",
                "1",
                "monthly",
                "12",
                "3",
                "BRL"
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.RecurringPayment.Recurring != null
                        && r.Order.RecurringPayment.Recurring.Action == "new"
                        && r.Order.RecurringPayment.Recurring.Period == "monthly"
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void Recurring_WithToken_SetsOnFilePayType()
        {
            SetupTransactionResponse();
            var customerId = Faker.Random.AlphaNumeric(10);
            var token = Faker.Random.AlphaNumeric(20);

            _transaction.Recurring(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                customerId,
                token,
                ProcessorId(),
                "1",
                null,
                IpAddress(),
                "new",
                "2024-01-01",
                "1",
                "monthly",
                "12",
                "3",
                "BRL"
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.RecurringPayment.TransactionDetail.PayType.OnFile != null
                        && r.Order.RecurringPayment.TransactionDetail.PayType.OnFile.CustomerId
                            == customerId
                        && r.Order.RecurringPayment.TransactionDetail.PayType.OnFile.Token == token
                    ),
                    Arg.Any<string>()
                );
        }

        // ── OnlineDebit ───────────────────────────────────────────────────────

        [Fact]
        public void OnlineDebit_SetsOnlineDebitPayType()
        {
            SetupTransactionResponse();
            var parametersUrl = "https://bank.example.com/params?key=value";

            _transaction.OnlineDebit(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                ProcessorId(),
                parametersUrl,
                IpAddress(),
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.TransactionDetail.PayType.OnlineDebit != null
                        && r.Order.Sale.TransactionDetail.PayType.OnlineDebit.ParametersURL
                            == parametersUrl
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void OnlineDebit_WithNullParametersUrl_UsesEmptyString()
        {
            SetupTransactionResponse();

            _transaction.OnlineDebit(
                MerchantId(),
                MerchantKey(),
                ReferenceNum(),
                ChargeTotal(),
                ProcessorId(),
                null,
                IpAddress(),
                null
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<TransactionRequest>(r =>
                        r.Order.Sale.TransactionDetail.PayType.OnlineDebit.ParametersURL
                        == string.Empty
                    ),
                    Arg.Any<string>()
                );
        }

        // ── Environment propagation ───────────────────────────────────────────

        [Fact]
        public void AllMethods_UseConfiguredEnvironment()
        {
            SetupTransactionResponse();
            _transaction.Environment = "LIVE";

            _transaction.Void(
                MerchantId(),
                MerchantKey(),
                Faker.Random.AlphaNumeric(15),
                IpAddress()
            );

            _utils.Received(1).SendRequest(Arg.Any<TransactionRequest>(), "LIVE");
        }
    }
}
