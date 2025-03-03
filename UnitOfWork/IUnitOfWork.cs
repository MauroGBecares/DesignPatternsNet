using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Movie> Movies { get; }
        IRepository<MovieGenre> MovieGenres { get; }
        void Save();
    }
}
