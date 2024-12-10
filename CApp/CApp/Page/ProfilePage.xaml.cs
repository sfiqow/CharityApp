using CApp.Interface;
using CApp.Services;
namespace CApp.Page;

public partial class ProfilePage : ContentPage
{
    private readonly IUserService _userService;
    public ProfilePage(IUserService userService)
	{

		InitializeComponent();
		_userService= userService;
	}

    //loggin out
    private void Button_Clicked(object sender, EventArgs e)
    {
		//loggin out the user
		_userService.Logout();

        Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}