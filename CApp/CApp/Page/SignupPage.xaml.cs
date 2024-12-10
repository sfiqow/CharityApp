using CApp.ViewModel;
namespace CApp.Page;

public partial class SignupPage : ContentPage
{
    public SignupPage(SignupViewModel SignupViewModel)
    {
        InitializeComponent();
        BindingContext = SignupViewModel;

    }
}