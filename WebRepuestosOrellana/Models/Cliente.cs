using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}