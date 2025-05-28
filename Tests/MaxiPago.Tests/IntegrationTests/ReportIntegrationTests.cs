using System;
using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.Reports;
using MaxiPago.Gateway;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace MaxiPago.Tests.IntegrationTests
{
    public class ReportIntegrationTests : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly Faker _faker;

        public ReportIntegrationTests()
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
        public void GetTransactionDetailReport_ShouldReturnValidResponse()
        {
            // Arrange: Setup WireMock to simulate a successful report response
            string reportResponse =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                <rapi-response>
                    <header>
                        <errorCode>0</errorCode>
                        <errorMsg></errorMsg>
                        <command>transactionDetailReport</command>
                        <time>2025-04-27T12:00:00</time>
                    </header>
                    <result>
                        <resultSetInfo>
                            <totalNumberOfRecords>2</totalNumberOfRecords>
                            <pageToken>1</pageToken>
                            <pageNumber>1</pageNumber>
                        </resultSetInfo>
                        <records>
                            <record>
                                <transactionId>123456</transactionId>
                                <transactionDate>2025-04-26T10:30:00</transactionDate>
                                <referenceNumber>REF123456</referenceNumber>
                                <customerName>John Doe</customerName>
                                <transactionType>SALE</transactionType>
                                <paymentType>CREDITCARD</paymentType>
                                <cardNumber>411111******1111</cardNumber>
                                <amount>100.00</amount>
                                <status>APPROVED</status>
                            </record>
                            <record>
                                <transactionId>123457</transactionId>
                                <transactionDate>2025-04-26T11:45:00</transactionDate>
                                <referenceNumber>REF123457</referenceNumber>
                                <customerName>Jane Smith</customerName>
                                <transactionType>SALE</transactionType>
                                <paymentType>CREDITCARD</paymentType>
                                <cardNumber>511111******1111</cardNumber>
                                <amount>150.00</amount>
                                <status>APPROVED</status>
                            </record>
                        </records>
                    </result>
                </rapi-response>";

            _server
                .Given(Request.Create().WithPath("/").UsingPost())
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBody(reportResponse)
                        .WithHeader("Content-Type", "application/xml")
                );

            // Generate test data using Bogus
            string merchantId = _faker.Random.AlphaNumeric(10);
            string merchantKey = _faker.Random.AlphaNumeric(16);
            string period = "today";
            string pageSize = "10";
            string startDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string endDate = DateTime.Now.ToString("yyyy-MM-dd");
            string startTime = "00:00:00";
            string endTime = "23:59:59";
            string orderByName = "transactionDate";
            string orderByDirection = "desc";
            string startRecordNumber = "1";
            string endRecordNumber = "10";

            // Create Report instance and point to mock server
            var report = new Report();
            report.Environment = _server.Urls[0];

            // Act: Get transaction detail report
            var response = report.GetTransactionDetailReport(
                merchantId,
                merchantKey,
                period,
                pageSize,
                startDate,
                endDate,
                startTime,
                endTime,
                orderByName,
                orderByDirection,
                startRecordNumber,
                endRecordNumber
            );

            // Assert: Verify the response using FluentAssertions
            response.Should().NotBeNull();
            response.Should().BeOfType<RapiResponse>();

            var rapiResponse = response as RapiResponse;
            rapiResponse.Header.Should().NotBeNull();
            rapiResponse.Header.ErrorCode.Should().Be("0");
            rapiResponse.Header.Command.Should().Be("transactionDetailReport");

            rapiResponse.Result.Should().NotBeNull();
            rapiResponse.Result.ResultSetInfo.Should().NotBeNull();
            rapiResponse.Result.ResultSetInfo.TotalNumberOfRecords.Should().Be("2");
            rapiResponse.Result.ResultSetInfo.PageToken.Should().Be("1");

            rapiResponse.Result.Records.Should().NotBeNull();
            rapiResponse.Result.Records.Record.Should().NotBeNull();
            rapiResponse.Result.Records.Record.Should().HaveCount(2);

            var firstRecord = rapiResponse.Result.Records.Record[0];
            firstRecord.TransactionId.Should().Be("123456");
            firstRecord.ReferenceNumber.Should().Be("REF123456");
            firstRecord.CustomerName.Should().Be("John Doe");
            firstRecord.Amount.Should().Be("100.00");
            firstRecord.Status.Should().Be("APPROVED");
        }

        [Fact]
        public void GetTransactionDetailReport_WithInvalidCredentials_ShouldReturnErrorResponse()
        {
            // Arrange: Setup WireMock to simulate an error response
            string errorResponse =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                <rapi-response>
                    <header>
                        <errorCode>1</errorCode>
                        <errorMsg>Invalid merchant credentials</errorMsg>
                        <command>transactionDetailReport</command>
                        <time>2025-04-27T12:00:00</time>
                    </header>
                </rapi-response>";

            _server
                .Given(Request.Create().WithPath("/").UsingPost())
                .RespondWith(
                    Response
                        .Create()
                        .WithStatusCode(200)
                        .WithBody(errorResponse)
                        .WithHeader("Content-Type", "application/xml")
                );

            // Generate test data using Bogus
            string merchantId = "invalid_id";
            string merchantKey = "invalid_key";
            string period = "today";
            string pageSize = "10";
            string startDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            string endDate = DateTime.Now.ToString("yyyy-MM-dd");
            string startTime = "00:00:00";
            string endTime = "23:59:59";
            string orderByName = "transactionDate";
            string orderByDirection = "desc";
            string startRecordNumber = "1";
            string endRecordNumber = "10";

            // Create Report instance and point to mock server
            var report = new Report();
            report.Environment = _server.Urls[0];

            // Act: Get transaction detail report with invalid credentials
            var response = report.GetTransactionDetailReport(
                merchantId,
                merchantKey,
                period,
                pageSize,
                startDate,
                endDate,
                startTime,
                endTime,
                orderByName,
                orderByDirection,
                startRecordNumber,
                endRecordNumber
            );

            // Assert: Verify the error response using FluentAssertions
            response.Should().NotBeNull();
            response.Should().BeOfType<RapiResponse>();

            var rapiResponse = response as RapiResponse;
            rapiResponse.Header.Should().NotBeNull();
            rapiResponse.Header.ErrorCode.Should().Be("1");
            rapiResponse.Header.ErrorMsg.Should().Be("Invalid merchant credentials");
            rapiResponse.Header.Command.Should().Be("transactionDetailReport");

            // Result should be null or empty since this is an error response
            rapiResponse.Result.Should().BeNull();
        }
    }
}
