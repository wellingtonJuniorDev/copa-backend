using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalEsportes.Copa.EquipesAdapter.Clients
{
    internal interface IEquipesApi
    {
        [Get("/equipes.json")]
        Task<IEnumerable<EquipesGetResult>> ObterEquipes();
    }
}
