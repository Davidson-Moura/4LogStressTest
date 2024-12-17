using System.Collections.Generic;

namespace Api.Domain.SBO.Documents.DocumentSearchs.DocumentLines
{
    public class DocumentLineSearchSBO
    {
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal? DiscPrcnt { get; set; }
        public string ShipToCode { get; set; }
        public decimal? Price { get; set; }
        public decimal? AltQty { get; set; }
        public decimal? BaseQty { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? OpenCreQty { get; set; }
        public int? ItmsGrpCod { get; set; }
        public decimal? Volume { get; set; }
        public string WhsCode { get; set; }
        public string WhsName { get; set; }
        public int? SlpCode { get; set; }
        public string SlpName { get; set; }
        public decimal? LineTotalPlusVatSum { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
        public decimal? GrsWeight { get; set; }
        public decimal? Wght1Unit { get; set; }
        public decimal? LineTotal { get; set; }
        public decimal? LineFreightTotal { get; set; }
        public bool? ManBtchNum { get; set; }
        public string ManBtchNumChar
        {
            get { return null; }
            set { ManBtchNum = (value ?? "N") == "Y"; }
        }
        public bool? ManSerialNum { get; set; }
        public string ManSerialNumChar
        {
            get { return null; }
            set { ManSerialNum = (value ?? "N") == "Y"; }
        }
        public bool? InvntItem { get; set; }
        public string InvntItemChar
        {
            get { return null; }
            set { InvntItem = (value ?? "N") == "Y"; }
        }
        public int Territory { get; set; }
        public string TerritoryName { get; set; }

        public string City { get; set; }
        public string Block { get; set; }
        public string AddrType { get; set; }
        public string ZipCode { get; set; }
        public int County { get; set; }
        public string CountyName { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string Country { get; set; }
        public string FullAddress
        {
            get
            {
                var list = new List<string>();
                if (!string.IsNullOrEmpty(Country)) list.Add(Country);
                if (!string.IsNullOrEmpty(State)) list.Add(State);
                if (!string.IsNullOrEmpty(City)) list.Add(City);
                if (!string.IsNullOrEmpty(CountyName)) list.Add(CountyName);
                if (!string.IsNullOrEmpty(Block)) list.Add(Block);
                if (!string.IsNullOrEmpty(AddrType)) list.Add(AddrType);
                if (!string.IsNullOrEmpty(Street)) list.Add(Street);
                if (!string.IsNullOrEmpty(StreetNo)) list.Add(StreetNo);
                if (!string.IsNullOrEmpty(ZipCode)) list.Add(ZipCode);
                return "";
            }
            set { }
        }

        public char? TreeType { get; set; }
    }
    public class MinDocumentLineSearchSBO
    {
        public int DocEntry { get; set; }
        public int ObjType { get; set; }
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string CodeBars { get; set; }
    }
}
