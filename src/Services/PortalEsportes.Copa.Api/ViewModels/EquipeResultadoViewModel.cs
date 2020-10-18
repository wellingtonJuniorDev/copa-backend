using System;

namespace PortalEsportes.Copa.Api.ViewModels
{
    public class EquipeResultadoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Vencedora { get; set; }
    }
}
