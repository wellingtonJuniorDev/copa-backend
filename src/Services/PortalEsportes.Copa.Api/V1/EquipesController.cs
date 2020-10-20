using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalEsportes.Copa.Api.Controllers;
using PortalEsportes.Copa.Api.ViewModels;
using PortalEsportes.Copa.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalEsportes.Copa.Api.V1
{
    [ApiVersion("1.0")]
    public class EquipesController : MainController
    {
        private readonly IEquipesService equipesService;
        private readonly IMapper mapper;
        public EquipesController(IEquipesService equipesService,
            IMapper mapper)
        {
            this.equipesService = equipesService ??
                throw new ArgumentNullException(nameof(equipesService));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Recurso que obtém as equipes de uma fonte externa.
        /// </summary>
        /// <returns>Uma coleção de equipes.</returns>
        /// <response code="200">Retorna uma coleção de 16 equipes.</response>
        /// <response code="500">Houve um erro interno no servidor da aplicação.</response>
        [HttpGet]
        [ProducesResponseType(typeof(EquipeViewModel), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> ObterEquipesAsync()
        {
            var equipes = await equipesService.ObterEquipesAsync();

            return Ok(mapper.Map<IEnumerable<EquipeViewModel>>(equipes));
        }
    }
}
