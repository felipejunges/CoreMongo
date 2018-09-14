using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var retorno = new string[] { "Linha XXX" };

            return retorno;
        }

        [Route("{id}/[action]")]
        [HttpGet]
        public IEnumerable<string> Status(string id)
        {
            var retorno = new string[] { "Linha 1", "Linha 2", "Linha 3", $"Id {id}", "Linha 4", "Linha 5" };

            return retorno;
        }

        [Route("{id}/[action]")]
        [HttpGet]
        public IEnumerable<string> Ofertas(string id)
        {
            var retorno = new string[] { "Linha X1", "Linha X2", "Linha X3", $"Id X{id}", "Linha X4" };

            return retorno;
        }

        [Route("{id}/propostas")]
        [HttpGet]
        public IEnumerable<string> Propostas(string id)
        {
            var retorno = new string[] { "Linha Y1", "Linha Y2", $"Id X{id}", "Linha Y3" };

            return retorno;
        }
    }
}