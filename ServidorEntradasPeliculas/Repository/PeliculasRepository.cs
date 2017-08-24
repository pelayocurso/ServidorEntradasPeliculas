using ServidorDatosBancarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorDatosBancarios.Repository
{
    public class PeliculasRepository:IPeliculasRepository
    {
        public Pelicula Create(Pelicula pelicula)
        {
            return ApplicationDbContext.applicationDbContext.Peliculas.Add(pelicula);
        }

        public Pelicula Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Peliculas.Find(id);
        }

        public IQueryable<Pelicula> ReadAll()
        {
            IList<Pelicula> peliculas = new List<Pelicula>(ApplicationDbContext.applicationDbContext.Peliculas);
            return peliculas.AsQueryable();
        }

        public void Update(long id, Pelicula pelicula)
        {
            if (ApplicationDbContext.applicationDbContext.Peliculas.Count(e => e.Id == pelicula.Id) == 0)
            {
                throw new Exception("No se ha encontrado la entidad.");
            }
        }

        public Pelicula Delete(long id)
        {
            Pelicula pelicula = ApplicationDbContext.applicationDbContext.Peliculas.Find(id);
            if (pelicula == null)
            {
                throw new Exception("No se ha encontrado la entidad.");
            }
            ApplicationDbContext.applicationDbContext.Peliculas.Remove(pelicula);
            return pelicula;
        }
    }
}
