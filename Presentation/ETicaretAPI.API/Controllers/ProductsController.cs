using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository = null, ICustomerWriteRepository customerWriteRepository = null, IOrderWriteRepository orderWriteRepository = null, ICustomerReadRepository customerReadRepository = null, IOrderReadRepository orderReadRepository = null)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderReadRepository = orderReadRepository;
        }


        [HttpGet]
        public async Task Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("44CF07D1-31B2-45D5-1D7F-08DAF1A0E555");
            order.Address = "İstanbul";
            await _orderWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
