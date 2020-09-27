using Capa_Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class Tienda
    {
        public List<Pago> ObtenerPagos()
        {
            PagoADO p = new PagoADO();

            return p.LeerPagos();
        }

        public bool InsertarPago(Pago p)
        {
            PagoADO pA = new PagoADO();
            bool resultado = pA.InsertarPago(p.Codigo_Cliente, p.Forma_pago, p.Id_Transaccion, p.Fecha_Pago, p.Total);

            return resultado;
        }

        public Pago ActualizarPago(Pago p)
        {
            PagoADO pA = new PagoADO();
            Pago resultado = pA.ActualizarPago(p);

            return resultado;
        }

    }
}
