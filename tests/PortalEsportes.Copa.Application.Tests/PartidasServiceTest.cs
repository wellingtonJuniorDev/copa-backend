using PortalEsportes.Copa.Application.Tests.Fixtures;
using PortalEsportes.Copa.Domain.Exceptions;
using PortalEsportes.Copa.Domain.Models;
using PortalEsportes.Copa.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PortalEsportes.Copa.Application.Tests
{
    [Collection(nameof(TestsFixtureCollection))]
    public class PartidasServiceTest
    {
        private readonly TestsFixture testsFixture;
        private readonly IPartidasService partidasService;

        public PartidasServiceTest(TestsFixture testsFixture)
        {
            this.testsFixture = testsFixture;
            partidasService = new PartidasService();
        }

        [Fact]
        [Trait("IPartidasService_GerarCopa", "Sucesso")]
        public void IPartidasService_GerarCopa_Sucesso()
        {
            var equipes = testsFixture.GerarEquipesDaEspecificacao();

            var equipeVencedora = equipes.FirstOrDefault(e => e.Nome == "Equipe 5");

            var resultadoDaCopa = partidasService.GerarCopa(equipes);

            Assert.Equal(equipeVencedora, resultadoDaCopa.EquipeVencedora);
        }

        [Fact]
        [Trait("IPartidasService_OrdenarEquipesPorOrdemAlfabetica", "Sucesso")]
        public void IPartidasService_OrdenarEquipesPorOrdemAlfabetica_Sucesso()
        {
            var equipes = new List<Equipe>()
            {
                testsFixture.GerarEquipe("TTQuinta"),
                testsFixture.GerarEquipe("Terceira"),
                testsFixture.GerarEquipe("TTQuarta"),
                testsFixture.GerarEquipe("Primeira"),
                testsFixture.GerarEquipe("Segunda"),
            };

            var equipesOrdenadas = partidasService
                  .OrdenarEquipesPorOrdemAlfabetica(equipes);

            Assert.Equal("Primeira", equipesOrdenadas.ElementAt(0).Nome);
            Assert.Equal("Segunda", equipesOrdenadas.ElementAt(1).Nome);
            Assert.Equal("Terceira", equipesOrdenadas.ElementAt(2).Nome);
            Assert.Equal("TTQuarta", equipesOrdenadas.ElementAt(3).Nome);
            Assert.Equal("TTQuinta", equipesOrdenadas.ElementAt(4).Nome);
        }

        [Fact]
        [Trait("IPartidasService_ObterEquipesVencedoras", "Sucesso")]
        public void IPartidasService_ObterEquipesVencedoras_Sucesso()
        {
            var equipes = new List<Equipe>()
            {
                testsFixture.GerarEquipe(null, 5),
                testsFixture.GerarEquipe(null, 4),
                testsFixture.GerarEquipe(null, 3),
                testsFixture.GerarEquipe(null, 2)
            };

            var equipesVencedorasEsperadas = new List<Equipe>()
            {
                equipes.ElementAt(0),
                equipes.ElementAt(2)
            };

            var partidas = new List<Partida>()
            {
                PartidaFactory.NovaPartida(equipes.ElementAt(0), equipes.ElementAt(1)),
                PartidaFactory.NovaPartida(equipes.ElementAt(2), equipes.ElementAt(3))
            };

            var equipesVencedoras = partidasService.ObterEquipesVencedoras(partidas);

            Assert.Equal(equipesVencedorasEsperadas, equipesVencedoras);
        }
                
        [Fact]
        [Trait("IPartidasService_ObterPartidasPrimeiraFase", "Exception")]
        public void IPartidasService_ObterPartidasPrimeiraFase_Exception()
        {
            var equipes = testsFixture.GerarEquipesRandomicas(10);

            var exception =
                Assert.Throws<CoreException>(() => partidasService.ObterPartidasPrimeiraFase(equipes));

            Assert.Equal($"O método {nameof(partidasService.ObterPartidasPrimeiraFase)} aceita somente uma coleção de 08 equipes", exception.Message);
        }

        [Fact]
        [Trait("IPartidasService_ObterPartidasSegundaFase", "Exception")]
        public void IPartidasService_ObterPartidasSegunda_Exception()
        {
            var equipes = testsFixture.GerarEquipesRandomicas(5);

            var exception =
                Assert.Throws<CoreException>(() => partidasService.ObterPartidasSegundaFase(equipes));

            Assert.Equal($"O método {nameof(partidasService.ObterPartidasSegundaFase)} aceita somente uma coleção de 04 equipes", exception.Message);
        }

        [Fact]
        [Trait("IPartidasService_ObterPartidaFinal", "Exception")]
        public void IPartidasService_ObterPartidaFinal_Exception()
        {
            var equipes = testsFixture.GerarEquipesRandomicas(4);

            var exception =
                Assert.Throws<CoreException>(() => partidasService.ObterPartidaFinal(equipes));

            Assert.Equal($"O método {nameof(partidasService.ObterPartidaFinal)} aceita somente uma coleção de 02 equipes", exception.Message);
        }

        [Fact]
        [Trait("IPartidasService_ObterPartidasPrimeiraFase", "Sucesso")]
        public void IPartidasService_ObterPartidasPrimeiraFase_Sucesso()
        {
            var equipes = testsFixture.GerarEquipesDaEspecificacao();

            var partidasEsperadas = new List<Partida>()
            {
                PartidaFactory.NovaPartida(equipes.ElementAt(0), equipes.ElementAt(7)),
                PartidaFactory.NovaPartida(equipes.ElementAt(1), equipes.ElementAt(6)),
                PartidaFactory.NovaPartida(equipes.ElementAt(2), equipes.ElementAt(5)),
                PartidaFactory.NovaPartida(equipes.ElementAt(3), equipes.ElementAt(4))
            };

            var partidasPrimeiraFase = partidasService.ObterPartidasPrimeiraFase(equipes);

            Assert.Equal(4, partidasPrimeiraFase.Count());

            Assert.True(partidasEsperadas.ElementAt(0).EquipeVencedora
                .Equals(partidasPrimeiraFase.ElementAt(0).EquipeVencedora));

            Assert.True(partidasEsperadas.ElementAt(1).EquipeVencedora
                .Equals(partidasPrimeiraFase.ElementAt(1).EquipeVencedora));

            Assert.True(partidasEsperadas.ElementAt(2).EquipeVencedora
                .Equals(partidasPrimeiraFase.ElementAt(2).EquipeVencedora));

            Assert.True(partidasEsperadas.ElementAt(3).EquipeVencedora
                .Equals(partidasPrimeiraFase.ElementAt(3).EquipeVencedora));
        }

        [Fact]
        [Trait("IPartidasService_ObterPartidasSegundaFase", "Sucesso")]
        public void IPartidasService_ObterPartidasSegundaFase_Sucesso()
        {            
            var equipesSegundaFase = testsFixture.ObterEquipesDaSegundaFase();

            var partidasEsperadas = new List<Partida>()
            {
                PartidaFactory.NovaPartida(equipesSegundaFase.ElementAt(0), equipesSegundaFase.ElementAt(1)),
                PartidaFactory.NovaPartida(equipesSegundaFase.ElementAt(2), equipesSegundaFase.ElementAt(3))
            };

            var partidasSegundaFase = partidasService.ObterPartidasSegundaFase(equipesSegundaFase);

            Assert.Equal(2, partidasSegundaFase.Count());

            Assert.True(partidasEsperadas.ElementAt(0).EquipeVencedora
                .Equals(partidasSegundaFase.ElementAt(0).EquipeVencedora));

            Assert.True(partidasEsperadas.ElementAt(1).EquipeVencedora
                .Equals(partidasSegundaFase.ElementAt(1).EquipeVencedora));
        }

        [Fact]
        [Trait("IPartidasService_ObterPartidaFinal", "Sucesso")]
        public void IPartidasService_ObterPartidaFinal_Sucesso()
        {
            var equipes = testsFixture.ObterEquipesFinais();

            var partidaEsperada = PartidaFactory.NovaPartida(equipes.First(), equipes.Last());

            var partidaFinal = partidasService.ObterPartidaFinal(equipes);

            Assert.IsType<Partida>(partidaFinal);

            Assert.True(partidaEsperada.PrimeiraEquipe
                .Equals(partidaFinal.PrimeiraEquipe));

            Assert.True(partidaEsperada.SegundaEquipe
                .Equals(partidaFinal.SegundaEquipe));

        }
    }
}
