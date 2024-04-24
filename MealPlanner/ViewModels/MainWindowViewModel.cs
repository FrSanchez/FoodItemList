// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Net;
using System.Reactive.Linq;
using Avalonia.Controls.ApplicationLifetimes;
using MealPlanner.Models;
using MealPlanner.TempServices;
using Newtonsoft.Json;
using PlannerEngine.FoodStuff;
using PlannerEngine.GoalStuff;
using PlannerEngine.PlanStuff;
using PlannerEngine.PlateStuff;
using ReactiveUI;

namespace MealPlanner.ViewModels;

/// <summary>
/// MainWindowViewModel class. Where the core magic happens.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    // TODO: Make ViewModels for Goal, Plate, and the Main Menu.
    private ViewModelBase contentViewModel;
    private Fridge fridge;
    private DailyGoal currentGoal;
    private DailyPlan currentPlan;

    // this has a dependency on the ToDoListService

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
    {
        this.fridge = new Fridge();
        try
        {
            var temp = ReadProductFromFile("./fridge.json");
            if (temp != null)
            {
                fridge = temp;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        this.currentGoal = new DailyGoal();
        this.currentPlan = new DailyPlan(DateTime.Today, this.currentGoal);
        foreach (var meal in Enum.GetValues(typeof(MealType)))
        {
            this.currentPlan.Plates.Add(new Plate(DateTime.Today, (MealType)meal));
        }

        var service = new FoodItemService(this.fridge);
        this.FoodItemList = new FoodItemViewModel(service.GetItems(), this);
        this.FoodItemList.ListItems.CollectionChanged += (sender, args) =>
        {
            Console.WriteLine("CollectionChanged.");
            Console.WriteLine(args);

            // if (args.NewItems != null)
            // {
            //     foreach (var item in args.NewItems)
            //     {
            //         if (item is FoodItemModel foodItem)
            //         {
            //             this.fridge.AddToFridge(foodItem.Item, foodItem.Quantity);
            //         }
            //     }
            // }
        };
        this.DailyPlanView = new DailyPlannerViewModel(this.currentPlan, this.fridge);
        this.GoalView = new GoalViewModel(this.currentGoal);
        this.contentViewModel = new MainMenuViewModel();
    }

    public void OnExit(object? sender, ControlledApplicationLifetimeExitEventArgs e)
    {
        try
        {
            this.WriteProductToFile(this.fridge, "./fridge.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing file");
            Console.WriteLine(ex);
        }
    }

    private static Fridge? ReadProductFromFile(string filePath)
    {
        // Read the JSON file contents
        string json = System.IO.File.ReadAllText(filePath);

        try
        {
            // Deserialize JSON to Product object
            var product = JsonConvert.DeserializeObject<Fridge>(json);
            return product;
        }
        catch (JsonException ex)
        {
            // Handle JSON deserialization errors
            Console.WriteLine("Error deserializing JSON: " + ex.Message);
            return null;
        }
    }

    private void WriteProductToFile(Fridge product, string filePath)
    {
        try
        {
            // Serialize Product object to JSON
            var json = JsonConvert.SerializeObject(product, Formatting.Indented);

            // Write JSON to file
            System.IO.File.WriteAllText(filePath, json);

            Console.WriteLine("Product serialized and saved to file successfully.");
        }
        catch (JsonException ex)
        {
            // Handle JSON serialization errors
            Console.WriteLine("Error serializing JSON: " + ex.Message);
        }
    }

    /// <summary>
    /// Gets FoodItemViewModel FoodItemList.
    /// </summary>
    public FoodItemViewModel FoodItemList { get; }

    public DailyPlannerViewModel DailyPlanView { get; }


    public GoalViewModel GoalView { get; }

    /// <summary>
    /// Gets ViewModelBase ContentViewModel.
    /// </summary>
    public ViewModelBase ContentViewModel
    {
        get => this.contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref this.contentViewModel, value);
    }

    public void Goal()
    {
        this.ContentViewModel = this.GoalView;
    }

    public void Parents()
    {
        this.ContentViewModel = this.FoodItemList;
    }

    public void Meals()
    {
        this.ContentViewModel = this.DailyPlanView;
    }

    public void MainMenu()
    {
        this.ContentViewModel = new MainMenuViewModel();
    }

    /// <summary>
    /// Adds a new item by calling AddItem with an empty object.
    /// </summary>
    public void AddItem()
    {
        this.AddItem(null);
    }

    /// <summary>
    /// Adds an item to the FoodItemList.
    /// </summary>
    /// <param name="item">Nullable FoodItemModel.</param>
    public void AddItem(FoodItemModel? item = null)
    {
        var addFoodItemViewModel = new AddFoodItemViewModel(item);

        Observable.Merge(
                addFoodItemViewModel.OkCommand,
                addFoodItemViewModel.CancelCommand.Select(_ => (FoodItemModel?)null))
            .Take(1)
            .Subscribe(
                newItem =>
                {
                    // If the OK button was pressed
                    if (newItem != null)
                    {
                        if (newItem.IsEdited)
                        {
                            this.fridge.ChangeFridgeItem(newItem.Item, newItem.Quantity);
                        }
                        else
                        {
                            this.FoodItemList.ListItems.Add(newItem);
                            this.fridge.AddToFridge(newItem.Item, newItem.Quantity);
                        }
                    }

                    // Else, the Cancel button was pressed. Nothing really changes anyways

                    // Regardless of which button was clicked
                    this.ContentViewModel = this.FoodItemList;
                    Console.WriteLine(this.fridge);
                });

        this.ContentViewModel = addFoodItemViewModel;
    }

}