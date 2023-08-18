using AutoMapper;
using EventoUp.Data.DTOs.Evento;
using EventoUp.Data.DTOs.Produto;
using EventoUp.Models;

namespace EventoUp.Profiles
{
    /// <summary>
    /// Classe para mapear os objetos do auto mapper relacionados a usuário
    /// </summary>
    public class EventoProfile : Profile
    {
        /// <summary>
        /// Mapea as conversões de objetos para DTOs e virse-versa e auxilia o proxies a preencher os objetos necessarios
        /// </summary>
        public EventoProfile()
        {
            CreateMap<UpdateEventoDTO, Evento>()
                .ReverseMap();
            CreateMap<CreateEventoDTO, Evento>()
                .ReverseMap();
            CreateMap<Evento, ReadEventoResumidoDTO>()
                .ReverseMap();
            CreateMap<Evento, ReadEventoDTO>()
                .ForMember(eventoDTO => eventoDTO.UsuarioResponsavel,
                opt => opt.MapFrom(evento => evento.UsuarioAdministrador))
                .ReverseMap();
        }
    }
}
