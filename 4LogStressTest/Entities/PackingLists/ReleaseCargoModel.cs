namespace _4LogStressTest.Entities.PackingLists
{
    public class ReleaseCargoModel
    {
        public int PackingListID { get; set; }
        public List<ReleaseCargoDownPaymentByOrderModel> DownPayments { get; set; } = null;
    }
    public class ReleaseCargoDownPaymentByOrderModel
    {
        public int? PackingListOrderID { get; set; }
        public int DocEntryDownPaymentToDraw { get; set; }
        public decimal AmountUsedAdvance { get; set; }
    }
    public class ReleaseCargoModelBySelection
    {
        public int PackingListID { get; set; }
        public List<ReleaseCargoDownPaymentByOrderModelBySelection> Orders { get; set; }
    }
    public class ReleaseCargoDownPaymentByOrderModelBySelection
    {
        public int PackingListID { get; set; }
        public int? PackingListOrderID { get; set; }
        public int ObjTypeId { get; set; }
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public decimal ItemsTotal { get; set; }
    }
}
