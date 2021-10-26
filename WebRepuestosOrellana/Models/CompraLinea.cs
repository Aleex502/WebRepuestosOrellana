using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class CompraLinea
    {
        [Key]
        public int ID { get; set; }
        public int NoLinea { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        public int CompraID { get; set; }
        public Compra Compra { get; set; }
    }
}