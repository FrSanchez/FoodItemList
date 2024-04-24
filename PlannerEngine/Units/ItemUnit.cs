// <copyright file="ItemUnit.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PlannerEngine.Units;

/// <summary>
/// Item unit class. Comes with constructor.
/// </summary>
/// <param name="name">string.</param>
/// <param name="unit">double.</param>
public class ItemUnit(string name, double unit) : IComparable<ItemUnit>
{
    /// <summary>
    /// Gets or sets Name parameter.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets Unit parameter.
    /// </summary>
    public double Unit { get; set; } = unit;

    /// <summary>
    /// Compares this ItemUnit to another ItemUnit.
    /// </summary>
    /// <param name="other">ItemUnit.</param>
    /// <returns>bool.</returns>
    public bool Equals(ItemUnit other)
    {
        return this.Name == other.Name && this.Unit.Equals(other.Unit);
    }

    /// <summary>
    /// Overrides ToString method.
    /// </summary>
    /// <returns>string.</returns>
    public override string ToString()
    {
        return $"{this.Unit} {this.Name}";
    }

    /// <summary>
    /// Compares this ItemUnit object to an unkown object of (potentially) another class.
    /// </summary>
    /// <param name="other">ItemUnit?.</param>
    /// <returns>int.</returns>
    public int CompareTo(ItemUnit? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var nameComparison = string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        return this.Unit.CompareTo(other.Unit);
    }
}