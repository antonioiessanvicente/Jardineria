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

        public Pago(int codigo, string formaPago, string transaccion, DateTime fechaPago, decimal total)
        {
            Codigo_Cliente = codigo;
            Forma_pago = formaPago;
            Id_Transaccion = transaccion;
            Fecha_Pago = fechaPago;
            Total = total;
            /////
        }

        public override string ToString()
        {
            return Codigo_Cliente.ToString() + " - " + Forma_pago + " - " + Id_Transaccion + " - " + Fecha_Pago.ToString() + " - " + Total.ToString();
        }
    }
}
