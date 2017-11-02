using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ngFluxo.Controllers.Resources;
using ngFluxo.Models;
using ngFluxo.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ngFluxo.Controllers
{
    [Route("/api/fornecedores")]
    public class FornecedoresController : Controller
    {
        private readonly FluxoDeCaixaDAO context;
        private readonly IMapper mapper;
        public FornecedoresController(FluxoDeCaixaDAO context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpPost]
        public async Task<IActionResult> CreateFornecedor([FromBody] FornecedorResource fornecedorResource)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var fornecedor = mapper.Map<FornecedorResource, Fornecedor>(fornecedorResource);
            fornecedor.AdicionadoEm = DateTime.Now;

            context.Fornecedores.Add(fornecedor);
            await context.SaveChangesAsync();

            var result = mapper.Map<Fornecedor, FornecedorResource>(fornecedor);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorResource>> GetFornecedores()
        {
            var fornecedores = await context.Fornecedores.ToListAsync();

            return mapper.Map<List<Fornecedor>, List<FornecedorResource>>(fornecedores);
        }
    }
}