using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // Esto en realidad, se debería de hacer con una base de datos, pero para efectos de este ejemplo,
        // se hará con una lista que nos traemos desde el program.
        private List<TEntity> _entities;
        public Repository(List<TEntity> entities)
        {
            _entities = entities;
        }
        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(int id)
        {
            if (id >= 0 && id < _entities.Count)
            {
                _entities.RemoveAt(id);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "El id proporcionado está fuera del rango.");
            }
        }

        public IEnumerable<TEntity> Get()
        {
            return _entities;
        }

        public TEntity Get(int id)
        {
            if (id >= 0 && id < _entities.Count)
            {
                return _entities[id];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "El id proporcionado está fuera del rango.");
            }
        }

        public void Update(TEntity entity)
        {
            var index = _entities.IndexOf(entity);
            if (index != -1)
            {
                _entities[index] = entity;
            }
            else
            {
                throw new ArgumentException("La entidad proporcionada no existe en la lista.", nameof(entity));
            }
        }
    }
}
