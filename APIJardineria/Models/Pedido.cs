using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIJardineria.Models
{
    public class Pedido
    {
        [Key]
        public int Codigo_Pedido { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Esperada { get; set; }
        public DateTime? Fecha_Entrega { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }

        [ForeignKey("cliente")]
        public int Codigo_Cliente { get; set; }

        //Colección para tener las líneas del pedido. No está en la base de datos.
       // public ICollection<Detalle_Pedido> LineasPedido { get; set; }

    }
}
