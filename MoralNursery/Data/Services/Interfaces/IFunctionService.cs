using MoralNursery.Data.Models;
namespace MoralNursery.Data.Services.Interfaces
{
    public interface IFunctionService
    {
        Task<List<Function>> GetFunctions();
    }
}
