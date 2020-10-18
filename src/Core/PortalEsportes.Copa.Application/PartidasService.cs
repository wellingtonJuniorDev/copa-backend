using PortalEsportes.Copa.Domain.Exceptions;
using PortalEsportes.Copa.Domain.Models;
using PortalEsportes.Copa.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace PortalEsportes.Copa.Application
{
    public class PartidasService : IPartidasService
    {
        public Partida GerarCopa(IEnumerable<Equipe> equipes)
        {
            equipes = OrdenarEquipesPorOrdemAlfabetica(equipes);

            var partidasPrimeiraFase = ObterPartidasPrimeiraFase(equipes);
            var equipesSemiFinais = ObterEquipesVencedoras(partidasPrimeiraFase);

            var partidasSegundaFase = ObterPartidasSegundaFase(equipesSemiFinais);
            var equipesPartidaFinal = ObterEquipesVencedoras(partidasSegundaFase);

            var partidaFinal = ObterPartidaFinal(equipesPartidaFinal);

            return partidaFinal;
        }

        public IEnumerable<Equipe> OrdenarEquipesPorOrdemAlfabetica(IEnumerable<Equipe> equipes)
        {
            var charArrayNumeros = "0123456789".ToCharArray();

            return equipes
              .OrderBy(x => x.Nome.LastIndexOfAny(charArrayNumeros))
              .ThenBy(x => x.Nome);
        }

        public IEnumerable<Partida> ObterPartidasPrimeiraFase(IEnumerable<Equipe> equipes)
        {
            if (equipes.Count() != 8)
            {
                throw new CoreException
                    ($"O método {nameof(ObterPartidasPrimeiraFase)} aceita somente uma coleção de 08 equipes");
            }

            var partidas = new List<Partida>();

            for (int indice = 0; indice < (equipes.Count() / 2); indice++)
            {
                var primeiraEquipe = equipes.ElementAt(indice);
                var segundaEquipe = equipes.ElementAt(equipes.Count() - (indice + 1));

                var partida = PartidaFactory.
                                NovaPartida(primeiraEquipe, segundaEquipe);
               
                partidas.Add(partida);
            }

            return partidas.AsEnumerable();
        }

        public IEnumerable<Equipe> ObterEquipesVencedoras(IEnumerable<Partida> partidas)
        {
            return partidas.Select(p => p.EquipeVencedora);
        }

        public IEnumerable<Partida> ObterPartidasSegundaFase(IEnumerable<Equipe> equipes)
        {
            if (equipes.Count() != 4)
            {
                throw new CoreException
                    ($"O método {nameof(ObterPartidasSegundaFase)} aceita somente uma coleção de 04 equipes");
            }

            var partidas = new List<Partida>();

            for (int i = 0; i < equipes.Count(); i++)
            {
                var primeiraEquipe = equipes.ElementAt(i);
                var segundaEquipe = equipes.ElementAt(++i);

                var partida = PartidaFactory.
                                NovaPartida(primeiraEquipe, segundaEquipe);

                partidas.Add(partida);
            }

            return partidas.AsEnumerable();
        }

        public Partida ObterPartidaFinal(IEnumerable<Equipe> equipes)
        {
            if (equipes.Count() != 2)
            {
                throw new CoreException
                    ($"O método {nameof(ObterPartidaFinal)} aceita somente uma coleção de 02 equipes");
            }

            return PartidaFactory
                .NovaPartida(equipes.First(), equipes.Last());
        }
    }
}
