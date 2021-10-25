
namespace NUCAL.Application.Core.Entities
{
    public partial class ReferenceMeasurements
    {
        public string IdFood { get; set; }
        public float? ReferenceMassInGrams { get; set; }
        public float? RererenceVolumeInMililiters { get; set; }
        public float? ReferenceUnits { get; set; }
        public virtual Food IdFoodNavigation { get; set; }
    }
}
