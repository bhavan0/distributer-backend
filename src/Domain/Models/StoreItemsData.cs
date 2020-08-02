namespace Domain.Models
{
    public class StoreItemsData
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Name { get; set; }

        public double SellingPrice { get; set; }

        public int BoughtCount { get; set; }

        public string Date { get; set; }
    }
}
