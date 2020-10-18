using Moq;
using PortalEsportes.Copa.Application.Tests.Fixtures;
using PortalEsportes.Copa.Domain.Adapters;
using PortalEsportes.Copa.Domain.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PortalEsportes.Copa.Application.Tests
{
    [Collection(nameof(TestsFixtureCollection))]
    public class EquipesServiceTest
    {
        private readonly TestsFixture testsFixture;
        private readonly IEquipesService equipesService;
        private readonly Mock<IEquipesAdapter> equipeAdapterMock;

        public EquipesServiceTest(TestsFixture testsFixture)
        {
            this.testsFixture = testsFixture;
            equipeAdapterMock = new Mock<IEquipesAdapter>();
            equipesService = new EquipesService(equipeAdapterMock.Object);
        }

        [Fact]
        [Trait("IEquipesService_ObterEquipesAsync", "Sucesso")]
        public async Task ObterEquipesAsync_Sucesso()
        {
            var quantidadeDeEquipes = 3;
            var expected = testsFixture.GerarEquipesRandomicas(quantidadeDeEquipes);

            equipeAdapterMock
                .Setup(e => e.ObterEquipesAsync())
                .ReturnsAsync(expected);

            var equipes = await equipesService.ObterEquipesAsync();

            equipeAdapterMock.Verify(e => e.ObterEquipesAsync(), Times.Once);

            Assert.NotEmpty(equipes);
            Assert.Equal(expected, equipes);
            Assert.Equal(quantidadeDeEquipes, equipes.Count());
        }

        [Fact]
        [Trait("IEquipesService_ObterEquipesSelecionadasAsync", "Sucesso")]
        public async Task ObterEquipesSelecionadasAsync_Sucesso()
        {
            int quantidadeDeEquipesSelecionadas = 2;
            var quantidadeDeEquipes = 5;

            var equipes = testsFixture.GerarEquipesRandomicas(quantidadeDeEquipes);
            var equipesIds = equipes.Select(e => e.Id)
                .Take(quantidadeDeEquipesSelecionadas);

            equipeAdapterMock
                .Setup(e => e.ObterEquipesAsync())
                .ReturnsAsync(equipes);

            var equipesSelecionadas = await equipesService
                .ObterEquipesSelecionadasAsync(equipesIds);

            equipeAdapterMock.Verify(e => e.ObterEquipesAsync(), Times.Once);

            Assert.Equal(equipesIds, equipesSelecionadas.Select(e => e.Id));
        }
    }
}
