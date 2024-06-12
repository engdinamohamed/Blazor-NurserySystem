using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public FunctionService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }

        public async Task<List<Function>> GetFunctions()
        {
            return await _nurseryDbContext.Functions.ToListAsync();
        }
    }
}
