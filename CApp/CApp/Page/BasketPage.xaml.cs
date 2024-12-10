using CApp.ViewModel;

namespace CApp.Page;
public partial class BasketPage : ContentPage
{
   private readonly BasketViewModel _basketViewModel;
    public BasketPage(BasketViewModel basketViewModel)
    {
        _basketViewModel = basketViewModel;
        InitializeComponent();
        BindingContext = _basketViewModel;
    }

    async private void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage));
    }
}