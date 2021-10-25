using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Services
{
    public interface IFoodCategoriesService
    {
        public Task<ResponseItemDTO<List<FoodCategoryDTO>>> GetAll();
        public Task<ResponseItemDTO<FoodCategoryDTO>> GetById(string id);
        public Task<ResponseItemDTO<FoodCategoryDTO>> GetByName(string name);
        public Task<ResponseItemDTO<FoodCategoryDTO>> Create(FoodCategoryDTO foodCategoryDTO);
        public Task<ResponseDTO> Update(FoodCategoryEditDTO foodCategoryEditDTO, string id);
        public Task<ResponseDTO> Delete(string id);
    }
}
