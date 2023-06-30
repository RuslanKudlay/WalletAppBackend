using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.RequestModel;

namespace BAL.Service
{
    public interface IUserService
    {
        Task CreateUser(CreateModel user);
        Task<List<GetUsers>> GetUsers();
        Task<bool> DeleteUser(Guid userId);
    }
}
