using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maria_P1_AP2.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage ="La descripción es obligatoria")]
        public string Descripcion { get; set; }

        public Categorias()
        {
            CategoriaId = 0;
            Descripcion = string.Empty;
        }
    }
}