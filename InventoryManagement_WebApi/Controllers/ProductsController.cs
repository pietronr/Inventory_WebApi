using InventoryManagement.Entities.Models;
using InventoryManagement.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagement.WebApi.Controllers
{
    [ApiController]
    [EnableCors("InventoryManagementPolicy")]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _repository;

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.GetAsync(x => x.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {

            return Ok(await _repository.InsertAsync(product));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            return Ok(await _repository.UpdateAsync(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _repository.DeleteAsync(id);
            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}
