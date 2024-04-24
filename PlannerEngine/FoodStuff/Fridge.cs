// <copyright file="Fridge.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Text;
using PlannerEngine.ExceptionStuff;

namespace PlannerEngine.FoodStuff;

/// <summary>
/// Class <c>Fridge</c> IS the fridge that contains the FoodItems, and modifies them as needed.
/// </summary>
public class Fridge
{
    // Where the items go.

    // Easiser way of identifying items in fridge.
    public Dictionary<long, double> QtyFridge { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Fridge"/> class.
    /// </summary>
    public Fridge()
    {
        this.InFridge = [];
        this.QtyFridge = [];
    }

    /// <summary>
    /// Gets inFridge property.
    /// </summary>
    public Dictionary<long, FoodItem> InFridge { get; }

    /// <summary>
    /// Index that gets the quantity of a fridge.
    /// </summary>
    /// <param name="id">long.</param>
    public double this[long id] => this.GetFoodItemQuantity(id);

    /// <summary>
    /// Gets the quantity of the food in the fridge. If it's not there, throws an exception.
    /// </summary>
    /// <param name="id">long.</param>
    /// <returns>double.</returns>
    /// <exception cref="ItemNotFoundException">ItemNotFoundException.</exception>
    public double GetFoodItemQuantity(long id)
    {
        if (this.QtyFridge.TryGetValue(id, out var value))
        {
            // Since tuples are immutable, we'll just quickly make a new tuple
            return value;
        }

        throw new ItemNotFoundException(id.ToString());
    }

    /// <summary>
    /// Checks to see if a "new" item is already in the fridge. If so,
    /// that item gets returned. Otherwise the item gets created.
    /// </summary>
    /// <param name="item">FoodItem.</param>
    /// <param name="quantity">double.</param>
    public void AddToFridge(
        FoodItem item,
        double quantity)
    {
        // If the item is already in the fridge, we'll just update the quantity.
        if (this.QtyFridge.TryGetValue(item.Id, out var value))
        {
            // Since tuples are immutable, we'll just quickly make a new tuple
            this.QtyFridge[item.Id] += quantity;
        }

        // Add the item to the fridge.
        else
        {
            this.InFridge.Add(item.Id, item);
            this.QtyFridge.Add(item.Id, quantity);
        }
    }

    /// <summary>
    /// Clears out the fridge.
    /// </summary>
    public void ClearFridge()
    {
        this.InFridge.Clear();
    }

    /// <summary>
    /// Deletes an item from the fridge.
    /// </summary>
    /// <param name="itemId">string.</param>
    /// <exception cref="ItemNotFoundException">If the item isn't in the fridge.</exception>
    public void DeleteItem(long itemId)
    {
        if (!this.InFridge.ContainsKey(itemId))
        {
            throw new ItemNotFoundException(itemId.ToString());
        }

        this.InFridge.Remove(itemId);
        this.QtyFridge.Remove(itemId);
    }

    /// <summary>
    /// Gets the food item connected to itemId.
    /// </summary>
    /// <param name="itemId">long.</param>
    /// <returns>FoodItem.</returns>
    public FoodItem GetItemInfo(long itemId)
    {
        return this.GetItem(itemId, 0);
    }

    /// <summary>
    /// Gets the amount of foodItem connected to itemId and reduces the quantity.
    /// </summary>
    /// <param name="itemId">string.</param>
    /// <param name="qty">double.</param>
    /// <returns>FoodItem.</returns>
    /// <exception cref="ItemNotFoundException">If the item is already not in the fridge.</exception>
    /// <exception cref="InvalidQuantityException">If there's less of the item in the fridge than is being taken
    /// out.</exception>
    public FoodItem GetItem(long itemId, double qty)
    {
        // If the fridge contains the item
        if (!this.InFridge.TryGetValue(itemId, out var value))
        {
            throw new ItemNotFoundException(itemId.ToString());
        }

        // If the fridge contains the correct quantity
        if (this.QtyFridge[itemId] < qty)
        {
            throw new InvalidQuantityException(itemId.ToString() + qty);
        }

        this.QtyFridge[itemId] -= qty;

        // If getting stuff from the fridge means there's now no more items left.
        if (this.QtyFridge[itemId] > 0)
        {
            return value;
        }

        // Saves the FoodItem and deletes it from the fridge.
        var retItem = value;
        this.DeleteItem(itemId);
        return retItem;
    }

    /// <summary>
    /// Changes item in fridge if it exists.
    /// </summary>
    /// <param name="item">FoodItem.</param>
    /// <exception cref="ItemNotFoundException">ItemNotFoundException.</exception>
    public void ChangeFridgeItem(FoodItem item, double qty)
    {
        // If the item is already in the fridge, we'll just update the quantity.
        if (!this.QtyFridge.TryGetValue(item.Id, out var value))
        {
            throw new ItemNotFoundException(item.Id.ToString());
        }

        // Update the item
        this.InFridge[item.Id] = item;
        this.QtyFridge[item.Id] = qty;
    }

    /// <summary>
    /// Gets the contents of a fridge 
    /// </summary>
    /// <returns>List of FoodItems.</returns>
    public List<FoodItem> FridgeContents()
    {
        return this.InFridge.Values.ToList();
    }

    /// <summary>
    /// Overrides ToString to show contents and quantities.
    /// </summary>
    /// <returns>string.</returns>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in this.QtyFridge)
        {
            sb.Append(item.Key)
            .Append(':')
            .Append(item.Value)
            .Append(" - ");
        }

        return sb.ToString();
    }
}