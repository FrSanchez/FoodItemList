// <copyright file="FridgeViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.FoodStuff;

namespace MealPlanner.ViewModels;

public class FridgeViewModel : ViewModelBase
{
    private readonly Fridge fridge;

    public FridgeViewModel(Fridge fridge)
    {
        this.fridge = fridge;
    }
    
    public Fridge Fridge => this.fridge;
}