using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Entities;
using NUCAL.Application.Core.Entities;
using System.Collections.Generic;

namespace NUCAL.Application.Core.Interfaces
{
    public interface IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source) where TSource: class where TDestination : class;
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) where TSource : class where TDestination : class;
        ResponseItemDTO<T> MapResponseDTOToResponseItemDTO<T>(ResponseDTO responseDTO);
    }
}
