using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebRepuestosOrellana.Models
{
    public class TipoProducto
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}