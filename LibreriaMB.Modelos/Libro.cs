using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMB.Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Autor { get; set; }
        public int NumeroPag { get; set; }

        //relacion
        public Libreria? Libreria { get; set; }
        public int LibreriaId { get; set; } //FK
    }
}
