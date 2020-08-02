using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPaymentsRepository
    {
        Task<int> AddPaymentForStoreOnDate(PaymentEntity payment);

        Task<int> UpdatePaymentForStoreOnDate(PaymentEntity payment);

        Task<IList<PaymentEntity>> GetAllPaymenetsDoneByStore(int storeId);

        double GetTotalPaymenetsRecieved();

        Task<double> GetTotalPaymenetsRecievedOnDate(string date);

        Task<double> GetTotalPaymenetsRecievedByStoreOnDate(int storeId, string date);

        double GetTotalPaymenetsRecievedByStore(int storeId);
    }
}
