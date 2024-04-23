using System;
using System.Reactive.Linq;
using ReactiveUI;
using ToDoList.DataModel;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;

        //this has a dependency on the ToDoListService

        public MainWindowViewModel()
        {
            var service = new FoodItemService();
            FoodItem = new FoodItemViewModel(service.GetItems());
            _contentViewModel = FoodItem;
        }

        public FoodItemViewModel FoodItem { get; }
        
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void AddItem()
        {
            AddItemViewModel addItemViewModel = new();

            Observable.Merge(
                    addItemViewModel.OkCommand,
                    addItemViewModel.CancelCommand.Select(_ => (FoodItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        FoodItem.ListItems.Add(newItem );
                    }
                    ContentViewModel = FoodItem;
                });

            ContentViewModel = addItemViewModel;
        }
    }
}