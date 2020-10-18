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

        [HttpGet]
        [ProducesResponseType(typeof(EquipeViewModel), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> ObterEquipesAsync()
        {
            var equipes = await equipesService.ObterEquipesAsync();

            return Ok(mapper.Map<IEnumerable<EquipeViewModel>>(equipes));
        }
    }
}
