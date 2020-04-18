using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{

    [Serializable]
    [XmlRoot(ElementName = "record")]
    public class Record
    {

        [XmlElement("approvalCode")]
        public string ApprovalCode { get; set; }

        [XmlElement("comments")]
        public string Comments { get; set; }

        [XmlElement("companyName")]
        public string CompanyName { get; set; }

        [XmlElement("creditCardType")]
        public string CreditCardType { get; set; }

        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [XmlElement("paymentType")]
        public string PaymentType { get; set; }

        [XmlElement("recurringPaymentFlag")]
        public string RecurringPaymentFlag { get; set; }

        [XmlElement("responseCode")]
        public string ResponseCode { get; set; }

        [XmlElement("transactionAmount")]
        public string TransactionAmount { get; set; }

        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        [XmlElement("transactionStatus")]
        public string TransactionStatus { get; set; }

        [XmlElement("transactionState")]
        public string TransactionState { get; set; }

        [XmlElement("transactionType")]
        public string TransactionType { get; set; }

        [XmlElement("transactionDate")]
        public string TransactionDate { get; set; }

        [XmlElement("avsResponseCode")]
        public string AvsResponseCode { get; set; }

        [XmlElement("billingAddress1")]
        public string BillingAddress1 { get; set; }

        [XmlElement("billingAddress2")]
        public string BillingAddress2 { get; set; }

        [XmlElement("billingCity")]
        public string BillingCity { get; set; }

        [XmlElement("billingCountry")]
        public string BillingCountry { get; set; }

        [XmlElement("billingEmail")]
        public string BillingEmail { get; set; }

        [XmlElement("billingName")]
        public string BillingName { get; set; }

        [XmlElement("billingPhone")]
        public string BillingPhone { get; set; }

        [XmlElement("billingState")]
        public string BillingState { get; set; }

        [XmlElement("billingZip")]
        public string BillingZip { get; set; }

        [XmlElement("boletoNumber")]
        public string BoletoNumber { get; set; }

        [XmlElement("expirationDate")]
        public string ExpirationDate { get; set; }

        [XmlElement("dateOfPayment")]
        public string DateOfPayment { get; set; }

        /// <summary>
        /// Data de liquidação do valor, se o banco a informou. Formato mm/dd/aaaa
        /// </summary>
        [XmlElement("dateOfFunding")]
        public string DateOfFunding { get; set; }

        /// <summary>
        /// Código FEBRABAN do banco onde foi feito o pagamento.
        /// </summary>
        [XmlElement("bankOfPayment")]
        public string BankOfPayment { get; set; }

        /// <summary>
        /// Agência onde foi feito o pagamento.
        /// </summary>
        [XmlElement("branchOfPayment")]
        public string BranchOfPayment { get; set; }

        /// <summary>
        /// Valor pago pelo cliente.
        /// </summary>
        [XmlElement("paidAmount")]
        public string PaidAmount { get; set; }

        /// <summary>
        /// Taxa de cobrança do boleto, se o banco a informou.
        /// </summary>
        [XmlElement("bankFee")]
        public string BankFee { get; set; }

        /// <summary>
        /// Valor líquido a receber (valor pago - taxa)
        /// </summary>
        [XmlElement("netAmount")]
        public string NetAmount { get; set; }

        /// <summary>
        /// Código de pagamento do boleto no banco.
        /// </summary>
        [XmlElement("returnCode")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// Código de liquidação do banco, se informado.
        /// </summary>
        [XmlElement("clearingCode")]
        public string ClearingCode { get; set; }

        /// <summary>
        /// Código do meio de pagamento.
        /// </summary>
        [XmlElement("processorID")]
        public string ProcessorId { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField1")]
        public string CustomField1 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField2")]
        public string CustomField2 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField3")]
        public string CustomField3 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField4")]
        public string CustomField4 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        [XmlElement("customField5")]
        public string CustomField5 { get; set; }

        /// <summary>
        /// Url para imprimir o boleto.
        /// </summary>
        [XmlElement("boletoUrl")]
        public string BoletoUrl { get; set; }

        /// <summary>
        /// Número de parcelas.
        /// </summary>
        [XmlElement("numberOfInstallments")]
        public string NumberOfInstallments { get; set; }

        /// <summary>
        /// Juros.
        /// </summary>
        [XmlElement("chargeInterest")]
        public string ChargeInterest { get; set; }




    }
}
