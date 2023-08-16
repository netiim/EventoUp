using AutoMapper;
using EventoUp.Data.DTOs.Usuario;
using EventoUp.Models;

namespace EventoUp.Profiles
{
    /// <summary>
    /// Classe para mapear os objetos do auto mapper relacionados a usuário
    /// </summary>
    public class UsuarioProfile : Profile
    {
        /// <summary>
        /// Mapea as conversões de objetos para DTOs e virse-versa e auxilia o proxies a preencher os objetos necessarios
        /// </summary>
        public UsuarioProfile()
        {
            CreateMap<UpdateUsuarioDTO, Usuario>()
                .ReverseMap();
            CreateMap<CreateUsuarioDTO, Usuario>()
                .ReverseMap();
            CreateMap<ReadUsuarioDTO, Usuario>()
                .ReverseMap();

        }
    }
}
