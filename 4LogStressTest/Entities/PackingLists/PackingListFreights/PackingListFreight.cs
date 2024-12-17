using System.Collections.Generic;
using System;

namespace Api.Domain.Entities.PackingLists.PackingListFreights
{
    public class PackingListFreight
    {
        public int ID { get; set; }
        public int? PackingListId { get; set; }
        public int? VehicleId { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? DateQuote { get; set; }
        public string ContactName { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }
        public bool? Approved { get; set; }
        public string ShippingCompanyCardCode { get; set; }
        public string ShippingCompanyCardName { get; set; }
        #region Props not in table
        public string VehicleName { get; set; }
        public string PackingListDesc { get; set; }
        #endregion
    }
}
