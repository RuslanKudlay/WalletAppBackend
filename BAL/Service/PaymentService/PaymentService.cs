using RAL.Repository.PaymentRepository;
using System;
using System.Threading.Tasks;

namespace BAL.Service.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<string> GetPaymentDue(Guid userId)
        {
            bool hasPaymentTransaction = await _paymentRepository.GetPaymentDue(userId);
            DateTime currentDate = DateTime.UtcNow;

            if (hasPaymentTransaction)
            {
                return $"You've paid your {currentDate.ToString("MMMM")} balance";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
