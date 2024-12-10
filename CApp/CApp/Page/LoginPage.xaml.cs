using CApp.ViewModel;

namespace CApp.Page;

public partial class LoginPage : ContentPage
{

    public LoginPage(LoginViewModel LoginViewModel)
    {
        InitializeComponent();
		BindingContext = LoginViewModel;

	}

}