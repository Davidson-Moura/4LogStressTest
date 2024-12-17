using System;

namespace Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentLines
{
    public class PackingListPaymentLine
    {
        public int Id { get; set; }
        public int? PackingListPaymentId { get; set; }
        public int? PackingListId { get; set; }
        public int? DocEntry { get; set; }
        public int? ObjType { get; set; }
        public DateTime? DocDate { get; set; } = DateTime.Now;
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public int? Serial { get; set; }
        public decimal? LineTotal { get; set; }
        public decimal? DocumentFreightCost { get; set; }
        public DateTime? InvoiceCreateDate { get; set; }
        public DateTime? PackingCreateDate { get; set; }
    }
}
