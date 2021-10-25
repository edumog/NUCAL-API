using System.ComponentModel.DataAnnotations;

namespace NUCAL.Application.Core.DTOs.Entities
{
    public partial class FoodCategoryEditionDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
