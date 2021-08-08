using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Dotz.Programa.Fidelidade.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetProductQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var result = _productRepository.GetAllProduct();

                if (result == null)
                    return new NotFoundObjectResult($"Nenhum produto encontrado.");
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetByProductId")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetProductQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetByProductId(int ProductId)
        {
            try
            {
                var result = _productRepository.GetByProductId(ProductId);

                if (result == null)
                    return new NotFoundObjectResult($"Nenhum produto encontrado.");
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PostProduct")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager")]
        public IActionResult PostProduct([FromQuery] ProductRequest productModel)
        {
            try
            {
                var result = _productRepository.PostProduct(productModel);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na gravação do produto");
                else
                    return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutProduct")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager")]
        public IActionResult PutProduct([FromQuery] ProductPutRequest productPutRequest)
        {
            try
            {
                var result = _productRepository.PutProduct(productPutRequest);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na atualização do produto");
                else
                    return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager")]
        public IActionResult DeleteProduct([FromQuery] int ProductId)
        {
            try
            {
                var result = _productRepository.DeleteProduct(ProductId);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na exclusão do produto");
                else
                    return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
