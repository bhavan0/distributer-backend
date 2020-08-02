using System.Collections.Generic;

namespace Domain.Models
{
    public class StoreDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<DateStoreItemsData> DateStoreItemsData { get; set; }
    }
}
