using Bogus;
using PortalEsportes.Copa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PortalEsportes.Copa.Application.Tests.Fixtures
{
    [CollectionDefinition(nameof(TestsFixtureCollection))]
    public class TestsFixtureCollection : ICollectionFixture<TestsFixture>
    { }

    public class TestsFixture
    {
        private const string fakerLanguage = "pt_BR";

        public List<Equipe> GerarEquipesRandomicas(int quantidade)
        {
            return new Faker<Equipe>()
                .RuleFor(e => e.Id, e => e.Random.Guid())
                .RuleFor(e => e.Nome, e => e.Name.JobArea())
                .RuleFor(e => e.Sigla, e => e.Name.JobArea().Substring(0, 2))
                .RuleFor(e => e.Gols, e => e.Random.Number(12))
                .GenerateLazy(quantidade)
                .ToList();
        }

        public Equipe GerarEquipe(string nome, int gols = 1)
        {
            var faker = new Faker(fakerLanguage);
            var id = Guid.NewGuid();

            if (string.IsNullOrEmpty(nome))
            {
                nome = faker.Name.JobArea();
            }

            var sigla = nome.Substring(0, 2);

            return new Equipe(id, nome, sigla, gols);
        }

        public IEnumerable<Equipe> GerarEquipesDaEspecificacao()
        {
            return new List<Equipe>()
            {
                GerarEquipe("Equipe 1", 3),
                GerarEquipe("Equipe 2", 1),
                GerarEquipe("Equipe 3", 0),
                GerarEquipe("Equipe 4", 5),
                GerarEquipe("Equipe 5", 10),
                GerarEquipe("Equipe 6", 7),
                GerarEquipe("Equipe 7", 9),
                GerarEquipe("Equipe 8", 8)
            }
            .AsEnumerable();
        }

        public IEnumerable<Equipe> ObterEquipesDaSegundaFase()
        {
            var equipes = GerarEquipesDaEspecificacao();

            var equipesSegundaFase = new List<Partida>()
            {
                PartidaFactory.NovaPartida(equipes.ElementAt(0), equipes.ElementAt(7)),
                PartidaFactory.NovaPartida(equipes.ElementAt(1), equipes.ElementAt(6)),
                PartidaFactory.NovaPartida(equipes.ElementAt(2), equipes.ElementAt(5)),
                PartidaFactory.NovaPartida(equipes.ElementAt(3), equipes.ElementAt(4))
            }
            .Select(p => p.EquipeVencedora);

            return equipesSegundaFase;
        }

        public IEnumerable<Equipe> ObterEquipesFinais()
        {
            var equipesSegundaFase = ObterEquipesDaSegundaFase();

            var equipesFinais = new List<Partida>()
            {
                PartidaFactory.NovaPartida(equipesSegundaFase.ElementAt(0), equipesSegundaFase.ElementAt(1)),
                PartidaFactory.NovaPartida(equipesSegundaFase.ElementAt(2), equipesSegundaFase.ElementAt(3))
            }
            .Select(p => p.EquipeVencedora);

            return equipesFinais;
        }
    }
}
