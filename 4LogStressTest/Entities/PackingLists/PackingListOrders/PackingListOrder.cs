using Api.Domain.Entities.PackingLists.PackingListOrders.PackingListOrderItems;
using Api.Domain.SBO.Documents.DocumentSearchs.DocumentLines;
using Api.Domain.SBO.Documents.DocumentSearchs;
using System.Linq;
using System;

namespace Api.Domain.Entities.PackingLists.PackingListOrders
{
    public class PackingListOrder
    {
        public int ID { get; set; }
        public int? PackingListId { get; set; }
        public int? ObjTypeId { get; set; }
        public int? DocEntry { get; set; }
        public int? DocNum { get; set; }
        public int? OrderNum { get; set; }
        public int? TerritoryId { get; set; }
        public DateTime? DocDate { get; set; }
        public short? DocTime { get; set; }
        public DateTime? DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public decimal? DocTotal { get; set; }
        public int? CompanyHierarchyId { get; set; }
        public string Comments { get; set; }
        public decimal? FreightCost { get; set; }
        public bool? Scheduled { get; set; }
        public bool? PartSupply { get; set; }
        public string TranspName { get; set; }
        public int? StatusId { get; set; } = (int)PackingListStatusEnum.PendingLiberatedQuote;
        public int? EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int? EmployeeAssistanteCode { get; set; }
        public string EmployeeAssistanteName { get; set; }
        public string ShipToCode { get; set; }
        public decimal? DocumentDiscount { get; set; }
        public decimal? DocumentTaxes { get; set; }
        public decimal? DocumentFreightCost { get; set; }
        public decimal? DocumentTerritoryNegotiationPercentage { get; set; }
        public decimal? DocumentTerritoryNegotiationMinimum { get; set; }
        public int? Serial { get; set; }
        public string ConfOrder { get; set; } = "Sim";
        public decimal? ItemsTotal { get; set; }
        public string CardFName { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public int? PackQuantity { get; set; }
        public string AddressConf { get; set; }
        public DateTime? CreateDate { get; set; }
        public string DeliveryBP { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int? County { get; set; }
        public string City { get; set; }
        public string Block { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string ZipCode { get; set; }
        public int PackingListRouteID { get; set; }
        public List<PackingListOrderItem> Items { get; set; } = new List<PackingListOrderItem>();
        #region props not in table
        public string StatusName { get; set; }
        public string CountyName { get; set; }
        public string TerritoryName { get; set; }

        #endregion
        public decimal ItensQuantity()
        {
            return Items.Sum(x => x.Quantity ??0m);
        }

        internal void FillValues(DocumentSearchSBO doc)
        {
            if (doc is null) return;
            DocumentLineSearchSBO currentLine = null;
            decimal freight = decimal.Zero;
            decimal itemsTotal = decimal.Zero;
            decimal netWeight = decimal.Zero;

            Items.ForEach(x => {
                currentLine = doc.DocumentLines.FirstOrDefault(y => y.LineNum == x.LineNum && y.ItemCode == x.ItemCode);
                x.FillValues(currentLine);

                freight += x.LineFreightTotal??0m;
                itemsTotal += x.LineTotal??0m;
                netWeight += x.Weight??0m;
            });
            DocNum = doc.DocNum;
            TerritoryId = currentLine.Territory;
            DocDate = doc.DocDate;
            if(short.TryParse(doc.DocTime, out short shortDocTime)) DocTime = shortDocTime;
            DocDueDate = doc.DocDueDate;
            CardCode = doc.CardCode;
            CardName = doc.CardName;
            DocTotal = doc.DocTotal;
            ShipToCode = currentLine.ShipToCode;
            DocumentDiscount = doc.DocumentDiscount;
            if (DocumentFreightCost is null) DocumentFreightCost = freight;
            ItemsTotal = itemsTotal;
            CardFName = doc.CardFName;
            GrossWeight = doc.GrossWeight;
            NetWeight = netWeight;
            if(ID <= 0) CreateDate = DateTime.Now;
            Country = currentLine.Country;
            State = currentLine.State;
            County = currentLine.County;
            City = currentLine.City;
            Block = currentLine.Block;
            Block = currentLine.Block;
            Street = currentLine.Street;
            StreetNo = currentLine.StreetNo;
            ZipCode = currentLine.ZipCode;
        }
    }
}
