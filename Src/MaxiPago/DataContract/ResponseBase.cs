// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="ResponseBase.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MaxiPago.DataContract.NonTransactional;
using MaxiPago.DataContract.Reports;
using MaxiPago.DataContract.Transactional;

namespace MaxiPago.DataContract
{

    /// <summary>
    /// Class ResponseBase.
    /// </summary>
    public abstract class ResponseBase
    {

        /// <summary>
        /// Gets a value indicating whether this instance is transaction response.
        /// </summary>
        /// <value><c>true</c> if this instance is transaction response; otherwise, <c>false</c>.</value>
        public bool IsTransactionResponse => this is TransactionResponse;

        /// <summary>
        /// Gets a value indicating whether this instance is error response.
        /// </summary>
        /// <value><c>true</c> if this instance is error response; otherwise, <c>false</c>.</value>
        public bool IsErrorResponse => this is ErrorResponse;

        /// <summary>
        /// Gets a value indicating whether this instance is API response.
        /// </summary>
        /// <value><c>true</c> if this instance is API response; otherwise, <c>false</c>.</value>
        public bool IsApiResponse => this is ApiResponse;

        /// <summary>
        /// Gets a value indicating whether this instance is report response.
        /// </summary>
        /// <value><c>true</c> if this instance is report response; otherwise, <c>false</c>.</value>
        public bool IsReportResponse => this is RapiResponse;
    }
}
