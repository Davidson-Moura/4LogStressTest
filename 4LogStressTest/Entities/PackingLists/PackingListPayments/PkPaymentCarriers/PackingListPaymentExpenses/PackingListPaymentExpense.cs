using System;

namespace Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentExpenses
{
    public class PackingListPaymentExpense
    {
        public int Id { get; set; }
        public int? PackingListPaymentId { get; set; }
        public int? ExpenseCode { get; set; }
        public string ExpenseName { get; set; }
        public decimal? ExpenseTotal { get; set; }
        public string Comments { get; set; }
    }
}
