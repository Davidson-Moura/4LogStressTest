using System.Collections.Generic;

namespace Api.Domain.Entities.PackingLists.PackingListOrders.PkOrderDownPayments
{
    public class PkOrderDownPayment
    {
        public int ID { get; set; }
        public int PackingListOrderID { get; set; }
        public int DocEntryDownPaymentToDraw { get; set; }
        public decimal AmountUsedAdvance { get; set; }
    }
}
