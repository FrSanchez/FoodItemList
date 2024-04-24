// <copyright file="FoodItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Globalization;
using PlannerEngine.ExceptionStuff;
using PlannerEngine.Units;

namespace PlannerEngine.FoodStuff;

/// <summary>
/// Food item class.
/// </summary>
public class FoodItem : IComparable<FoodItem>
{
    private string? name;
    private ItemUnit? unit;
    private double servingSize; // 0% - 100%
    private long id;
    private static Random rnd = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItem"/> class.
    /// </summary>
    /// <param name="categories">FoodCategory array.</param>
    /// <param name="name">string.</param>
    /// <param name="unit">ItemUnit.</param>
    /// <param name="servingSize">int.</param>
    public FoodItem(FoodCategory[] categories, string name, ItemUnit unit, double servingSize)
    {
        this.Categories = categories;
        this.Name = name;
        this.Unit = unit;
        this.ServingSize = servingSize;
        this.id = rnd.NextInt64();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodItem"/> class.
    /// Default constructor for when parameters are basically empty.
    /// </summary>
    public FoodItem()
        : this([], string.Empty, new ItemUnit(string.Empty, 0.0), 0)
    {
    }

    /// <summary>
    /// Gets Id category.
    /// </summary>
    public long Id => this.id;

    /// <summary>
    /// Gets or sets Categories.
    /// </summary>
    public FoodCategory[] Categories { get; set; }

    /// <summary>
    /// Gets or sets Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets Unit.
    /// </summary>
    public ItemUnit Unit
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets ServingSize.
    /// </summary>
    public double ServingSize
    {
        get => this.servingSize;
        set
        {
            if (value is > 1 or < 0)
            {
                throw new InvalidServingSizeException(value.ToString(CultureInfo.InvariantCulture));
            }

            this.servingSize = value;
        }
    }

    /// <summary>
    /// Compares 2 FoodItem objects to see if they have the same parameters or not.
    /// </summary>
    /// <param name="item">FoodItem.</param>
    /// <returns>bool.</returns>
    public bool Equals(FoodItem item)
    {
        var firstExcept = this.Categories.Except(item.Categories);
        var secondExcept = item.Categories.Except(this.Categories);
        if (firstExcept.Any() || secondExcept.Any())
        {
            return false;
        }

        if (this.Name != item.Name)
        {
            return false;
        }

        if (string.Compare(this.Name, item.Name, StringComparison.OrdinalIgnoreCase) != 0)
        {
            return false;
        }

        return Math.Abs(this.ServingSize - item.ServingSize) < 0.000001;
    }

    /// <summary>
    /// Compares this FoodItem with another one.
    /// </summary>
    /// <param name="other">FoodItem.</param>
    /// <returns>int.</returns>
    public int CompareTo(FoodItem? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        return this.id.CompareTo(other.id);
    }
}