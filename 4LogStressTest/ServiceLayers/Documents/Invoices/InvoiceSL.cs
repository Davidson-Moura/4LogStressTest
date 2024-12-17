﻿using Api.Domain.ServiceLayers.Documents.Lines.DocumentInstallments;
using Api.Domain.ServiceLayers.Documents.Lines.DownPaymentsToDraws;
using Api.Domain.ServiceLayers.Documents.Lines.AdditionalExpenses;
using Api.Domain.ServiceLayers.Documents.Lines.TaxExtensions;
using Api.Domain.ServiceLayers.Documents.Lines.DocumentLines;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Api.Domain.SBO;
using System;

namespace Api.Domain.ServiceLayers.Documents.Invoices
{
    public class InvoiceSL : IDocumentSL
    {
        public string GetPathSL() => "Invoices";
        public int DocEntry { get; set; }
        //public int DocNum { get; set; }
        public int? BPL_IDAssignedToInvoice { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Project { get; set; }
        public DateTime? DocDate { get; set; } = DateTime.Now;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? TaxDate { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DocDueDate { get; set; } = null;
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
        public List<DownPaymentsToDrawSL> DownPaymentsToDraw { get; set; }
        public List<AdditionalExpenseSL> DocumentAdditionalExpenses { get; set; }
        public string U_SEQCODENFE { get; set; }
        public string U_WB_RouteNumber { get; set; }
    }
}
