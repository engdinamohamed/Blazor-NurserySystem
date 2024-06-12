using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IFeeMethodService
    {
        Task<List<FeeMethod>> GetFeeMethods();
        Task<FeeMethod?> GetFeeMethodById(int id);

        Task<bool> CreateFeeMethod(FeeMethod feeMethod);
        Task<bool> UpdateFeeMethod(FeeMethod feeMethod);
        Task<bool> DeleteFeeMethod(FeeMethod feeMethod);
    }
}
