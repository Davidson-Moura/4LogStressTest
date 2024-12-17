using Api.Domain.SBO.Documents.Lines.AdditionalExpenses;
using Api.Domain.SBO.Documents.Lines.DocumentLines;
using Api.Domain.SBO.Documents.Lines.TaxExtensions;
using System.Collections.Generic;
using System;

namespace Api.Domain.SBO.Documents
{
    public class DocumentSBO
    {
        public int DocEntry { get; set; }
        public int ObjType { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public string DocStatus { get; set; }
        public int? BPLId { get; set; }
        public int? OwnerCode { get; set; }
        public int? GroupNum { get; set; }
        public string PeyMethod { get; set; }
        public string NumAtCard { get; set; }
        public int? SplCode { get; set; }
        public string Indicator { get; set; }
        public int? PQTGrpNum { get; set; }
        public string Cancelled { get; set; }

        public List<DocumentLineSBO> DocumentLines { get; set; } = new List<DocumentLineSBO>();
        public TaxExtensionSBO TaxExtension { get; set; }
        public List<AdditionalExpenseSBO> AdditionalExpenses { get; set; } = new List<AdditionalExpenseSBO>();
        public string U_SEQCODENFE { get; set; }
    }
}
