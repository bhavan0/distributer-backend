using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    [Table("Itenary", Schema = "dbo")]
    public class ItenaryEntity
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Date { get; set; }

        public int BoughtCount { get; set; }

        public int SoldCount { get; set; }

        public virtual ItemEntity Item { get; set; }
    }
}
