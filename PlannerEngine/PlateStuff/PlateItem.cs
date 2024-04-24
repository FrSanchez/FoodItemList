// <copyright file="PlateItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using PlannerEngine.FoodStuff;

namespace PlannerEngine.PlateStuff;

/// <summary>
/// PlateItem class.
/// </summary>
public class PlateItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlateItem"/> class.
    /// </summary>
    /// <param name="item">FoodItem.</param>
    /// <param name="qty">double.</param>
    public PlateItem(FoodItem item, double qty)
    {
        this.Item = item;
        this.Qty = qty;
    }

    /// <summary>
    /// Gets or sets Item.
    /// </summary>
    public FoodItem Item { get; set; }

    /// <summary>
    /// Gets or sets Qty.
    /// </summary>
    public double Qty { get; set; }
}