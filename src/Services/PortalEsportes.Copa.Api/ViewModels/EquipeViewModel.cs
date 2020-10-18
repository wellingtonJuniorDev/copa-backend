using System;

namespace PortalEsportes.Copa.Api.ViewModels
{
    public class EquipeViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int Gols { get; set; }
    }
}
