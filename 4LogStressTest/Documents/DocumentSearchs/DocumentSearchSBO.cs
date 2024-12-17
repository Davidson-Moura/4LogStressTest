using Api.Domain.SBO.Documents.DocumentSearchs.DocumentLines;

namespace Api.Domain.SBO.Documents.DocumentSearchs
{
    public class DocumentSearchSBO
    {
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public int ObjTypeId { get; set; }
        public DateTime DocDueDate { get; set; }
        public DateTime DocDate { get; set; }
        public int DaysToDelivery { get; set; }
        public string DocTime { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardFName { get; set; }
        public int? SalePersonCode { get; set; }
        public string SalePersonName { get; set; }
        public string TrnspName { get; set; }
        public decimal ItemsTotal { get; set; }
        public decimal DocTotal { get; set; }
        public decimal DocumentDiscount { get; set; }
        public decimal DocumentFreightCost { get; set; }
        public decimal GrossWeight { get; set; }
        public List<DocumentLineSearchSBO> DocumentLines { get; set; } = new List<DocumentLineSearchSBO>();

        internal void FillAdditionalExpFreight()
        {
            DocumentFreightCost = DocumentLines.Sum(x => x.LineFreightTotal ?? 0m);
        }
    }
}
