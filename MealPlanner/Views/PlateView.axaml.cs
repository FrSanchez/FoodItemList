// <copyright file="PlateView.axaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MealPlanner.Views;

public partial class PlateView : UserControl
{
    public PlateView()
    {
        InitializeComponent();
    }

    private void PlateGrid_OnLayoutUpdated(object? sender, EventArgs e)
    {
        Console.WriteLine("PlateGrid_OnLayoutUpdated");
    }
}