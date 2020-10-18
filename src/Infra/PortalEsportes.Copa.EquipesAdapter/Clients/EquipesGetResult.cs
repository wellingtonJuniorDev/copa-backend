using System;

namespace PortalEsportes.Copa.EquipesAdapter.Clients
{
    /// <summary>
    /// Modelo de retorno para a rota /equipes.json do EquipeAdapterApi
    /// <para>
    /// A classe eh interna ao adaptador,
    /// pois os dados serao mapeados para serem expostos
    /// O mapeamento eh feito em <see cref="EquipesAdapter.ObterEquipesAsync"/>
    /// </para>
    /// </summary>
    internal class EquipesGetResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int Gols { get; set; }
    }
}
