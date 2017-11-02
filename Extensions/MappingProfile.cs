using AutoMapper;
using ngFluxo.Controllers.Resources;
using ngFluxo.Models;
using System.Linq;

namespace ngFluxo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Categoria, CategoriaResource>();
            CreateMap<Categoria, KeyValuePairResource>();
            CreateMap<SubCategoria, KeyValuePairResource>();
            CreateMap<Fornecedor, KeyValuePairResource>();
            CreateMap<Produto, ProdutoResource>()
            .ForMember(pr => pr.Categoria, opt => opt.MapFrom(p => p.SubCategoria.Categoria));
            CreateMap<SubCategoria, SubCategoriaResource>();
            CreateMap<Fornecedor, FornecedorResource>();
            CreateMap<ProdutoQuery, ProdutoQueryResource>();
            CreateMap<Produto, GravarProdutoResource>();
            
            
            // API Resource to Domain
            CreateMap<CategoriaResource, Categoria>();          
            CreateMap<FornecedorResource, Fornecedor>();
            CreateMap<ProdutoResource, Produto>();      
            CreateMap<SubCategoriaResource, SubCategoria>();
            CreateMap<ProdutoQueryResource, ProdutoQuery>();
            CreateMap<GravarProdutoResource, Produto>();
        }
    }
}