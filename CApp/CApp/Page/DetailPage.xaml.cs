using CApp.ViewModel;

namespace CApp.Page;

public partial class DetailPage : ContentPage
{
	private readonly DetailViewModel _detailViewModel;
    public DetailPage(DetailViewModel detailViewModel)
	{
        InitializeComponent(); //initializing xaml components
        _detailViewModel = detailViewModel; //injecting basket viewmodel
		BindingContext = _detailViewModel; //Setting the BindingContext to BasketViewModel- data binding.
    }

    //searching for charities
	void SearchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
	{
		if(!string.IsNullOrEmpty(e.OldTextValue) && !string.IsNullOrEmpty(e.NewTextValue))
		{
            //execute SearchCharitiessCommand from the DetailViewModel.
            _detailViewModel.SearchCharitiessCommand.Execute(null);

        }

    }

}


