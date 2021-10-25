using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Entities;
using NUCAL.Application.Core.Entities;
using NUCAL.Application.Core.Helpers;
using NUCAL.Application.Core.Interfaces;
using NUCAL.Application.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Services
{
    public class FoodCategoriesService : IFoodCategoriesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FoodCategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ResponseItemDTO<List<FoodCategoryDTO>>> GetAll()
        {
            try
            {
                List<FoodCategory> foodCategories = await unitOfWork.FoodCategoriesRepository.GetAllEntities();
                return new ResponseItemDTO<List<FoodCategoryDTO>>
                {
                    Succeeded = true,
                    StatusCode = 200,
                    Item = mapper.Map<List<FoodCategory>,
                    List<FoodCategoryDTO>>(foodCategories)
                };
            }catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<List<FoodCategoryDTO>>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<FoodCategoryDTO>> GetById(string id)
        {
            try
            {
                FoodCategory foodCategory = await unitOfWork.FoodCategoriesRepository.GetEntityById(id);
                ResponseItemDTO<FoodCategoryDTO> response = mapper.MapResponseDTOToResponseItemDTO<FoodCategoryDTO>(Validations.CheckExistence(foodCategory));
                if (response.Succeeded)
                {
                    response.StatusCode = 200;
                    response.Item = mapper.Map<FoodCategory, FoodCategoryDTO>(foodCategory);
                }
                return response;
            }catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<FoodCategoryDTO>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<FoodCategoryDTO>> GetByName(string name)
        {
            try
            {
                FoodCategory foodCategory = await unitOfWork.FoodCategoriesRepository.GetByName(name);
                ResponseItemDTO<FoodCategoryDTO> response = new ResponseItemDTO<FoodCategoryDTO>
                {
                    StatusCode = 200,
                    Succeeded = true,
                    Item = mapper.Map<FoodCategory, FoodCategoryDTO>(foodCategory)
                };
                return response;
            }
            catch (Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<FoodCategoryDTO>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<FoodCategoryDTO>> Create(FoodCategoryDTO foodCategoryDTO)
        {
            try
            {
                ResponseItemDTO<FoodCategoryDTO> response = await ValidateName(foodCategoryDTO.Name);
                if (response.Succeeded)
                {
                    response.Item = await RegisterCategory(foodCategoryDTO);
                    response.StatusCode = 201;
                }
                return response;
            }catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<FoodCategoryDTO>(ExceptionHandler.GetResult(exception));
            }
        }
        private async Task<ResponseItemDTO<FoodCategoryDTO>> ValidateName(string name)
        {
            ResponseItemDTO<FoodCategoryDTO> response = new ResponseItemDTO<FoodCategoryDTO>();
            var foodCategory = await unitOfWork.FoodCategoriesRepository.GetByName(name);
            response = mapper.MapResponseDTOToResponseItemDTO<FoodCategoryDTO>(Validations.CheckAvailability("Name", foodCategory));
            return response;
        }
        private async Task<FoodCategoryDTO> RegisterCategory(FoodCategoryDTO foodCategoryDTO)
        {
            foodCategoryDTO.Id = Utilities.GenerateGuid();
            FoodCategory foodCategory = mapper.Map<FoodCategoryDTO, FoodCategory>(foodCategoryDTO);
            foodCategory = await unitOfWork.FoodCategoriesRepository.Add(foodCategory);
            unitOfWork.commit();
            return mapper.Map<FoodCategory, FoodCategoryDTO>(foodCategory); 
        }

        public async Task<ResponseDTO> Update(FoodCategoryEditDTO foodCategory, string id)
        {
            try
            {
                FoodCategory foodCategoryDb = await unitOfWork.FoodCategoriesRepository.GetEntityById(id);
                ResponseDTO response = await ValidateForEdition(foodCategory, foodCategoryDb);
                if (response.Succeeded)
                {
                    foodCategoryDb = mapper.Map(foodCategory, foodCategoryDb);
                    unitOfWork.commit();
                    response.StatusCode = 204;
                }
                return response;
            }
            catch(Exception exception)
            {
                return ExceptionHandler.GetResult(exception);
            }
        }
        private async Task<ResponseDTO> ValidateForEdition(FoodCategoryEditDTO foodCategory, FoodCategory foodCategoryDb)
        {
            ResponseDTO result = new ResponseDTO();
            result = Validations.CheckExistence(foodCategoryDb);
            if (!result.Succeeded) return result;
            result = await ValidateName(foodCategory.Name, foodCategoryDb.Name, result);
            return result;
        }
        private async Task<ResponseDTO> ValidateName(string name, string nameDb, ResponseDTO result)
        {
            if (name == nameDb) result.Succeeded = true;
            else
            {
                FoodCategory FoundByName = await unitOfWork.FoodCategoriesRepository.GetByName(name);
                result = Validations.CheckAvailability(name, FoundByName);
            }
            return result;
        }

        public async Task<ResponseDTO> Delete(string id)
        {
            try
            {
                FoodCategory foodCategory = await unitOfWork.FoodCategoriesRepository.GetEntityById(id);
                ResponseDTO response = Validations.CheckExistence(foodCategory);
                if (response.Succeeded)
                {
                    unitOfWork.FoodCategoriesRepository.Delete(foodCategory);
                    unitOfWork.commit();
                    response.StatusCode = 204;
                }
                return response;
            }catch(Exception exception)
            {
                return ExceptionHandler.GetResult(exception);
            }
        }
    }
}
