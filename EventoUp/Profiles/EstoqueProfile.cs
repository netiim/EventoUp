using AutoMapper;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Data.DTOs.Estoque;
using EventoUp.Models;

namespace EventoUp.Profiles
{
    public class EstoqueProfile : Profile
    {
        public EstoqueProfile()
        {
            CreateMap<UpdateEstoqueDTO, Estoque>()
                .ReverseMap();
            CreateMap<ReadEstoqueDTO, Estoque>()
                .ReverseMap();
            CreateMap<CreateEstoqueDTO, Estoque>()
                .ReverseMap();

        }
    }
}
