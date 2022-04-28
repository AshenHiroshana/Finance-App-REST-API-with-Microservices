using Expense_Service.Models;
using Expense_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {

        private readonly ITransactionRepository _transactionRepository;

        public ExpensesController(ITransactionRepository repository)
        {
            _transactionRepository = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<Transaction>> GetTransactions()
        {
            var transactions = _transactionRepository.GetAllTransactions();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            var transaction = _transactionRepository.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound("Transaction Not Found");
            }
            return Ok(transaction); ;
        }

        [HttpPost]
        public IActionResult AddTransaction(Transaction transaction)
        {
            var newTransaction = _transactionRepository.AddTransaction(transaction);
            return Ok(newTransaction); ;
        }

        [HttpPut]
        public IActionResult UpdateTransaction(Transaction transaction)
        {
            
            if (_transactionRepository.GetTransaction((int)transaction.Id) == null)
            {
                return NotFound("Transaction Not Found");
            }

            var newTransaction = _transactionRepository.UpdateTransaction(transaction);
            return Ok(newTransaction);


        }


        [HttpDelete("{id}")]
        public IActionResult AddTransaction(int id)
        {
            Transaction transaction = _transactionRepository.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound("Transaction Not Found");
            }

            _transactionRepository.DeleteTransaction(transaction);
            return Ok("Transaction Successfully Deleted");
        }

    }
}
