using Api.Domain.Entities.PackingLists.PackingListOrders;

namespace Api.Domain.Entities.PackingLists.PackingListPayments.PackingListPaymentCarriers
{
    public class PackingListPaymentCarrier
    {
        public PackingListPaymentCarrier()
        {
            
        }
        public PackingListPaymentCarrier(PackingListOrder order)
        {
            this.DocObjectCode = order.ObjTypeId.ToString();
            this.DocumentTaxes = order.DocumentTaxes;
            this.DocumentDiscount = order.DocumentDiscount;
            this.DocEntry = order.DocEntry;
            this.DocTotal = order.DocTotal;
            this.Serial = order.Serial;
            this.PackingListId = order.PackingListId;
        }
        public int ID { get; set; }
        public int? PackingListId { get; set; }
        public int? NegotiationId { get; set; }
        public int? DocEntry { get; set; }
        public string TransportationCardCode { get; set; }
        public string TransportationCardName { get; set; }
        public decimal? NegotiationFixedValue { get; set; }
        public decimal? NegotiationPercentage { get; set; }
        public decimal? DocTotal { get; set; }
        public decimal? DocumentDiscount { get; set; }
        public decimal? DocumentTaxes { get; set; }
        public decimal? DocumentFreightCost { get; set; }
        public int? Serial { get; set; }
        public string DocObjectCode { get; set; }
        #region props not in table
        public string PackingDesc { get; set; }
        public DateTime? PackingCreateDate { get; set; }
        #endregion
    }
    public class PKAndOrderModel
    {
        public int PackingListId { get; set; }
        public int DocEntry { get; set; }
        public int ObjType { get; set; }
    }
}
