using System.ComponentModel.DataAnnotations;

namespace LibreriaMB.Modelos
{
    public class Libreria
    {
        [Key]
        public int LibreriaId { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        
        //relaciones
        public List <Libro>? Libros { get; set; }

    }
}