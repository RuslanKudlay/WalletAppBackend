using System;
using System.Threading.Tasks;

namespace RAL.Repository.PaymentRepository
{
    public interface IPaymentRepository
    {
        Task<bool> GetPaymentDue(Guid userId);
    }
}
