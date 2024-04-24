using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using MealPlanner.ViewModels;
using PlannerEngine.PlateStuff;

namespace MealPlanner.Behaviors;

/// <inheritdoc />
public sealed class ItemsDataGridDropHandler : BaseDataGridDropHandler<PlateItemViewModel>
{

    protected override PlateItemViewModel MakeCopy(ObservableCollection<PlateItemViewModel> parentCollection,
        PlateItemViewModel item)
    {
        Console.WriteLine("MakeCopy " + item);
        return (PlateItemViewModel)item.Clone();
    }

    /// <inheritdoc/>
    protected override bool Validate(DataGrid dg, DragEventArgs e, object? sourceContext, object? targetContext,
        bool bExecute)
    {
        var action = bExecute ? "Execute" : "Validate";
        Console.WriteLine($"Grid {action} " + sourceContext + ":" + targetContext);
        if (sourceContext is not FridgeItemViewModel sourceItem
            || targetContext is not PlateViewModel vm
            || dg.GetVisualAt(e.GetPosition(dg)) is not Control targetControl
            // || targetControl.DataContext is not PlateItemViewModel targetItem)
           )
        {
            Console.WriteLine("false");
            return false;
        }

        Console.WriteLine("Target Control" + targetControl);

        var items = vm.PlateItems;
        var source = new PlateItemViewModel(new PlateItem(sourceItem.Item, 1.0));
        var targetItem = new PlateItemViewModel(new PlateItem(sourceItem.Item, 1.0));
        return this.RunDropAction(dg, e, bExecute, source, targetItem, items);
    }
}