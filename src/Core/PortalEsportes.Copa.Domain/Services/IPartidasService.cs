using PortalEsportes.Copa.Domain.Models;
using System.Collections.Generic;

namespace PortalEsportes.Copa.Domain.Services
{
    public interface IPartidasService
    {
        /// <summary>
        /// Metodo que recebe uma colecao de 16 equipes
        /// e faz o processamento para definir a equipe vencedora
        /// </summary>
        /// <param name="equipes">As equipes que irao participar da copa</param>
        /// <returns>
        /// A ultima partida realizada entre as equipes
        /// contendo a equipe vencedora
        /// </returns>
        Partida GerarCopa(IEnumerable<Equipe> equipes);

        /// <summary>
        /// Metodo que recebe uma colecao de equipes
        /// e faz a ordenacao por ordem alfabetica
        /// </summary>
        /// <param name="equipes">As equipes que irao participar da copa</param>
        /// <returns>As equipes ordenadas</returns>
        IEnumerable<Equipe> OrdenarEquipesPorOrdemAlfabetica(IEnumerable<Equipe> equipes);

        /// <summary>
        /// Metodo que recebe uma colecao de 8 equipes
        /// e faz o agrupamento para cada partida obtendo 
        /// as equipes pelas extremidades
        /// </summary>
        /// <param name="equipes">As equipes que irao participar da primeira fase</param>
        /// <returns>As partidas realizadas na primeira fase</returns>
        IEnumerable<Partida> ObterPartidasPrimeiraFase(IEnumerable<Equipe> equipes);

        /// <summary>
        /// Metodo que recebe uma coleção de partidas
        /// e obtem as equipes vencedoras
        /// </summary>
        /// <param name="partidas">As partidas realizadas</param>
        /// <returns>As equipes vencedoras das respectivas partidas</returns>
        IEnumerable<Equipe> ObterEquipesVencedoras(IEnumerable<Partida> partidas);

        /// <summary>
        /// Método que recebe uma colecao de 4 equipes
        /// e faz o agrupamento para cada partida
        /// obtendo as equipes por ordem ascendente de classificacao
        /// </summary>
        /// <param name="equipes">As equipes que irao participar da segunda fase</param>
        /// <returns></returns>
        IEnumerable<Partida> ObterPartidasSegundaFase(IEnumerable<Equipe> equipes);

        /// <summary>
        /// Método que recebe uma colecao de 2 equipes
        /// e realiza a partida final
        /// </summary>
        /// <param name="equipes">As esquipes que irao participar da final</param>
        /// <returns>A ultima partida realizada</returns>
        Partida ObterPartidaFinal(IEnumerable<Equipe> equipes);
    }
}
