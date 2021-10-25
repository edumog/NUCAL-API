
using System.Collections.Generic;

namespace NUCAL.Application.Core.Entities
{
    public partial class User: BaseEntity
    {

        public User()
        {
            ConsumedFoods = new HashSet<ConsumedFood>();
            FoodsEditedByUsers = new HashSet<FoodEditedByUser>();
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ConsumedFood> ConsumedFoods { get; set; }
        public virtual ICollection<FoodEditedByUser> FoodsEditedByUsers { get; set; }
    }
}
