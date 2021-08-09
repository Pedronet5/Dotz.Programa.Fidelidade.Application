using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Dotz.Programa.Fidelidade.Domain.Enums;

namespace Dotz.Programa.Fidelidade.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPointsTransactionRepository _pointsTransactionRepository;
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IExchangeItemRepository _exchangeItemRepository;

        public ExchangeController(IProductRepository productRepository, IPointsTransactionRepository pointsTransactionRepository,
            IExchangeRepository exchangeRepository, IExchangeItemRepository exchangeItemRepository)
        {
            _productRepository = productRepository;
            _pointsTransactionRepository = pointsTransactionRepository;
            _exchangeRepository = exchangeRepository;
            _exchangeItemRepository = exchangeItemRepository;
        }

        [HttpGet]
        [Route("GetExchangeListing")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetProductQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetExchangeListing([FromQuery] int userId)
        {
            try
            {
                var balance = _pointsTransactionRepository.GetBalanceAccountByUserId(userId);

                if (balance == 0)
                {
                    return new NotFoundObjectResult($"Saldo insuficiente para realizar trocas!");
                }
                else
                {
                    var result = _productRepository.GetProductsExchangeListing(balance);
                    return new OkObjectResult(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetExchangesByUser")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetExchangeByUserQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetExchangesByUser([FromQuery] int userId)
        {
            try
            {
                var result = _exchangeRepository.GetExchangeByUserId(userId);

                if (result == null)
                    return new NotFoundObjectResult($"Nenhuma exchange encontrada para o usuário informado: {userId}");
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PostExchange")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager,employee")]
        public IActionResult PostExchange([FromBody] ExchangeRequest exchangeRequest)
        {
            try
            {
                var result = _exchangeRepository.PostExchange(exchangeRequest);

                if (!result)
                {
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na gravação da troca");
                }
                else
                {
                    float valor = 0;
                    string produtos = "";
                    foreach (var item in exchangeRequest.ProductsIds)
                    {
                        valor += _productRepository.GetProductValue(item);
                        produtos += item + ", ";
                    }

                    PointsTransationRequest pointsTransationRequest = new PointsTransationRequest();
                    pointsTransationRequest.UserId = exchangeRequest.UserId;
                    pointsTransationRequest.CompanyId = exchangeRequest.CompanyId;
                    pointsTransationRequest.Value = valor;
                    pointsTransationRequest.Description = $"Débito referente a troca dos produtos: {produtos.Remove(produtos.Length -1)}";

                    _pointsTransactionRepository.PostPointsTransation(pointsTransationRequest, EOperationType.Debito);
                    return new OkObjectResult(result);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetExchangeDelivery")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetProductQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetExchangeDelivery([FromQuery] int userId)
        {
            try
            {
                var balance = _pointsTransactionRepository.GetBalanceAccountByUserId(userId);

                if (balance == 0)
                {
                    return new NotFoundObjectResult($"Saldo insuficiente para realizar trocas!");
                }
                else
                {
                    var result = _productRepository.GetProductsExchangeListing(balance);
                    return new OkObjectResult(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetOrderListingExchange")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetExchangeListingQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetOrderListingExchange([FromQuery] int ExchangeId)
        {
            try
            {
                var result = _exchangeRepository.GetExchangeListing(ExchangeId);

                if (result == null)
                {
                    return new NotFoundObjectResult($"Nenhum pedido encontrado para o pedido de troca informado: {ExchangeId}");
                }
                else
                {
                    var item = _exchangeItemRepository.GetExchangeItens(ExchangeId);

                    result.Itens = item;


                    return new OkObjectResult(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}