using Dotz.Programa.Fidelidade.Domain.Commands;
using Dotz.Programa.Fidelidade.Domain.Models;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dotz.Programa.Fidelidade.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserAccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetUserAccount")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetUserAccountQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetUserAccount([FromQuery] UserAccountCommand userAccountCommand)
        {
            try
            {
                if (ValidateEmailService.EmailEValido(userAccountCommand.Email))
                {
                    var result = _userRepository.GetUserAccount(userAccountCommand);

                    if (result == null)
                        return new NotFoundObjectResult($"Conta de Email: {userAccountCommand.Email} não encontrada!");
                    else
                        return new OkObjectResult(result);
                }
                else
                    return new NotFoundObjectResult($"Email informado invalido!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PostUserAccount")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetUserAccountQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager")]
        public IActionResult PostUserAccount([FromQuery] UserAccountModel userAccountModel)
        {
            try
            {
                 if (ValidateEmailService.EmailEValido(userAccountModel.Email))
                {
                    if (!_userRepository.CheckExistingEmail(userAccountModel.Email))
                    {
                        var result = _userRepository.PostUserAccount(userAccountModel);

                        if (!result)
                            return new UnprocessableEntityObjectResult("Ocorreu um problema na gravação do usuário");
                        else
                            return new OkObjectResult(result);
                    }
                    else
                        return new UnprocessableEntityObjectResult("Email já cadastrado.");

                }
                else
                    return new NotFoundObjectResult($"O Email informado não é valido!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutUserAccount")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetUserAccountQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager")]
        public IActionResult PutUserAccount([FromQuery] UserAccountModel userAccountModel)
        {
            try
            {
                if (_userRepository.CheckExistingEmail(userAccountModel.Email))
                {
                    var result = _userRepository.PutUserAccount(userAccountModel);

                    if (!result)
                        return new UnprocessableEntityObjectResult("Ocorreu um problema na atualização do usuário");
                    else
                        return new OkObjectResult(result);
                }
                else
                    return new NotFoundObjectResult($"Email não cadastrado!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUserAccount")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetUserAccountQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager")]
        public IActionResult DeleteUserAccount([FromQuery] string Email)
        {
            try
            {
                if (_userRepository.CheckExistingEmail(Email))
                {
                    var result = _userRepository.DeleteUserAccount(Email);

                    if (!result)
                        return new UnprocessableEntityObjectResult("Ocorreu um problema na exclusão do usuário");
                    else
                        return new OkObjectResult(result);
                }
                else
                    return new NotFoundObjectResult($"Email não cadastrado!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
