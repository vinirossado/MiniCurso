using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veiculos.Api.Controllers.Interface
{
    public interface IBaseController<T> where T : class
    {
        IEnumerable List(long clienteAppId);
        IActionResult Find(long clienteAppId, long id);

        IActionResult Post(long clienteAppId, [FromBody]T obj);

        IActionResult Delete(long clienteAppId, long id);
    }
}
