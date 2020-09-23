using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIJardineria.Models
{
    public class Pago
    {
        [ForeignKey("cliente")]
        public int Codigo_Cliente { get; set; }
        
        public string Forma_pago { get; set; }

        [Key]
        public string Id_Transaccion { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public decimal Total { get; set; }
    }
}
