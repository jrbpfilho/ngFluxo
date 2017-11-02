using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ngFluxo.Controllers.Resources;
using ngFluxo.Core;
using ngFluxo.Models;
using ngFluxo.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ngFluxo.Controllers
{
    [Route("/api/produtos")]
    public class ProdutosController : Controller
    {
        private readonly FluxoDeCaixaDAO context;
        private readonly IMapper mapper;
        private readonly IProdutoRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ProdutosController(IMapper mapper, IProdutoRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] GravarProdutoResource produtoResource)
        {
            if(!ModelState.IsValid)
            {
            return BadRequest(ModelState);
            }

            var produto = mapper.Map<GravarProdutoResource, Produto>(produtoResource);
            produto.AdicionadoEm = DateTime.Now;
            produto.ModificadoEm = DateTime.Now;

            /* Produto nomeDoProdutoExiste = await context.Produtos.Where(p => p.NomeDoProduto == produtoResource.NomeDoProduto).FirstOrDefaultAsync();
            if(nomeDoProdutoExiste != null) 
            {
                ModelState.AddModelError("nomeDoProduto", "Um produto com este nome já existe");
                return BadRequest(ModelState);
            }  */

            repository.Add(produto);
            await unitOfWork.CompleteAsync();

            produto = await repository.GetProduto(produto.Id);

            var result = mapper.Map<Produto, ProdutoResource>(produto);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] GravarProdutoResource produtoResource)
        {
            if(!ModelState.IsValid)
            
            return BadRequest(ModelState);
            
            var produto = await repository.GetProduto(id);

            if (produto == null)

            return NotFound();

            mapper.Map<GravarProdutoResource, Produto>(produtoResource, produto);
            produto.ModificadoEm = DateTime.Now;

            await unitOfWork.CompleteAsync();

            produto = await repository.GetProduto(produto.Id);

            var result = mapper.Map<Produto, ProdutoResource>(produto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            
            var produto = await repository.GetProduto(id, includeRelated: false);

            if (produto == null)

            return NotFound();

            repository.Remove(produto);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
        var produto = await repository.GetProduto(id);

        if (produto == null)
            return NotFound();

        var produtoResource = mapper.Map<Produto, ProdutoResource>(produto);

        return Ok(produtoResource);
        }

        [HttpGet]
        public async Task<QueryResultResource<ProdutoResource>> GetProdutos(ProdutoQueryResource filterResource)
        {
            var filter = mapper.Map<ProdutoQueryResource, ProdutoQuery>(filterResource);

            var queryResult = await repository.GetProdutos(filter);
          //  var produtos = await context.Produtos.ToListAsync();

            return mapper.Map<QueryResult<Produto>, QueryResultResource<ProdutoResource>>(queryResult);
        }
    }
}