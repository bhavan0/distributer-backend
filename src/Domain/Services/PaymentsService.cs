using Domain.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IStoreItemsRepository _storeItemsRpository;

        public PaymentsService(IPaymentsRepository repo, IStoreItemsRepository repo1)
        {
            _paymentsRepository = repo;
            _storeItemsRpository = repo1;
        }

        public async Task<IList<PaymentEntity>> GetAllPaymenetsDoneByStore(int storeId)
        {
            return await _paymentsRepository.GetAllPaymenetsDoneByStore(storeId).ConfigureAwait(false);
        }

        public double GetTotalPaymenetsRecieved()
        {
            return _paymentsRepository.GetTotalPaymenetsRecieved();
        }

        public async Task<double> GetTotalPaymenetsRecievedByStoreOnDate(int storeId, string date)
        {
            return await _paymentsRepository.GetTotalPaymenetsRecievedByStoreOnDate(storeId, date).ConfigureAwait(false);
        }

        public async Task<double> GetTotalPaymenetsRecievedOnDate(string date)
        {
            return await _paymentsRepository.GetTotalPaymenetsRecievedOnDate(date).ConfigureAwait(false);
        }

        public double GetTotalPaymentRecievedByStore(int storeId)
        {
            return _paymentsRepository.GetTotalPaymenetsRecievedByStore(storeId);
        }

        public async Task<double> GetStorePaymentLeft(int storeId)
        {
            var storeItems = await _storeItemsRpository.GetAllItemsBoughtByStore(storeId).ConfigureAwait(false);
            var amountBoughtByStore = CalculateTotalAmountBought(storeItems);
            var totalAmountPaidByStore = GetTotalPaymentRecievedByStore(storeId);
            return amountBoughtByStore - totalAmountPaidByStore;
        }

        public async Task<int> AddPaymentForStoreOnDate(PaymentEntity payment)
        {
            return await _paymentsRepository.AddPaymentForStoreOnDate(payment);
        }

        public async Task<int> UpdatePaymentForStoreOnDate(PaymentEntity payment)
        {
            return await _paymentsRepository.UpdatePaymentForStoreOnDate(payment);
        }

        private double CalculateTotalAmountBought(IList<StoreItemEntity> storeItems)
        {
            double amount = 0;
            foreach (var storeItem in storeItems)
            {
                amount += (storeItem.BoughtCount * storeItem.Item.SellingPrice);
            }
            return amount;
        }
    }
}
