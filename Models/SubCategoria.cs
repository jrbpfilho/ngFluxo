using System.ComponentModel.DataAnnotations;

namespace ngFluxo.Models
{
    public class SubCategoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string NomeDaSubCategoria { get; set; }

        public int CategoriaId { get; set; }
        
        public Categoria Categoria { get; set; }
    }
}