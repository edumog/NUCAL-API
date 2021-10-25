using NUCAL.Application.Core.DTOs;
using IAutoMapper = AutoMapper.IMapper;
using IMapper = NUCAL.Application.Core.Interfaces.IMapper;

namespace NUCAL.Infrastructure.Mapping
{
    public class Mapper : IMapper
    {
        private readonly IAutoMapper mapper;

        public Mapper(IAutoMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source) where TSource : class where TDestination : class => mapper.Map<TDestination>(source);

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) where TSource : class where TDestination : class => mapper.Map(source, destination);

        public ResponseItemDTO<T> MapResponseDTOToResponseItemDTO<T>(ResponseDTO responseDTO) => new ResponseItemDTO<T>
        {
            Succeeded = responseDTO.Succeeded,
            Errors = responseDTO.Errors,
            StatusCode = responseDTO.StatusCode
        };
    }
}
