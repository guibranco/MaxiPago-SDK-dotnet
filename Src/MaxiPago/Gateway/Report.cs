// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Report.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MaxiPago.DataContract;
using MaxiPago.DataContract.Reports;

namespace MaxiPago.Gateway
{

    /// <summary>
    /// Class Report.
    /// Implements the <see cref="ServiceBase" />
    /// </summary>
    /// <seealso cref="ServiceBase" />
    public class Report : ServiceBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Report"/> class.
        /// </summary>
        public Report()
        {
            Environment = "TEST";
        }

        /// <summary>
        /// The request
        /// </summary>
        private RapiRequest _request;

        /// <summary>
        /// Gets the transaction detail report.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="period">The period.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="orderByName">Name of the order by.</param>
        /// <param name="orderByDirection">The order by direction.</param>
        /// <param name="startRecordNumber">The start record number.</param>
        /// <param name="endRecordNumber">The end record number.</param>
        /// <returns>RapiResponse.</returns>
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

        /// <summary>
        /// Gets the transaction detail report.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>RapiResponse.</returns>
        /// Queries one transaction
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string transactionId)
        {

            _request = new RapiRequest(merchantId, merchantKey) { Command = "transactionDetailReport" };
            _request.ReportRequest.FilterOptions.TransactionId = transactionId;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// <summary>
        /// Gets the transaction detail report by order identifier.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>RapiResponse.</returns>
        /// Queries one or more transactions by orderId.
        public RapiResponse GetTransactionDetailReportByOrderId(string merchantId, string merchantKey, string orderId)
        {

            _request = new RapiRequest(merchantId, merchantKey) { Command = "transactionDetailReport" };
            _request.ReportRequest.FilterOptions.OrderId = orderId;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// <summary>
        /// Gets the transaction detail report.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="pageToken">The page token.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns>RapiResponse.</returns>
        /// Flips through report pages
        public RapiResponse GetTransactionDetailReport(string merchantId, string merchantKey, string pageToken, string pageNumber)
        {

            _request = new RapiRequest(merchantId, merchantKey) { Command = "transactionDetailReport" };
            _request.ReportRequest.FilterOptions.PageToken = pageToken;
            _request.ReportRequest.FilterOptions.PageNumber = pageNumber;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// <summary>
        /// Checks the request status.
        /// </summary>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="merchantKey">The merchant key.</param>
        /// <param name="requestToken">The request token.</param>
        /// <returns>RapiResponse.</returns>
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
