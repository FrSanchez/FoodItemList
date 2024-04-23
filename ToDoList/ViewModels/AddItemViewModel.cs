using ReactiveUI;
using System.Reactive;
using ToDoList.DataModel;

namespace ToDoList.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string _name = string.Empty;

        public ReactiveCommand<Unit, FoodItem> OkCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        
        public AddItemViewModel()
        {
            var isValidObservable = this.WhenAnyValue(
                x => x.Name,
                x => !string.IsNullOrWhiteSpace(x));

            OkCommand = ReactiveCommand.Create(
                () => new FoodItem { Name = Name }, isValidObservable);
            CancelCommand = ReactiveCommand.Create(() => { });
        }

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
    }
}