using Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentLineDocuments;
using Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentExpenses;
using Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentLines;
using Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers.PackingListPaymentHists;

namespace Api.Domain.Entities.PackingLists.PackingListPayments.PkPaymentCarriers
{
    //[IV_RT_PackingListPayment]
    public class PkPaymentCarrier
    {
        public int Id { get; set; }
        public int? DocEntry { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? DocDueDate { get; set; }
        public DateTime? DateCreate { get; set; }
        public string UserName { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public decimal? ExpenseTotal { get; set; }
        public decimal? DocTotalBeforeDiscount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DocTotal { get; set; }
        public List<PackingListPaymentLine> Lines { get; set; } = new List<PackingListPaymentLine>();
        public List<PackingListPaymentExpense> Expenses { get; set; } = new List<PackingListPaymentExpense>();
        public List<PackingListPaymentHist> Hist { get; set; } = new List<PackingListPaymentHist>();
        public List<PackingListPaymentLineDocument> PaymentDocuments { get; set; } = new List<PackingListPaymentLineDocument>();
        #region props not in table
        public string StatusName { get; set; }
        #endregion
        public void CalculateTotals()
        {
            this.ExpenseTotal = Expenses.Where(c => c.ExpenseTotal != null).Sum(c => (decimal)c.ExpenseTotal);

            this.DocTotalBeforeDiscount = 
                Lines.Where(c => c.DocumentFreightCost != null).Sum(c => (decimal)c.DocumentFreightCost)
                + this.ExpenseTotal;

            this.DocTotal = DocTotalBeforeDiscount - (DocTotalBeforeDiscount * (Discount ?? 0) / 100);
        }
    }
}
