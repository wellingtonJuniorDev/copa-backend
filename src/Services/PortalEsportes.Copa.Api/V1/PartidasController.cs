using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalEsportes.Copa.Api.Controllers;
using PortalEsportes.Copa.Api.ViewModels;
using PortalEsportes.Copa.Domain.Models;
using PortalEsportes.Copa.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEsportes.Copa.Api.V1
{
    [ApiVersion("1.0")]
    public class PartidasController : MainController
    {
        private readonly IPartidasService partidasService;
        private readonly IEquipesService equipesService;
        private readonly IMapper mapper;

        public PartidasController(IPartidasService partidasService,
            IEquipesService equipesService,
            IMapper mapper)
        {
            this.partidasService = partidasService ??
                throw new ArgumentNullException(nameof(partidasService));

            this.equipesService = equipesService ??
                throw new ArgumentNullException(nameof(equipesService));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("copa")]
        [ProducesResponseType(typeof(EquipeResultadoViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> GerarCopaAsync(IEnumerable<Guid> equipesIds)
        {     
            var equipes = await equipesService.ObterEquipesSelecionadasAsync(equipesIds);

            if (!ExistirOitoEquipesSelecionadas(equipes))
            {
                AdicionarErroValidacao($"É necessário selecionar 8 equipes, você selecionou {equipes.Count()}");
            }

            if (ExistirEquipesComNomesIguais(equipes))
            {
                AdicionarErroValidacao("A copa não pode ser realizada quando 2 equipes ou mais possuem nomes iguais.");
            }

            if (OperacaoInvalida()) return CustomResponse();

            var resultadoDaCopa = partidasService.GerarCopa(equipes);

            return CustomResponse(mapper.Map<List<EquipeResultadoViewModel>>(resultadoDaCopa));
        }

        private bool ExistirOitoEquipesSelecionadas(IEnumerable<Equipe> equipes)
        {
            return equipes.Count() != equipes.Distinct().Count() ||
                equipes.Count().Equals(8);
        }

        private bool ExistirEquipesComNomesIguais(IEnumerable<Equipe> equipes)
        {
            return equipes.Count() > 
                   equipes.Select(e => e.Nome).Distinct().Count();
        }
    }
}
