using BAL.Model;
using BAL.Service.TransactionService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WalletAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("add-transaction")]
        public async Task<IActionResult> AddTransaction(TransactionModel transactionModel)
        {
            try
            {
                await _transactionService.CreateTransaction(transactionModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-transactions-specific-user")]
        public async Task<IActionResult> GetListTransactions(Guid userId)
        {
            try
            {
                var result = await _transactionService.GetListTransactions(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-transaction-by-id")]
        public async Task<IActionResult> GetTransactionById(Guid transactionId)
        {
            var result = await _transactionService.GetTransactionById(transactionId);
            return Ok(result);
        }
    }
}
