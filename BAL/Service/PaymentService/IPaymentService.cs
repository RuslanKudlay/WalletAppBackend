using System;
using System.Threading.Tasks;

namespace BAL.Service.PaymentService
{
    public interface IPaymentService
    {
        Task<string> GetPaymentDue(Guid userId);
    }
}
