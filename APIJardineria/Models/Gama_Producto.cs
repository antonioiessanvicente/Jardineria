using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APIJardineria.Models
{
    public class Gama_Producto
    {

        [Key]
        [ForeignKey("gama_productos")]
        public string Gama { get; set; }
        public string Descripcion_Texto { get; set; }
        public string Descripcion_HTML { get; set; }
        
        [StringLength(256, ErrorMessage = "La ruta de la imagen no puede exceder de 256 caractéres")]
        public string Imagen { get; set; }
        
    }
}
