using MaxiPago.DataContract;

namespace MaxiPago.Gateway
{
    /// <summary>
    /// Abstraction over the HTTP request/response utility used by gateway classes.
    /// Enables substitution in unit tests without hitting real endpoints.
    /// </summary>
    public interface IUtils
    {
        /// <summary>Serializes <paramref name="request"/> to XML, posts it to the MaxiPago endpoint
        /// resolved by <paramref name="environment"/>, and returns the deserialized response.</summary>
        ResponseBase SendRequest<T>(T request, string environment);
    }
}
