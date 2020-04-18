using MaxiPago.DataContract;
using MaxiPago.DataContract.Reports;

namespace MaxiPago.Gateway
{

    public class Report : ServiceBase
    {

        public Report()
        {
            Environment = "TEST";
        }

        private RapiRequest _request;

        /// Queries a list of transactions
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string period,
            string pageSize, string startDate, string endDate, string startTime, string endTime, string orderByName,
            string orderByDirection, string startRecordNumber, string endRecordNumber)
        {
            _request = new RapiRequest(merchantId, merchantKey) { Command = "transactionDetailReport" };

            var filter = _request.ReportRequest.FilterOptions;

            filter.Period = period;
            filter.PageSize = pageSize;
            filter.StartDate = startDate;
            filter.EndDate = endDate;
            filter.StartTime = startTime;
            filter.EndTime = endTime;
            filter.OrderByName = orderByName;
            filter.OrderByDirection = orderByDirection;
            filter.StartRecordNumber = startRecordNumber;
            filter.EndRecordNumber = endRecordNumber;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// Queries one transaction
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string transactionId)
        {

            _request = new RapiRequest(merchantId, merchantKey) { Command = "transactionDetailReport" };
            _request.ReportRequest.FilterOptions.TransactionId = transactionId;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// Queries one or more transactions by orderId.
        public RapiResponse GetTransactionDetailReportByOrderId(string merchantId, string merchantKey, string orderId)
        {

            _request = new RapiRequest(merchantId, merchantKey) { Command = "transactionDetailReport" };
            _request.ReportRequest.FilterOptions.OrderId = orderId;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// Flips through report pages
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string pageToken, string pageNumber)
        {

            _request = new RapiRequest(merchantId, merchantKey) { Command = "transactionDetailReport" };
            _request.ReportRequest.FilterOptions.PageToken = pageToken;
            _request.ReportRequest.FilterOptions.PageNumber = pageNumber;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// Queries the status of a pending report
        public RapiResponse CheckRequestStatus(string merchantId, string merchantKey, string requestToken)
        {

            _request = new RapiRequest(merchantId, merchantKey)
            {
                Command = "checkRequestStatus",
                ReportRequest = { RequestToken = requestToken }
            };


            return new Utils().SendRequest(_request, Environment) as RapiResponse;

        }

    }
}
