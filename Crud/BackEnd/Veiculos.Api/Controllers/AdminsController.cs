using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHome.Api.Controllers.Interface;
using MyHome.App.Interface;
using MyHome.Security;
using OnAuth2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Api.Controllers
{
    [Route("admins")]
    public class AdminsController : ControllerBase, IBaseController<Admin>
    {

        private readonly IAdminApp _adminApp;
        public AdminsController(IAdminApp adminApp) => _adminApp = adminApp;

        [HttpGet("cliente/{clienteAppId}")]
        //[Authorize]
        public virtual IActionResult Get(long clienteAppId) => Ok(_adminApp.List(clienteAppId));

        [HttpGet("cliente/{clienteAppId}/{id}")]
        //[Authorize]
        public virtual IActionResult Get(long clienteAppId, long id) => Ok(_adminApp.Find(clienteAppId, id));

        [HttpPost("cliente/{clienteAppId}")]
        //[Authorize]
        public virtual IActionResult Post(long clienteAppId, [FromBody]Admin usuario)
        {
            try
            {
                var alterandoSenha = false;
                return Ok(_adminApp.SaveAdmin(clienteAppId, usuario, alterandoSenha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("cliente/{clienteAppId}/{id}")]
        //[Authorize]
        public virtual IActionResult Delete(long clienteAppId, long id)
        {
            try
            {
                _adminApp.Remove(clienteAppId, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IEnumerable List(long clienteAppId)
        {
            return _adminApp.List(clienteAppId);
        }
    }
}
