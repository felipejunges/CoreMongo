using CoreMongo.Models;
using CoreMongo.Repositorys;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
            var nota = contexto.Notas.Find(o => true).FirstOrDefault();

            return nota;
        }

        [HttpPost]
        public void Post([FromBody] Nota nota)
        {
            var contexto = new MongoDbContext();
            //contexto.Notas.InsertOne(nota);

            BsonDocument doc = new BsonDocument();
            doc.Add("nome", "Maack");
            doc.Add("linguagemFavorita", "C#");
            doc.Add("linguagemQueMenosGosta", "Java");
            contexto.NotasDocs.InsertOne(doc);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Nota nota)
        {
            var contexto = new MongoDbContext();
            contexto.Notas.ReplaceOne(o => o.Id == id, nota);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var contexto = new MongoDbContext();
            contexto.Notas.DeleteOne(o => o.Id == id);
        }
    }
}