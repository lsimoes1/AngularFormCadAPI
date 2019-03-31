using System.Collections.Generic;
using System.Linq;
using APIformCad.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace APIformCad.Services
{
    public class FormServices
    {
        private readonly IMongoCollection<Usuario> _usuario;

        public FormServices(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("FormDB");
            _usuario = database.GetCollection<Usuario>("Usuario");
        }

        public List<Usuario> Get()
        {
            return _usuario.Find(Usuario => true).ToList();
        }

        public Usuario Get(string id)
        {
            return _usuario.Find<Usuario>(Usuario => Usuario.Id == id).FirstOrDefault();
        }

        public Usuario Create(Usuario usuario)
        {
            _usuario.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Usuario usuario)
        {
            _usuario.ReplaceOne(usu => usu.Id == id, usuario);
        }

        public void Remove(Usuario usuario)
        {
            _usuario.DeleteOne(usu => usu.Id == usuario.Id);
        }

        public void Remove(string id)
        {
            _usuario.DeleteOne(usu => usu.Id == id);
        }
    }
}
