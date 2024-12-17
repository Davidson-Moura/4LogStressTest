using System;
namespace Api.Domain.Entities.PackingLists.PackingListFreights.FreightQuoteVolumeInfos
{
    public class FreightQuoteVolumeInfo
    {
        public int Id { get; set; }
        public int? PackingListId { get; set; }
        public int? Volumes { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
    }
}
