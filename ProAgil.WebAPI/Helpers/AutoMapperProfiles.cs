using System.Linq;
using AutoMapper;
using ProAgil.Domain;
using ProAgil.Domain.Identity;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.Palestrantes, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
                } ).ReverseMap();

            //CreateMap<EventoDto, Evento>();

            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest => dest.Eventos, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
                } ).ReverseMap();
                
            CreateMap<Lote, LoteDto>().ReverseMap();
            //CreateMap<LoteDto, Lote>();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            //CreateMap<RedeSocialDto, RedeSocial>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            
        }
    }
}