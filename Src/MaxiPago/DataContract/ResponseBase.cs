using MaxiPago.DataContract.NonTransactional;
using MaxiPago.DataContract.Reports;
using MaxiPago.DataContract.Transactional;

namespace MaxiPago.DataContract
{

    public abstract class ResponseBase
    {

        public bool IsTransactionResponse => this is TransactionResponse;

        public bool IsErrorResponse => this is ErrorResponse;

        public bool IsApiResponse => this is ApiResponse;

        public bool IsReportResponse => this is RapiResponse;
    }
}
