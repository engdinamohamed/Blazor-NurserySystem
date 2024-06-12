using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<List<Register>> GetRegisters();
        Task<Register?> GetRegisterById(int id);

        Task<bool> CreateRegister(Register register);
        Task<bool> UpdateRegister(Register register);
        Task<bool> DeleteRegister(Register register);
        Task<Dictionary<string, List<int>>> GetMonthlyRegistrationsByFeeMethods(int year);
    }
}
