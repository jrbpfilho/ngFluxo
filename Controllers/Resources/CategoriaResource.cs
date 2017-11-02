using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ngFluxo.Controllers.Resources
{
    public class CategoriaResource
    {
        public int Id {get; set;}

        public string NomeDaCategoria { get; set; }

        public ICollection<SubCategoriaResource> SubCategorias { get; set; }
      
        public CategoriaResource()
        {
            SubCategorias = new Collection<SubCategoriaResource>();
        }
    }
}