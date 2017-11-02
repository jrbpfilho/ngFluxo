using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngFluxo.Models
{
   [Table("Categorias")]
    public class Categoria
    {
        public int Id {get; set;}

        [Required]
        [StringLength(255)]
        public string NomeDaCategoria { get; set; }

        public virtual ICollection<SubCategoria> SubCategorias { get; set; }
      
        public Categoria()
        {
            SubCategorias = new Collection<SubCategoria>();
        }
        
    }

}
