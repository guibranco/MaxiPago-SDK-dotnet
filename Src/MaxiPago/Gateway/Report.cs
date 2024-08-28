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
        /// Retrieves the transaction detail report for a specified merchant.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="pageToken">The token for pagination to retrieve specific pages of the report.</param>
        /// <param name="pageNumber">The number of the page to retrieve from the report.</param>
        /// <returns>A <see cref="RapiResponse"/> object containing the transaction detail report data.</returns>
        /// <remarks>
        /// This method constructs a request to obtain a transaction detail report by initializing a
        /// <see cref="RapiRequest"/> object with the provided merchant credentials and setting the
        /// appropriate command and filter options for pagination. It then sends the request using
        /// the <see cref="Utils.SendRequest"/> method, which communicates with the relevant service
        /// and returns the response. The response is cast to a <see cref="RapiResponse"/> type,
        /// which contains the details of the transaction report requested.
        /// </remarks>
        public RapiResponse GetTransactionDetailReport(
            string merchantId,
            string merchantKey,
            string period,
            string pageSize,
            string startDate,
            string endDate,
            string startTime,
            string endTime,
            string orderByName,
            string orderByDirection,
            string startRecordNumber,
            string endRecordNumber
        )
        {
            _request = new RapiRequest(merchantId, merchantKey)
            {
                Command = "transactionDetailReport",
            };

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
        public RapiResponse GetTransactionDetailReport(
            string merchantId,
            string merchantKey,
            string transactionId
        )
        {
            _request = new RapiRequest(merchantId, merchantKey)
            {
                Command = "transactionDetailReport",
            };
            _request.ReportRequest.FilterOptions.TransactionId = transactionId;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// <summary>
        /// Retrieves the transaction detail report for a specific order ID.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="orderId">The unique identifier for the order whose transaction details are to be retrieved.</param>
        /// <returns>A <see cref="RapiResponse"/> object containing the transaction detail report for the specified order ID.</returns>
        /// <remarks>
        /// This method constructs a request to fetch the transaction detail report by setting up a new instance of
        /// <see cref="RapiRequest"/> with the provided merchant ID and key. It specifies the command as
        /// "transactionDetailReport" and applies a filter based on the provided order ID. The request is then sent
        /// using the <see cref="Utils.SendRequest"/> method, which handles the communication with the relevant
        /// service. The response is cast to a <see cref="RapiResponse"/> type, which contains the details of the
        /// transaction report.
        /// </remarks>
        public RapiResponse GetTransactionDetailReportByOrderId(
            string merchantId,
            string merchantKey,
            string orderId
        )
        {
            _request = new RapiRequest(merchantId, merchantKey)
            {
                Command = "transactionDetailReport",
            };
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
        public RapiResponse GetTransactionDetailReport(
            string merchantId,
            string merchantKey,
            string pageToken,
            string pageNumber
        )
        {
            _request = new RapiRequest(merchantId, merchantKey)
            {
                Command = "transactionDetailReport",
            };
            _request.ReportRequest.FilterOptions.PageToken = pageToken;
            _request.ReportRequest.FilterOptions.PageNumber = pageNumber;

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }

        /// <summary>
        /// Checks the status of a request using the provided merchant credentials and request token.
        /// </summary>
        /// <param name="merchantId">The unique identifier for the merchant.</param>
        /// <param name="merchantKey">The key associated with the merchant for authentication.</param>
        /// <param name="requestToken">The token representing the specific request whose status is to be checked.</param>
        /// <returns>A <see cref="RapiResponse"/> object containing the status of the request.</returns>
        /// <remarks>
        /// This method creates a new instance of <see cref="RapiRequest"/> with the specified merchant ID and key,
        /// and sets the command to "checkRequestStatus". It then populates the request with the provided request token.
        /// Finally, it sends the request using the <see cref="Utils.SendRequest"/> method and returns the response as a <see cref="RapiResponse"/>.
        /// This allows the caller to determine the current status of the request identified by the given token.
        /// </remarks>
        public RapiResponse CheckRequestStatus(
            string merchantId,
            string merchantKey,
            string requestToken
        )
        {
            _request = new RapiRequest(merchantId, merchantKey)
            {
                Command = "checkRequestStatus",
                ReportRequest = { RequestToken = requestToken },
            };

            return new Utils().SendRequest(_request, Environment) as RapiResponse;
        }
    }
}
