namespace Api.Domain.ServiceLayers.Documents.Lines.BatchNumbers
{
    public class BatchNumberLineSL
    {
        public string BatchNumber { get;set; }
        public string ItemCode { get;set; }
        public decimal? Quantity { get;set; }
        public int SystemSerialNumber { get; internal set; }
    }
}
