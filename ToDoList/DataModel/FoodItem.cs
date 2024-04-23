using System;

namespace ToDoList.DataModel
{
    public class FoodItem
    {
        public string Name { get; set; } = string.Empty;
        public double ServingSize { get; set; }
        public FoodCategory[] FoodCategories { get; set; }
        
        public ItemUnit ItemUnit { get; set; }

        public FoodItem()
        {
            FoodCategories = [];
            ServingSize = 0.0;
            Name = string.Empty;
            ItemUnit = new ItemUnit(string.Empty, 0.0);
        }
    }
}