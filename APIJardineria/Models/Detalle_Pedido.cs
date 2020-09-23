using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIJardineria.Models
{
    public class Detalle_Pedido
    {
        // Clave compuesta por código pedido y número de linea. No implementado en BD.
        public int Codigo_Pedido { get; set; }

        [ForeignKey("producto")]
        public string Codigo_Producto { get; set; }
        
        public int Cantidad { get; set; }
        public decimal Precio_unidad { get; set; }
        public int Numero_linea { get; set; }

    }
}
