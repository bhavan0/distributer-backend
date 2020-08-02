using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    [Table("Items", Schema = "dbo")]
    public class ItemEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double CostPrice { get; set; }

        public double SellingPrice { get; set; }
    }
}
