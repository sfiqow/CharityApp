using CApp.ViewModel;

namespace CApp.Page;

public partial class Charity1Page : ContentPage
{
    private readonly Charity1ViewModel _charity1ViewModel;
    public Charity1Page(Charity1ViewModel charity1ViewModel)
    {
        _charity1ViewModel = charity1ViewModel;
        InitializeComponent();
        BindingContext = _charity1ViewModel;
    }
}