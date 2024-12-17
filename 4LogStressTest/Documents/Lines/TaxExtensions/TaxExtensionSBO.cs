namespace Api.Domain.SBO.Documents.Lines.TaxExtensions
{
    public class TaxExtensionSBO
    {
        public int DocEntry { get; set; }
        public string PackDesc { get; set; }
        public int? QoP { get; set; }
        public string Carrier { get; set; }
        public int MainUsage { get; set; }
        public string Incoterms { get; set; }
    }
}
