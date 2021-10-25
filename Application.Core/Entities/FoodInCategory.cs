
namespace NUCAL.Application.Core.Entities
{
    public partial class FoodInCategory
    {
        public string FoodCategoryId { get; set; }
        public string FoodId { get; set; }

        public virtual Food Food { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
    }
}
