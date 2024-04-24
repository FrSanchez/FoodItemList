using System;
using System.Reactive.Linq;
using ReactiveUI;
using ToDoList.DataModel;
using ToDoList.Services;
using ToDoList.Views;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        private readonly Fridge _fridge;

        //this has a dependency on the ToDoListService

        public MainWindowViewModel()
        {
            var fService = new FridgeService();
            _fridge = fService.getItems();
            var service = new FoodItemService();
            FoodItem = new FoodItemViewModel(service.GetItems());
            Plan = new PlanViewModel(_fridge);
            GoalView = new GoalViewModel();
            _contentViewModel = new MenuViewModel();
        }

        public GoalViewModel GoalView { get; }
        public FoodItemViewModel FoodItem { get; }
        public PlanViewModel Plan { get;  }
        
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void Goal()
        {
            ContentViewModel = GoalView;
        }
        public void Parents()
        {
            ContentViewModel = FoodItem;
        }

        public void Meals()
        {
            ContentViewModel = Plan;
        }

        public void MainMenu()
        {
            ContentViewModel = new MenuViewModel();
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