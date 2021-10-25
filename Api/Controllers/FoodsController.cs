using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    public class FoodsController : CustomBaseController
    {
        private readonly IFoodsService foodService;

        public FoodsController(IFoodsService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseItemDTO<List<FoodDTO>>>> Get()
        {
            ResponseItemDTO<List<FoodDTO>> result = await foodService.Get();
            return GetResponse(result, result.Item);
        }

        [HttpGet("getWithCategories")]
        public async Task<ActionResult<ResponseItemDTO<List<FoodWithCategoriesDTO>>>> GetAllWithCategories()
        {
            ResponseItemDTO<List<FoodWithCategoriesDTO>> result = await foodService.GetAllWithCategories();
            return GetResponse(result, result.Item);
        }

        [HttpGet("{id}", Name = "GetFood")]
        public async Task<ActionResult<ResponseItemDTO<FoodDetailsDTO>>> GetById(string id)
        {
            ResponseItemDTO<FoodDetailsDTO> result = await foodService.GetById(id);
            return GetResponse(result, result.Item);
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<ResponseItemDTO<FoodDTO>>> GetByName(string name)
        {
            ResponseItemDTO<FoodDTO> result = await foodService.GetByName(name);
            return GetResponse(result, result.Item);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ResponseItemDTO<FoodDTO>>> Create([FromBody] FoodEditionDTO newFood)
        {
            ResponseItemDTO<FoodDTO> result = await foodService.Create(newFood);
            string itemId = (result.Item != null) ? result.Item.Id : null;
            return GetCreationResponse(result, result.Item, itemId, "GetFood");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO>> Update([FromBody] FoodEditionDTO editedFood, string id)
        {
            return GetResponse(await foodService.Update(id, editedFood));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> Delete(string id)
        {
            return GetResponse(await foodService.Delete(id));
        }
    }
}
