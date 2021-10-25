
namespace NUCAL.Application.Core.Entities
{
    public partial class FoodReference
    {
        public string IdFood { get; set; }
        public string IdReference { get; set; }
        public virtual Food IdFoodNavigation { get; set; }
        public virtual Reference IdReferenceNavigation { get; set; }

    }
}
