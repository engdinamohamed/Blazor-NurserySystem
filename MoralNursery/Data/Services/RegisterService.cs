using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{
    public class RegisterService :IRegisterService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public RegisterService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public async Task<bool> CreateRegister(Register register)
        {
            await _nurseryDbContext.Registers.AddAsync(register);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRegister(Register register)
        {
            _nurseryDbContext.Registers.Remove(register);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Register?> GetRegisterById(int id)
        {
            Register register = await _nurseryDbContext.Registers
                .Include(s => s.Student)
                .ThenInclude(c => c.ClassRoom)
                .Include(f => f.FeeMethod)
                .Include(u => u.User)
                .FirstOrDefaultAsync(r => r.Id.Equals(id));
            return register;
        }

        public async Task<List<Register>> GetRegisters()
        {
            return await _nurseryDbContext.Registers
                .Include(s => s.Student)
                .ThenInclude(c => c.ClassRoom)
                 .Include(f => f.FeeMethod)
                 .Include(u => u.User)
                .OrderByDescending(x => x.AddedIn).ToListAsync();
        }

        public async Task<bool> UpdateRegister(Register register)
        {
            _nurseryDbContext.Registers.Update(register);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }
		public async Task<Dictionary<string, List<int>>> GetMonthlyRegistrationsByFeeMethods(int year)
		{
			var feeMethods = await _nurseryDbContext.FeeMethods.ToListAsync();

			var result = new Dictionary<string, List<int>>();

			foreach (var feeMethod in feeMethods)
			{
				var monthlyRegistrations = await _nurseryDbContext.Registers
					.Where(r => r.AddedIn.Year == year && r.FeeMethodId == feeMethod.Id)
					.GroupBy(r => r.AddedIn.Month)
					.Select(g => new { Month = g.Key, Count = g.Count() })
					.ToListAsync();

				var monthlyCounts = new List<int>(new int[12]);
				foreach (var reg in monthlyRegistrations)
				{
					monthlyCounts[reg.Month - 1] = reg.Count;
				}

				result[feeMethod.FeeMethodName] = monthlyCounts;
			}

			return result;
		}
	}
}

