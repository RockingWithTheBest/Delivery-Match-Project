using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IPayment
    {
        IEnumerable<Payment> GetAllPayments();
        Payment GetSingleRecord(int Id);
        int AddPaymentRecord(Payment pay);
        int UpdatePaymentRecord(int Id, Payment record);
        int DeletePaymentRecord(int Id);
    }
}
