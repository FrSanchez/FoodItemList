using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ToDoList.DataModel;

namespace ToDoList.Views;

public partial class AddItemView : UserControl
{
    public AddItemView()
    {
        InitializeComponent();
        // FoodCategoryInput.ItemsSource = Enum.GetValues(typeof(FoodCategory));
    }
}