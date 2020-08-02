using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Context
{
    public class DistributerContext : DbContext
    {
        public DistributerContext()
        {
        }

        public DistributerContext(DbContextOptions<DistributerContext> options)
            : base(options)
        {
        }

        public DbSet<ItemEntity> Items { get; set; }

        public DbSet<ItenaryEntity> Itenary { get; set; }

        public DbSet<StoreEntity> Stores { get; set; }

        public DbSet<StoreItemEntity> StoreItems { get; set; }

        public DbSet<PaymentEntity> Payments { get; set; }
    }
}
