using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIformCad.Models;
using APIformCad.Services;

namespace APIformCad.Controllers
{
    [Route("api")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly FormServices _Services;
        public FormController(FormServices Services)
        {
            _Services = Services;
        }
        [HttpPost]
        public ActionResult<Usuario> Cadastrar( Usuario usu )
        {
            _Services.Create(usu);

            return CreatedAtAction("Usuario", new { id = usu.Id.ToString()  }, usu);
        }

        [HttpGet("Teste")]
        public string Teste()
        {
            return "Funcionando!";
        }
    }
}