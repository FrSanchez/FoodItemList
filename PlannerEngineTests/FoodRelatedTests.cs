// <copyright file="FoodRelatedTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using PlannerEngine.ExceptionStuff;
using PlannerEngine.FoodStuff;
using PlannerEngine.Units;

namespace PlannerEngineTests;

/// <summary>
/// Class of tests related to the FoodItems.
/// </summary>
[TestFixture]
public class FoodRelatedTests
{
    private Fridge fridge;

    /// <summary>
    /// Setup for testing.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        this.fridge = new Fridge();
    }

    /// <summary>
    /// Cleanup for testing.
    /// </summary>
    [TearDown]
    public void Cleanup()
    {
    }

    /// <summary>
    /// Creates a unit item. Makes sure it's properties are correct.
    /// </summary>
    [Test]
    public void MakeUnit()
    {
        ItemUnit testUnit = new ItemUnit("ounce", 1.0);
        Assert.That(testUnit.Name, Is.EqualTo("ounce"));
        Assert.That(testUnit.Unit, Is.EqualTo(1.0));
    }

    /// <summary>
    /// Creates a food item. Tests to see if it's in the dictionary.
    /// </summary>
    [Test]
    public void MakeFoodCheckQuantity()
    {
        var testItem = new FoodItem([FoodCategory.Fruits], "Apple", new ItemUnit("ounce", 2), 1);
        this.fridge.AddToFridge(testItem, 3);
        Assert.That(this.fridge["Apple"], Is.EqualTo(3));
    }

    /// <summary>
    /// Creates a food item. Tests to see if it's in the dictionary.
    /// </summary>
    [Test]
    public void AreFoodParametersEqual()
    {
        var testItem = new FoodItem([FoodCategory.Fruits], "Apple", new ItemUnit("ounce", 2), 1);
        this.fridge.AddToFridge(testItem, 1);
        Assert.That(this.fridge.InFridge["Apple"].Equals(testItem), Is.True);
    }

    /// <summary>
    /// Tests whether an item that's of the same name that's "added to the fridge" actually increments
    /// the quantity of that item or not.
    /// </summary>
    [Test]
    public void AddToQuantityInsteadOfNewItem()
    {
        var testItem = new FoodItem([FoodCategory.Fruits], "Apple", new ItemUnit("ounce", 2), 1);

        this.fridge.AddToFridge(testItem, 1);
        this.fridge.AddToFridge(testItem, 1);
        Assert.That(this.fridge.InFridge, Has.Count.EqualTo(1));
        Assert.That(this.fridge["Apple"], Is.EqualTo(2));
    }

    /// <summary>
    /// Tests to see if an invalid serving size is allowed.
    /// </summary>
    [Test]
    public void TestServingSizeException()
    {
        try
        {
            var testItem = new FoodItem(
                [FoodCategory.Fruits],
                "Apple",
                new ItemUnit("ounce", 2),
                2);
            Assert.Fail();
        }
        catch (InvalidServingSizeException)
        {
            Assert.Pass();
        }
    }

    /// <summary>
    /// Tests to see if we can get an item from the fridge.
    /// </summary>
    [Test]
    public void GetItemFromFridgeTest()
    {
        var testItem = new FoodItem(
            [FoodCategory.Fruits],
            "Apple",
            new ItemUnit("ounce", 2),
            1);
        this.fridge.AddToFridge(testItem, 10);
        this.fridge.GetItem(testItem.Name, 2);
        Assert.That(this.fridge["Apple"], Is.EqualTo(8));
    }

    /// <summary>
    /// Tests empty exception on removal.
    /// </summary>
    [Test]
    public void ItemRemovalInvalidQuantityFailureTest()
    {
        var testItem = new FoodItem(
            [FoodCategory.Fruits],
            "Apple",
            new ItemUnit("ounce", 2),
            1);
        this.fridge.AddToFridge(testItem, 10);
        Assert.Throws<InvalidQuantityException>(() => this.fridge.GetItem("Apple", 20));
    }

    /// <summary>
    /// Tests to see if item from fridge can be deleted.
    /// </summary>
    [Test]
    public void ItemDeletionTest()
    {
        var testItem = new FoodItem(
            [FoodCategory.Fruits],
            "Apple",
            new ItemUnit("ounce", 2),
            1);
        this.fridge.AddToFridge(testItem, 1);
        this.fridge.DeleteItem(testItem.Name);
        Assert.Throws<ItemNotFoundException>(() => this.fridge.GetFoodItemQuantity(testItem.Name));
    }

    /// <summary>
    /// Tests Exception on deletion.
    /// </summary>
    [Test]
    public void ItemDeletionFailureTest()
    {
        Assert.Throws<ItemNotFoundException>(() => this.fridge.DeleteItem("test"));
    }
}