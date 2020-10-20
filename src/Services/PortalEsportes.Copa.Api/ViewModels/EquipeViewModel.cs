using System;
using System.ComponentModel.DataAnnotations;

namespace PortalEsportes.Copa.Api.ViewModels
{
    public class EquipeViewModel
    {
        /// <summary>
        /// O identificador da Equipe na aplicação.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// O nome da Equipe.
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// O identificador da Equipe fora da aplicação.
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// O número de gols da equipe utilizado nas disputas.
        /// </summary>
        [Required]
        public int Gols { get; set; }
    }
}
