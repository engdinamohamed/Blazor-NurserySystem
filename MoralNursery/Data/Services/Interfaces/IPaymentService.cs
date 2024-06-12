using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetPayment();
        Task<List<Payment>> GetPaymentByRegisterId(int registerId);
        Task<Payment?> GetPaymentById(int id);

        Task<bool> CreatePayment(Payment Payment);
        Task<bool> UpdatePayment(Payment Payment);
        Task<bool> DeletPayment(Payment Payment);
        public float getTotalPayedAmount(int registerId);
    }
}
