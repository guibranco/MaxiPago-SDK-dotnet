using System;
using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.Transactional;
using MaxiPago.Gateway;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace MaxiPago.Tests.IntegrationTests
{
    public class TransactionIntegrationTests : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly Faker _faker;

        public TransactionIntegrationTests()
        {
            _server = WireMockServer.Start();
            _faker = new Faker();
        }

        public void Dispose()
        {
            _server.Stop();
            _server.Dispose();
        }

        [Fact]
        public void Sale_WithValidCreditCard_ShouldReturnApprovedResponse()
        {
            // Arrange: Setup WireMock to simulate a successful transaction response
            string successResponse =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                <transaction-response>
                    <authCode>123456</authCode>
                    <orderID>12345</orderID>
                    <referenceNum>REF123456</referenceNum>
                    <transactionID>987654321</transactionID>
                    <transactionTimestamp>2025-04-27T12:00:00</transactionTimestamp>
                    <responseCode>0</responseCode>
                    <responseMessage>APPROVED</responseMessage>
                    <avsResponseCode>A</avsResponseCode>
                    <cvvResponseCode>M</cvvResponseCode>
                    <processorCode>A</processorCode>
                    <processorMessage>APPROVED</processorMessage>
                    <errorMessage></errorMessage>
                    <processorTransactionID>123456789</processorTransactionID>
                    <processorReferenceNumber>REF987654321</processorReferenceNumber>
                </transaction-response>";

            _server
                .Given(Request.Create().WithPath("/").UsingPost())
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBody(successResponse)
                        .WithHeader("Content-Type", "application/xml")
                );

            // Generate test data using Bogus
            string merchantId = _faker.Random.AlphaNumeric(10);
            string merchantKey = _faker.Random.AlphaNumeric(16);
            string referenceNum = _faker.Random.AlphaNumeric(8);
            string chargeTotal = _faker.Finance.Amount(10, 1000, 2).ToString();
            string creditCardNumber = _faker.Finance.CreditCardNumber();
            string expMonth = _faker.Date.Future().Month.ToString("00");
            string expYear = _faker.Date.Future().Year.ToString();
            string cvvInd = "1";
            string cvvNumber = _faker.Random.Number(100, 999).ToString();
            string processorId = _faker.Random.Number(1, 10).ToString();
            int numberOfInstallments = _faker.Random.Number(1, 12);
            string chargeInterest = _faker.Random.Bool().ToString().ToLower();
            string ipAddress = _faker.Internet.Ip();

            // Create Transaction instance and point to mock server
            var transaction = new Transaction();
            transaction.Environment = _server.Urls[0];

            // Act: Process a sale transaction
            var response = transaction.Sale(
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
                ipAddress
            );

            // Assert: Verify the response using FluentAssertions
            response.Should().NotBeNull();
            response.Should().BeOfType<TransactionResponse>();

            var transactionResponse = response as TransactionResponse;
            transactionResponse.ResponseCode.Should().Be("0");
            transactionResponse.ResponseMessage.Should().Be("APPROVED");
            transactionResponse.TransactionID.Should().Be("987654321");
            transactionResponse.AuthCode.Should().Be("123456");
            transactionResponse.OrderID.Should().Be("12345");
            transactionResponse.ReferenceNum.Should().Be("REF123456");
        }

        [Fact]
        public void Sale_WithInvalidCreditCard_ShouldReturnDeclinedResponse()
        {
            // Arrange: Setup WireMock to simulate a declined transaction response
            string declinedResponse =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                <transaction-response>
                    <authCode></authCode>
                    <orderID>12345</orderID>
                    <referenceNum>REF123456</referenceNum>
                    <transactionID>987654321</transactionID>
                    <transactionTimestamp>2025-04-27T12:00:00</transactionTimestamp>
                    <responseCode>1</responseCode>
                    <responseMessage>DECLINED</responseMessage>
                    <avsResponseCode></avsResponseCode>
                    <cvvResponseCode></cvvResponseCode>
                    <processorCode>D</processorCode>
                    <processorMessage>DECLINED</processorMessage>
                    <errorMessage>Invalid credit card number</errorMessage>
                    <processorTransactionID>123456789</processorTransactionID>
                    <processorReferenceNumber>REF987654321</processorReferenceNumber>
                </transaction-response>";

            _server
                .Given(Request.Create().WithPath("/").UsingPost())
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBody(declinedResponse)
                        .WithHeader("Content-Type", "application/xml")
                );

            // Generate test data using Bogus
            string merchantId = _faker.Random.AlphaNumeric(10);
            string merchantKey = _faker.Random.AlphaNumeric(16);
            string referenceNum = _faker.Random.AlphaNumeric(8);
            string chargeTotal = _faker.Finance.Amount(10, 1000, 2).ToString();
            string creditCardNumber = "4111111111111112"; // Invalid card number
            string expMonth = _faker.Date.Future().Month.ToString("00");
            string expYear = _faker.Date.Future().Year.ToString();
            string cvvInd = "1";
            string cvvNumber = _faker.Random.Number(100, 999).ToString();
            string processorId = _faker.Random.Number(1, 10).ToString();
            int numberOfInstallments = _faker.Random.Number(1, 12);
            string chargeInterest = _faker.Random.Bool().ToString().ToLower();
            string ipAddress = _faker.Internet.Ip();

            // Create Transaction instance and point to mock server
            var transaction = new Transaction();
            transaction.Environment = _server.Urls[0];

            // Act: Process a sale transaction with invalid card
            var response = transaction.Sale(
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
                ipAddress
            );

            // Assert: Verify the response using FluentAssertions
            response.Should().NotBeNull();
            response.Should().BeOfType<TransactionResponse>();

            var transactionResponse = response as TransactionResponse;
            transactionResponse.ResponseCode.Should().Be("1");
            transactionResponse.ResponseMessage.Should().Be("DECLINED");
            transactionResponse.ErrorMessage.Should().Be("Invalid credit card number");
        }

        [Fact]
        public void Capture_WithValidTransactionId_ShouldReturnSuccessResponse()
        {
            // Arrange: Setup WireMock to simulate a successful capture response
            string captureResponse =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                <transaction-response>
                    <authCode>123456</authCode>
                    <orderID>12345</orderID>
                    <referenceNum>REF123456</referenceNum>
                    <transactionID>987654321</transactionID>
                    <transactionTimestamp>2025-04-27T12:00:00</transactionTimestamp>
                    <responseCode>0</responseCode>
                    <responseMessage>CAPTURED</responseMessage>
                    <processorCode>A</processorCode>
                    <processorMessage>APPROVED</processorMessage>
                    <errorMessage></errorMessage>
                </transaction-response>";

            _server
                .Given(Request.Create().WithPath("/").UsingPost())
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBody(captureResponse)
                        .WithHeader("Content-Type", "application/xml")
                );

            // Generate test data using Bogus
            string merchantId = _faker.Random.AlphaNumeric(10);
            string merchantKey = _faker.Random.AlphaNumeric(16);
            string transactionId = "987654321";
            string amount = _faker.Finance.Amount(10, 1000, 2).ToString();

            // Create Transaction instance and point to mock server
            var transaction = new Transaction();
            transaction.Environment = _server.Urls[0];

            // Act: Process a capture transaction
            var response = transaction.Capture(merchantId, merchantKey, transactionId, amount);

            // Assert: Verify the response using FluentAssertions
            response.Should().NotBeNull();
            response.Should().BeOfType<TransactionResponse>();

            var transactionResponse = response as TransactionResponse;
            transactionResponse.ResponseCode.Should().Be("0");
            transactionResponse.ResponseMessage.Should().Be("CAPTURED");
            transactionResponse.TransactionID.Should().Be("987654321");
        }
    }
}
