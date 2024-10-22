﻿using AutoMapper;
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
    public class SellerController : Controller
    {
        private readonly IRepository<Seller> _repository;
        private readonly IMapper _mapper;

        public SellerController(IRepository<Seller> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sellers = await _repository.GetAsync();
            IEnumerable<SellerViewModel> response = _mapper.Map<IEnumerable<SellerViewModel>>(sellers);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var seller = await _repository.GetAsync(x => x.Id == id);
            SellerViewModel response = _mapper.Map<SellerViewModel>(seller);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SellerViewModel seller)
        {
            seller.Id = 0;
            Seller mapped = _mapper.Map<Seller>(seller);
            Seller response = await _repository.InsertAsync(mapped);
            return Ok(_mapper.Map<SellerViewModel>(response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SellerViewModel seller)
        {
            Seller mapped = _mapper.Map<Seller>(seller);
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
