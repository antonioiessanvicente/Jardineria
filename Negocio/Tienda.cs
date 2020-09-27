using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Entidades;

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

    }
}
