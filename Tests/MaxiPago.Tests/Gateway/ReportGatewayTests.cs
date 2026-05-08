using Bogus;
using FluentAssertions;
using MaxiPago.DataContract.Reports;
using MaxiPago.Gateway;
using NSubstitute;
using Xunit;

namespace MaxiPago.Tests.Gateway
{
    public class ReportGatewayTests
    {
        private static readonly Faker Faker = new();
        private readonly IUtils _utils;
        private readonly Report _report;

        public ReportGatewayTests()
        {
            _utils = Substitute.For<IUtils>();
            _report = new Report(_utils);
        }

        private static string MerchantId() => Faker.Random.AlphaNumeric(8);

        private static string MerchantKey() => Faker.Random.AlphaNumeric(32);

        private void SetupRapiResponse() =>
            _utils
                .SendRequest(Arg.Any<RapiRequest>(), Arg.Any<string>())
                .Returns(new RapiResponse());

        // ── environment ───────────────────────────────────────────────────────

        [Fact]
        public void DefaultConstructor_SetsEnvironmentToTest()
        {
            var report = new Report();
            report.Environment.Should().Be("TEST");
        }

        [Fact]
        public void InjectedConstructor_SetsEnvironmentToTest()
        {
            _report.Environment.Should().Be("TEST");
        }

        // ── GetTransactionDetailReport (full filter) ──────────────────────────

        [Fact]
        public void GetTransactionDetailReport_FullFilter_SendsTransactionDetailReportCommand()
        {
            SetupRapiResponse();

            _report.GetTransactionDetailReport(
                MerchantId(),
                MerchantKey(),
                "today",
                "25",
                "2024-01-01",
                "2024-01-31",
                "00:00:00",
                "23:59:59",
                "transactionDate",
                "asc",
                "0",
                "24"
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r => r.Command == "transactionDetailReport"),
                    "TEST"
                );
        }

