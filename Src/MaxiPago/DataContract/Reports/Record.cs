// ***********************************************************************
// Assembly         : MaxiPago
// Author           : Guilherme Branco Stracini
// Created          : 16/01/2023
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 16/01/2023
// ***********************************************************************
// <copyright file="Record.cs" company="Guilherme Branco Stracini ME">
//     © 2023 Guilherme Branco Stracini. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Xml.Serialization;

namespace MaxiPago.DataContract.Reports
{
    /// <summary>
    /// Class Record.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "record")]
    public class Record
    {
        /// <summary>
        /// Gets or sets the approval code.
        /// </summary>
        /// <value>The approval code.</value>
        [XmlElement("approvalCode")]
        public string ApprovalCode { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        [XmlElement("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        [XmlElement("companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the credit card.
        /// </summary>
        /// <value>The type of the credit card.</value>
        [XmlElement("creditCardType")]
        public string CreditCardType { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [XmlElement("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>The reference number.</value>
        [XmlElement("referenceNumber")]
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the payment.
        /// </summary>
        /// <value>The type of the payment.</value>
        [XmlElement("paymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        /// Gets or sets the recurring payment flag.
        /// </summary>
        /// <value>The recurring payment flag.</value>
        [XmlElement("recurringPaymentFlag")]
        public string RecurringPaymentFlag { get; set; }

        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>The response code.</value>
        [XmlElement("responseCode")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <value>The transaction amount.</value>
        [XmlElement("transactionAmount")]
        public string TransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>The transaction identifier.</value>
        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction status.
        /// </summary>
        /// <value>The transaction status.</value>
        [XmlElement("transactionStatus")]
        public string TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets the state of the transaction.
        /// </summary>
        /// <value>The state of the transaction.</value>
        [XmlElement("transactionState")]
        public string TransactionState { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>The type of the transaction.</value>
        [XmlElement("transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>The transaction date.</value>
        [XmlElement("transactionDate")]
        public string TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the avs response code.
        /// </summary>
        /// <value>The avs response code.</value>
        [XmlElement("avsResponseCode")]
        public string AvsResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the billing address1.
        /// </summary>
        /// <value>The billing address1.</value>
        [XmlElement("billingAddress1")]
        public string BillingAddress1 { get; set; }

        /// <summary>
        /// Gets or sets the billing address2.
        /// </summary>
        /// <value>The billing address2.</value>
        [XmlElement("billingAddress2")]
        public string BillingAddress2 { get; set; }

        /// <summary>
        /// Gets or sets the billing city.
        /// </summary>
        /// <value>The billing city.</value>
        [XmlElement("billingCity")]
        public string BillingCity { get; set; }

        /// <summary>
        /// Gets or sets the billing country.
        /// </summary>
        /// <value>The billing country.</value>
        [XmlElement("billingCountry")]
        public string BillingCountry { get; set; }

        /// <summary>
        /// Gets or sets the billing email.
        /// </summary>
        /// <value>The billing email.</value>
        [XmlElement("billingEmail")]
        public string BillingEmail { get; set; }

        /// <summary>
        /// Gets or sets the name of the billing.
        /// </summary>
        /// <value>The name of the billing.</value>
        [XmlElement("billingName")]
        public string BillingName { get; set; }

        /// <summary>
        /// Gets or sets the billing phone.
        /// </summary>
        /// <value>The billing phone.</value>
        [XmlElement("billingPhone")]
        public string BillingPhone { get; set; }

        /// <summary>
        /// Gets or sets the state of the billing.
        /// </summary>
        /// <value>The state of the billing.</value>
        [XmlElement("billingState")]
        public string BillingState { get; set; }

        /// <summary>
        /// Gets or sets the billing zip.
        /// </summary>
        /// <value>The billing zip.</value>
        [XmlElement("billingZip")]
        public string BillingZip { get; set; }

        /// <summary>
        /// Gets or sets the boleto number.
        /// </summary>
        /// <value>The boleto number.</value>
        [XmlElement("boletoNumber")]
        public string BoletoNumber { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>The expiration date.</value>
        [XmlElement("expirationDate")]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the date of payment.
        /// </summary>
        /// <value>The date of payment.</value>
        [XmlElement("dateOfPayment")]
        public string DateOfPayment { get; set; }

        /// <summary>
        /// Data de liquidação do valor, se o banco a informou. Formato mm/dd/aaaa
        /// </summary>
        /// <value>The date of funding.</value>
        [XmlElement("dateOfFunding")]
        public string DateOfFunding { get; set; }

        /// <summary>
        /// Código FEBRABAN do banco onde foi feito o pagamento.
        /// </summary>
        /// <value>The bank of payment.</value>
        [XmlElement("bankOfPayment")]
        public string BankOfPayment { get; set; }

        /// <summary>
        /// Agência onde foi feito o pagamento.
        /// </summary>
        /// <value>The branch of payment.</value>
        [XmlElement("branchOfPayment")]
        public string BranchOfPayment { get; set; }

        /// <summary>
        /// Valor pago pelo cliente.
        /// </summary>
        /// <value>The paid amount.</value>
        [XmlElement("paidAmount")]
        public string PaidAmount { get; set; }

        /// <summary>
        /// Taxa de cobrança do boleto, se o banco a informou.
        /// </summary>
        /// <value>The bank fee.</value>
        [XmlElement("bankFee")]
        public string BankFee { get; set; }

        /// <summary>
        /// Valor líquido a receber (valor pago - taxa)
        /// </summary>
        /// <value>The net amount.</value>
        [XmlElement("netAmount")]
        public string NetAmount { get; set; }

        /// <summary>
        /// Código de pagamento do boleto no banco.
        /// </summary>
        /// <value>The return code.</value>
        [XmlElement("returnCode")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// Código de liquidação do banco, se informado.
        /// </summary>
        /// <value>The clearing code.</value>
        [XmlElement("clearingCode")]
        public string ClearingCode { get; set; }

        /// <summary>
        /// Código do meio de pagamento.
        /// </summary>
        /// <value>The processor identifier.</value>
        [XmlElement("processorID")]
        public string ProcessorId { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        /// <value>The custom field1.</value>
        [XmlElement("customField1")]
        public string CustomField1 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        /// <value>The custom field2.</value>
        [XmlElement("customField2")]
        public string CustomField2 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        /// <value>The custom field3.</value>
        [XmlElement("customField3")]
        public string CustomField3 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        /// <value>The custom field4.</value>
        [XmlElement("customField4")]
        public string CustomField4 { get; set; }

        /// <summary>
        /// Campo livre.
        /// </summary>
        /// <value>The custom field5.</value>
        [XmlElement("customField5")]
        public string CustomField5 { get; set; }

        /// <summary>
        /// Url para imprimir o boleto.
        /// </summary>
        /// <value>The boleto URL.</value>
        [XmlElement("boletoUrl")]
        public string BoletoUrl { get; set; }

        /// <summary>
        /// Número de parcelas.
        /// </summary>
        /// <value>The number of installments.</value>
        [XmlElement("numberOfInstallments")]
        public string NumberOfInstallments { get; set; }

        /// <summary>
        /// Juros.
        /// </summary>
        /// <value>The charge interest.</value>
        [XmlElement("chargeInterest")]
        public string ChargeInterest { get; set; }
    }
}
