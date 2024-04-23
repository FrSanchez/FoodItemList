using System.Collections.Generic;
using ToDoList.DataModel;

namespace ToDoList.Services
{
    public class FoodItemService
    {
        public IEnumerable<FoodItem> GetItems() => new[]
        {
            new FoodItem { Name = "Milk", FoodCategories = [FoodCategory.Dairy], ServingSize = 0.5, ItemUnit = new ItemUnit("cup", 0.5)},
            new FoodItem { Name = "Lentils" , FoodCategories = [FoodCategory.Vegetable, FoodCategory.Grains], ServingSize = .3, ItemUnit = new ItemUnit("ounces", 3)},
            new FoodItem { Name = "Apple", FoodCategories = [FoodCategory.Fruit], ServingSize = 1, ItemUnit = new ItemUnit("cup", 1)},
            new FoodItem { Name = "Meat", FoodCategories = [FoodCategory.Protein], ServingSize = 0.5, ItemUnit = new ItemUnit("ounces", 5)},
        };
    }
}