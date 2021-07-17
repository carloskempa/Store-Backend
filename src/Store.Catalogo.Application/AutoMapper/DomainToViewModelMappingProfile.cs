using AutoMapper;
using Store.Catalogo.Application.ViewModels;
using Store.Catalogo.Domain;

namespace Store.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
