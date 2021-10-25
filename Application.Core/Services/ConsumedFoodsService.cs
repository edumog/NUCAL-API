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
    public class ConsumedFoodsService : IConsumedFoodsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ConsumedFoodsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseItemDTO<List<ConsumedFoodDTO>>> GetByUser(string userId)
        {
            try
            {
                List<ConsumedFood> consumedFoodsDb = await unitOfWork.ConsumedFoodsRepository.GetByUser(userId);
                ResponseItemDTO<List<ConsumedFoodDTO>> response = mapper.MapResponseDTOToResponseItemDTO<List<ConsumedFoodDTO>>(Validations.CheckExistence(consumedFoodsDb));
                if (response.Succeeded)
                {
                    response.Item = mapper.Map<List<ConsumedFood>, List<ConsumedFoodDTO>>(consumedFoodsDb);
                    response.StatusCode = 200;
                }
                return response;

            }catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<List<ConsumedFoodDTO>>(ExceptionHandler.GetResult(exception));
            }
        }

        public async Task<ResponseItemDTO<ConsumedFoodDTO>> Create(ConsumedFoodDTO newConsumedFood)
        {
            try
            {
                ResponseItemDTO<ConsumedFoodDTO> response = await ValidateForCreation(newConsumedFood);
                if (response.Succeeded)
                {
                    ConsumedFood consumedFood = mapper.Map<ConsumedFoodDTO, ConsumedFood>(newConsumedFood);
                    consumedFood = await unitOfWork.ConsumedFoodsRepository.Add(consumedFood);
                    response.Item = mapper.Map<ConsumedFood, ConsumedFoodDTO>(consumedFood);
                    unitOfWork.commit();
                    response.StatusCode = 201;
                }
                return response;
            }catch(Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<ConsumedFoodDTO>(ExceptionHandler.GetResult(exception));
            }
        }
        private async Task<ResponseItemDTO<ConsumedFoodDTO>> ValidateForCreation(ConsumedFoodDTO consumedFood)
        {
            DateTime date = DateTime.Now;
            ConsumedFood consumedFoodDb = await unitOfWork.ConsumedFoodsRepository.GetById(consumedFood.IdUser, date, consumedFood.NumberOfPlate, consumedFood.IdFood);
            return mapper.MapResponseDTOToResponseItemDTO<ConsumedFoodDTO>(Validations.CheckAvailability("Id", consumedFoodDb));
        }

        public async Task<ResponseDTO> Update(ConsumedFoodEditDTO consumedFood)
        {
            try
            {
                ConsumedFood consumedFoodDb = await unitOfWork.ConsumedFoodsRepository.GetById(consumedFood.IdUser, DateTime.Parse(consumedFood.Date), consumedFood.NumberOfPlate, consumedFood.IdFood);
                ResponseDTO response = Validations.CheckExistence(consumedFood);
                if (response.Succeeded)
                {
                    Update(consumedFood, consumedFoodDb);
                    response.StatusCode = 204;
                }
                return response;
            }catch(Exception exception)
            {
                return ExceptionHandler.GetResult(exception);
            }
        }
        private void Update(ConsumedFoodEditDTO consumedFood, ConsumedFood consumedFoodDb)
        {
            consumedFoodDb = mapper.Map(consumedFood, consumedFoodDb);
            unitOfWork.ConsumedFoodsRepository.update(consumedFoodDb);
            unitOfWork.commit();
        }

        public async Task<ResponseDTO> Delete(ConsumedFoodDTO consumedFood)
        {
            try
            {
                ConsumedFood consumedFoodDb = await unitOfWork.ConsumedFoodsRepository.GetById(consumedFood.IdUser, DateTime.Parse(consumedFood.Date), consumedFood.NumberOfPlate, consumedFood.IdFood);
                ResponseDTO response = Validations.CheckExistence(consumedFoodDb);
                if (response.Succeeded)
                {
                    Delete(consumedFoodDb);
                    response.StatusCode = 204;
                }
                return response;
            }catch(Exception exception)
            {
                return ExceptionHandler.GetResult(exception);
            }
        }

        private void Delete(ConsumedFood consumedFoodDb)
        {
            unitOfWork.ConsumedFoodsRepository.Delete(consumedFoodDb);
            unitOfWork.commit();
        }
    }
}
