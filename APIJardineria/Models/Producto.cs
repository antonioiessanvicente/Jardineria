using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIJardineria.Models
{
    public class Producto
    {
        [Key]
        public string Codigo_Producto { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("gama_productos")]
        public string Gama { get; set; }
 
        public string Dimensiones { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_en_Stock { get; set; }
        public decimal Precio_venta { get; set; }
        public decimal? Precio_proveedor { get; set; }
        
    }
}
