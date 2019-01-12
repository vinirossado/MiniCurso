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
        IEnumerable List();
        IActionResult Find(long id);

        IActionResult Post([FromBody]T obj);

        IActionResult Delete(long id);
    }
}
