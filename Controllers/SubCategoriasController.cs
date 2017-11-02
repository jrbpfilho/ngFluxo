using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ngFluxo.Controllers.Resources;
using ngFluxo.Models;
using ngFluxo.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ngFluxo.Controllers
{
    [Route("/api/categorias/subcategorias")]
    public class SubCategoriasController : Controller
    {
        private readonly FluxoDeCaixaDAO context;
        private readonly IMapper mapper;
        public SubCategoriasController(FluxoDeCaixaDAO context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] SubCategoriaResource subCategoriaResource)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var subCategoria = mapper.Map<SubCategoriaResource, SubCategoria>(subCategoriaResource);
        

            context.SubCategorias.Add(subCategoria);
            await context.SaveChangesAsync();

            var result = mapper.Map<SubCategoria, SubCategoriaResource>(subCategoria);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<SubCategoriaResource>> GetSubCategorias()
        {
            var subCategorias = await context.SubCategorias.ToListAsync();

            return mapper.Map<List<SubCategoria>, List<SubCategoriaResource>>(subCategorias);
        }
    }
}