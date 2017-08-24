using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorEntradasPeliculas.Models
{
    public class Entrada
    {
        [Key]
        public long Id { get; set; }
        public string Pelicula { get; set; }
        public DateTime Sesion { get; set; }
        public float Precio { get; set; }

    }
}
