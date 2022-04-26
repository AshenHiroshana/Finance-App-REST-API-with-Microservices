using Finance_App.Entity;
using Income_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Income_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICatagoryRepository _catagoryRepository;

        public CategoriesController(ICatagoryRepository repository)
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

    }
}
