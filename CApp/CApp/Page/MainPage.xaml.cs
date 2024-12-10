using CApp.ViewModel;

namespace CApp.Page;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel MainViewModel)
    {
        InitializeComponent();
        BindingContext = MainViewModel;
    }

}


