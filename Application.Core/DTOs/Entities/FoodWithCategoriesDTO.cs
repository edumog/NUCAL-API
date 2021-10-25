using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.DTOs.Entities
{
    public partial class FoodWithCategoriesDTO : FoodDTO
    {
        public string[] Categories { get; set; }
    }
}
