using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPaymentsService
    {
        Task<int> AddPaymentForStoreOnDate(PaymentEntity payment);

        Task<int> UpdatePaymentForStoreOnDate(PaymentEntity payment);

        Task<IList<PaymentEntity>> GetAllPaymenetsDoneByStore(int storeId);

        double GetTotalPaymenetsRecieved();

        Task<double> GetTotalPaymenetsRecievedOnDate(string date);

        Task<double> GetTotalPaymenetsRecievedByStoreOnDate(int storeId, string date);

        Task<double> GetStorePaymentLeft(int storeId);

        double GetTotalPaymentRecievedByStore(int storeId);
    }
}
