using System;
using MealPlanner.Models;
using PlannerEngine.FoodStuff;
using ReactiveUI;

namespace MealPlanner.ViewModels;

public class FridgeItemViewModel : ViewModelBase
{
    /// <summary>
    /// Food Item Name
    /// </summary>
    private string? _name;

    private double _qty;
    private FoodItem _item;

    public FoodItem Item
    {
        get => _item;
        set => _item = this.RaiseAndSetIfChanged(ref this._item, value);
    }

    public FridgeItemViewModel(FoodItem item, double getFoodItemQuantity)
    {
        this.Name = item.Name;
        this.Item = item;
        this.Qty = getFoodItemQuantity;
    }

    public double Qty
    {
        get => this._qty;
        set => this.RaiseAndSetIfChanged(ref this._qty, value);
    }

    public string? Name
    {
        get => this._name;
        set => this.RaiseAndSetIfChanged(ref this._name, value);
    }

    public override string? ToString() => this.Name;
}