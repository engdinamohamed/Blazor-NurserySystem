using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Services.Interfaces;
using MoralNursery.Pages.User;
namespace MoralNursery.Data.Services
{
    public class UserService : IUserService
	{
		private readonly NurseryDbContext _nurseryDbContext;
		public UserService(NurseryDbContext nurseryDbContext)
		{
			_nurseryDbContext = nurseryDbContext;
		}
		public async Task<List<User>> GetAllUsers()
		{
            return await _nurseryDbContext.Users
                .Include(x => x.Roles)
                .ThenInclude(rf => rf.Functions)
                .AsNoTracking() // Add AsNoTracking for read-only queries
                .OrderBy(x => x.FullName).ToListAsync();
        }
		public async Task<User> CheckUser(string username, string password)
		{
			User user = new User();
			user = await Task.FromResult(_nurseryDbContext.Users.
                SingleOrDefault(u => u.Username == username && u.PasswordHash == password ));
			return user;
		}

        public async Task<User?> GetUserById(int id)
        {
            User user = await _nurseryDbContext.Users.AsNoTracking()
				.Include(x => x.Roles)
                .ThenInclude(rf => rf.Functions)
                .AsNoTracking() // Add AsNoTracking for read-only queries
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
            return user;
        }

        public async Task<bool> CreateUser(User User)
        {
            await _nurseryDbContext.Users.AddAsync(User);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        //public async Task<bool> UpdateUser(User User)
        //{
        //    _nurseryDbContext.Users.Update(User);
        //    await _nurseryDbContext.SaveChangesAsync();
        //    return true;
        //}
        public async Task<bool> UpdateUser(User user)
        {
            _nurseryDbContext.ChangeTracker.Clear();
            // Detach existing user to avoid tracking conflicts
            var existingUser = await _nurseryDbContext.Users
            .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser != null)
            {
                // Update scalar properties of the user
                _nurseryDbContext.Entry(existingUser).CurrentValues.SetValues(user);

                // Update or insert roles associated with the user
                foreach (var role in user.Roles)
                {
                    if (existingUser.Roles.Any(r => r.Id == role.Id))
                    {
                        // role already exists for the user, update it if necessary
                        var existingRole = existingUser.Roles.First(r => r.Id == role.Id);
                        _nurseryDbContext.Entry(existingRole).CurrentValues.SetValues(role);
                    }
                    else
                    {
                        // roles does not exist for the user, add it
                        existingUser.Roles.Add(role);
                    }
                }

                // Remove any roles that are no longer associated with the user
                var rolesToRemove = existingUser.Roles.Where(r => !user.Roles.Any(ur => ur.Id == r.Id)).ToList();
                foreach (var functionToRemove in rolesToRemove)
                {
                    existingUser.Roles.Remove(functionToRemove);
                }

                await _nurseryDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        //public async Task<bool> DeleteUser(User User)
        //{
        //    _nurseryDbContext.Users.Remove(User);
        //    await _nurseryDbContext.SaveChangesAsync();
        //    return true;
        //}

        public async Task<bool> DeleteUser(User user)
        {
			

			// Remove roles associated with the user
			user.Roles.Clear();

            // Update the user to remove the associated roles
            _nurseryDbContext.Users.Update(user);

            // Save changes to the database
            await _nurseryDbContext.SaveChangesAsync();

			// Attach the user to the context if it's not already being tracked
			if (_nurseryDbContext.Entry(user).State == EntityState.Detached)
			{
				_nurseryDbContext.Users.Attach(user);
			}

			// Now, you can safely delete the user
			_nurseryDbContext.Users.Remove(user);
            await _nurseryDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            User user = await _nurseryDbContext.Users
               .Include(x => x.Roles)
               .ThenInclude(rf => rf.Functions)
               .AsNoTracking() // Add AsNoTracking for read-only queries
               .FirstOrDefaultAsync(c => c.Username.Equals(username));
            return user;
        }

        public async Task<List<User>> GetUserByRoleId(int id)
        {
            return await _nurseryDbContext.Users
        .Include(x => x.Roles)
            .ThenInclude(rf => rf.Functions)
        .Where(u => u.Roles.Any(r => r.Id == id))
        .OrderBy(x => x.Username)
        .ToListAsync();
        }
    }
}
