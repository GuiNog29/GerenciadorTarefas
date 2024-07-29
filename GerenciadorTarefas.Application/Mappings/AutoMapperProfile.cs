using AutoMapper;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Helpers;

namespace GerenciadorTarefas.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Projeto, ProjetoDto>().ReverseMap();

            CreateMap<Comentario, ComentarioDto>().ReverseMap();

            CreateMap<Tarefa, TarefaDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => EnumExtensions.ObterDescricaoEnum(src.Status)))
                .ForMember(dest => dest.Prioridade, opt => opt.MapFrom(src => EnumExtensions.ObterDescricaoEnum(src.Prioridade)))
                .ReverseMap();
        }
    }
}
