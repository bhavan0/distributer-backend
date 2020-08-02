using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    [Table("StoreItems", Schema = "dbo")]
    public class StoreItemEntity
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int ItemId { get; set; }

        public string Date { get; set; }

        public int BoughtCount { get; set; }

        public virtual StoreEntity Store { get; set; }

        public virtual ItemEntity Item { get; set; }
    }
}
