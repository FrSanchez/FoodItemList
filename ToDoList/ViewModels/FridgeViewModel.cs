using ToDoList.DataModel;

namespace ToDoList.ViewModels;

public class FridgeViewModel : ViewModelBase
{
    public FridgeViewModel(Fridge fridge)
    {
        this.Fridge = fridge;
    }

    public Fridge Fridge { get; }
}