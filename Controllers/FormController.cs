using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIformCad.Models;
using APIformCad.Services;
using Microsoft.AspNetCore.Cors;

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

        [EnableCors("AllowMyOrigin")]
        [HttpPost("Cadastrar")]
        public ActionResult<Usuario> Cadastrar( Usuario usu )
        {
            _Services.Create(usu);

            return CreatedAtAction("Usuario", new { id = usu.Id.ToString()  }, usu);
        }

        [HttpGet("consulta/{nome}")]
        public Usuario ConsultaUsuario(string nome)
        {
            Usuario result = _Services.Get(nome);
            return result;
        }

        [HttpGet("consulta")]
        public IEnumerable<Usuario> ConsultaUsuario()
        {
            IList<Usuario> result = _Services.Get();
            return result;
        }

        [EnableCors("AllowMyOrigin")]
        [HttpGet("Teste")]
        public object Teste()
        {
            var dados = new { Nome = "Luan", Sobrenome = "Simoes" };
            return dados;
        }
    }
}