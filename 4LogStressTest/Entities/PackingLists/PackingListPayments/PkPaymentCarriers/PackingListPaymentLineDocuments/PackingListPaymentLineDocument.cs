using System;

namespace Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentLineDocuments
{
    public class PackingListPaymentLineDocument
    {
        public int ID { get; set; }
        public int? DocEntry { get; set; }
        public int? ObjType { get; set; }
        public int? PackingListPaymentId { get; set; }
        public string TransportationCardCode { get; set; }
        public string TransportationCardName { get; set; }
        public decimal? DocumentFreightCost { get; set; }
    }
}
