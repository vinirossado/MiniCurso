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
    [Route("clientes")]
    public class ClientesController : ControllerBase, IBaseController<Cliente>
    {
        private readonly IClienteApp _clienteApp;
        public ClientesController(IClienteApp clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpGet("cliente/{clienteAppId}")]
        [AuthorizeRoles(Permissoes.Admin)]
        public virtual IActionResult List(long clienteAppId)
        {
            var retorno = _clienteApp.List(clienteAppId);
            return Ok(retorno);
        }

        [HttpGet("cliente/{clienteAppId}/{id}")]
        [AuthorizeRoles(Permissoes.Admin)]
        public virtual IActionResult Get(long clienteAppId, long id) => Ok(_clienteApp.Find(clienteAppId, id));
        
        [HttpPost("cliente/{clienteAppId}")]
        public virtual IActionResult Post(long clienteAppId, [FromBody]Cliente cliente)
        {
            try
            {
                var alterandoSenha = false;
                return Ok(_clienteApp.Save(clienteAppId, cliente, alterandoSenha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("cliente/{clienteAppId}/{id}")]
        [AuthorizeRoles(Permissoes.Admin)]
        public virtual IActionResult Delete(long clienteAppId, long id)
        {
            try
            {
                _clienteApp.Remove(clienteAppId, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        IEnumerable IBaseController<Cliente>.List(long clienteAppId)
        {
            return _clienteApp.List(clienteAppId);
            
        }
    }
}
