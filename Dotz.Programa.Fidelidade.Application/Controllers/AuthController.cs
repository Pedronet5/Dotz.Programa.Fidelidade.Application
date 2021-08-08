using Dotz.Programa.Fidelidade.Configurations;
using Dotz.Programa.Fidelidade.Domain.Models;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Dotz.Programa.Fidelidade.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult GetToken([FromBody] UserValidAccountModel userValidAccountCommand)
        {
            var user = UserLogin(userValidAccountCommand);

            if (user == null)
                return Unauthorized("Usuário sem permissão de acesso.");

            var tokenString = TokenService.GenerateToken(user);

            return Ok(new { Token = tokenString });
        }

        private GetUserAccountQueryResult UserLogin(UserValidAccountModel login)
        {
            var emailValido = ValidateEmailService.EmailEValido(login?.Email);

            if (login == null || !emailValido || string.IsNullOrWhiteSpace(login.Password))
                return null;

            return _userRepository.GetValidAccount(login);
        }
    }
}

