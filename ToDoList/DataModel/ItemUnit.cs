namespace ToDoList.DataModel;

public class ItemUnit(string name, double value)
{
    public double Value { get; set; } = value;
    public string Name { get; set; } = name;

    public override string ToString()
    {
        return $"{Value} {Name}";
    }
}