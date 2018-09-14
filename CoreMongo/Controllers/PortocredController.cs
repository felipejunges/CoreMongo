using CoreMongo.Models.Portocred;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortocredController : ControllerBase
    {
        [Route("{id}/{cpf}")]
        [HttpGet]
        public RoboEnelPropostaResponse Get(string id, string cpf)
        {
            return new RoboEnelPropostaResponse()
            {
                Nome = "José dos Santos",
                Concessionaria = "Ceará",
                RegiaoAtendimento = "CE",
                DataProximaLeitura = DateTime.Now.AddDays(7),
                DataUltimoVencimento = DateTime.Now.AddDays(-10),
                DataEmissaoFatura = DateTime.Now.AddDays(-20),
                DataNascimento = new DateTime(1900, 5, 1),
                NomeMae = "Maria Luisa dos Santos"
            };
        }

        [HttpPost]
        public void Salva()
        {

        }
    }
}