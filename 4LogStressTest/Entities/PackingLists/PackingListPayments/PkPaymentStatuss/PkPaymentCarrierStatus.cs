using System.Collections.Generic;
using System;

namespace Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentStatuss
{
    public class PkPaymentCarrierStatus
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
    public enum PkPaymentCarrierStatusEnum
    {
        None,
        Pending,
        Disapproved,
        Approved,
        Canceled
    }
}
