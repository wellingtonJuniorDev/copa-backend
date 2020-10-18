using AutoMapper;
using PortalEsportes.Copa.Api.ViewModels;
using PortalEsportes.Copa.Domain.Models;
using System.Collections.Generic;

namespace PortalEsportes.Copa.Api.Configuration.Mappings
{
    public class ModelsMappingProfile : Profile
    {
        public ModelsMappingProfile()
        {
            CreateMap<Equipe, EquipeViewModel>();

            CreateMap<EquipeViewModel, Equipe>()
                .ConstructUsing(e => new Equipe(e.Id, e.Nome, e.Sigla, e.Gols));

            CreateMap<Partida, List<EquipeResultadoViewModel>>()
                .ConstructUsing(p => new List<EquipeResultadoViewModel>()
                { 
                    new EquipeResultadoViewModel
                    { 
                        Id = p.PrimeiraEquipe.Id,
                        Nome = p.PrimeiraEquipe.Nome,
                        Vencedora = p.EquipeVencedora.Equals(p.PrimeiraEquipe)
                    },
                    new EquipeResultadoViewModel
                    {
                        Id = p.SegundaEquipe.Id,
                        Nome = p.SegundaEquipe.Nome,
                        Vencedora = p.EquipeVencedora.Equals(p.SegundaEquipe)
                    }
                });
        }
    }
}
