using System.Collections.Generic;

namespace NUCAL.Application.Core.DTOs.Entities
{
    public partial class FoodDetailsDTO: FoodDTO
    {
        public ReferenceMeasurementsDTO ReferenceMeasurements { get; set; }
        public FattyAcidsAndCholesterolDTO FattyAcidsAndCholesterol { get; set; }
        public MacronutrientsDTO Macronutrients { get; set; }
        public MineralsDTO Minerals { get; set; }
        public VitaminsDTO Vitamins { get; set; }
        public string[] Categories { get; set; }
    }
}
