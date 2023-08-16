using AutoMapper;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Data.DTOs.Produto;
using EventoUp.Models;

namespace EventoUp.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<UpdateProdutoDTO, Produto>()
                .ReverseMap();
            CreateMap<ReadProdutoDTO, Produto>()
                .ReverseMap();
            CreateMap<CreateProdutoDTO, Produto>()
                .ReverseMap();

        }
    }
}
