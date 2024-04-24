// <copyright file="PlateViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PlannerEngine.PlateStuff;

namespace MealPlanner.ViewModels;

public class PlateViewModel : ViewModelBase
{
    private Plate plate;

    public PlateViewModel(Plate plate)
    {
        this.plate = plate;
        var plateItems = new List<PlateItemViewModel>();
        foreach (var item in this.plate.PlateItems)
        {
            plateItems.Add(new PlateItemViewModel(item));
        }

        this.PlateItems = new ObservableCollection<PlateItemViewModel>(plateItems);
    }

    public DateTime Date => this.plate.Date;

    public MealType Meal => this.plate.MealType;

    public ObservableCollection<PlateItemViewModel> PlateItems { get; }
}