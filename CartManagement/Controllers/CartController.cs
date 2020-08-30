using System;
using System.Net;
using Ardalis.GuardClauses;
using CartManagement.Business.Interfaces;
using CartManagement.Domain.Requests;
using CartManagement.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CartManagement.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public ActionResult<AddProductToCartResponse> AddProductToCart(AddProductToCartRequest addProductToCartRequest)
        {
            try
            {
                Guard.Against.Null(addProductToCartRequest, nameof(addProductToCartRequest));
                Guard.Against.NegativeOrZero(addProductToCartRequest.CustomerId, nameof(addProductToCartRequest.CustomerId));
                Guard.Against.NegativeOrZero(addProductToCartRequest.ProductId, nameof(addProductToCartRequest.ProductId));
                Guard.Against.NegativeOrZero(addProductToCartRequest.Quantity, nameof(addProductToCartRequest.Quantity));

                AddProductToCartResponse response = _cartService.AddProductToCart(addProductToCartRequest.ProductId, addProductToCartRequest.CustomerId, addProductToCartRequest.Quantity);

                if (response.ErrorMessage == string.Empty)
                {
                    return Ok(response);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new AddProductToCartResponse {
                    ErrorMessage = ex.Message
                });
            }
            
        }

    }
}
