using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{

    [Serializable]
    [XmlRoot(ElementName = "filterOptions")]
    public class FilterOptions
    {

        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("period")]
        public string Period { get; set; }

        [XmlElement("pageSize")]
        public string PageSize { get; set; }

        [XmlElement("startDate")]
        public string StartDate { get; set; }

        [XmlElement("endDate")]
        public string EndDate { get; set; }

        [XmlElement("startTime")]
        public string StartTime { get; set; }

        [XmlElement("endTime")]
        public string EndTime { get; set; }

        [XmlElement("orderByName")]
        public string OrderByName { get; set; }

        [XmlElement("orderByDirection")]
        public string OrderByDirection { get; set; }

        [XmlElement("startRecordNumber")]
        public string StartRecordNumber { get; set; }

        [XmlElement("endRecordNumber")]
        public string EndRecordNumber { get; set; }

        [XmlElement("pageNumber")]
        public string PageNumber { get; set; }

        [XmlElement("pageToken")]
        public string PageToken { get; set; }

    }
}
