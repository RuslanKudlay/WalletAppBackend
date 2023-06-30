using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAL.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<List<User>> GetUsers();
        Task<bool> DeleteUser(Guid userId);

        Task<User> GetUserById(Guid userId);
        Task UpdateUser(User user);
    }
}
