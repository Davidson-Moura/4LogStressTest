namespace Api.Domain.ServiceLayers.Documents.Lines.AdditionalExpenses
{
    public class AdditionalExpenseSL
    {
        public int? ExpenseCode { get; set; }
        public decimal? LineTotal { get; set; }
        public string Remarks { get; set; }
    }
}
