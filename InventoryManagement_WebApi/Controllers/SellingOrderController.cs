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
    public class SellingOrderController : Controller
    {
        private readonly IRepository<SellingOrder> _repository;
        private readonly IMapper _mapper;

        public SellingOrderController(IRepository<SellingOrder> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sellingOrders = await _repository.GetAsync();
            IEnumerable<SellingOrderViewModel> response = _mapper.Map<IEnumerable<SellingOrderViewModel>>(sellingOrders);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sellingOrder = await _repository.GetAsync(x => x.Id == id);
            SellingOrderViewModel response = _mapper.Map<SellingOrderViewModel>(sellingOrder);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SellingOrderViewModel sellingOrder)
        {
            sellingOrder.Id = 0;
            SellingOrder mapped = _mapper.Map<SellingOrder>(sellingOrder);
            SellingOrder response = await _repository.InsertAsync(mapped);
            return Ok(_mapper.Map<SellerViewModel>(response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SellingOrderViewModel sellingOrder)
        {
            SellingOrder mapped = _mapper.Map<SellingOrder>(sellingOrder);
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
