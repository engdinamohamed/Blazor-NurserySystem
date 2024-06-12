using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public PaymentService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public async Task<bool> CreatePayment(Payment Payment)
        {
            await _nurseryDbContext.Payments.AddAsync(Payment);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletPayment(Payment Payment)
        {
            _nurseryDbContext.Payments.Remove(Payment);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Payment>> GetPayment()
        {
            return await _nurseryDbContext.Payments
                .Include(r => r.Register)
                .ThenInclude(fm => fm.FeeMethod)
                .Include(r => r.Register)
                .ThenInclude(s => s.Student)
                .ThenInclude(c => c.ClassRoom)

                .Include(pm => pm.PaymentMethod)
                 .Include(us => us.User)
                .OrderByDescending(x => x.AddedIn).ToListAsync();
        }

        public async Task<Payment?> GetPaymentById(int id)
        {
            Payment Payment = await _nurseryDbContext.Payments
                .Include(r => r.Register)
                .ThenInclude(s => s.Student)
                .ThenInclude(c => c.ClassRoom)
                .Include(r => r.Register)
                .ThenInclude(fm => fm.FeeMethod)
                .Include(pm => pm.PaymentMethod)                
                 .Include(us => us.User)
               .FirstOrDefaultAsync(p => p.Id.Equals(id));
            return Payment;
        }

        public async Task<List<Payment>> GetPaymentByRegisterId(int id)
        {
            return await _nurseryDbContext.Payments
               .Include(r => r.Register)
                .Include(us => us.User)                 
            .Where(x => x.RegisterId == id)
               .OrderByDescending(x => x.AddedIn).ToListAsync();
        }

        public float getTotalPayedAmount(int registerId)
        {
            try
            {                
                var totalAmount = _nurseryDbContext.Payments
                    .Include(r => r.Register)
                    .Include(pm => pm.PaymentMethod)
                    .Where(p => p.RegisterId == registerId)
                    .Sum(p => p.Amount);

                return totalAmount;
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error occurred: {ex.Message}");
                return 0; // Default value or throw the exception again as per your requirement
            }
        }

        public async Task<bool> UpdatePayment(Payment Payment)
        {
            _nurseryDbContext.Payments.Update(Payment);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }
       
    }
}
