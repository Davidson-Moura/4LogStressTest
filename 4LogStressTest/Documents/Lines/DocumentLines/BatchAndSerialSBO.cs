namespace Api.Domain.SBO.Documents.Lines.DocumentLines
{
    public class BatchAndSerialSBO
    {
        public int SysNumber { get; set; }
        public string DistNumber { get; set; }
        public string ItemCode { get; set; }
        public int DocLine { get; set; }
        public decimal Quantity { get; set; }
        public string ManBtchNum { get; set; }
        public string ManSerNum { get; set; }
    }
}
