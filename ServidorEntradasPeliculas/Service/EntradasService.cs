using ServidorDatosBancarios.Models;
using ServidorDatosBancarios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorDatosBancarios.Service
{
    public class EntradasService : IEntradasService
    {
        private IEntradasRepository entradasRepository;
        public EntradasService(IEntradasRepository entradasRepository)
        {
            this.entradasRepository = entradasRepository;
        }

        public Entrada Create(Entrada entrada)
        {
            return entradasRepository.Create(entrada);
        }

        public Entrada Read(long id)
        {
            return entradasRepository.Read(id);
        }

        public IQueryable<Entrada> ReadAll()
        {
            IQueryable<Entrada> entradas;
            entradas = entradasRepository.ReadAll();
            return entradas;
        }

        public void Update(long id, Entrada entrada)
        {
            entradasRepository.Update(id, entrada);
        }

        public Entrada Delete(long id)
        {
            //Entradas entrada = entradasRepository.Read(id);
            return entradasRepository.Delete(id);
        }
    }
}
