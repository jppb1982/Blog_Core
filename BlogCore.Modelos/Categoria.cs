using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BlogCore.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la categoría.")]
        [Display(Name = "Nombre de categoría")] /*Alias -> como se va a mostrar*/
        public required string Nombre { get; set; }

        [Display(Name = "Orden de la visualización")]

        [Range(1, 100, ErrorMessage = "El valor debe estar entre 1 y 100")]
        public int? Orden { get; set; }
    }
}