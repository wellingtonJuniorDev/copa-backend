using PortalEsportes.Copa.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalEsportes.Copa.Domain.Adapters
{
    /// <summary>
    /// Adapter para acesso na Api externa de Equipes
    /// </summary>
    public interface IEquipesAdapter
    {
        /// <summary>
        /// Realiza a busca de equipes.
        /// </summary>
        /// <returns>A coleção de Equipes encontradas</returns>
        Task<IEnumerable<Equipe>> ObterEquipesAsync();
    }
}
