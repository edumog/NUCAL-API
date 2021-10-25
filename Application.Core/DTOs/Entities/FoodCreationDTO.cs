
namespace NUCAL.Application.Core.DTOs.Entities
{
    public partial class FoodEditionDTO
    {
        public string Name { get; set; }
        public FattyAcidsAndCholesterolDTO FattyAcidsAndCholesterol { get; set; }
        public MacronutrientsDTO Macronutrients { get; set; }
        public MineralsDTO Minerals { get; set; }
        public ReferenceMeasurementsDTO ReferenceMeasurements { get; set; }
        public VitaminsDTO Vitamins { get; set; }
        public string[] Categories { get; set; }
    }
}
