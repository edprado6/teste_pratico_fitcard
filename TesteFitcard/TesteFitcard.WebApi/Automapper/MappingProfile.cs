using AutoMapper;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Dominio.Filtros;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.DominioViewModel.Filtros;

namespace TesteFitcard.WebApi.Automapper
{
    /// <summary>
    /// Configuração do Automapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            /// Categoria
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<CategoriaFiltro, CategoriaFiltroViewModel>();
            CreateMap<CategoriaFiltroViewModel, CategoriaFiltro>().ForMember(dto => dto.Predicate, opt => opt.Ignore());

            /// Estabelecimento
            CreateMap<Estabelecimento, EstabelecimentoViewModel>();
            CreateMap<EstabelecimentoViewModel, Estabelecimento>();
            CreateMap<EstabelecimentoFiltro, EstabelecimentoFiltroViewModel>();
            CreateMap<EstabelecimentoFiltroViewModel, EstabelecimentoFiltro>().ForMember(dto => dto.Predicate, opt => opt.Ignore());
        }
    }
}
