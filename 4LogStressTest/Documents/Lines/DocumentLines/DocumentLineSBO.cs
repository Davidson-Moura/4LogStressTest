using System.Collections.Generic;

namespace Api.Domain.SBO.Documents.Lines.DocumentLines
{
    public class DocumentLineSBO
    {
        public int DocEntry { get; set; }
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string LineStatus { get; set; }
        public decimal Quantity { get; set; }
        public string CodeBars { get; set; }
        public int Usage { get; set; }
        public string TaxCode { get; set; }
        public string WhsCode { get; set; }
        public int SlpCode { get; set; }
        public int? UomEntry { get; set; }
        public decimal NumPerMsr { get; set; }

        public List<BatchAndSerialSBO> SerialNumbers { get; set; } = new List<BatchAndSerialSBO>();
        public List<BatchAndSerialSBO> BatchNumbers { get; set; } = new List<BatchAndSerialSBO>();
    }
}
