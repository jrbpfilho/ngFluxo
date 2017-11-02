using System.Collections;
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
    [Route("/api/categorias")]
    public class CategoriasController : Controller
    {
        private readonly FluxoDeCaixaDAO context;
        private readonly IMapper mapper;
        public CategoriasController(FluxoDeCaixaDAO context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaResource categoriaResource)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var categoria = mapper.Map<CategoriaResource, Categoria>(categoriaResource);
        
            // Call DB
            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();

            var result = mapper.Map<Categoria, CategoriaResource>(categoria);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaResource>> GetCategorias()
        {
            var categorias = await context.Categorias.Include(c => c.SubCategorias).ToListAsync();

            return mapper.Map<List<Categoria>, List<CategoriaResource>>(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await context.Categorias.SingleAsync( c => c.Id == id);

            var categoriaResource = mapper.Map<Categoria, CategoriaResource>(categoria);

            return Ok(categoriaResource);
        }

        // // [HttpGet("{id}")]
        // // public async Task<IEnumerable<CategoriaResource> GetCategorias(int id)
        // // {
        // //     var categoria = context.Categorias.Single(c => c.Categoria.Id == c.id);
        // //     return

        // // }

        // public async Task<IEnumerable<CategoriaResource>> GetCategorias(int id) {
        //     var categoria = await context.Categorias.SingleAsync(c => c.Id == c.Id);

        //     return Ok(Mapper.Map<List<Categoria>,List<CategoriaResource>>(categoria));
        // }
    }
}
