// <copyright file="PlateItemViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using PlannerEngine.FoodStuff;
using PlannerEngine.PlateStuff;
using PlannerEngine.Units;

namespace MealPlanner.ViewModels;

public class PlateItemViewModel : ViewModelBase, ICloneable
{

    public PlateItemViewModel(PlateItem item)
    {
        this.Quantity = item.Qty;
        this.Name = item.Item.Name;
        this.Unit = item.Item.Unit;
        this.Categories = item.Item.Categories;
        this.ServingSize = item.Item.ServingSize;
    }

    public double ServingSize { get; set; }

    public FoodCategory[] Categories { get; set; }

    public ItemUnit Unit { get; set; }

    public string Name { get; set; }

    public double Quantity { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}