using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.DTOs
{
    public partial class ExceptionResponseDTO
    {
        public List<ErrorDTO> Errors { get; set; }
    }
}
