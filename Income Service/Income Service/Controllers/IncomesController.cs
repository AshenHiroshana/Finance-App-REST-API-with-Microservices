using Finance_App.Entity;
using Income_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Income_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {

        private readonly ITransactionRepository _transactionRepository;

        public IncomesController(ITransactionRepository repository)
        {
            _transactionRepository = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<Transaction>> GetTransactions()
        {
            var categories = _transactionRepository.GetAllTransactions();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            var catagory = _transactionRepository.GetTransaction(id);
            if (catagory == null)
            {
                return NotFound("Catagory Not Found");
            }
            return Ok(catagory); ;
        }

    }
}
