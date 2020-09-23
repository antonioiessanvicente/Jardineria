using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIJardineria.Models
{
    public class Oficina
    {
        [Key]
        public string Codigo_Oficina { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Region { get; set; }
        public string Codigo_Postal { get; set; }
        public string Telefono { get; set; }
        public string Linea_Direccion1 { get; set; }
        public string Linea_Direccion2 { get; set; }
    }
}
