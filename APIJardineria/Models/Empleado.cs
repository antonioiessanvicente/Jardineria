using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace APIJardineria.Models
{
    public class Empleado
    {
        [Key]
        public int Codigo_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }

        [ForeignKey("oficina")]
        public string Codigo_Oficina { get; set; }

        [ForeignKey("empleado")]
        public int? Codigo_Jefe { get; set; }
        
        public string Puesto { get; set; }

        public string Pass { get; set; }
    }
}
