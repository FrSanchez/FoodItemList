using ToDoList.DataModel;

namespace ToDoList.Services;

public class FridgeService
{
    public Fridge getItems()
    {
        var fridge = new Fridge();
        var fis = new FoodItemService();
        foreach (var item in fis.GetItems())
        {
            fridge.AddFoodItem(item, 1);
        }
        return fridge;
    }
}