using Avalonia.Remote.Protocol.Input;

namespace MealPlanner.Models;

public class FridgeItemModel
{
    public double Qty { get; }

    public FoodItemModel Item { get; }

    public FridgeItemModel(FoodItemModel item, double amount)
    {
        this.Item = item;
        this.Qty = amount;
    }
}