        [Fact]
        public void GetTransactionDetailReport_FullFilter_PopulatesFilterOptions()
        {
            SetupRapiResponse();
            var startDate = "2024-01-01";
            var endDate = "2024-01-31";
            var pageSize = "50";

            _report.GetTransactionDetailReport(
                MerchantId(),
                MerchantKey(),
                "today",
                pageSize,
                startDate,
                endDate,
                "00:00:00",
                "23:59:59",
                "transactionDate",
                "asc",
                "0",
                "49"
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r =>
                        r.ReportRequest.FilterOptions.StartDate == startDate
                        && r.ReportRequest.FilterOptions.EndDate == endDate
                        && r.ReportRequest.FilterOptions.PageSize == pageSize
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void GetTransactionDetailReport_FullFilter_SetsOrderByFields()
        {
            SetupRapiResponse();

            _report.GetTransactionDetailReport(
                MerchantId(),
                MerchantKey(),
                "today",
                "25",
                "2024-01-01",
                "2024-01-31",
                "00:00:00",
                "23:59:59",
                "transactionDate",
                "desc",
                "0",
                "24"
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r =>
                        r.ReportRequest.FilterOptions.OrderByName == "transactionDate"
                        && r.ReportRequest.FilterOptions.OrderByDirection == "desc"
                    ),
                    Arg.Any<string>()
                );
        }

        [Fact]
        public void GetTransactionDetailReport_FullFilter_ReturnsRapiResponse()
        {
            var expected = new RapiResponse();
            _utils.SendRequest(Arg.Any<RapiRequest>(), Arg.Any<string>()).Returns(expected);

            var result = _report.GetTransactionDetailReport(
                MerchantId(),
                MerchantKey(),
                "today",
                "25",
                "2024-01-01",
                "2024-01-31",
                "00:00:00",
                "23:59:59",
                "transactionDate",
                "asc",
                "0",
                "24"
            );

            result.Should().BeSameAs(expected);
            result.IsReportResponse.Should().BeTrue();
        }

        // ── GetTransactionDetailReport (by transactionId) ─────────────────────

        [Fact]
        public void GetTransactionDetailReport_ByTransactionId_SetsTransactionIdFilter()
        {
            SetupRapiResponse();
            var transactionId = Faker.Random.AlphaNumeric(15);

            _report.GetTransactionDetailReport(MerchantId(), MerchantKey(), transactionId);

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r =>
                        r.Command == "transactionDetailReport"
                        && r.ReportRequest.FilterOptions.TransactionId == transactionId
                    ),
                    "TEST"
                );
        }

        // ── GetTransactionDetailReportByOrderId ───────────────────────────────

        [Fact]
        public void GetTransactionDetailReportByOrderId_SetsOrderIdFilter()
        {
            SetupRapiResponse();
            var orderId = Faker.Random.AlphaNumeric(12);

            _report.GetTransactionDetailReportByOrderId(MerchantId(), MerchantKey(), orderId);

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r =>
                        r.Command == "transactionDetailReport"
                        && r.ReportRequest.FilterOptions.OrderId == orderId
                    ),
                    "TEST"
                );
        }

        // ── GetTransactionDetailReport (pagination) ───────────────────────────

        [Fact]
        public void GetTransactionDetailReport_Pagination_SetsPageTokenAndNumber()
        {
            SetupRapiResponse();
            var pageToken = Faker.Random.AlphaNumeric(20);
            var pageNumber = "2";

            _report.GetTransactionDetailReport(MerchantId(), MerchantKey(), pageToken, pageNumber);

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r =>
                        r.Command == "transactionDetailReport"
                        && r.ReportRequest.FilterOptions.PageToken == pageToken
                        && r.ReportRequest.FilterOptions.PageNumber == pageNumber
                    ),
                    "TEST"
                );
        }

        // ── CheckRequestStatus ────────────────────────────────────────────────

        [Fact]
        public void CheckRequestStatus_SendsCheckRequestStatusCommand()
        {
            SetupRapiResponse();
            var requestToken = Faker.Random.AlphaNumeric(30);

            _report.CheckRequestStatus(MerchantId(), MerchantKey(), requestToken);

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r =>
                        r.Command == "checkRequestStatus"
                        && r.ReportRequest.RequestToken == requestToken
                    ),
                    "TEST"
                );
        }

        [Fact]
        public void CheckRequestStatus_ReturnsRapiResponse()
        {
            var expected = new RapiResponse();
            _utils.SendRequest(Arg.Any<RapiRequest>(), Arg.Any<string>()).Returns(expected);

            var result = _report.CheckRequestStatus(
                MerchantId(),
                MerchantKey(),
                Faker.Random.AlphaNumeric(30)
            );

            result.Should().BeSameAs(expected);
        }

        // ── Environment propagation ───────────────────────────────────────────

        [Fact]
        public void AllMethods_UseConfiguredEnvironment()
        {
            SetupRapiResponse();
            _report.Environment = "LIVE";

            _report.CheckRequestStatus(MerchantId(), MerchantKey(), Faker.Random.AlphaNumeric(30));

            _utils.Received(1).SendRequest(Arg.Any<RapiRequest>(), "LIVE");
        }

        // ── Merchant credentials propagation ──────────────────────────────────

        [Fact]
        public void GetTransactionDetailReport_ByTransactionId_SetsMerchantCredentials()
        {
            SetupRapiResponse();
            var merchantId = MerchantId();
            var merchantKey = MerchantKey();

            _report.GetTransactionDetailReport(
                merchantId,
                merchantKey,
                Faker.Random.AlphaNumeric(15)
            );

            _utils
                .Received(1)
                .SendRequest(
                    Arg.Is<RapiRequest>(r =>
                        r.Verification.MerchantId == merchantId
                        && r.Verification.MerchantKey == merchantKey
                    ),
                    Arg.Any<string>()
                );
        }
    }
}
