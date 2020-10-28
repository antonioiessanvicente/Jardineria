using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIJardineria.Models
{
    public class Cliente
    {
        [Key]
        public int Codigo_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Nombre_Contacto { get; set; }
        public string Apellido_Contacto { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Linea_Direccion1 { get; set; }
        public string Linea_Direccion2 { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }
        public string Codigo_Postal { get; set; }

        [ForeignKey("empleado")]
        public int? Codigo_Empleado_Rep_Ventas { get; set; }
        public decimal? Limite_Credito { get; set; }
        public string Pass { get; set; }
    }
}
