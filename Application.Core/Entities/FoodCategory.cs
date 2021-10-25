using System.Collections.Generic;

namespace NUCAL.Application.Core.Entities
{
    public partial class FoodCategory: BaseEntity
    {
        public FoodCategory()
        {
            FoodInCategories = new HashSet<FoodInCategory>();
        }

        public string Name { get; set; }

        public virtual ICollection<FoodInCategory> FoodInCategories { get; set; }
    }
}
