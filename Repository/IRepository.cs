using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);

        // SaveChanges: Guarda los datos en la base de datos pero se usa en entity framework o otros ORM que lo requieran
        // Luego en UnitOfWork se implementa este método para guardar los datos en la base de datos integrando todos los repositorios.
        //void SaveChanges();
    }
}
