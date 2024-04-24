using System;
using System.Collections.Generic;

namespace ToDoList.DataModel;

public class Fridge
{
    public Dictionary<long, FoodItem> InFridge
    {
        get;
        // set => inFridge = value ?? throw new ArgumentNullException(nameof(value));
    } = new();

    public Dictionary<long, double> QtyFridge
    {
        get;
        // set => qtyFridge = value ?? throw new ArgumentNullException(nameof(value));
    } = new();

    public void AddFoodItem(FoodItem item, double qty)
    {
        if (InFridge.TryAdd(item.Id, item))
        {
            QtyFridge.Add(item.Id, 0.0);
        }

        QtyFridge[item.Id] += qty;
    }

    public FoodItem GetFoodItem(long id)
    {
        if (InFridge.TryGetValue(id, out var item))
        {
            return item;
        }

        throw new InvalidOperationException("invalid id");
    }
}