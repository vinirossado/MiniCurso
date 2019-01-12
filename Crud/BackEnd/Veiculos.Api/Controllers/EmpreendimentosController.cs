using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHome.Api.Controllers.Interface;
using MyHome.app.Interface;
using MyHome.Security;
using OnAuth2;
using System;
using System.Collections;

namespace MyHome.Api.Controllers
{
    [Route("empreendimentos")]
    public class EmpreendimentosController : ControllerBase, IBaseController<Empreendimento>
    {
        private readonly IEmpreendimentoApp _empreendimentoApp;

        public EmpreendimentosController(IEmpreendimentoApp empreendimentoApp)
        {
            _empreendimentoApp = empreendimentoApp;
        }

        [HttpDelete("cliente/{clienteAppId}/{id}")]
        //[Authorize]
        public virtual IActionResult Delete(long clienteAppId, long id)
        {
            try
            {
                _empreendimentoApp.Remove(clienteAppId, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet("cliente/{clienteAppId}/{id}")]
        //[Authorize]
        public IActionResult Get(long clienteAppId, long id)
        {
            try
            {
               return Ok(_empreendimentoApp.Find(clienteAppId, id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[Authorize]
        [HttpGet("cliente/{clienteAppId}")]
        public IEnumerable List(long clienteAppId)
        {
            return _empreendimentoApp.List(clienteAppId);
        }

        [HttpPost("cliente/{clienteAppId}")]
        public IActionResult Post(long clienteAppId, [FromBody] Empreendimento obj)
        {
            try
            {
                return Ok(_empreendimentoApp.Save(clienteAppId, obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
