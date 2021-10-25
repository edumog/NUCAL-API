using System;

namespace NUCAL.Application.Core.Entities
{
    public partial class ConsumedFood
    {
        public string IdUser { get; set; }
        public DateTime Date { get; set; }
        public byte NumberOfPlate { get; set; }
        public string IdFood { get; set; }
        public float? MassConsumedInGr { get; set; }
        public float? VolumeConsumedInMl { get; set; }
        public short? ConsumedUnits { get; set; }

        public virtual Food IdFoodNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
