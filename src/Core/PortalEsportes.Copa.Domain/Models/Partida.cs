using System.Collections.Generic;
using System.Linq;

namespace PortalEsportes.Copa.Domain.Models
{
    public class Partida
    {
        public Equipe PrimeiraEquipe { get; set; }
        public Equipe SegundaEquipe { get; set; }
        public Equipe EquipeVencedora => DefinirEquipeVencedora();

        private Equipe DefinirEquipeVencedora()
        {
            if (EquipesEmpataramEmNumeroDeGols())
            {
                return PrimeiraEquipeVencePeloCriterioDeDesempate() ?
                    PrimeiraEquipe : SegundaEquipe;
            }

            return PrimeiraEquipeTemMaiorNumeroDeGols() ? 
                PrimeiraEquipe : SegundaEquipe;
        }

        public bool EquipesEmpataramEmNumeroDeGols()
        {
            return PrimeiraEquipe.Gols.Equals(SegundaEquipe.Gols);
        }

        public bool PrimeiraEquipeVencePeloCriterioDeDesempate()
        {
            var equipes = new List<Equipe> { PrimeiraEquipe, SegundaEquipe };
            var charArrayNumeros = "0123456789".ToCharArray();

            var result = equipes
              .OrderBy(x => x.Nome.LastIndexOfAny(charArrayNumeros))
              .ThenBy(x => x.Nome);

            return result.First().Equals(PrimeiraEquipe);
        }

        public bool PrimeiraEquipeTemMaiorNumeroDeGols()
        {
            return PrimeiraEquipe.Gols > SegundaEquipe.Gols;
        }
    }


    public static class PartidaFactory
    {
        public static Partida NovaPartida(Equipe primeiraEquipe, Equipe segundaEquipe)
        {
            return new Partida
            {
                PrimeiraEquipe = primeiraEquipe,
                SegundaEquipe = segundaEquipe
            };
        }
    }
}
