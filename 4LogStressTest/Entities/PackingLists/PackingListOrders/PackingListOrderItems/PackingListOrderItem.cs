using Api.Domain.SBO.Documents.DocumentSearchs.DocumentLines;

namespace Api.Domain.Entities.PackingLists.PackingListOrders.PackingListOrderItems
{
    public class PackingListOrderItem
    {
        public int ID { get; set; }
        public int? PackingListOrderId { get; set; }
        public string ItemCode { get; set; }
        public int? LineNum { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscPrcnt { get; set; }
        public string Description { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Weight { get; set; }
        public decimal? GrsWeight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? OnHand { get; set; }
        public decimal? LineTotal { get; set; }
        public string WhsCode { get; set; }
        public int? TransferDocEntry { get; set; }
        public bool? BackOrdr { get; set; }
        public bool? ManBtchNum { get; set; }
        public bool? ManSerialNum { get; set; }
        public bool? InvntItem { get; set; }
        public bool? OpenCreQty { get; set; }
        public short? ItmsGrpCod { get; set; }
        public decimal? QtdCuty { get; set; }
        public decimal? LineFreightTotal { get; set; }
        public int? SlpCode { get; set; }
        public decimal? LineTotalPlusVatSum { get; set; }
        public string TreeType { get; set; }
        public decimal? QuantityMeasureBase { get; set; }
        public int? Wght1Unit { get; set; }
        public decimal? AltQty { get; set; }
        public decimal? BaseQty { get; set; }
        #region props not in table
        public string SlpName { get; set; }
        public string WhsName { get; set; }

        internal void FillValues(DocumentLineSearchSBO line)
        {
            if(line is null) return;
            Quantity = line.Quantity ?? 0m;
            Price = line.Price ?? 0m;
            DiscPrcnt = line.DiscPrcnt ?? 0m;
            Description = line.Description;
            Volume = line.Volume ?? 0m;
            Weight = line.Weight ?? 0m;
            Height = line.Height ?? 0m;
            Width = line.Width ?? 0m;
            Length = line.Length ?? 0m;
            if(line.LineFreightTotal is not null && line.LineFreightTotal > 0m) LineFreightTotal = line.LineFreightTotal;
            WhsCode = line.WhsCode;
            ManBtchNum = line.ManBtchNum ?? false;
            ManSerialNum = line.ManSerialNum ?? false;
            InvntItem = line.InvntItem ?? false;
            OpenCreQty = line.OpenCreQty is not null && line.OpenCreQty > 0;
            ItmsGrpCod = (short)line.ItmsGrpCod;
            SlpCode = line.SlpCode;
            LineTotal = Price * Quantity;
            LineTotalPlusVatSum = line.LineTotalPlusVatSum ?? 0m;
            TreeType = line.TreeType?.ToString()??"";

            Wght1Unit = (int)(line.Wght1Unit ?? 0);
            AltQty = line.AltQty ?? 1m;
            BaseQty = line.BaseQty ?? 1m;
            if (BaseQty <= 0) BaseQty = 1m;
            QuantityMeasureBase = Quantity * ( line.AltQty / line.BaseQty);
        }
        #endregion
    }
    public class PkOrderLineInfo
    {
        public int DocEntry { get; set; }
        public int ObjTypeId { get; set; }
        public int ID { get; set; }
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string CodeBars { get; set; }
    }
}
