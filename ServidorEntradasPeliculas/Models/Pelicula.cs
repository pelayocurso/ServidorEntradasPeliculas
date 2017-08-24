using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorEntradasPeliculas.Models
{
    public class Pelicula
    {
        [Key]
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Ano { get; set; }
        public string Pais { get; set; }
        public string Director { get; set; }
    }
}
