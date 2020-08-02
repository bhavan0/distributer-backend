using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class PaymentsRepository : IPaymentsRepository
    {
        internal DistributerContext Context { get; }

        public PaymentsRepository(DistributerContext context)
        {
            Context = context;
        }

        public async Task<IList<PaymentEntity>> GetAllPaymenetsDoneByStore(int storeId)
        {
            return await Context.Payments.Where(w => w.StoreId == storeId).ToListAsync().ConfigureAwait(false);
        }

        public double GetTotalPaymenetsRecieved()
        {
            var payments = Context.Payments.AsEnumerable();
            return Context.Payments.AsEnumerable().Sum(x => x.Amount);
        }

        public async Task<double> GetTotalPaymenetsRecievedOnDate(string date)
        {
            var payment = await Context.Payments.Where(x => x.Date.Equals(date)).ToListAsync().ConfigureAwait(false);
            return payment.Sum(x => x.Amount);
        }

        public async Task<double> GetTotalPaymenetsRecievedByStoreOnDate(int storeId, string date)
        {
            var payment = await Context.Payments.Where(x => x.StoreId == storeId && x.Date.Equals(date)).ToListAsync().ConfigureAwait(false);
            return payment.Sum(x => x.Amount);
        }

        public async Task<int> AddPaymentForStoreOnDate(PaymentEntity payment)
        {
            await Context.Payments.AddAsync(payment);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdatePaymentForStoreOnDate(PaymentEntity payment)
        {
            Context.Payments.Update(payment);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public double GetTotalPaymenetsRecievedByStore(int storeId)
        {
            var payments = Context.Payments.Where(w => w.StoreId == storeId).AsEnumerable();
            return Context.Payments.AsEnumerable().Sum(x => x.Amount);
        }
    }
}
