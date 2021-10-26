using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class Bodega
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}