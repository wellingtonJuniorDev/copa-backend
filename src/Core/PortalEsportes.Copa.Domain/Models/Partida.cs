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

        public override bool Equals(object obj)
        {
            var compareTo = obj as Partida;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return PrimeiraEquipe.Equals(compareTo.PrimeiraEquipe) &&
                   SegundaEquipe.Equals(compareTo.SegundaEquipe) &&
                   EquipeVencedora.Equals(compareTo.EquipeVencedora);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 911) + EquipeVencedora.Id.GetHashCode();
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
