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
    public class FoodsService : IFoodsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FoodsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseItemDTO<List<FoodDTO>>> Get()
        {
            try
            {
                List<Food> foods = await unitOfWork.FoodsRepository.GetAllEntities();
                return new ResponseItemDTO<List<FoodDTO>>
                {
                    Succeeded = true,
                    StatusCode = 200,
                    Item = mapper.Map<List<Food>, List<FoodDTO>>(foods)
                };
            }catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<List<FoodDTO>>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<List<FoodWithCategoriesDTO>>> GetAllWithCategories()
        {
            try
            {
                List<Food> foods = await unitOfWork.FoodsRepository.GetAllWithCategories();
                return new ResponseItemDTO<List<FoodWithCategoriesDTO>>
                {
                    Succeeded = true,
                    StatusCode = 200,
                    Item = mapper.Map<List<Food>, List<FoodWithCategoriesDTO>>(foods)
                };
            }
            catch (Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<List<FoodWithCategoriesDTO>>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<FoodDetailsDTO>> GetById(string id)
        {
            try
            {
                Food foodDb = await unitOfWork.FoodsRepository.GetByIdWithDetails(id);
                ResponseItemDTO<FoodDetailsDTO> response = mapper.MapResponseDTOToResponseItemDTO<FoodDetailsDTO>(Validations.CheckExistence(foodDb));
                if (response.Succeeded)
                {
                    response.Item = this.mapper.Map<Food, FoodDetailsDTO>(foodDb);
                    response.StatusCode = 200;
                }
                return response;
            }
            catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<FoodDetailsDTO>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<FoodDTO>> GetByName(string name)
        {
            try
            {
                Food food = await unitOfWork.FoodsRepository.GetByName(name);
                return new ResponseItemDTO<FoodDTO>
                {
                    Succeeded = true,
                    StatusCode = 200,
                    Item = mapper.Map<Food, FoodDTO>(food)
                };
            }
            catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<FoodDTO>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<FoodDTO>> Create(FoodEditionDTO newFood)
        {
            try
            {
                ResponseItemDTO<FoodDTO> response = await ValidateForCreation(newFood);
                if (response.Succeeded)
                {
                    Food food = mapper.Map<FoodEditionDTO, Food>(newFood);
                    response.Item = await Create(food);
                    return response;
                }
                return response;
            }
            catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<FoodDTO>(ExceptionHandler.GetResult(exception));
            }
        }
        private async Task<ResponseItemDTO<FoodDTO>> ValidateForCreation(FoodEditionDTO newFood)
        {
            var foodDb = await unitOfWork.FoodsRepository.GetByName(newFood.Name);
            ResponseItemDTO<FoodDTO> validationResult = mapper.MapResponseDTOToResponseItemDTO<FoodDTO>(Validations.CheckAvailability("Name", foodDb));
            return validationResult;
        }
        private async Task<FoodDTO> Create(Food food)
        {
            food.Id = Utilities.GenerateGuid();
            food = await unitOfWork.FoodsRepository.Add(food);
            unitOfWork.commit();
            return mapper.Map<Food, FoodDTO>(food);
        }

        public async Task<ResponseDTO> Update(string id, FoodEditionDTO foodEdited)
        {
            try
            {
                Food foodDb = await unitOfWork.FoodsRepository.GetByIdWithDetails(id);
                ResponseDTO response = await ValidateForEdition(foodDb, foodEdited);
                if (response.Succeeded)
                {
                    foodDb = mapper.Map(foodEdited, foodDb);

                    unitOfWork.FoodsRepository.update(foodDb);
                    unitOfWork.commit();
                }
                return response;
            }catch(Exception exception)
            {
                return ExceptionHandler.GetResult(exception);
            }
        }
        private async Task<ResponseDTO> ValidateForEdition(Food foodDb, FoodEditionDTO foodEdited)
        {
            ResponseDTO result = Validations.CheckExistence(foodDb);
            if (result.Succeeded)
            {
                result = await ValidateNameForEdition(foodEdited.Name, foodDb.Name, result);
            }

            return result;
        }
        private async Task<ResponseDTO> ValidateNameForEdition(string newName, string currentName, ResponseDTO result)
        {
            if(newName != currentName)
            {
                Food foodDb = await unitOfWork.FoodsRepository.GetByName(newName);
                result = Validations.CheckAvailability("Name", foodDb);
            }
            return result;
        }

        public async Task<ResponseDTO> Delete(string id)
        {
            Food food = await unitOfWork.FoodsRepository.GetEntityById(id);
            ResponseDTO response = Validations.CheckExistence(food);
            if (response.Succeeded)
            {
                unitOfWork.FoodsRepository.Delete(food);
                unitOfWork.commit();
            }
            return response;
        }
    }
}
