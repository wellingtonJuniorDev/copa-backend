using AutoMapper;
using PortalEsportes.Copa.Domain.Models;
using PortalEsportes.Copa.EquipesAdapter.Clients;

namespace PortalEsportes.Copa.EquipesAdapter
{
    public class EquipeMapperProfile : Profile
    {
        public EquipeMapperProfile()
        {
            CreateMap<EquipesGetResult, Equipe>()
                .ConstructUsing(e => new Equipe(e.Id, e.Nome, e.Sigla, e.Gols));
        }
    }
}
