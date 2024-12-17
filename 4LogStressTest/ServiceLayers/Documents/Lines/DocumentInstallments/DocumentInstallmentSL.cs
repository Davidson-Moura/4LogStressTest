using System;

namespace Api.Domain.ServiceLayers.Documents.Lines.DocumentInstallments
{
    public class DocumentInstallmentSL
    {
        public DateTime? DueDate { get; set; }
        public decimal Percentage { get; set; }
    }
}
