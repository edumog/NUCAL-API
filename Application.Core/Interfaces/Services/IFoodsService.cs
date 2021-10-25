using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Services
{
    public interface IFoodsService
    {
        public Task<ResponseItemDTO<List<FoodDTO>>> Get();
        public Task<ResponseItemDTO<List<FoodWithCategoriesDTO>>> GetAllWithCategories();
        public Task<ResponseItemDTO<FoodDetailsDTO>> GetById(string id);
        public Task<ResponseItemDTO<FoodDTO>> GetByName(string name);
        public Task<ResponseItemDTO<FoodDTO>> Create(FoodEditionDTO foodCategoryDTO);
        public Task<ResponseDTO> Update(string id, FoodEditionDTO editedFood);
        public Task<ResponseDTO> Delete(string id);
    }
}
