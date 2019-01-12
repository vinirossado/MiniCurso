using Microsoft.AspNetCore.Mvc;
using MyHome.App.Interface;
using MyHome.Dtos;
using MyHome.Security;
using OnAuth2;
using System;

namespace MyHome.Api.Controllers
{
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginApp _loginApp;
        public LoginController(ILoginApp loginApp) => _loginApp = loginApp;

        [HttpPost("cliente/{clienteAppId}/{role}")]
        public IActionResult Login(long clienteAppId, string role, [FromBody]DefaultLogin login)
        {
            try
            {
                return Ok(_loginApp.Login(clienteAppId, role, login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

        }

        [HttpPost("cliente/{clienteAppId}/social/{role}")]
        public IActionResult LoginSocial(long clienteAppId, string role, [FromBody]SocialLogin login)
        {
            try
            {
                return Ok(_loginApp.LoginSocial(clienteAppId, role, login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        //[AuthorizeRoles(Permissoes.Admin, Permissoes.User)]
        [HttpPost("cliente/{clienteAppId}/alterar-senha/{perfil}")]
        public IActionResult AlterarSenha(long clienteAppId, string perfil, [FromBody]ChangePassword changePassword)
        {
            try
            {
                _loginApp.AlterarSenha(clienteAppId, perfil, changePassword);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

        }

        [HttpGet("resetar-senha/{role}/{email}/{clienteAppId}")]
        public IActionResult ResetSenha(string role, string email, long clienteAppId)
        {
            try
            {
                return Ok(_loginApp.GenerateResetCode(clienteAppId, role, email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

        }

        [HttpPost("cliente/{clienteAppId}/resetar-senha/{role}/cadastrar")]
        public IActionResult CadastrarNovaSenha(long clienteAppId, string role, [FromBody] ResetarSenhaDto reset)
        {
            try
            {
                _loginApp.ResetPassword(clienteAppId, role, reset);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

        }
    }
}
