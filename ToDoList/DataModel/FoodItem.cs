using System;

namespace ToDoList.DataModel
{
    public class FoodItem
    {
        private readonly Random _rnd = new ();
        
        public long Id { get; set; }
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
            Id = _rnd.NextInt64();
        }
    }
}