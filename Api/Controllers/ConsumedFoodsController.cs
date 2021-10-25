using Microsoft.AspNetCore.Mvc;
using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Entities;
using NUCAL.Application.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUCAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumedFoodsController: CustomBaseController
    {
        private readonly IConsumedFoodsService consumedFoodsService;

        public ConsumedFoodsController(IConsumedFoodsService consumedFoodsService)
        {
            this.consumedFoodsService = consumedFoodsService;
        }

        [HttpGet("GetByUser")]
        public async Task<ActionResult<ResponseItemDTO<List<ConsumedFoodDTO>>>> Get([FromQuery]string id)
        {
            ResponseItemDTO<List<ConsumedFoodDTO>> result = await consumedFoodsService.GetByUser(id);
            return GetResponse(result, result.Item);
        }

        [HttpPost] 
        public async Task<ActionResult<ResponseItemDTO<ConsumedFoodDTO>>> Create([FromBody] ConsumedFoodDTO consumedFood)
        {
            ResponseItemDTO<ConsumedFoodDTO> result = await consumedFoodsService.Create(consumedFood);
            return GetCreationResponse(result, result.Item);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> Update([FromBody] ConsumedFoodEditDTO consumedFoodEdited)
        {
            return GetResponse(await consumedFoodsService.Update(consumedFoodEdited));
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseDTO>> Delete([FromBody] ConsumedFoodDTO consumedFood)
        {
            return GetResponse(await consumedFoodsService.Delete(consumedFood));
        }
    }
}
