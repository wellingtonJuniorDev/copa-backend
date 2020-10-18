using Bogus;
using PortalEsportes.Copa.Domain.Models;
using System;
using Xunit;

namespace PortalEsportes.Copa.Domain.Tests.Fixtures
{
    [CollectionDefinition(nameof(TestsFixtureCollection))]
    public class TestsFixtureCollection : ICollectionFixture<TestsFixture>
    { }

    public class TestsFixture
    {
        private const string fakerLanguage = "pt_BR";

        public Equipe GerarEquipe(string nome = null, int gols = 1)
        {
            var faker = new Faker(fakerLanguage);

            if (string.IsNullOrEmpty(nome))
            {
                nome = faker.Name.JobArea();
            }

            var sigla = nome.Substring(0, 2);

            return new Equipe(Guid.NewGuid(), nome, sigla, gols);
        }
    }
}
