using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.DTOs
{
    public partial class ResponseDTO
    {
        [Required]
        public bool Succeeded { get; set; }
        [Required]
        public int StatusCode { get; set; }
        public List<ErrorDTO> Errors { get; set; }
    }
}
