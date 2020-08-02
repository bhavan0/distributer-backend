using System.Collections.Generic;

namespace Domain.Models
{
    public class DateStoreItemsData
    {
        public IList<StoreItemsData> StoreItems { get; set; }

        public string Date { get; set; }
    }
}
