using PortalEsportes.Copa.Domain.Adapters;
using PortalEsportes.Copa.Domain.Models;
using PortalEsportes.Copa.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEsportes.Copa.Application
{
    public class EquipesService : IEquipesService
    {
        private readonly IEquipesAdapter equipesAdapter;

        public EquipesService(IEquipesAdapter equipesAdapter)
        {
            this.equipesAdapter = equipesAdapter ??
                throw new ArgumentNullException(nameof(equipesAdapter));
        }

        public async Task<IEnumerable<Equipe>> ObterEquipesAsync()
        {
            return await equipesAdapter.ObterEquipesAsync();
        }

        public async Task<IEnumerable<Equipe>> ObterEquipesSelecionadasAsync(IEnumerable<Guid> equipesIds)
        {
            var equipes = await ObterEquipesAsync();

            return equipes.Where(e => equipesIds.Any(id => id.Equals(e.Id)));
        }
    }
}
