using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Modelos
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Artículo")]
        public string  Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la descripción del artículo.")]
        [Display(Name = "Descripción del artículo")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de creación")]
        public string? FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? URLImagen { get; set; }

        [Required(ErrorMessage = "La categoría es obligatorio")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
