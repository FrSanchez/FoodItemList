// <copyright file="FoodItemView.axaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Avalonia.Controls;
using Avalonia.Input;
using MealPlanner.Models;
using MealPlanner.ViewModels;

namespace MealPlanner.Views;

/// <summary>
/// ViewModel class for FoodItem itself.
/// </summary>
public partial class FoodItemView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItemView"/> class.
    /// </summary>
    public FoodItemView()
    {
        this.InitializeComponent();
    }

    private void Grid_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (this.DataContext is not FoodItemViewModel viewModel)
        {
            return;
        }

        if (sender is not DataGrid grid)
        {
            return;
        }

        viewModel.RaiseEvent(grid.SelectedItem as FoodItemModel);
    }
}