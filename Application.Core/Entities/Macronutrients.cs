
namespace NUCAL.Application.Core.Entities
{
    public partial class Macronutrients
    {
        public string IdFood { get; set; }
        public float? Calories { get; set; }
        public float? Protein { get; set; }
        public double? Carbohydrates { get; set; }
        public float? Grease { get; set; }
        public float? Fiber { get; set; }

        public virtual Food IdFoodNavigation { get; set; }
    }
}
