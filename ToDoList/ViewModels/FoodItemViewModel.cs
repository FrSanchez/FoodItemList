using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoList.DataModel;

namespace ToDoList.ViewModels;

public class FoodItemViewModel : ViewModelBase
{
    public FoodItemViewModel(IEnumerable<FoodItem> items)
    {
        ListItems = new ObservableCollection<FoodItem>(items);
    }

    public ObservableCollection<FoodItem> ListItems { get; }
}