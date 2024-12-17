namespace Api.Domain.ServiceLayers.Documents.Lines.TaxExtensions
{
    public class TaxExtensionSL
    {
        public string PackDescription { get; set; }
        public int? PackQuantity { get; set; }
        public string Vehicle { get; set; }
        public string VehicleState { get; set; }
        public string Carrier { get; set; }
        public int? MainUsage { get; set; }
        public string Incoterms { get; set; }
    }
}
