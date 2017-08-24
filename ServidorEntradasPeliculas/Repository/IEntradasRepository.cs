using ServidorDatosBancarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorDatosBancarios.Repository {
    public interface IEntradasRepository {
        Entrada Create(Entrada entrada);
        Entrada Read(long id);
        IQueryable<Entrada> ReadAll();
        void Update(long id, Entrada entrada);
        Entrada Delete(long id);
    }
}
