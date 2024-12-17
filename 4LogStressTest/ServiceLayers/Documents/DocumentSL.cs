using Api.Domain.ServiceLayers.Documents.Lines.DocumentInstallments;
using Api.Domain.ServiceLayers.Documents.Lines.AdditionalExpenses;
using Api.Domain.ServiceLayers.Documents.Lines.TaxExtensions;
using Api.Domain.ServiceLayers.Documents.Lines.DocumentLines;
using System.Collections.Generic;
using Api.Domain.SBO;
using System;

namespace Api.Domain.ServiceLayers.Documents
{
    public interface IDocumentSL
    {
        int DocEntry { get; set; }
        //int DocNum { get; set; }
        int? BPL_IDAssignedToInvoice { get; set; }
        string CardCode { get; set; }
        string CardName { get; set; }
        string Project { get; set; }
        DateTime? DocDate { get; set; }
        DateTime? TaxDate { get; set; }
        DateTime? DocDueDate { get; set; }
        int? PaymentGroupCode { get; set; }
        string PaymentMethod { get; set; }
        int? NumberOfInstallments { get; set; }
        string Comments { get; set; }
        string Cancelled { get; set; }
        int? DocumentsOwner { get; set; }
        int? GroupNumber { get; set; }
        string NumAtCard { get; set; }
        int? SalesPersonCode { get; set; }
        string Indicator { get; set; }
        int? SequenceCode { get; set; }
        TaxExtensionSL TaxExtension { get; set; }
        List<DocumentInstallmentSL> DocumentInstallments { get; set; }
        List<DocumentLineSL> DocumentLines { get; set; }
        List<AdditionalExpenseSL> DocumentAdditionalExpenses { get; set; }
        string U_SEQCODENFE { get; set; }
        string U_WB_RouteNumber { get; set; }
        string GetPathSL();
    }
}
