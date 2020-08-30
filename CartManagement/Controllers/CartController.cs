using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartManagement.Business.Interfaces;
using CartManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CartManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<Product> GetProduct(int id)
        {
            return Ok(_cartService.GetProduct(id));
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(_cartService.GetProducts());
        }

        [HttpGet]
        public ActionResult GetHealth()
        {
            return Ok("OK");
        }
    }
}
