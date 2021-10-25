
namespace NUCAL.Application.Core.Entities
{
    public partial class Minerals
    {
        public string IdFood { get; set; }
        public float? Calcium { get; set; }
        public float? Iron { get; set; }
        public float? Sodium { get; set; }
        public float? Phosphorus { get; set; }
        public float? Iodo { get; set; }
        public float? Zinc { get; set; }
        public float? Manganese { get; set; }
        public float? Potassium { get; set; }

        public virtual Food IdFoodNavigation { get; set; }
    }
}
