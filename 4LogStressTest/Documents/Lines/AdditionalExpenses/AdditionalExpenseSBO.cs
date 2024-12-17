namespace Api.Domain.SBO.Documents.Lines.AdditionalExpenses
{
    public class AdditionalExpenseSBO
    {
        public int DocEntry { get; set; }
        public int? ExpnsCode { get; set; }
        public decimal? LineTotal { get; set; }
    }
}
