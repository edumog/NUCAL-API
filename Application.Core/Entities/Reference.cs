using System.Collections.Generic;

namespace NUCAL.Application.Core.Entities
{
    public partial class Reference: BaseEntity
    {
        public Reference()
        {
            FoodReferences = new HashSet<FoodReference>();
        }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FoodReference> FoodReferences { get; set; }
    }
}
