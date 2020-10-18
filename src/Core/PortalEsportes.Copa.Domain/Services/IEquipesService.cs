using PortalEsportes.Copa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalEsportes.Copa.Domain.Services
{
    public interface IEquipesService
    {
        /// <summary>
        /// Realiza a busca de equipes.
        /// </summary>
        /// <returns>A coleção de Equipes encontradas</returns>
        Task<IEnumerable<Equipe>> ObterEquipesAsync();

        /// <summary>
        /// Realiza a busca de equipes
        /// filtrando por uma colecao de ids das equipes
        /// </summary>
        /// <param name="equipesIds">Os identificadores das equipes selecionadas</param>
        /// <returns>As equipes selecionadas</returns>
        Task<IEnumerable<Equipe>> ObterEquipesSelecionadasAsync(IEnumerable<Guid> equipesIds);
    }
}
