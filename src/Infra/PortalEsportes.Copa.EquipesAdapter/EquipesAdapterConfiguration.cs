using System.ComponentModel.DataAnnotations;

namespace PortalEsportes.Copa.EquipesAdapter
{
    public class EquipesAdapterConfiguration
    {
        [Required]
        public string ApiUrlBase { get; set; }
    }
}
