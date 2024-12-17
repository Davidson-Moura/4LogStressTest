namespace Api.Domain.Entities.PackingLists.PackingListRoutes.PackingListRoutePoints
{
    public class PackingListRoutePoint
    {
        public int ID { get; set; }
        public int? PackingListRouteID { get; set; }
        public int? OrderNum { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public string Address { get; set; }
        public decimal? Distance { get; set; }
        public int? Direction { get; set; }
    }
}
