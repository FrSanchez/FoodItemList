// <copyright file="DailyPlannerViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PlannerEngine.FoodStuff;
using PlannerEngine.GoalStuff;
using PlannerEngine.PlanStuff;
using PlannerEngine.PlateStuff;

namespace MealPlanner.ViewModels;

public class DailyPlannerViewModel : ViewModelBase
{
    private DateTime date;
    private DailyGoal goal;
    private DailyPlan plan;
    private Fridge madeFridge;

    public DailyPlannerViewModel(DailyPlan plan, Fridge fridge)
    {
        this.date = plan.Date;
        this.goal = plan.Goal;
        this.plan = plan;
        this.madeFridge = fridge;
        var listPlates = new List<PlateViewModel>();
        foreach (var plate in plan.Plates)
        {
            listPlates.Add(new PlateViewModel(plate));
        }
        this.Plates = new ObservableCollection<PlateViewModel>(listPlates);
    }
    public ObservableCollection<PlateViewModel> Plates { get; }
    
    public DateTime Date
    {
        get => this.date;
        set => this.date = value;
    }
    
    public DailyGoal Goal => this.goal;
    
    public Fridge MadeFridge { get; }
}