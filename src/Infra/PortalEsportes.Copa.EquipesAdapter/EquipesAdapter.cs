using AutoMapper;
using PortalEsportes.Copa.Domain.Adapters;
using PortalEsportes.Copa.Domain.Models;
using PortalEsportes.Copa.EquipesAdapter.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalEsportes.Copa.EquipesAdapter
{
    internal class EquipesAdapter : IEquipesAdapter
    {
        private readonly IEquipesApi equipesApi;
        private readonly IMapper mapper;

        public EquipesAdapter(IEquipesApi equipesApi,
                              IMapper mapper)
        {
            this.equipesApi = equipesApi ??
                throw new ArgumentNullException(nameof(equipesApi));

            this.mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Equipe>> ObterEquipesAsync()
        {
            var equipesResult = await equipesApi.ObterEquipes();

            return mapper.Map<IEnumerable<Equipe>>(equipesResult);
        }
    }
}
