using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetUserByRoleId(int id);
        Task<User?> CheckUser(string username, string password);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByUsername(string username);
        Task<bool> CreateUser(User User);
        Task<bool> UpdateUser(User User);
        Task<bool> DeleteUser(User User);
    }
}
