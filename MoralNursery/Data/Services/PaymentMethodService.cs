using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public PaymentMethodService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public async Task<List<PaymentMethod>> GetPaymentMethods()
        {
            return await _nurseryDbContext.PaymentMethods.ToListAsync();
        }
        public async Task<bool> CreatePaymentMethod(PaymentMethod PaymentMethod)
        {
            await _nurseryDbContext.PaymentMethods.AddAsync(PaymentMethod);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletPaymentMethod(PaymentMethod PaymentMethod)
        {
            _nurseryDbContext.PaymentMethods.Remove(PaymentMethod);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PaymentMethod?> GetPaymentMethodById(int id)
        {
            PaymentMethod paymentMethod = await _nurseryDbContext.PaymentMethods.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return paymentMethod;
        }



        public async Task<bool> UpdatePaymentMethod(PaymentMethod PaymentMethod)
        {
            _nurseryDbContext.PaymentMethods.Update(PaymentMethod);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }
    }
}
