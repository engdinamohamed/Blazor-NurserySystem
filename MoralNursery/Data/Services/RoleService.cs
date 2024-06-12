using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{

    public class RoleService : IRoleService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public RoleService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public async Task<List<Role>> GetRoles()
        {
            return await _nurseryDbContext.Roles               
                .Include(rf => rf.Functions)
                .AsNoTracking() // Add AsNoTracking for read-only queries
                .OrderBy(x => x.RoleName).ToListAsync();
        }
        public async Task<Role?> GetRoleById(int id)
        {
            Role role = await _nurseryDbContext.Roles               
                .Include(rf => rf.Functions)
                .AsNoTracking() // Add AsNoTracking for read-only queries
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
            return role;
        }
        public async Task<Role?> GetRoleByName(string roleName)
        {
            Role role = await _nurseryDbContext.Roles
                .Include(rf => rf.Functions)
                .AsNoTracking() // Add AsNoTracking for read-only queries
                .FirstOrDefaultAsync(c => c.RoleName.Equals(roleName));
            return role;
        }
        public async Task<bool> CreateRole(Role Role)
        {
            await _nurseryDbContext.Roles.AddAsync(Role);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        //public async Task<bool> DeleteRole(Role Role)
        //{
        //    _nurseryDbContext.Roles.Remove(Role);
        //    await _nurseryDbContext.SaveChangesAsync();
        //    return true;
        //}
        public async Task<bool> DeleteRole(Role role)
        {
            // Remove functions associated with the role
            role.Functions.Clear();

            // Update the role to remove the associated functions
            _nurseryDbContext.Roles.Update(role);

            // Save changes to the database
            await _nurseryDbContext.SaveChangesAsync();

            // Now, you can safely delete the role
            _nurseryDbContext.Roles.Remove(role);
            await _nurseryDbContext.SaveChangesAsync();

            return true;
        }

        //public async Task<bool> UpdateRole(Role Role)
        //{
        //    _nurseryDbContext.ChangeTracker.Clear();
        //    _nurseryDbContext.Roles.Update(Role);
        //    await _nurseryDbContext.SaveChangesAsync();
        //    return true;
        //}


        public async Task<bool> UpdateRole(Role role)
        {
            _nurseryDbContext.ChangeTracker.Clear();
            // Detach existing role to avoid tracking conflicts
            var existingRole = await _nurseryDbContext.Roles
                .Include(r => r.Functions)
                .FirstOrDefaultAsync(r => r.Id == role.Id);

            if (existingRole != null)
            {
                // Update scalar properties of the role
                _nurseryDbContext.Entry(existingRole).CurrentValues.SetValues(role);

                // Update or insert functions associated with the role
                foreach (var function in role.Functions)
                {
                    if (existingRole.Functions.Any(f => f.Id == function.Id))
                    {
                        // Function already exists for the role, update it if necessary
                        var existingFunction = existingRole.Functions.First(f => f.Id == function.Id);
                        _nurseryDbContext.Entry(existingFunction).CurrentValues.SetValues(function);
                    }
                    else
                    {
                        // Function does not exist for the role, add it
                        existingRole.Functions.Add(function);
                    }
                }

                // Remove any functions that are no longer associated with the role
                var functionsToRemove = existingRole.Functions.Where(f => !role.Functions.Any(rf => rf.Id == f.Id)).ToList();
                foreach (var functionToRemove in functionsToRemove)
                {
                    existingRole.Functions.Remove(functionToRemove);
                }

                await _nurseryDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }




    }
}

