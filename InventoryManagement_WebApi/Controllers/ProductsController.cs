using AutoMapper;
using InventoryManagement.Entities.Dtos;
using InventoryManagement.Entities.Models;
using InventoryManagement.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.WebApi.Controllers
{
    [ApiController]
    [EnableCors("InventoryManagementPolicy")]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductsController(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repository.GetAsync();
            IEnumerable<ProductViewModel> response = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _repository.GetAsync(x => x.Id == id);
            ProductViewModel response = _mapper.Map<ProductViewModel>(product);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel product)
        {
            product.Id = 0;
            Product mapped = _mapper.Map<Product>(product);
            Product response = await _repository.InsertAsync(mapped);
            return Ok(_mapper.Map<SellerViewModel>(response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductViewModel product)
        {
            Product mapped = _mapper.Map<Product>(product);
            return Ok(await _repository.UpdateAsync(mapped));
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
