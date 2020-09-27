using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pago
    {
        public int Codigo_Cliente { get; set; }
        public string Forma_pago { get; set; }
        public string Id_Transaccion { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public decimal Total { get; set; }
    }
}
