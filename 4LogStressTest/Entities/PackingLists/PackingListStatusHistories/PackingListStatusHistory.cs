using System;

namespace Api.Domain.Entities.PackingLists.PackingListStatusHistories
{
    public class PackingListStatusHistory
    {
        public int ID { get; set; }
        public int? PackingListId { get; set; }
        public int? StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CarrierDriverId { get; set; }
    }
}
