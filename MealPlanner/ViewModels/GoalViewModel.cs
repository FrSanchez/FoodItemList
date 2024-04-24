// <copyright file="GoalViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using MealPlanner.Views;
using PlannerEngine.FoodStuff;
using PlannerEngine.GoalStuff;
using PlannerEngine.PlateStuff;

namespace MealPlanner.ViewModels;

public class GoalViewModel : ViewModelBase
{
    private DailyGoal dailyGoal;
    public GoalViewModel(DailyGoal dailyGoal)
    {
        this.dailyGoal = dailyGoal;
        this.Goals = new ObservableCollection<CategoryGoal>(this.dailyGoal.GoalCategories);
    }
    
    public DailyGoal DailyGoal => this.dailyGoal;
    
    public ObservableCollection<CategoryGoal> Goals { get; }
}