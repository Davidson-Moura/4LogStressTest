using Api.Domain.Entities.PackingLists.PackingListRoutes.PackingListRoutePoints;

namespace Api.Domain.Entities.PackingLists.PackingListRoutes
{
    public class PackingListRoute
    {
        public int ID { get; set; }
        public int? PackingListId { get; set; }
        public int? OrderNum { get; set; }
        public int? Territory { get; set; }
        public string CardCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Distance { get; set; }
        public decimal? DistanceManual { get; set; }
        public decimal? FreightCost { get; set; }
        public decimal? AccumulativeDistance { get; set; }
        public string ShipToCode { get; set; }
        public List<PackingListRoutePoint> RoutePoints { get; set; } = new List<PackingListRoutePoint>();
        #region props not in table
        public string TerritoryName { get; set; }
        #endregion
    }
}
