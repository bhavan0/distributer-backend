using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    [Table("Payments", Schema = "dbo")]
    public class PaymentEntity
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public string Date { get; set; }

        public double Amount { get; set; }

        public virtual StoreEntity Store { get; set; }
    }
}
