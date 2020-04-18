using MaxiPago.DataContract;
using MaxiPago.DataContract.Reports;
using System;

namespace MaxiPago.Gateway
{

    public class Report : ServiceBase
    {

        public Report()
        {
            Environment = "TEST";
        }

        private RapiRequest request;

        /// Queries a list of transactions
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string period,
            string pageSize, string startDate, string endDate, string startTime, string endTime, string orderByName,
            string orderByDirection, string startRecordNumber, string endRecordNumber)
        {
            request = new RapiRequest(merchantId, merchantKey);
            request.Command = "transactionDetailReport";

            FilterOptions filter = request.ReportRequest.FilterOptions;

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

            return new Utils().SendRequest(request, Environment) as RapiResponse;
        }

        /// Queries one transaction
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string transactionId)
        {

            request = new RapiRequest(merchantId, merchantKey);
            request.Command = "transactionDetailReport";

            FilterOptions filter = request.ReportRequest.FilterOptions;
            filter.TransactionId = transactionId;

            return new Utils().SendRequest(request, Environment) as RapiResponse;
        }

        /// Queries one or more transactions by orderId.
        public RapiResponse GetTransactionDetailReportByOrderId(string merchantId, string merchantKey, string orderId)
        {

            request = new RapiRequest(merchantId, merchantKey);
            request.Command = "transactionDetailReport";

            FilterOptions filter = request.ReportRequest.FilterOptions;
            filter.OrderId = orderId;

            return new Utils().SendRequest(request, Environment) as RapiResponse;
        }

        /// Flips through report pages
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string pageToken, string pageNumber)
        {

            request = new RapiRequest(merchantId, merchantKey);
            request.Command = "transactionDetailReport";

            FilterOptions filter = request.ReportRequest.FilterOptions;

            filter.PageToken = pageToken;
            filter.PageNumber = pageNumber;

            return new Utils().SendRequest(request, Environment) as RapiResponse;
        }

        /// Queries the status of a pending report
        public RapiResponse CheckRequestStatus(string merchantId, string merchantKey, string requestToken)
        {

            request = new RapiRequest(merchantId, merchantKey);
            request.Command = "checkRequestStatus";

            request.ReportRequest.RequestToken = requestToken;

            return new Utils().SendRequest(request, Environment) as RapiResponse;

        }

    }
}
