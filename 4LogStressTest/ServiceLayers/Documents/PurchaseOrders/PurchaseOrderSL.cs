using Api.Domain.ServiceLayers.Documents.Lines.DocumentInstallments;
using Api.Domain.ServiceLayers.Documents.Lines.AdditionalExpenses;
using Api.Domain.ServiceLayers.Documents.Lines.TaxExtensions;
using Api.Domain.ServiceLayers.Documents.Lines.DocumentLines;
using Api.Domain.ServiceLayers.Documents;
using System.Collections.Generic;
using Api.Domain.SBO;
using System;

namespace RouteOne.DI.ServiceLayers.Entities.Documents.PurchaseOrders
{
    public class PurchaseOrderSL : IDocumentSL
    {
        public string GetPathSL() => "PurchaseOrders";
        public int DocEntry { get; set; }
        //public int DocNum { get; set; }
        public int? BPL_IDAssignedToInvoice { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Project { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? TaxDate { get; set; }
        public DateTime? DocDueDate { get; set; }
        public int? PaymentGroupCode { get; set; }
        public string PaymentMethod { get; set; }
        public int? NumberOfInstallments { get; set; }
        public string Comments { get; set; }
        public string Cancelled { get; set; }
        public int? DocumentsOwner { get; set; }
        public int? GroupNumber { get; set; }
        public string NumAtCard { get; set; }
        public int? SalesPersonCode { get; set; }
        public string Indicator { get; set; }
        public int? SequenceCode { get; set; }
        public TaxExtensionSL TaxExtension { get; set; }
        public List<DocumentInstallmentSL> DocumentInstallments { get; set; }
        public List<DocumentLineSL> DocumentLines { get; set; }
        public List<AdditionalExpenseSL> DocumentAdditionalExpenses { get; set; }
        public string U_SEQCODENFE { get; set; }
        public string U_WB_RouteNumber { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
