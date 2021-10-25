using System;
using System.Collections.Generic;

namespace NUCAL.Application.Core.DTOs
{
    public partial class ResponseItemDTO<T>: ResponseDTO
    {
        public T Item { get; set; }
    }
}
