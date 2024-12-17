using System;

namespace Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentHists
{
    public class PackingListPaymentHist
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? PackingListPaymentId { get; set; }
        public int? StatusId { get; set; }
        public string Comments { get; set; }
        public string UserName { get; set; }
        #region props not in table
        public string StatusName { get; set; }
        #endregion
    }
}
