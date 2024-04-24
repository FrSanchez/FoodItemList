// <copyright file="PlateViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using PlannerEngine.PlateStuff;

namespace MealPlanner.ViewModels;

public class PlateViewModel : ViewModelBase
{
    private Plate plate;
    public PlateViewModel(Plate plate)
    {
        this.plate = plate;
    }

    public DateTime Date => this.plate.Date;

    public MealType Meal => this.plate.MealType;

    public List<PlateItem> PlateItems => this.plate.PlateItems;

}