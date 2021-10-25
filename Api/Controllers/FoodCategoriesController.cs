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
    public class FoodCategoriesController : CustomBaseController
    {
        private readonly IFoodCategoriesService foodCategoriesService;

        public FoodCategoriesController(IFoodCategoriesService foodCategoriesService)
        {
            this.foodCategoriesService = foodCategoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseItemDTO<List<FoodCategoryDTO>>>> GetAll()
        {
            ResponseItemDTO<List<FoodCategoryDTO>> result = await foodCategoriesService.GetAll();
            return GetResponse(result, result.Item);
        }

        [HttpGet("{id}", Name = "GetFoodCategory")]
        public async Task<ActionResult<ResponseItemDTO<FoodCategoryDTO>>> GetById(string id)
        {
            ResponseItemDTO<FoodCategoryDTO> result = await foodCategoriesService.GetById(id);
            return GetResponse(result, result.Item);
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<ResponseItemDTO<FoodCategoryDTO>>> GetByName(string name)
        {
            ResponseItemDTO<FoodCategoryDTO> result = await foodCategoriesService.GetByName(name);
            return GetResponse(result, result.Item);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ResponseItemDTO<FoodCategoryDTO>>> Create([FromBody] FoodCategoryDTO foodCategory)
        {
            ResponseItemDTO<FoodCategoryDTO> result = await foodCategoriesService.Create(foodCategory);
            string itemId = (result.Item != null) ? result.Item.Id : null;
            return GetCreationResponse(result, result.Item, itemId, "GetFoodCategory");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO>> Update([FromBody] FoodCategoryEditDTO foodCategoryEdited, string id)
        {
            return GetResponse(await foodCategoriesService.Update(foodCategoryEdited, id));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> Delete(string id)
        {
            return GetResponse(await foodCategoriesService.Delete(id));
        }
    }
}
