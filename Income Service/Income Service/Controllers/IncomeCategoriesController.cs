using Finance_App.Entity;
using Income_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Income_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeCategoriesController : ControllerBase
    {

        private readonly ICatagoryRepository _catagoryRepository;

        public IncomeCategoriesController(ICatagoryRepository repository)
        {
            _catagoryRepository = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<Catagory>> GetCategories()
        {
            var categories = _catagoryRepository.GetAllCatagories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCatagory(int id)
        {
            var catagory = _catagoryRepository.GetCatagory(id);
            if (catagory == null)
            {
                return NotFound("Catagory Not Found");
            }
            return Ok(catagory); ;
        }

        [HttpGet("Name/{name}")]
        public IActionResult GetCatagoryByName(string name)
        {
            var catagory = _catagoryRepository.GetCatagoryByName(name);
            if (catagory == null)
            {
                return NotFound("Catagory Not Found");
            }
            return Ok(catagory); ;
        }

        [HttpPost]
        public IActionResult AddCatagory(Catagory catagory)
        {
            var newCatagory = _catagoryRepository.AddCatagory(catagory);
            return Ok(newCatagory); ;
        }

    }
}
