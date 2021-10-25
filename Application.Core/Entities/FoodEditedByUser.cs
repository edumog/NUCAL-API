using System;

namespace NUCAL.Application.Core.Entities
{
    public partial class FoodEditedByUser
    {
        public string UserId { get; set; }
        public string FoodId { get; set; }
        public DateTime EditionDate { get; set; }
        public bool Creation { get; set; }
        public bool Edition { get; set; }

        public virtual Food Food { get; set; }
        public virtual User User { get; set; }
    }
}
