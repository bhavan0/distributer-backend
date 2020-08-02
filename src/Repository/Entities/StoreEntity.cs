using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    [Table("Stores", Schema = "dbo")]
    public class StoreEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
