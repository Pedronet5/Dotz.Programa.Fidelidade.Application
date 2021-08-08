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
    public class PointsTransationController : Controller
    {
        private readonly IPointsTransactionRepository _pointsTransactionRepository;
        public PointsTransationController(IPointsTransactionRepository pointsTransactionRepository)
        {
            _pointsTransactionRepository = pointsTransactionRepository;
        }

        [HttpGet]
        [Route("GetExtractByUserId")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetExtractQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager,user")]
        public IActionResult GetExtractByUserId(int UserId)
        {
            try
            {
                var result = _pointsTransactionRepository.GetExtractByUserId(UserId);

                if (result == null)
                    return new NotFoundObjectResult($"Cliente sem histórico de transações.");
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetBalanceAccountByUserId")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(float), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager,user")]
        public IActionResult GetBalanceAccountByUserId(int UserId)
        {
            try
            {
                var result = _pointsTransactionRepository.GetBalanceAccountByUserId(UserId);

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
        [ProducesResponseType(typeof(GetExtractQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager,employee")]
        public IActionResult PostProduct([FromQuery] PointsTransationRequest pointsTransationRequest)
        {
            try
            {
                var result = _pointsTransactionRepository.PostPointsTransation(pointsTransationRequest, EOperationType.Credito);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na gravação da transação");
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
