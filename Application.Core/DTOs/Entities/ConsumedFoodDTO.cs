using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.DTOs.Entities
{
    public partial class ConsumedFoodDTO
    {
        public string IdUser { get; set; }
        public string Date { get; set; }
        public byte NumberOfPlate { get; set; }
        public string IdFood { get; set; }
        public float? MassConsumedInGr { get; set; }
        public float? VolumeConsumedInMl { get; set; }
        public short? ConsumedUnits { get; set; }
    }
}
