using ReactiveUI;
using System.Reactive;
using ToDoList.DataModel;

namespace ToDoList.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string _name = string.Empty;
        private double _serving = 0.5;
        private FoodCategory[] _categories = [];

        public ReactiveCommand<Unit, FoodItem> OkCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        
        public AddItemViewModel()
        {
            _categories =
            [
                FoodCategory.Dairy, FoodCategory.Fruit, FoodCategory.Grains, FoodCategory.Protein,
                FoodCategory.Vegetable
            ];
            var isValidObservable = this.WhenAnyValue(
                x => x.Name,
                x => !string.IsNullOrWhiteSpace(x));

            OkCommand = ReactiveCommand.Create(
                () => new FoodItem { Name = Name, ServingSize = Serving}, isValidObservable);
            CancelCommand = ReactiveCommand.Create(() => { });
        }

        public FoodCategory[] Categories
        {
            get => _categories;
            set => this.RaiseAndSetIfChanged(ref _categories, value);
        }

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public double Serving
        {
            get => _serving;
            set => this.RaiseAndSetIfChanged(ref _serving, value);
        }
    }
}