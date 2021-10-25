using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Services
{
    public interface IConsumedFoodsService
    {
        public Task<ResponseItemDTO<List<ConsumedFoodDTO>>> GetByUser(string userId);
        public Task<ResponseItemDTO<ConsumedFoodDTO>> Create(ConsumedFoodDTO consumedFood);
        public Task<ResponseDTO> Update(ConsumedFoodEditDTO consumedFood);
        public Task<ResponseDTO> Delete(ConsumedFoodDTO consumedFood);

    }
}
