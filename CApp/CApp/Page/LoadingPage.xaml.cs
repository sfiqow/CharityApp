using CApp.Interface;
namespace CApp.Page;

public partial class LoadingPage : ContentPage
{
	private readonly IUserService _userService;
	public LoadingPage(IUserService userService)
	{
		InitializeComponent();
        _userService = userService;
	}

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

		if(await _userService.isAuthAsync())
		{
			//user is logged in -going to main page
			await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
			//no back button when navigated
        }
		else
		{
            // user isnt logged on-redirect to login page
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

        }
    }
}