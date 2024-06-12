using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethod>> GetPaymentMethods();
        Task<PaymentMethod?> GetPaymentMethodById(int id);

        Task<bool> CreatePaymentMethod(PaymentMethod PaymentMethod);
        Task<bool> UpdatePaymentMethod(PaymentMethod PaymentMethod);
        Task<bool> DeletPaymentMethod(PaymentMethod PaymentMethod);
    }
}
