using FluentAssertions;
using MaxiPago.DataContract;
using MaxiPago.DataContract.NonTransactional;
using MaxiPago.DataContract.Reports;
using MaxiPago.DataContract.Transactional;
using Xunit;

namespace MaxiPago.Tests.DataContract
{
    public class ResponseBaseTests
    {
        [Fact]
        public void TransactionResponse_IsTransactionResponse_IsTrue()
        {
            var response = new TransactionResponse();
            response.IsTransactionResponse.Should().BeTrue();
        }

        [Fact]
        public void TransactionResponse_IsApiResponse_IsFalse()
        {
            var response = new TransactionResponse();
            response.IsApiResponse.Should().BeFalse();
        }

        [Fact]
        public void TransactionResponse_IsErrorResponse_IsFalse()
        {
            var response = new TransactionResponse();
            response.IsErrorResponse.Should().BeFalse();
        }

        [Fact]
        public void TransactionResponse_IsReportResponse_IsFalse()
        {
            var response = new TransactionResponse();
            response.IsReportResponse.Should().BeFalse();
        }

        [Fact]
        public void ApiResponse_IsApiResponse_IsTrue()
        {
            var response = new ApiResponse();
            response.IsApiResponse.Should().BeTrue();
        }

        [Fact]
        public void ApiResponse_IsTransactionResponse_IsFalse()
        {
            var response = new ApiResponse();
            response.IsTransactionResponse.Should().BeFalse();
        }

        [Fact]
        public void ApiResponse_IsErrorResponse_IsFalse()
        {
            var response = new ApiResponse();
            response.IsErrorResponse.Should().BeFalse();
        }

        [Fact]
        public void ApiResponse_IsReportResponse_IsFalse()
        {
            var response = new ApiResponse();
            response.IsReportResponse.Should().BeFalse();
        }

        [Fact]
        public void ErrorResponse_IsErrorResponse_IsTrue()
        {
            var response = new ErrorResponse();
            response.IsErrorResponse.Should().BeTrue();
        }

        [Fact]
        public void ErrorResponse_IsTransactionResponse_IsFalse()
        {
            var response = new ErrorResponse();
            response.IsTransactionResponse.Should().BeFalse();
        }

        [Fact]
        public void ErrorResponse_IsApiResponse_IsFalse()
        {
            var response = new ErrorResponse();
            response.IsApiResponse.Should().BeFalse();
        }

        [Fact]
        public void ErrorResponse_IsReportResponse_IsFalse()
        {
            var response = new ErrorResponse();
            response.IsReportResponse.Should().BeFalse();
        }

        [Fact]
        public void RapiResponse_IsReportResponse_IsTrue()
        {
            var response = new RapiResponse();
            response.IsReportResponse.Should().BeTrue();
        }

        [Fact]
        public void RapiResponse_IsTransactionResponse_IsFalse()
        {
            var response = new RapiResponse();
            response.IsTransactionResponse.Should().BeFalse();
        }

        [Fact]
        public void RapiResponse_IsApiResponse_IsFalse()
        {
            var response = new RapiResponse();
            response.IsApiResponse.Should().BeFalse();
        }

        [Fact]
        public void RapiResponse_IsErrorResponse_IsFalse()
        {
            var response = new RapiResponse();
            response.IsErrorResponse.Should().BeFalse();
        }

        [Fact]
        public void ResponseBase_IsAssignableFrom_AllConcreteTypes()
        {
            typeof(TransactionResponse).Should().BeAssignableTo<ResponseBase>();
            typeof(ApiResponse).Should().BeAssignableTo<ResponseBase>();
            typeof(ErrorResponse).Should().BeAssignableTo<ResponseBase>();
            typeof(RapiResponse).Should().BeAssignableTo<ResponseBase>();
        }
    }
}
