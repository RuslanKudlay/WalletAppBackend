using BAL.Model;
using Common.RequestModel;
using DAL.Entity;
using System;
using System.Collections.Generic;

namespace BAL.Helpers
{
    public static class WalletHelper
    {
        public static Transaction Map(TransactionModel transactionModel)
        {
            var transaction = new Transaction
            {
                Id = transactionModel.Id.Value,
                UserId = transactionModel.UserId,
                TransactionType = (DAL.Entity.TransactionType)transactionModel.TransactionType,
                Sum = transactionModel.Sum,
                NameTransaction = transactionModel.NameTransaction,
                DescriptionTransaction = transactionModel.DescriptionTransaction,
                CreateAt = transactionModel.CreatedAt,
                IsPending = transactionModel.IsPending,
                IconPath = transactionModel.IconPath
            };
            return transaction;
        }

        public static List<TransactionModel> Map(List<Transaction> transactions)
        {
            List<TransactionModel> transactionModels = new List<TransactionModel>();
            transactions.ForEach(transaction =>
            {
                var transactionModel = new TransactionModel
                {
                    Id = transaction.Id,
                    UserId = transaction.UserId,
                    TransactionType = (BAL.Model.TransactionType)transaction.TransactionType,
                    Sum = transaction.Sum,
                    NameTransaction = transaction.NameTransaction,
                    DescriptionTransaction = transaction.DescriptionTransaction,
                    CreatedAt = transaction.CreateAt,
                    IsPending = transaction.IsPending,
                    IconPath = transaction.IconPath
                };
                transactionModels.Add(transactionModel);
            });

            return transactionModels;
        }

        public static User Map(UserModel userModel)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userModel.Name,
                Balance = userModel.Balance,
                MaxLimit = userModel.MaxLimit,
                Available = userModel.Available,
                DailyPoints = new List<DailyPoint>(),
                Transactions = new List<Transaction>()
            };
            return user;
        }

        public static List<UserModel> Map(List<User> users)
        {
            List<UserModel> userModels = new List<UserModel>();

            users.ForEach(u =>
            {
                var userModel = new UserModel
                {
                    UserId = u.Id,
                    Name = u.Name,
                    Balance = u.Balance,
                    MaxLimit = u.MaxLimit,
                    Available = u.Available
                };
                userModels.Add(userModel);
            });

            return userModels;
        }

        public static List<GetUsers> Map(List<UserModel> userModels)
        {
            List<GetUsers> getUsersModels = new List<GetUsers>();
            userModels.ForEach(user =>
            {
                var getUsersModel = new GetUsers
                {
                    Id = user.UserId,
                    Name = user.Name,
                    Balance = user.Balance,
                    MaxLimit = user.MaxLimit,
                    Available = user.Available
                };
                getUsersModels.Add(getUsersModel);
            });
            return getUsersModels;
        }

        public static UserModel Map(User user)
        {
            List<TransactionModel> transactions = new List<TransactionModel>();
            foreach (var item in user.Transactions)
            {
                var transaction = new TransactionModel
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    NameTransaction = item.NameTransaction,
                    TransactionType = (BAL.Model.TransactionType)item.TransactionType,
                    Sum = item.Sum,
                    CreatedAt = item.CreateAt
                };
                transactions.Add(transaction);
            }

            var userModel = new UserModel
            {
                UserId = Guid.NewGuid(),
                Name = user.Name,
                Transactions = transactions,
            };

            return userModel;
        }

        public static TransactionDetail MapModelTransactionDetail(UserModel userModel)
        {
            foreach (var temp in userModel.Transactions)
            {
                var transactionDetail = new TransactionDetail
                {
                    Name = userModel.Name,
                    TransactionName = temp.NameTransaction,
                    Total = temp.Sum,
                    TransactionType = (DAL.Entity.TransactionType)temp.TransactionType,
                    CreateAt = temp.CreatedAt
                };
                return transactionDetail;
            }
            return null;
        }
    }
}
