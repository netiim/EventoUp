using AutoMapper;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Data.DTOs.Produto;
using EventoUp.Models;

namespace EventoUp.Profiles
{
    public class EventoProfile : Profile
    {
        public EventoProfile()
        {
            CreateMap<UpdateEventoDTO, Evento>()
                .ReverseMap();
            CreateMap<UpdateProdutoDTO, Produto>()
                .ReverseMap();

        }
    }
}
