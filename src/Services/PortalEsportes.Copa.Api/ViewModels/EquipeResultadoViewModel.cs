using System;
using System.ComponentModel.DataAnnotations;

namespace PortalEsportes.Copa.Api.ViewModels
{
    public class EquipeResultadoViewModel
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
        /// Indica se a equipe é a vencedora da copa ou não.
        /// </summary>
        public bool Vencedora { get; set; }
    }
}
