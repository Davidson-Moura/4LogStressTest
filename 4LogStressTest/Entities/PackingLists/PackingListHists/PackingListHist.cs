using System.Collections.Generic;
using System;

namespace Api.Domain.Entities.PackingLists.PackingListHists
{
    public class PackingListHist
    {
        public int PackingListID { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserID { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        #region props not in table
        public string StatusName { get; set; }
        #endregion
    }
}
