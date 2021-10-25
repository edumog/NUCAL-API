using AutoMapper;
using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Entities;
using NUCAL.Application.Core.Entities;
using NUCAL.Security.Models;
using System;

namespace NUCAL.Infrastructure.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserCreationDTO, User>();
            CreateMap<UserCreationDTO, UserSecurityDTO>();

            CreateMap<ApplicationUser, UserDTO>();
            CreateMap<FoodCategory, FoodCategoryDTO>().ReverseMap();
            CreateMap<FoodCategoryEditDTO, FoodCategory>();

            CreateMap<FoodEditionDTO, Food>()
                .ForMember(x => x.ReferenceMeasurements, options => options.MapFrom(MappingFunctions.MapReferenceMeasurementsDTOToReferenceMeasurementsEntity))
                .ForMember(x => x.FattyAcidsAndCholesterol, options => options.MapFrom(MappingFunctions.MapFattyDTOToFattyEntity))
                .ForMember(x => x.Macronutrients, options => options.MapFrom(MappingFunctions.MapMacronutrientsDTOToMacronutrients))
                .ForMember(x => x.Minerals, options => options.MapFrom(MappingFunctions.MapMineralsDTOToMinerals))
                .ForMember(x => x.Vitamins, options => options.MapFrom(MappingFunctions.MapVitaminsDTOToVitamins))
                .ForMember(x => x.FoodInCategories, options => options.MapFrom(MappingFunctions.MapFoodIncategoryToFooInCategoryEntity));
            CreateMap<Food, FoodDTO>();
            CreateMap<Food, FoodDetailsDTO>()
                .ForMember(x => x.ReferenceMeasurements, options => options.MapFrom(MappingFunctions.MapReferenceMeasurementsToReferenceMeasurementsDTO))
                .ForMember(x => x.FattyAcidsAndCholesterol, options => options.MapFrom(MappingFunctions.MapFattyEntityToFattyDTO))
                .ForMember(x => x.Macronutrients, options => options.MapFrom(MappingFunctions.MapMacronutrientsToMacronutrientsDTO))
                .ForMember(x => x.Minerals, options => options.MapFrom(MappingFunctions.MapMineralsToMineralsDTO))
                .ForMember(x => x.Vitamins, options => options.MapFrom(MappingFunctions.MapVitaminsToVitaminsDTO))
                .ForMember(x => x.Categories, options => options.MapFrom(MappingFunctions.MapFoodCategoryToFoodCategoryDTO));
            CreateMap<Food, FoodWithCategoriesDTO>()
                .ForMember(x => x.Categories, options => options.MapFrom(MappingFunctions.MapFoodCategoryToFoodCategoryDTO));
            CreateMap<FattyAcidsAndCholesterolDTO, FattyAcidsAndCholesterol>();

            CreateMap<ConsumedFoodDTO, ConsumedFood>()
                .ForMember(x => x.Date, options => options.MapFrom(MappingFunctions.MapCurrentDate));
            CreateMap<ConsumedFood, ConsumedFoodDTO>()
                .ForMember(x => x.Date, options => options.MapFrom(MappingFunctions.MapDate));
            CreateMap<ConsumedFoodEditDTO, ConsumedFood>()
                .ForMember(x => x.IdUser, options => options.Ignore())
                .ForMember(x => x.Date, options => options.Ignore())
                .ForMember(x => x.NumberOfPlate, options => options.Ignore())
                .ForMember(x => x.IdFood, options => options.Ignore());
        }
    }
}
