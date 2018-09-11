using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CoreMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Nota> Get()
        {
            var contexto = new MongoDbContext();
            var notas = contexto.Notas.Find(o => true).ToList();

            return notas.ToArray();
        }

        [HttpGet("{id}", Name = "Get")]
        public Nota Get(int id)
        {
            var contexto = new MongoDbContext();
            var nota = contexto.Notas.Find(o => o.Titulo != "alala").FirstOrDefault();

            return nota;
        }

        [HttpPost]
        public void Post([FromBody] Nota nota)
        {
            var contexto = new MongoDbContext();
            contexto.Notas.InsertOne(nota);
        }

        // PUT: api/Notas/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Nota item)
        {
            var contexto = new MongoDbContext();
            var nota = contexto.Notas.Find(o => o.Id == id).FirstOrDefault();

            nota.Titulo = item.Titulo;
            nota.Conteudo = item.Conteudo;
            nota.Acessos = item.Acessos;

            //contexto.Notas.UpdateOne(o => o.Id == id, nota);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var contexto = new MongoDbContext();
            //contexto.Notas.DeleteOne();
        }
    }
}
