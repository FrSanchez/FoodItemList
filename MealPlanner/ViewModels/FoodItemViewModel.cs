// <copyright file="FoodItemViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MealPlanner.Models;
using PlannerEngine.FoodStuff;

namespace MealPlanner.ViewModels;

/// <summary>
/// FoodItemViewModel class.
/// </summary>
public class FoodItemViewModel : ViewModelBase
{
    private MainWindowViewModel otherWindow;
    private ObservableCollection<FoodItemModel> listItems;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItemViewModel"/> class.
    /// </summary>
    /// <param name="items">IEnumerable of FoodItemModel.</param>
    public FoodItemViewModel(IEnumerable<FoodItemModel> items, MainWindowViewModel window)
    {
        this.listItems = new ObservableCollection<FoodItemModel>(items);
        this.otherWindow = window;
    }

    /// <summary>
    /// Gets or sets observable collection of FoodItems.
    /// </summary>
    public ObservableCollection<FoodItemModel> ListItems
    {
        get => this.listItems;
        set => this.listItems = value;
    }

    /// <summary>
    /// Event Handler that sends event out to create an item.
    /// </summary>
    /// <param name="item">FoodItemModel.</param>
    public void RaiseEvent(FoodItemModel? item)
    {
        Console.WriteLine("RaiseEvent - Adding Item!", item);
        this.otherWindow.AddItem(item);
    }
}