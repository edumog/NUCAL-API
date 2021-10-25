using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.DTOs.Entities
{
    public partial class MacronutrientsDTO
    {
        public float? Calories { get; set; }
        public float? Protein { get; set; }
        public double? Carbohydrates { get; set; }
        public float? Grease { get; set; }
        public float? Fiber { get; set; }
    }
}
