using System.ComponentModel.DataAnnotations;

namespace NUCAL.Application.Core.DTOs.Entities
{
    public partial class FoodCategoryEditDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
