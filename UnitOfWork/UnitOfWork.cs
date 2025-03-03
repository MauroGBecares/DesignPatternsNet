using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // Las listas simulas ser el contexto de la base de datos
        private List<Movie> _movieList;
        private List<MovieGenre> _movieGenreList;
        private IRepository<Movie> _movies;
        private IRepository<MovieGenre> _movieGenres;

        // Estos datos vendrían de una base de datos. Pero en este caso, los datos son hardcoded. Y lo traemos desde program.cs
        public UnitOfWork(List<Movie> movies, List<MovieGenre> movieGenres)
        {
            _movieList = movies;
            _movieGenreList = movieGenres;
        }

        public IRepository<Movie> Movies
        {
            get => _movies ??= new Repository<Movie>(_movieList);
        }

        public IRepository<MovieGenre> MovieGenres
        {
            get => _movieGenres ??= new Repository<MovieGenre>(_movieGenreList);
        }

        public void Save()
        {
            Console.WriteLine("Se guardaron los datos en la base de datos");
        }
    }
}
