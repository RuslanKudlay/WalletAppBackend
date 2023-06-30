using BAL.Helpers;
using BAL.Model;
using Common;
using Common.RequestModel;
using RAL.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(CreateModel userModel)
        {
            if (!string.IsNullOrEmpty(userModel.Name.Trim()))
            {
                Random rnd = new Random();
                decimal randomBalance = rnd.Next(1, 100);
                const decimal maxLimit = 1500;
                decimal available = maxLimit - randomBalance;

                var userP = new UserModel
                {
                    UserId = Guid.NewGuid(),
                    Name = userModel.Name,
                    Balance = randomBalance,
                    MaxLimit = maxLimit,
                    Available = available,
                    DailyPoints = new List<DailyPointModel>(),
                    Transactions = new List<TransactionModel>()
                };

                var user = WalletHelper.Map(userP);
                await _userRepository.CreateUser(user);
            }
            else
            {
                throw new Exception("The user with such ID does not exist!");
            }
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            return await _userRepository.DeleteUser(userId);
        }

        public async Task<List<GetUsers>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            if (users.Count == 0)
            {
                return new List<GetUsers>();
            }

            var usersModels = WalletHelper.Map(users);

            var getUsersModel = WalletHelper.Map(usersModels);

            return getUsersModel;
        }
    }
}
