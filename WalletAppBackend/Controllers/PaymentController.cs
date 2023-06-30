using BAL.Service.PaymentService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WalletAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("get-payment-due")]
        public async Task<IActionResult> GetPaymentDue(Guid userId)
        {
            var res = await _paymentService.GetPaymentDue(userId);
            return Ok(res);
        }
    }
}
