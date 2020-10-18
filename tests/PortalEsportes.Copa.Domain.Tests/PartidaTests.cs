
using PortalEsportes.Copa.Domain.Models;
using PortalEsportes.Copa.Domain.Tests.Fixtures;
using Xunit;

namespace PortalEsportes.Copa.Domain.Tests
{

    [Collection(nameof(TestsFixtureCollection))]
    public class PartidaTests
    {
        private readonly TestsFixture testsFixture;

        public PartidaTests(TestsFixture testsFixture)
        {
            this.testsFixture = testsFixture;
        }

        [Fact]
        [Trait("Partida_EquipesEmpataramEmNumeroDeGols", "Sucesso")]
        public void Partida_EquipesEmpataramEmNumeroDeGols_Sucesso()
        {
            var primeiraEquipe = testsFixture.GerarEquipe();
            var segundaEquipe = testsFixture.GerarEquipe();

            var partida = PartidaFactory.NovaPartida(primeiraEquipe, segundaEquipe);

            Assert.True(partida.EquipesEmpataramEmNumeroDeGols());
        }

        [Fact]
        [Trait("Partida_EquipesEmpataramEmNumeroDeGols", "Falha")]
        public void Partida_EquipesEmpataramEmNumeroDeGols_Falha()
        {
            var primeiraEquipe = testsFixture.GerarEquipe();
            var segundaEquipe = testsFixture.GerarEquipe(null, 2);

            var partida = PartidaFactory.NovaPartida(primeiraEquipe, segundaEquipe);

            Assert.False(partida.EquipesEmpataramEmNumeroDeGols());
        }

        [Theory]
        [InlineData("Equipe 1", "Equipe 8")]
        [InlineData("Equipe 19", "Equipe 100")]
        [InlineData("Equipe", "Equipe 1")]
        [Trait("Partida_PrimeiraEquipeVencePeloCriterioDeDesempate", "Sucesso")]
        public void Partida_PrimeiraEquipeVencePeloCriterioDeDesempate_Sucesso(string nomePrimeiraEquipe, string nomeSegundaEquipe)
        {
            var primeiraEquipe = testsFixture.GerarEquipe(nomePrimeiraEquipe);
            var segundaEquipe = testsFixture.GerarEquipe(nomeSegundaEquipe);

            var partida = PartidaFactory.NovaPartida(primeiraEquipe, segundaEquipe);

            Assert.True(partida.PrimeiraEquipeVencePeloCriterioDeDesempate());
        }

        [Theory]
        [InlineData("Equipe 8", "Equipe 1")]
        [InlineData("Equipe 100", "Equipe 19")]
        [InlineData("Equipe 1", "Equipe")]
        [Trait("Partida_SegundaEquipeVencePeloCriterioDeDesempate", "Sucesso")]
        public void Partida_SegundaEquipeVencePeloCriterioDeDesempate_Sucesso(string nomePrimeiraEquipe, string nomeSegundaEquipe)
        {
            var primeiraEquipe = testsFixture.GerarEquipe(nomePrimeiraEquipe);
            var segundaEquipe = testsFixture.GerarEquipe(nomeSegundaEquipe);

            var partida = PartidaFactory.NovaPartida(primeiraEquipe, segundaEquipe);

            Assert.False(partida.PrimeiraEquipeVencePeloCriterioDeDesempate());
        }

        [Theory]
        [InlineData(5, 3)]
        [InlineData(15, 11)]
        [InlineData(1, 0)]
        [InlineData(9, 6)]
        [Trait("Partida_PrimeiraEquipeTemMaiorNumeroDeGols", "Sucesso")]
        public void Partida_PrimeiraEquipeTemMaiorNumeroDeGols_Sucesso(int golsPrimeiraEquipe, int golsSegundaEquipe)
        {
            var primeiraEquipe = testsFixture.GerarEquipe(null, golsPrimeiraEquipe);
            var segundaEquipe = testsFixture.GerarEquipe(null, golsSegundaEquipe);

            var partida = PartidaFactory.NovaPartida(primeiraEquipe, segundaEquipe);

            Assert.True(partida.PrimeiraEquipeTemMaiorNumeroDeGols());
        }

        [Theory]
        [InlineData(3, 5)]
        [InlineData(15, 17)]
        [InlineData(1, 10)]
        [InlineData(9, 12)]
        [Trait("Partida_PrimeiraEquipeTemMaiorNumeroDeGols", "Falha")]
        public void Partida_PrimeiraEquipeTemMaiorNumeroDeGols_Falha(int golsPrimeiraEquipe, int golsSegundaEquipe)
        {
            var primeiraEquipe = testsFixture.GerarEquipe(null, golsPrimeiraEquipe);
            var segundaEquipe = testsFixture.GerarEquipe(null, golsSegundaEquipe);

            var partida = PartidaFactory.NovaPartida(primeiraEquipe, segundaEquipe);

            Assert.False(partida.PrimeiraEquipeTemMaiorNumeroDeGols());
        }
    }
}
