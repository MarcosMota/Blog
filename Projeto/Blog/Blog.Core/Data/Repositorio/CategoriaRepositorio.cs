using Blog.Core.Domain;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Blog.Core.Data.Repositorio
{
    public class CategoriaRepositorio : IRepository<Categorias>
    {
        private EfDbContext db;
        public CategoriaRepositorio(EfDbContext _db)
        {
            db = _db;
        }

        public void Delete(List<Categorias> entities)
        {
            if (entities == null)
                throw new BlogException("lista de categoria é nula");
            if (entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    db.Categorias.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public void Delete(Categorias entity)
        {
            if (entity == null)
                throw new BlogException("Categoria Null");

            db.Categorias.Remove(entity);
            db.SaveChanges();
            
        }

        public List<Categorias> GetAll()
        {
            return db.Categorias.AsEnumerable().ToList();
        }

        public Categorias GetById(object id)
        {
            return db.Categorias.Find(id);
        }

        public List<Categorias> GetForQuery(Func<Categorias, bool> filtro)
        {
            return db.Categorias.Where(filtro).ToList();
        }

        public void Insert(List<Categorias> entities)
        {
            if (entities == null)
                throw new BlogException("lista de categoria é nula");
            if (entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    db.Categorias.Add(item);
                }
                    db.SaveChanges();
            }
        }

        public void Insert(Categorias entity)
        {
            if (entity == null)
                throw new BlogException("categoria é nula");
            
                    db.Categorias.Remove(entity);
                    db.SaveChanges();
            
        }

        public void Update(List<Categorias> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Categorias entity)
        {
            if (entity == null)
                throw new BlogException("categoria é nula");
            Categorias categoria = db.Categorias.Find(entity.id_categoria);

            categoria = entity;
            db.SaveChanges();
        }
    }
}
