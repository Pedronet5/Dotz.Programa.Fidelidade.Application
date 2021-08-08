using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Models;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dotz.Programa.Fidelidade.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        [Route("GetAddress")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetUserAccountQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetAddress([FromQuery] int UserId)
        {
            try
            {
                var result = _addressRepository.GetAddress(UserId);

                if (result == null)
                    return new NotFoundObjectResult($"Nenhum endereço encontrado para o usuário informado: {UserId}");
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PostAddress")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetAddressQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager,employee")]
        public IActionResult PostAddress([FromQuery] AddressModel addressModel)
        {
            try
            {
                var result = _addressRepository.PostAddressAccount(addressModel);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na gravação do endereço");
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
