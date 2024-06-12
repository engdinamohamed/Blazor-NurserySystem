using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{
    public class FeeMethodService :IFeeMethodService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public FeeMethodService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public async Task<List<FeeMethod>> GetFeeMethods()
        {
            return await _nurseryDbContext.FeeMethods.ToListAsync();
        }
        public async Task<bool> CreateFeeMethod(FeeMethod feeMethod)
        {
            await _nurseryDbContext.FeeMethods.AddAsync(feeMethod);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFeeMethod(FeeMethod feeMethod)
        {
            _nurseryDbContext.FeeMethods.Remove(feeMethod);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<FeeMethod?> GetFeeMethodById(int id)
        {
            FeeMethod feeMethod = await _nurseryDbContext.FeeMethods.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return feeMethod;
        }



        public async Task<bool> UpdateFeeMethod(FeeMethod feeMethod)
        {
            _nurseryDbContext.FeeMethods.Update(feeMethod);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }
    }
}
