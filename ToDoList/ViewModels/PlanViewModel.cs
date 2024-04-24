using ToDoList.DataModel;

namespace ToDoList.ViewModels;

public class PlanViewModel : ViewModelBase
{

    public PlanViewModel() : this(new Fridge())
    {
    }

    public PlanViewModel(Fridge fridge)
    {
        this.Fridge = fridge;
    }

    public Fridge Fridge { get; set; }
}