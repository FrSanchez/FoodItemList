using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Xaml.Interactions.DragAndDrop;
using MealPlanner.ViewModels;

namespace MealPlanner.Behaviors;

public class ItemsListBoxDropHandler : DropHandlerBase
{
    private bool Validate<T>(ListBox listBox, DragEventArgs e, object? sourceContext, object? targetContext, bool bExecute)
        where T : FridgeItemViewModel
    {
        var action = bExecute ? "Execute" : "Validate";
        Console.WriteLine($"${action} drag and drop ");
        Console.WriteLine(sourceContext);
        Console.WriteLine(targetContext);
        Console.WriteLine(e.Data);
        if (sourceContext is not T sourceItem
            || targetContext is not DailyPlannerViewModel vm
            || listBox.GetVisualAt(e.GetPosition(listBox)) is not Control targetControl
            || targetControl.DataContext is not T targetItem)
        {
            Console.WriteLine("false");
            return false;
        }

        var items = vm.FridgeItems;
        var sourceIndex = items.IndexOf(sourceItem);
        var targetIndex = items.IndexOf(targetItem);

        if (sourceIndex < 0 || targetIndex < 0)
        {
            return false;
        }

        switch (e.DragEffects)
        {
            case DragDropEffects.Copy:
            {
                if (bExecute)
                {
                    var clone = new FridgeItemViewModel(sourceItem.Item, sourceItem.Qty);
                    InsertItem(items, clone, targetIndex + 1);
                }

                return true;
            }
            case DragDropEffects.Move:
            {
                if (bExecute)
                {
                    MoveItem(items, sourceIndex, targetIndex);
                }

                return true;
            }
            case DragDropEffects.Link:
            {
                if (bExecute)
                {
                    SwapItem(items, sourceIndex, targetIndex);
                }

                return true;
            }
            default:
                return false;
        }
    }

    /// <inheritdoc/>
    public override bool Validate(object? sender, DragEventArgs e, object? sourceContext, object? targetContext,
        object? state)
    {
        if (e.Source is Control && sender is ListBox listBox)
        {
            return this.Validate<FridgeItemViewModel>(listBox, e, sourceContext, targetContext, false);
        }

        return false;
    }

    /// <inheritdoc/>
    public override bool Execute(object? sender, DragEventArgs e, object? sourceContext, object? targetContext,
        object? state)
    {
        if (e.Source is Control && sender is ListBox listBox)
        {
            return this.Validate<FridgeItemViewModel>(listBox, e, sourceContext, targetContext, true);
        }

        return false;
    }
}
