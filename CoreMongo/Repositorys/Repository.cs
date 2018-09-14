using CoreMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreMongo.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MongoDbContext _context = null;

        public Repository(IOptions<Settings> settings)
        {
            _context = new MongoDbContext();
        }

        /*public async Task<IEnumerable<T>> Get()
        {
            try
            {
                return await _context.Notas.Find(m => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public async Task Insert(T obj)
        {
            await _context.Database.GetCollection<T>("Notas").InsertOneAsync(obj);
        }
    }
}