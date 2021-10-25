using NUCAL.Application.Core.DTOs.Entities;
using NUCAL.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NUCAL.Infrastructure.Mapping
{
    public static class MappingFunctions
    {
        public static ReferenceMeasurements MapReferenceMeasurementsDTOToReferenceMeasurementsEntity(FoodEditionDTO foodDTO, Food food)
        {
            var result = new ReferenceMeasurements();
            if(foodDTO.ReferenceMeasurements == null) { return result; }
            result.ReferenceMassInGrams = foodDTO.ReferenceMeasurements.ReferenceMassInGrams;
            result.RererenceVolumeInMililiters = foodDTO.ReferenceMeasurements.ReferenceVolumeInMililiters;
            result.ReferenceUnits = foodDTO.ReferenceMeasurements.ReferenceUnits;
            return result;
        }
        public static ReferenceMeasurementsDTO MapReferenceMeasurementsToReferenceMeasurementsDTO(Food food, FoodDetailsDTO foodDTO)
        {
            var result = new ReferenceMeasurementsDTO();
            if(food.ReferenceMeasurements == null) { return result; }
            result.ReferenceMassInGrams = food.ReferenceMeasurements.ReferenceMassInGrams;
            result.ReferenceVolumeInMililiters = food.ReferenceMeasurements.RererenceVolumeInMililiters;
            result.ReferenceUnits = food.ReferenceMeasurements.ReferenceUnits;
            return result;
        }
        public static FattyAcidsAndCholesterol MapFattyDTOToFattyEntity(FoodEditionDTO foodDTO, Food food)
        {
            var result = new FattyAcidsAndCholesterol();
            if(foodDTO.FattyAcidsAndCholesterol == null) { return result; }
            result.SaturatedFat = foodDTO.FattyAcidsAndCholesterol.SaturatedFat;
            result.MonounsaturatedFat = foodDTO.FattyAcidsAndCholesterol.MonounsaturatedFat;
            result.PolyunsaturatedFat = foodDTO.FattyAcidsAndCholesterol.PolyunsaturatedFat;
            result.Cholesterol = foodDTO.FattyAcidsAndCholesterol.Cholesterol;
            return result;
        }
        public static FattyAcidsAndCholesterolDTO MapFattyEntityToFattyDTO(Food food, FoodDetailsDTO foodDTO)
        {
            var result = new FattyAcidsAndCholesterolDTO();
            if (food.FattyAcidsAndCholesterol == null) { return result; }
            result.SaturatedFat = food.FattyAcidsAndCholesterol.SaturatedFat;
            result.MonounsaturatedFat = food.FattyAcidsAndCholesterol.MonounsaturatedFat;
            result.PolyunsaturatedFat = food.FattyAcidsAndCholesterol.PolyunsaturatedFat;
            result.Cholesterol = food.FattyAcidsAndCholesterol.Cholesterol;
            return result;
        }
        public static Macronutrients MapMacronutrientsDTOToMacronutrients(FoodEditionDTO foodDTO, Food food)
        {
            var result = new Macronutrients();
            if(foodDTO.Macronutrients == null) { return result;  }
            result.Calories = foodDTO.Macronutrients.Calories;
            result.Protein = foodDTO.Macronutrients.Protein;
            result.Carbohydrates = foodDTO.Macronutrients.Carbohydrates;
            result.Grease = foodDTO.Macronutrients.Grease;
            result.Fiber = foodDTO.Macronutrients.Fiber;
            return result;
        }
        public static MacronutrientsDTO MapMacronutrientsToMacronutrientsDTO(Food food, FoodDetailsDTO foodDTO)
        {
            var result = new MacronutrientsDTO();
            if (food.Macronutrients == null) { return result; }
            result.Calories = food.Macronutrients.Calories;
            result.Protein = food.Macronutrients.Protein;
            result.Carbohydrates = food.Macronutrients.Carbohydrates;
            result.Grease = food.Macronutrients.Grease;
            result.Fiber = food.Macronutrients.Fiber;
            return result;
        }
        public static Minerals MapMineralsDTOToMinerals(FoodEditionDTO foodDTO, Food food)
        {
            var result = new Minerals();
            if(foodDTO.Minerals == null) { return result; }
            result.Calcium = foodDTO.Minerals.Calcium;
            result.Iron = foodDTO.Minerals.Iron;
            result.Sodium = foodDTO.Minerals.Sodium;
            result.Phosphorus = foodDTO.Minerals.Phosphorus;
            result.Iodo = foodDTO.Minerals.Iodo;
            result.Zinc = foodDTO.Minerals.Zinc;
            result.Manganese = foodDTO.Minerals.Manganese;
            result.Potassium = foodDTO.Minerals.Potassium;
            return result;
        }
        public static MineralsDTO MapMineralsToMineralsDTO(Food food, FoodDetailsDTO foodDTO)
        {
            var result = new MineralsDTO();
            if (food.Minerals == null) { return result; }
            result.Calcium = food.Minerals.Calcium;
            result.Iron = food.Minerals.Iron;
            result.Sodium = food.Minerals.Sodium;
            result.Phosphorus = food.Minerals.Phosphorus;
            result.Iodo = food.Minerals.Iodo;
            result.Zinc = food.Minerals.Zinc;
            result.Manganese = food.Minerals.Manganese;
            result.Potassium = food.Minerals.Potassium;
            return result;
        }
        public static Vitamins MapVitaminsDTOToVitamins(FoodEditionDTO foodDTO, Food food)
        {
            var result = new Vitamins();
            if(foodDTO.Vitamins == null) { return result; }
            result.Thiamin = foodDTO.Vitamins.Thiamin;
            result.Riboflavin = foodDTO.Vitamins.Riboflavin;
            result.Niacin = foodDTO.Vitamins.Niacin;
            result.Folates = foodDTO.Vitamins.Folates;
            result.VitaminB12 = foodDTO.Vitamins.VitaminB12;
            result.VitaminC = foodDTO.Vitamins.VitaminC;
            result.VitaminA = foodDTO.Vitamins.VitaminA;
            return result;
        }
        public static VitaminsDTO MapVitaminsToVitaminsDTO(Food food, FoodDetailsDTO foodDTO)
        {
            var result = new VitaminsDTO();
            if (food.Vitamins == null) { return result; }
            result.Thiamin = food.Vitamins.Thiamin;
            result.Riboflavin = food.Vitamins.Riboflavin;
            result.Niacin = food.Vitamins.Niacin;
            result.Folates = food.Vitamins.Folates;
            result.VitaminB12 = food.Vitamins.VitaminB12;
            result.VitaminC = food.Vitamins.VitaminC;
            result.VitaminA = food.Vitamins.VitaminA;
            return result;
        }

        public static ICollection<FoodInCategory> MapFoodIncategoryToFooInCategoryEntity(FoodEditionDTO foodDTO, Food food)
        {
            ICollection<FoodInCategory> result = new Collection<FoodInCategory>();
            if (foodDTO.Categories == null) { return result; }
            foreach(string category in foodDTO.Categories)
            {
                result.Add(new FoodInCategory { FoodCategoryId = category });
            }
            return result;
        }

        public static List<string> MapFoodCategoryToFoodCategoryDTO(Food food, FoodDetailsDTO foodDTO)
        {
            return MapFoodCategoryToFoodCategoryDTO(food);
        }
        public static List<string> MapFoodCategoryToFoodCategoryDTO(Food food, FoodWithCategoriesDTO foodDTO)
        {
            return MapFoodCategoryToFoodCategoryDTO(food);
        }
        private static List<string> MapFoodCategoryToFoodCategoryDTO(Food food)
        {
            List<string> result = new List<string>();
            if (food.FoodInCategories.Count <= 0) { return result; }
            foreach (var category in food.FoodInCategories)
            {
                result.Add(category.FoodCategoryId);
            }
            return result;
        }

        public static DateTime MapCurrentDate(ConsumedFoodDTO consumedFoodDTO, ConsumedFood consumedFood)
        {
            return DateTime.Now;
        }

        public static string MapDate(ConsumedFood consumedFoodDb, ConsumedFoodDTO consumedFoodDTO)
        {
            return consumedFoodDb.Date.ToString("yyyy-MM-dd");
        }
        
    }
}
