using System.Collections.Generic;

namespace NUCAL.Application.Core.Entities
{
    public partial class Food: BaseEntity
    {
        public Food()
        {
            ConsumedFoods = new HashSet<ConsumedFood>();
            FoodInCategories = new HashSet<FoodInCategory>();
            FoodReferences = new HashSet<FoodReference>();
            FoodsEditedByUsers = new HashSet<FoodEditedByUser>();
        }

        public string Name { get; set; }

        public FattyAcidsAndCholesterol FattyAcidsAndCholesterol { get; set; }
        public Macronutrients Macronutrients { get; set; }
        public Minerals Minerals { get; set; }
        public ReferenceMeasurements ReferenceMeasurements { get; set; }
        public Vitamins Vitamins { get; set; }
        public ICollection<ConsumedFood> ConsumedFoods { get; set; }
        public ICollection<FoodInCategory> FoodInCategories { get; set; }
        public ICollection<FoodReference> FoodReferences { get; set; }
        public ICollection<FoodEditedByUser> FoodsEditedByUsers { get; set; }
    }
}
