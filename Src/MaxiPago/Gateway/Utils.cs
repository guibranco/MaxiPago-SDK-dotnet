// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 28/02/2023
// ***********************************************************************
// <copyright file="Utils.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MaxiPago.DataContract;
using MaxiPago.DataContract.NonTransactional;
using MaxiPago.DataContract.Reports;
using MaxiPago.DataContract.Transactional;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace MaxiPago.Gateway
{

    /// <summary>
    /// Class Utils.
    /// </summary>
    internal class Utils
    {

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <param name="environment">The environment.</param>
        /// <returns>ResponseBase.</returns>
        /// <exception cref="System.Exception">The Request can not be null or empty</exception>
        /// Sends the request
        internal ResponseBase SendRequest<T>(T request, string environment)
        {

            if (request == null)
                throw new Exception("The Request can not be null or empty");

            var xml = ToXml(request);

            // Gets environment URL
            var url = GetUrl(request, environment);

            var responseContent = Post(xml, url);

            // Parses response XML
            return ParseResponse(responseContent);

        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <param name="responseContent">Content of the response.</param>
        /// <returns>ResponseBase.</returns>
        /// <exception cref="System.Exception">Unexpected response was received.</exception>
        /// Parses response XML
        private static ResponseBase ParseResponse(string responseContent)
        {
            if (responseContent.Contains("transaction-response"))
                return Serialize<TransactionResponse>(responseContent);
            if (responseContent.Contains("rapi-response"))
                return Serialize<RapiResponse>(responseContent);
            if (responseContent.Contains("api-error"))
                return Serialize<ErrorResponse>(responseContent);
            if (responseContent.Contains("api-response"))
                return Serialize<ApiResponse>(responseContent);
            throw new Exception("Unexpected response was received.");
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <param name="environment">The environment.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">You must to inform the environment. (TEST or LIVE)</exception>
        /// Gets URL
        private static string GetUrl<T>(T request, string environment)
        {
            switch (environment)
            {
                case "LIVE":
                    if (request is TransactionRequest)
                        return "https://api.maxipago.net/UniversalAPI/postXML";
                    if (request is ApiRequest)
                        return "https://api.maxipago.net/UniversalAPI/postAPI";
                    if (request is RapiRequest)
                        return "https://api.maxipago.net/ReportsAPI/servlet/ReportsAPI";
                    break;
                case "TEST":
                    if (request is TransactionRequest)
                        return "https://testapi.maxipago.net/UniversalAPI/postXML";
                    if (request is ApiRequest)
                        return "https://testapi.maxipago.net/UniversalAPI/postAPI";
                    if (request is RapiRequest)
                        return "https://testapi.maxipago.net/ReportsAPI/servlet/ReportsAPI";
                    break;
            }
            throw new Exception("You must inform the environment. (TEST or LIVE)");

        }

        /// <summary>
        /// Converts to xml.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        private static string ToXml<T>(T request)
        {
            var serializer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, request, ns);
                var result = writer.ToString();
                result = result.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", null);
                return result;
            }
        }

        /// <summary>
        /// Posts the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// Posts data to maxiPago!
        private static string Post(string xml, string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "text/xml; charset=UTF-8";

            req.Timeout = 99999;

            using (var writer = new StreamWriter(req.GetRequestStream()))
                writer.Write(xml);

            var rsp = req.GetResponse();

            string responseContent;
            using (var reader = new StreamReader(rsp.GetResponseStream() ?? throw new InvalidOperationException()))
                responseContent = reader.ReadToEnd();
            return responseContent;
        }

        /// <summary>
        /// Serializes the specified XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns>T.</returns>
        /// Serializes XML
        private static T Serialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xml)));
        }
    }
}
