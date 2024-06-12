using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetRoles();
        Task<Role?> GetRoleById(int id);
        Task<Role?> GetRoleByName(string roleName);

        Task<bool> CreateRole(Role Role);
        Task<bool> UpdateRole(Role Role);
        Task<bool> DeleteRole(Role Role);
    }
}
